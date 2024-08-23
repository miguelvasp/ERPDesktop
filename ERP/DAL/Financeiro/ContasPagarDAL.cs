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
    public class ContasPagarDAL : Repository<ContasPagar>
    {
        public ContasPagarAbertoDAL EmAbertoDal = new ContasPagarAbertoDAL();
        public ContasPagarBaixaDAL BaixasDal = new ContasPagarBaixaDAL();



        public List<ContasPagarModelView> getByParams(int Fornecedor, string strFornecedor, DateTime VencimentoDe, DateTime VencimentoAte,  string Situacao,  decimal? ValorDe, decimal? ValorAte)
        {
            DateTime VI = new DateTime();
            if(VencimentoDe != null) VI = Convert.ToDateTime(VencimentoDe.ToShortDateString() + " 00:00:00");
            DateTime VF = new DateTime();
            if (VencimentoAte != null) VF = Convert.ToDateTime(VencimentoAte.ToShortDateString() + " 23:59:00");


            List<ContasPagarModelView> lista = (from p in db.ContasPagar
                                                join f in db.Fornecedor on p.IdFornecedor equals f.IdFornecedor
                                                where (Fornecedor == 0 || p.IdFornecedor == Fornecedor)
                                                && (strFornecedor == "" || f.RazaoSocial.Contains(strFornecedor))
                                                && (VencimentoDe == null || p.Vencimento >= VI)
                                                && (VencimentoAte == null || p.Vencimento <= VF)
                                                && (Situacao == (p.Saldo > 0 ? "1" : "2"))
                                                && (ValorDe == -1 || p.ValorLiquido >= ValorDe)
                                                && (ValorAte == -1 || p.ValorLiquido <= ValorAte)
                                                select new ContasPagarModelView
                                                {
                                                    IdContasPagar = p.IdContasPagar,
                                                    RazaoSocial = f.RazaoSocial,
                                                    Documento = p.Documento,
                                                    Vencimento = p.Vencimento,
                                                    ValorTitulo = p.ValorTitulo,
                                                    Desconto = p.Desconto,
                                                    Acrescimo = p.Acrecimo,
                                                    ValorLiquido = p.ValorLiquido,
                                                    ValorPago = p.ValorPago,
                                                    Saldo = p.Saldo,
                                                    Historico = p.Observacao,
                                                    Parcelas = p.Parcelas,
                                                    ParcelasPagas = p.ParcelasPagas
                                                }).ToList();
            return lista;
        }

        public ContasPagarAberto GetProximoAberto(int pIdContasPagar, out decimal ValorAberto)
        {
            List<ContasPagarAberto> lista = (from ca in db.ContasPagarAberto
                                             where ca.IdContasPagar == pIdContasPagar
                                             select ca).OrderBy(x => x.NumeroParcela).ToList();
            ContasPagarAberto conta = new ContasPagarAberto();
            ValorAberto = 0;
            bool achou = false;
            foreach(ContasPagarAberto a in lista)
            {
                var Baixas = (from b in db.ContasPagarBaixa
                              where b.IdContasPagarAberto == a.IdContasPagarAberto
                              select b).Sum(x => x.Valor);

                if(!achou)
                {
                    if(Baixas == null || Baixas == 0)
                    {
                        achou = true;
                        conta = a;
                        ValorAberto = (decimal)a.ValorLiquido;
                    }
                    else
                    {
                        if(Baixas < a.ValorLiquido)
                        {
                            achou = true;
                            conta = a;
                            ValorAberto = (decimal)a.ValorLiquido - (decimal)Baixas;
                        }
                    }
                }
            }
            return conta;
        }

        public List<ContasPagarAbertoModelView> GetContasEmAberto(int pIdContasPagar)
        { 
            List<ContasPagarAbertoModelView> lista = (from a in db.ContasPagarAberto

                                                      from bx in db.ContasPagarBaixa
                                                      .Where(x => x.IdContasPagarAberto == a.IdContasPagarAberto)
                                                      .DefaultIfEmpty()
                                                      where a.IdContasPagar == pIdContasPagar
                                                      group bx by new { a.IdContasPagarAberto, a.Vencimento, a.NumeroParcela, a.ValorLiquido } into g
                                                      select new ContasPagarAbertoModelView
                                                      {
                                                          Id = g.Key.IdContasPagarAberto,
                                                          Vencimento = g.Key.Vencimento,
                                                          NumeroParcela = g.Key.NumeroParcela,
                                                          ValorLiquido = g.Key.ValorLiquido,
                                                          ValorPago = g.Sum(x => x.Valor)
                                                      }).ToList();
            return lista;
        }

        public List<ContasPagarBaixaModelView> GetBaixas(int pIdContasPagarAberto)
        {
            List<ContasPagarBaixaModelView> lista = (from b in db.ContasPagarBaixa
                                                     where b.IdContasPagarAberto == pIdContasPagarAberto
                                                     select new ContasPagarBaixaModelView
                                                     {
                                                         Id = b.IdContasPagarBaixa,
                                                         Data = b.DataPagamento,
                                                         Documento = b.Documento,
                                                         Cheque = b.NumeroCheque,
                                                         Valor = b.Valor
                                                     }).ToList();
            return lista;
        }


        public ContasPagar CalculaPagamento(ContasPagar cp)
        {
            //Calcula pagamentos

            //Calcula os vencimentos em aberto e confronta com as baixas
            List<ContasPagarAberto> ListaEmAberto = (from a in db.ContasPagarAberto
                                                     where a.IdContasPagar == cp.IdContasPagar
                                                     select a).ToList();

            cp.Parcelas = ListaEmAberto.Count;

            foreach(ContasPagarAberto a in ListaEmAberto)
            {
                //Procura as baixas dos pagamentos
                decimal Soma  = db.ContasPagarBaixa.Where(x => x.IdContasPagarAberto == a.IdContasPagarAberto).Sum(x => x.Valor) ?? 0;
                if(Soma == a.ValorLiquido)
                {
                    a.Liquidada = true; 
                }
            }

            cp.ParcelasPagas = ListaEmAberto.Where(x => x.Liquidada == true).Count();

            //Atualiza o pagamento
            bool AtribuiuVencimento = false;
            foreach (ContasPagarAberto a in ListaEmAberto.Where(x => x.Liquidada == false).OrderBy(x => x.Vencimento).ToList())
            {
                if(!AtribuiuVencimento)
                {
                    cp.Vencimento = a.Vencimento;
                    AtribuiuVencimento = true;
                }
            }


            //Soma os acrescimos
            var Valores = (from a in db.ContasPagarAberto
                           where a.IdContasPagar == cp.IdContasPagar
                           group a by a.IdContasPagarAberto into g
                           select new
                           {
                               Multa = g.Sum(x => x.ValorMulta),
                               Juros = g.Sum(x => x.ValorJuros),
                               Desconto = g.Sum(x => x.Desconto),
                               DescontoAVista = g.Sum(x => x.ValorDescontoVista)
                           }).ToList();

            var Pago = (from a in db.ContasPagarAberto

                        from bx in db.ContasPagarBaixa
                        .Where(x => x.IdContasPagarAberto == a.IdContasPagarAberto)
                        .DefaultIfEmpty()
                        where a.IdContasPagar == cp.IdContasPagar
                        group bx by new { a.IdContasPagarAberto, a.Vencimento, a.NumeroParcela, a.ValorLiquido } into g
                        select new
                        {
                            ValorPago = g.Sum(x => x.Valor)
                        }).ToList();

            if(Valores != null)
            {

                cp.Acrecimo = (Valores.Sum(x => x.Multa) ?? 0) + (Valores.Sum(x => x.Juros) ?? 0);
                cp.Desconto = (Valores.Sum(x => x.Desconto) ?? 0) + (Valores.Sum(x => x.DescontoAVista) ?? 0);
            }
            else
            {
                cp.Acrecimo = 0;
                cp.Desconto = 0;
            }
            
            cp.ValorLiquido = cp.ValorTitulo + cp.Acrecimo - cp.Desconto;
            cp.ValorPago = Pago == null ? 0 : Pago.Sum(x => x.ValorPago);
            if (cp.ValorPago == null) cp.ValorPago = 0;
            cp.Saldo = cp.ValorLiquido - cp.ValorPago;
            if(cp.Saldo == 0)
            {
                cp.Status = 2;
            }


            this.Update(cp);
            this.Save();
            return cp;
        }



    }
}
