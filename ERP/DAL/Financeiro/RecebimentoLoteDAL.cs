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
    public class RecebimentoLoteDAL : Repository<RecebimentoLote>
    {
        public List<RecebimentoLoteVencimentoModelView> GetVencimentos(DateTime De, DateTime Ate, int IdCliente, int IdMetodoPagamento)
        {
            DB_ERPViewContext dbv = new DB_ERPViewContext();
            List<RecebimentoLoteVencimentoModelView> lista = (from v in dbv.vwVencimentosrecebimentos
                                                            where (v.Vencimento >= De && v.Vencimento <= Ate)
                                                            && (IdCliente == 0 || v.IdCliente == IdCliente)
                                                            && (IdMetodoPagamento == 0 || v.IdMetodoPagamento == IdMetodoPagamento)
                                                            select new RecebimentoLoteVencimentoModelView
                                                            {
                                                                IdContasreceber = v.IdContasReceber,
                                                                IdContasReceberAberto = v.IdContasReceberAberto,
                                                                RazaoSocial = v.RazaoSocial,
                                                                Vencimento = v.Vencimento,
                                                                ValorLiquido = v.ValorLiquido,
                                                                Saldo = v.Saldo,
                                                                MetodoPagamento = v.Nome,
                                                                Documento = v.Documento
                                                            }).OrderBy(x => x.Vencimento).ToList();
            return lista;
        }

        public List<RecebimentoLoteVencimentoModelView> GetTitulosPagos(int IdRecebimentoLote)
        {
            List<RecebimentoLoteVencimentoModelView> lista = (from i in db.RecebimentoLoteItem
                                                            join v in db.ContasReceberAberto on i.IdContasReceberAberto equals v.IdContasReceberAberto
                                                            join c in db.ContasReceber on v.IdContasReceber equals c.IdContasReceber
                                                            join f in db.Cliente on c.IdCliente equals f.IdCliente
                                                            where i.IdRecebimentoLote == IdRecebimentoLote
                                                            select new RecebimentoLoteVencimentoModelView
                                                            {
                                                                RazaoSocial = f.RazaoSocial,
                                                                Vencimento = v.Vencimento,
                                                                ValorLiquido = i.Valor,
                                                                Documento = c.Documento
                                                            }).OrderBy(x => x.Vencimento).ToList();
            return lista;
        }

        public List<ChequeTerceiroModelView> GetChequesTerceirosPagos(int IdRecebimentoLote)
        {
            var lista = (from i in db.RecebimentoLoteChequeTerceiro
                         join c in db.ChequeTerceiros on i.IdChequeTerceiro equals c.IdChequeTerceiro
                         join b in db.Banco on c.IdBanco equals b.IdBanco
                         where i.IdRecebimentoLote == IdRecebimentoLote
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

        public void CancelaRecebimentoLote(RecebimentoLote p)
        {
            //Cancela os cheques
            var cheques = (from c in db.RecebimentoLoteChequeTerceiro
                           where c.IdRecebimentoLote == p.IdRecebimentoLote
                           select c).ToList();

            //Libera os cheques e cancela
            ChequeTerceirosDAL chDal = new ChequeTerceirosDAL();
            RecebimentoLoteChequeTerceiroDAL pchDal = new RecebimentoLoteChequeTerceiroDAL();
            foreach (var c in cheques)
            {
                ChequeTerceiros ch = chDal.GetByID((int)c.IdChequeTerceiro);
                ch.IdContasReceberBaixa = null;
                chDal.Update(ch);
                chDal.Save();

                pchDal.Delete((int)c.IdRecebimentoLoteChequeTerceiro);
                pchDal.Save();
            }



            //libera as baixas, cancela os cheques do contas a receber e apaga o item
            RecebimentoLoteItemDAL pliDal = new RecebimentoLoteItemDAL();
            var TitulosBaixados = pliDal.GetByRecebimentoLoteId((int)p.IdRecebimentoLote);

            ContasReceberDAL cpDal = new ContasReceberDAL();
            ContasReceberBaixaDAL cpbDal = new ContasReceberBaixaDAL();
            ContasReceberChequeTerceirosDAL pchtDal = new ContasReceberChequeTerceirosDAL();
            foreach (var t in TitulosBaixados)
            {
                //apaga os cheques
                pchtDal.ApagaChequesPorBaixa((int)t.IdContasReceberBaixa);

                pliDal.Delete(t.IdRecebimentoLoteItem);
                pliDal.Save();

                cpbDal.Delete((int)t.IdContasReceberBaixa);
                cpbDal.Save();

                //Atualiza a conta a pagar
                ContasReceberAberto ca = new ContasReceberAbertoDAL().GetByID((int)t.IdContasReceberAberto);
                ContasReceber cp = cpDal.GetByID((int)ca.IdContasReceber);
                cpDal.CalculaRecebimento(cp);
            }

            Delete(p.IdRecebimentoLote);
            Save();


        }

        public List<RecebimentoLoteModelView> GetByParams(DateTime De, DateTime Ate, int IdFornecedor, int IdContaBancaria, int IdContaContabil, int IdCliente, int Situacao)
        {
            var Lista = (from p in db.RecebimentoLote
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

                         select new RecebimentoLoteModelView
                         {
                             IdRecebimentoLote = p.IdRecebimentoLote,
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
