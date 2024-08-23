using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using ERP.ModelView;

namespace ERP.DAL
{
    public class PagamentoLoteDAL : Repository<PagamentoLote>
    {
        public List<PagamentoLoteVencimentoModelView> GetVencimentos(DateTime De, DateTime Ate, int IdFornecedor, int IdMetodoPagamento)
        {
            DB_ERPViewContext dbv = new DB_ERPViewContext();
            List<PagamentoLoteVencimentoModelView> lista = (from v in dbv.vwVencimentos 
                                                            where (v.Vencimento >= De && v.Vencimento <= Ate)
                                                            && (IdFornecedor == 0 || v.IdFornecedor == IdFornecedor)
                                                            && (IdMetodoPagamento == 0 || v.IdMetodoPagamento == IdMetodoPagamento)  
                                                            select new PagamentoLoteVencimentoModelView
                                                            {
                                                                IdContasPagar = v.IdContasPagar,
                                                                IdContasPagarAberto = v.IdContasPagarAberto,
                                                                RazaoSocial = v.RazaoSocial,
                                                                Vencimento = v.Vencimento,
                                                                ValorLiquido = v.ValorLiquido,
                                                                Saldo = v.Saldo,
                                                                MetodoPagamento = v.Nome,
                                                                Documento = v.Documento
                                                            }).OrderBy(x => x.Vencimento).ToList();
            return lista;
        }

        public List<PagamentoLoteVencimentoModelView> GetTitulosPagos(int IdPagamentoLote)
        { 
            List<PagamentoLoteVencimentoModelView> lista = (from i in db.PagamentoLoteItem
                                                            join v in db.ContasPagarAberto on i.IdContasPagarAberto equals v.IdContasPagarAberto
                                                            join c in db.ContasPagar on v.IdContasPagar equals c.IdContasPagar
                                                            join f in db.Fornecedor on c.IdFornecedor equals f.IdFornecedor
                                                            where i.IdPagamentoLote == IdPagamentoLote
                                                            select new PagamentoLoteVencimentoModelView
                                                            { 
                                                                RazaoSocial = f.RazaoSocial,
                                                                Vencimento = v.Vencimento,
                                                                ValorLiquido = i.Valor,  
                                                                Documento = c.Documento
                                                            }).OrderBy(x => x.Vencimento).ToList();
            return lista;
        }

        public List<ChequeTerceiroModelView> GetChequesTerceirosPagos(int IdPagamentoLote)
        {
            var lista = (from i in db.PagamentoLoteChequeTerceiro
                         join c in db.ChequeTerceiros on i.IdChequeTerceiro equals c.IdChequeTerceiro
                         join b in db.Banco on c.IdBanco equals b.IdBanco
                         where i.IdPagamentoLote == IdPagamentoLote
                         select new ChequeTerceiroModelView
                         {
                             Banco = b.NomeBanco,
                             Nome = c.Nome,
                             Cheque = c.NumeroCheque,
                             Data = c.Emissao,
                             Valor = c.Valor,
                             Agencia = c.Agencia,
                             Conta = c.Conta
                         }).ToList();
            return lista;
        }

        public void CancelaPagamentoLote(PagamentoLote p)
        {
            //Cancela os cheques
            var cheques = (from c in db.PagamentoLoteChequeTerceiro
                           where c.IdPagamentoLote == p.IdPagamentoLote
                           select c).ToList();

            //Libera os cheques e cancela
            ChequeTerceirosDAL chDal = new ChequeTerceirosDAL();
            PagamentoLoteChequeTerceiroDAL pchDal = new PagamentoLoteChequeTerceiroDAL();
            foreach(var c in cheques)
            {
                ChequeTerceiros ch = chDal.GetByID((int)c.IdChequeTerceiro);
                ch.IdContasPagarBaixa = null;
                chDal.Update(ch);
                chDal.Save();

                pchDal.Delete((int)c.IdPagamentoLoteChequeTerceiro);
                pchDal.Save();
            }



            //libera as baixas, cancela os cheques do contas a pagar e apaga o item
            PagamentoLoteItemDAL pliDal = new PagamentoLoteItemDAL();
            var TitulosBaixados = pliDal.GetByPagamentoLoteId((int)p.IdPagamentoLote);

            ContasPagarDAL cpDal = new ContasPagarDAL();
            ContasPagarBaixaDAL cpbDal = new ContasPagarBaixaDAL();
            ContasPagarChequeTerceirosDAL pchtDal = new ContasPagarChequeTerceirosDAL();
            foreach(var t in TitulosBaixados)
            {
                //apaga os cheques
                pchtDal.ApagaChequesPorBaixa((int)t.IdContasPagarBaixa); 

                pliDal.Delete(t.IdPagamentoLoteItem);
                pliDal.Save();

                cpbDal.Delete((int)t.IdContasPagarBaixa);
                cpbDal.Save();

                //Atualiza a conta a pagar
                ContasPagarAberto ca = new ContasPagarAbertoDAL().GetByID((int)t.IdContasPagarAberto);
                ContasPagar cp = cpDal.GetByID((int)ca.IdContasPagar);
                cpDal.CalculaPagamento(cp); 
            }

            Delete(p.IdPagamentoLote);
            Save();


        }

        public List<PagamentoLoteModelView> GetByParams(DateTime De, DateTime Ate, int IdFornecedor, int IdContaBancaria, int IdContaContabil, int IdCliente, int Situacao)
        {
            var Lista = (from p in db.PagamentoLote
                         where (p.Data >= De && p.Data <= Ate)
                         && (IdFornecedor == 0 || p.IdFornecedor == IdFornecedor)
                         && (IdCliente == 0 || p.IdCliente == IdCliente)
                         && (IdContaBancaria == 0 || p.IdContaBancaria == IdContaBancaria)
                         && (IdContaContabil == 0 || p.IdContaContabil == IdContaContabil)

                         from f in db.Fornecedor
                         .Where(x => x.IdFornecedor == p.IdFornecedor).DefaultIfEmpty()

                         from c in db.Cliente
                         .Where(x => x.IdCliente == p.IdCliente).DefaultIfEmpty()

                         from cc in db.ContaContabil
                         .Where(x => x.IdContaContabil == p.IdContaContabil).DefaultIfEmpty()

                         from cb in db.ContaBancaria
                         .Where(x => x.IdContaBancaria == p.IdContaBancaria).DefaultIfEmpty()

                         from m in db.MetodoPagamento
                         .Where(x => x.IdMetodoPagamento == p.IdMetodoPagamento).DefaultIfEmpty()

                         select new PagamentoLoteModelView
                         {
                             IdPagamentoLote = p.IdPagamentoLote,
                             Data = p.Data,
                             ContaBancaria = cb.NomeConta,
                             Fornecedor = f.RazaoSocial,
                             Cliente = c.RazaoSocial,
                             ContaContabil = cc.Codigo,
                             MetodoPagamento = m.Nome,
                             Valor = p.Valor,
                             Cheque = p.Cheque
                         }).ToList();
            return Lista;

        }
    }
}
