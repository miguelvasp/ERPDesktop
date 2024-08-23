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
    public class ContasReceberDAL : Repository<ContasReceber>
    {
        public ContasReceberAbertoDAL EmAbertoDal = new ContasReceberAbertoDAL();
        public ContasReceberBaixaDAL BaixasDal = new ContasReceberBaixaDAL();

        public ContasReceberModelView getRecebimentoForBoleto(int IdContasReceber)
        { 
            var c = (from p in db.ContasReceber
                                                  join f in db.Cliente on p.IdCliente equals f.IdCliente
                                                  where p.IdContasReceber == IdContasReceber
                                                  select new ContasReceberModelView
                                                  {
                                                      IdContasReceber = p.IdContasReceber,
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
                                                  }).FirstOrDefault();
            return c;
        }

        public List<ContasReceberModelView> getByParams(int pIdCliente, string strCliente, DateTime VencimentoDe, DateTime VencimentoAte, string Situacao, decimal? ValorDe, decimal? ValorAte)
        {
            DateTime VI = new DateTime();
            if (VencimentoDe != null) VI = Convert.ToDateTime(VencimentoDe.ToShortDateString() + " 00:00:00");
            DateTime VF = new DateTime();
            if (VencimentoAte != null) VF = Convert.ToDateTime(VencimentoAte.ToShortDateString() + " 23:59:00");


            List<ContasReceberModelView> lista = (from p in db.ContasReceber
                                                  join f in db.Cliente on p.IdCliente equals f.IdCliente

                                                  from m in db.MetodoPagamento
                                                  .Where(x => x.IdMetodoPagamento == p.IdMetodoPagamento).DefaultIfEmpty()


                                                  where (pIdCliente == 0 || p.IdCliente == pIdCliente)
                                                  && (strCliente == "" || f.RazaoSocial.Contains(strCliente))
                                                  && (VencimentoDe == null || p.Vencimento >= VI)
                                                  && (VencimentoAte == null || p.Vencimento <= VF)
                                                  && (Situacao == (p.Saldo > 0 ? "1" : "2"))
                                                  && (ValorDe == -1 || p.ValorLiquido >= ValorDe)
                                                  && (ValorAte == -1 || p.ValorLiquido <= ValorAte)
                                                  select new ContasReceberModelView
                                                  {
                                                      IdContasReceber = p.IdContasReceber,
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
                                                      ParcelasPagas = p.ParcelasPagas,
                                                      MetodoPagamento = m == null ? "" : m.Nome
                                                  }).ToList();
            return lista;
        }

      

        public List<ContasReceberAbertoModelView> GetContasEmAberto(int pIdContasReceber)
        {
            List<ContasReceberAbertoModelView> lista = (from a in db.ContasReceberAberto

                                                        from bx in db.ContasReceberBaixa
                                                        .Where(x => x.IdContasReceberAberto == a.IdContasReceberAberto)
                                                        .DefaultIfEmpty()
                                                        where a.IdContasReceber == pIdContasReceber
                                                        group bx by new { a.IdContasReceberAberto, a.Vencimento, a.NumeroParcela, a.ValorLiquido } into g
                                                        select new ContasReceberAbertoModelView
                                                        {
                                                            Id = (int)g.Key.IdContasReceberAberto,
                                                            Vencimento = g.Key.Vencimento,
                                                            NumeroParcela = g.Key.NumeroParcela,
                                                            ValorLiquido = g.Key.ValorLiquido,
                                                            ValorPago = g.Sum(x => x.Valor)
                                                        }).ToList();
            return lista;
        }

        public List<ContasReceberBaixaModelView> GetBaixas(int pIdContasReceberAberto)
        {
            List<ContasReceberBaixaModelView> lista = (from b in db.ContasReceberBaixa
                                                       where b.IdContasReceberAberto == pIdContasReceberAberto
                                                       select new ContasReceberBaixaModelView
                                                       {
                                                           Id = (int)b.IdContasReceberBaixa,
                                                           Data = b.DataPagamento,
                                                           Documento = b.Documento,
                                                           Cheque = b.NumeroCheque,
                                                           Valor = b.Valor
                                                       }).ToList();
            return lista;
        }


        public ContasReceber CalculaRecebimento(ContasReceber cp)
        {
            //Calcula recebimentos

            //Calcula os vencimentos em aberto e confronta com as baixas
            List<ContasReceberAberto> ListaEmAberto = (from a in db.ContasReceberAberto
                                                       where a.IdContasReceber == cp.IdContasReceber
                                                       select a).ToList();

            cp.Parcelas = ListaEmAberto.Count;

            foreach (ContasReceberAberto a in ListaEmAberto)
            {
                //Procura as baixas dos recebientos
                decimal Soma = db.ContasReceberBaixa.Where(x => x.IdContasReceberAberto == a.IdContasReceberAberto).Sum(x => x.Valor) ?? 0;
                if (Soma == a.ValorLiquido)
                {
                    a.Liquidada = true;
                }
            }

            cp.ParcelasPagas = ListaEmAberto.Where(x => x.Liquidada == true).Count();

            //Atualiza o recebimento
            bool AtribuiuVencimento = false;
            foreach (ContasReceberAberto a in ListaEmAberto.Where(x => x.Liquidada == false).OrderBy(x => x.Vencimento).ToList())
            {
                if (!AtribuiuVencimento)
                {
                    cp.Vencimento = a.Vencimento;
                    AtribuiuVencimento = true;
                }
            }


            //Soma os acrescimos
            var Valores = (from a in db.ContasReceberAberto
                           where a.IdContasReceber == cp.IdContasReceber
                           group a by a.IdContasReceberAberto into g
                           select new
                           {
                               Multa = g.Sum(x => x.ValorMulta),
                               Juros = g.Sum(x => x.ValorJuros),
                               Desconto = g.Sum(x => x.Desconto),
                               DescontoAVista = g.Sum(x => x.ValorDescontoVista)
                           }).ToList();

            var Pago = (from a in db.ContasReceberAberto

                        from bx in db.ContasReceberBaixa
                        .Where(x => x.IdContasReceberAberto == a.IdContasReceberAberto)
                        .DefaultIfEmpty()
                        where a.IdContasReceber == cp.IdContasReceber
                        group bx by new { a.IdContasReceberAberto, a.Vencimento, a.NumeroParcela, a.ValorLiquido } into g
                        select new
                        {
                            ValorPago = g.Sum(x => x.Valor)
                        }).ToList();

            if (Valores != null)
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
            if (cp.Saldo == 0)
            {
                cp.Status = 2;
            }


            this.Update(cp);
            this.Save();
            return cp;
        }

        public static implicit operator ContasReceberDAL(ContasPagarDAL v)
        {
            throw new NotImplementedException();
        }
    }
}
