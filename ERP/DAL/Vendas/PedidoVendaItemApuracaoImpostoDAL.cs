using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class PedidoVendaItemApuracaoImpostoDAL : Repository<PedidoVendaItemApuracaoImposto>
    {
        public List<PedidoVendaItemApuracaoImposto> GetByPedidoItem(int Id)
        {
            List<PedidoVendaItemApuracaoImposto> lista = (from ai in db.PedidoVendaItemApuracaoImposto
                                                          where ai.IdPedidoVendaItem == Id
                                                          && (ai.ManterDadosAjustados == null || ai.ManterDadosAjustados == false)
                                                          select ai).ToList();
            return lista;
        }

        public void ApagaApuracaoImpostos(int Id)
        {
            List<PedidoVendaItemApuracaoImposto> lista = (from ai in db.PedidoVendaItemApuracaoImposto
                                                          where ai.IdPedidoVendaItem == Id
                                                          && (ai.ManterDadosAjustados == null || ai.ManterDadosAjustados == false)
                                                          select ai).ToList();
            foreach (PedidoVendaItemApuracaoImposto i in lista)
            {
                this.Delete(i.IdPedidoVendaItemApuracaoImposto);
                this.Save();
            }
        }

        public List<PedidoVendaItemApuracaoImposto> GetImpostosByNFPedidoItem(int idPedidoVendaItem)
        { 

            List<PedidoVendaItemApuracaoImposto> impostos = (from i in db.PedidoVendaItemApuracaoImposto
                                                             where i.IdPedidoVendaItem == idPedidoVendaItem
                                                             && i.ValorImposto > 0
                                                             select i).ToList();
            return impostos; 
        }

        public List<PedidoVendaItemApuracaoImposto> GetImpostosByNF(int idNotaFiscal)
        {
            var itens = (from i in db.NotaFiscalItem
                         where i.IdNotaFiscal == idNotaFiscal
                         select i.IdPedidoVendaItem).ToList();

            List < PedidoVendaItemApuracaoImposto > impostos = (from i in db.PedidoVendaItemApuracaoImposto
                                                                where itens.Contains(i.IdPedidoVendaItem)
                                                                && i.ValorImposto > 0
                                                                select i).ToList();
            return impostos;
        }

        public decimal GetImpostosNaoInclusosByNotaFiscal(int idNotaFiscal)
        {
            var itens = (from i in db.NotaFiscalItem
                         where i.IdNotaFiscal == idNotaFiscal
                         select i.IdPedidoVendaItem).ToList();

            List<PedidoVendaItemApuracaoImposto> impostos = (from i in db.PedidoVendaItemApuracaoImposto
                                                             join c in db.CodigoImposto on i.IdCodigoImposto equals c.IdCodigoImposto
                                                             where itens.Contains(i.IdPedidoVendaItem)
                                                             && i.ValorImposto > 0
                                                             && c.ImpostoIncluso == false
                                                             select i).ToList();
            decimal somaImpostos = 0;

            foreach(var i in impostos)
            {
                 
                if(i.ValorAjustado != null && i.ValorAjustado > 0)
                {
                    somaImpostos += Convert.ToDecimal(i.ValorAjustado);
                }
                else
                {
                    somaImpostos += Convert.ToDecimal(i.ValorImposto);
                }
                
            }
            return somaImpostos;
        }

        public CodigoImposto GetCodigoImpostoItemPedidoVenda(int IdPedidoVendaItem, int IdTipoImposto)
        {
            db.Configuration.LazyLoadingEnabled = true;
            return (from i in db.PedidoVendaItemApuracaoImposto
                         join c in db.CodigoImposto on i.IdCodigoImposto equals c.IdCodigoImposto
                         where i.IdPedidoVendaItem == IdPedidoVendaItem
                         && i.TipoImposto == IdTipoImposto
                         select c).FirstOrDefault();
        }

        public PedidoVendaItemApuracaoImposto GetApuracaoImpostoItem(int IdPedidoVendaItem, int IdTipoImposto)
        {
            return (from i in db.PedidoVendaItemApuracaoImposto
                    where i.IdPedidoVendaItem == IdPedidoVendaItem
                    && i.TipoImposto == IdTipoImposto
                    select i).FirstOrDefault();
        }


        public bool ContemTipoImposto(int IdPedidoVendaItem, int IdTipoImposto)
        {
            bool achou = false;

            var itens = (from i in db.PedidoVendaItemApuracaoImposto
                         where i.IdPedidoVendaItem == IdPedidoVendaItem
                         && i.TipoImposto == IdTipoImposto
                         select i).FirstOrDefault();
            if(itens != null)
            {
                if(Convert.ToDecimal(itens.ValorImposto) > 0)
                {
                    return true;
                }
            }

            return achou;
        }


        public void ApagaImpostos(int pId)
        {
            List<PedidoVendaItemApuracaoImposto> lista = (from d in db.PedidoVendaItemApuracaoImposto
                                                          where d.IdPedidoVendaItem == pId
                                                          select d).ToList();
            foreach(PedidoVendaItemApuracaoImposto i in lista)
            {
                this.Delete(i.IdPedidoVendaItemApuracaoImposto);
                this.Save();
            }
        }

        public List<ApuracaoImpostosModelView> GetListaImpostos(int pIdPedidoVendaItem)
        {
            List<ApuracaoImpostosModelView> lista = (from p in db.PedidoVendaItemApuracaoImposto
                                                     where p.IdPedidoVendaItem == pIdPedidoVendaItem

                                                     from ci in db.CodigoImposto.Where(x => x.IdCodigoImposto == p.IdCodigoImposto).DefaultIfEmpty()
                                                     from ct in db.CodigoTributacao.Where(x => x.IdCodigoTributacao == p.IdCodigoTributacao).DefaultIfEmpty()
                                                     from cta in db.CodigoTributacao.Where(x => x.IdCodigoTributacao == p.IdCodigoTributacaoAjustado).DefaultIfEmpty()
                                                     select new ApuracaoImpostosModelView
                                                     {
                                                         Id = p.IdPedidoVendaItemApuracaoImposto,
                                                         CodigoImposto = ci.Descricao,
                                                         CodigoTributacao = ct.Descricao,
                                                         CodigoTributacaoAjustada = cta.Descricao,
                                                         ValorFiscal = p.ValorFiscal,
                                                         ValorFiscalAjustado = p.ValorFiscalAjustado,
                                                         Aliquota = p.Aliquota,
                                                         BaseValor = p.BaseValor,
                                                         BaseValorAjustado = p.BaseValorAjustado,
                                                         OutroValorBase = p.OutroValorBase,
                                                         OutroValorImposto = p.OutroValorImposto,
                                                         ValorBaseIsencao = p.ValorBaseIsencao,
                                                         ValorIsencaoImposto = p.ValorIsencaoImposto,
                                                         ValorImposto = p.ValorImposto,
                                                         ValorAjustado = p.ValorAjustado,
                                                         DirecaoImposto = p.DirecaoImposto == null ? "" :
                                                                          p.DirecaoImposto == 1 ? "Imposto a Pagar" :
                                                                          p.DirecaoImposto == 2 ? "Imposto sobre o uso" :
                                                                          p.DirecaoImposto == 3 ? "Compra Insenta de Imposto" :
                                                                          p.DirecaoImposto == 4 ? "Venda Insenta de Impostos" :
                                                                          p.DirecaoImposto == 5 ? "Imposto a pagar diferença Vendas" :
                                                                          p.DirecaoImposto == 6 ? "6-Diferencial de Compras" : "",
                                                         FiscalOrigem = p.FiscalOrigem == 0 ? "0-Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8;" :
                                                                        p.FiscalOrigem == 1 ? "1-Estrangeira - Importação direta, exceto a indicada no código 6" :
                                                                        p.FiscalOrigem == 2 ? "2-Estrangeira - Adquirida no mercado interno, exceto a indicada no código 7" :
                                                                        p.FiscalOrigem == 3 ? "3-Nacional, mercadoria ou bem com Conteúdo de Importação superior a 40% (quarenta por cento) e inferior ou igual a 70% (setenta por cento)" :
                                                                        p.FiscalOrigem == 4 ? "4-Nacional, cuja produção tenha sido feita em conformidade com os processos produtivos básicos de que tratam o Decreto-Lei nº 288/67, e as Leis nºs 8.248/91, 8.387/91, 10.176/01 e 11.484/ 07" :
                                                                        p.FiscalOrigem == 5 ? "5-Nacional, mercadoria ou bem com Conteúdo de Importação inferior ou igual a 40% (quarenta por cento)" :
                                                                        p.FiscalOrigem == 6 ? "6-Estrangeira - Importação direta, sem similar nacional, constante em lista da Resolução CAMEX nº 79/2012 e gás natural" :
                                                                        p.FiscalOrigem == 7 ? "7-Estrangeira - Adquirida no mercado interno, sem similar nacional, constante em lista da Resolução CAMEX nº 79/2012 e gás natural" :
                                                                        p.FiscalOrigem == 8 ? "8-Nacional, mercadoria ou bem com Conteúdo de Importação superior a 70% (setenta por cento)" : "",
                                                         TipoImposto = p.TipoImposto == 1 ? "IPI" :
                                                                       p.TipoImposto == 2 ? "PIS" :
                                                                       p.TipoImposto == 3 ? "ICMS" :
                                                                       p.TipoImposto == 4 ? "COFINS" :
                                                                       p.TipoImposto == 5 ? "ISS" :
                                                                       p.TipoImposto == 6 ? "IRRF" :
                                                                       p.TipoImposto == 7 ? "INSS" :
                                                                       p.TipoImposto == 8 ? "Imposto de importação" :
                                                                       p.TipoImposto == 9 ? "Outros Impostos" :
                                                                       p.TipoImposto == 10 ? "CSLL" :
                                                                       p.TipoImposto == 11 ? "ICMSST" :
                                                                       p.TipoImposto == 12 ? "ICMSDiff" :
                                                                       p.TipoImposto == 1 ? "" :
                                                                       p.TipoImposto == 1 ? "" : ""
                                                     }).ToList();
            return lista;

        }

    }
}
