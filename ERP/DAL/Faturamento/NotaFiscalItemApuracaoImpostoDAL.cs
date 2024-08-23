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
    public class NotaFiscalItemApuracaoImpostoDAL : Repository<NotaFiscalItemApuracaoImposto>
    {
        public void AdicionaImpostos(int IdPedidoVendaItem, int IdNotaFiscalItem)
        {
            var lista = new PedidoVendaItemApuracaoImpostoDAL().GetByPedidoItem(IdPedidoVendaItem);
            foreach(var i in lista)
            {
                NotaFiscalItemApuracaoImposto n = new NotaFiscalItemApuracaoImposto();
                n.IdNotaFiscalItem = IdNotaFiscalItem;
                n.DataLancamento = i.DataLancamento;
                n.DataDocumento = i.DataDocumento;
                n.IdNotaFiscal = i.IdNotaFiscal;
                n.NotaFiscalNumero = i.NotaFiscalNumero;
                n.DataVencimentoImposto = i.DataVencimentoImposto;
                n.DataRegistroIVA = i.DataRegistroIVA;
                n.IdCodigoImposto = i.IdCodigoImposto;
                n.IdCodigoTributacao = i.IdCodigoTributacao;
                n.IdCodigoTributacaoAjustado = i.IdCodigoTributacaoAjustado;
                n.ValorFiscal = i.ValorFiscal;
                n.ValorFiscalAjustado = i.ValorFiscalAjustado;
                n.Aliquota = i.Aliquota;
                n.Quantidade = i.Quantidade;
                n.IdMoeda = i.IdMoeda;
                n.PercentualDaDiferencaICMS = i.PercentualDaDiferencaICMS;
                n.PercentualDeReducaoImposto = i.PercentualDeReducaoImposto;
                n.EncargoImposto = i.EncargoImposto;
                n.BaseValor = i.BaseValor;
                n.BaseValorAjustado = i.BaseValorAjustado;
                n.OutroValorBase = i.OutroValorBase;
                n.OutroValorImposto = i.OutroValorImposto;
                n.ValorBaseIsencao = i.ValorBaseIsencao;
                n.ValorIsencaoImposto = i.ValorIsencaoImposto;
                n.ValorImposto = i.ValorImposto;
                n.ValorAjustado = i.ValorAjustado;
                n.IdCodigoIsencao = i.IdCodigoIsencao;
                n.IdJurisdicaoImposto = i.IdJurisdicaoImposto;
                n.DirecaoImposto = i.DirecaoImposto;
                n.Automatico = i.Automatico;
                n.IdContaContabil = i.IdContaContabil;
                n.ImpostoRetido = i.ImpostoRetido;
                n.ImpostoImportacaoDireta = i.ImpostoImportacaoDireta;
                n.EntidadeLancamentoImpostoIntercompanhia = i.EntidadeLancamentoImpostoIntercompanhia;
                n.IdGrupoImposto = i.IdGrupoImposto;
                n.IdGrupoImpostoItem = i.IdGrupoImpostoItem;
                n.GST_HST = i.GST_HST;
                n.Isencao = i.Isencao;
                n.LancarImpostoAReceberLongoPrazo = i.LancarImpostoAReceberLongoPrazo;
                n.MetodoSubstituicaoTributaria = i.MetodoSubstituicaoTributaria;
                n.DiferencialICMS = i.DiferencialICMS;
                n.IdMoedaComprovante = i.IdMoedaComprovante;
                n.Origem = i.Origem;
                n.FiscalOrigem = i.FiscalOrigem;
                n.IdPeriodoLiquidacaoImposto = i.IdPeriodoLiquidacaoImposto;
                n.TipoImposto = i.TipoImposto;
                n.UsuarioFinal = i.UsuarioFinal;
                n.ManterDadosAjustados = i.ManterDadosAjustados;
                n.ImpostoIncluso = i.ImpostoIncluso;
                Insert(n);
                Save();
            }
        }

        public void AdicionaImpostosCompras(int IdPedidoComprasItem, int IdNotaFiscalItem)
        {
            var lista = new PedidoCompraItemApuracaoImpostoDAL().GetByPedidoItem(IdPedidoComprasItem);
            foreach (var i in lista)
            {
                NotaFiscalItemApuracaoImposto n = new NotaFiscalItemApuracaoImposto();
                n.IdNotaFiscalItem = IdNotaFiscalItem;
                n.DataLancamento = i.DataLancamento;
                n.DataDocumento = i.DataDocumento;
                n.IdNotaFiscal = i.IdNotaFiscal;
                n.NotaFiscalNumero = i.NotaFiscalNumero;
                n.DataVencimentoImposto = i.DataVencimentoImposto;
                n.DataRegistroIVA = i.DataRegistroIVA;
                n.IdCodigoImposto = i.IdCodigoImposto;
                n.IdCodigoTributacao = i.IdCodigoTributacao;
                n.IdCodigoTributacaoAjustado = i.IdCodigoTributacaoAjustado;
                n.ValorFiscal = i.ValorFiscal;
                n.ValorFiscalAjustado = i.ValorFiscalAjustado;
                n.Aliquota = i.Aliquota;
                n.Quantidade = i.Quantidade;
                n.IdMoeda = i.IdMoeda;
                n.PercentualDaDiferencaICMS = i.PercentualDaDiferencaICMS;
                n.PercentualDeReducaoImposto = i.PercentualDeReducaoImposto;
                n.EncargoImposto = i.EncargoImposto;
                n.BaseValor = i.BaseValor;
                n.BaseValorAjustado = i.BaseValorAjustado;
                n.OutroValorBase = i.OutroValorBase;
                n.OutroValorImposto = i.OutroValorImposto;
                n.ValorBaseIsencao = i.ValorBaseIsencao;
                n.ValorIsencaoImposto = i.ValorIsencaoImposto;
                n.ValorImposto = i.ValorImposto;
                n.ValorAjustado = i.ValorAjustado;
                n.IdCodigoIsencao = i.IdCodigoIsencao;
                n.IdJurisdicaoImposto = i.IdJurisdicaoImposto;
                n.DirecaoImposto = i.DirecaoImposto;
                n.Automatico = i.Automatico;
                n.IdContaContabil = i.IdContaContabil;
                n.ImpostoRetido = i.ImpostoRetido;
                n.ImpostoImportacaoDireta = i.ImpostoImportacaoDireta;
                n.EntidadeLancamentoImpostoIntercompanhia = i.EntidadeLancamentoImpostoIntercompanhia;
                n.IdGrupoImposto = i.IdGrupoImposto;
                n.IdGrupoImpostoItem = i.IdGrupoImpostoItem;
                n.GST_HST = i.GST_HST;
                n.Isencao = i.Isencao;
                n.LancarImpostoAReceberLongoPrazo = i.LancarImpostoAReceberLongoPrazo;
                n.MetodoSubstituicaoTributaria = i.MetodoSubstituicaoTributaria;
                n.DiferencialICMS = i.DiferencialICMS;
                n.IdMoedaComprovante = i.IdMoedaComprovante;
                n.Origem = i.Origem;
                n.FiscalOrigem = i.FiscalOrigem;
                n.IdPeriodoLiquidacaoImposto = i.IdPeriodoLiquidacaoImposto;
                n.TipoImposto = i.TipoImposto;
                n.UsuarioFinal = i.UsuarioFinal;
                n.ManterDadosAjustados = i.ManterDadosAjustados;
                //n.ImpostoIncluso = i.ImpostoIncluso;
                Insert(n);
                Save();
            }
        }

        public List<NotaFiscalItemApuracaoImposto> GetImpostosByNFItem(int IdNotaFiscalItem)
        {

            List<NotaFiscalItemApuracaoImposto> impostos = (from i in db.NotaFiscalItemApuracaoImposto
                                                            where i.IdNotaFiscalItem == IdNotaFiscalItem
                                                             && i.ValorImposto > 0
                                                             select i).ToList();
            return impostos;
        }

        public List<NotaFiscalItemApuracaoImposto> GetByPedidoItem(int Id)
        {
            List<NotaFiscalItemApuracaoImposto> lista = (from ai in db.NotaFiscalItemApuracaoImposto
                                                         where ai.IdNotaFiscalItem == Id
                                                         && (ai.ManterDadosAjustados == null || ai.ManterDadosAjustados == false)
                                                         select ai).ToList();
            return lista;
        }

        public void ApagaApuracaoImpostos(int Id)
        {
            List<NotaFiscalItemApuracaoImposto> lista = (from ai in db.NotaFiscalItemApuracaoImposto
                                                         where ai.IdNotaFiscalItem == Id
                                                         && (ai.ManterDadosAjustados == null || ai.ManterDadosAjustados == false)
                                                         select ai).ToList();
            foreach (NotaFiscalItemApuracaoImposto i in lista)
            {
                this.Delete(i.IdNotaFiscalItemApuracaoImposto);
                this.Save();
            }
        }

        public List<NotaFiscalItemApuracaoImposto> GetImpostosByNFPedidoItem(int idNotaFiscalItem)
        {

            List<NotaFiscalItemApuracaoImposto> impostos = (from i in db.NotaFiscalItemApuracaoImposto
                                                            where i.IdNotaFiscalItem == idNotaFiscalItem
                                                            && i.ValorImposto > 0
                                                            select i).ToList();
            return impostos;
        }

        public List<NotaFiscalItemApuracaoImposto> GetImpostosByNF(int idNotaFiscal)
        {
            var itens = (from i in db.NotaFiscalItem
                         where i.IdNotaFiscal == idNotaFiscal
                         select i.IdNotaFiscalItem).ToList();

            List<NotaFiscalItemApuracaoImposto> impostos = (from i in db.NotaFiscalItemApuracaoImposto
                                                            where itens.Contains(i.IdNotaFiscalItem)
                                                            && i.ValorImposto > 0
                                                            select i).ToList();
            return impostos;
        }

        public decimal GetImpostosNaoInclusosByNotaFiscal(int idNotaFiscal)
        {
            var itens = (from i in db.NotaFiscalItem
                         where i.IdNotaFiscal == idNotaFiscal
                         select i.IdNotaFiscalItem).ToList();

            List<NotaFiscalItemApuracaoImposto> impostos = (from i in db.NotaFiscalItemApuracaoImposto
                                                            join c in db.CodigoImposto on i.IdCodigoImposto equals c.IdCodigoImposto
                                                            where itens.Contains(i.IdNotaFiscalItem)
                                                            && i.ValorImposto > 0
                                                            && c.ImpostoIncluso == false
                                                            select i).ToList();
            decimal somaImpostos = 0;

            foreach (var i in impostos)
            {

                if (i.ValorAjustado != null && i.ValorAjustado > 0)
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

        public CodigoImposto GetCodigoImpostoItemNotaFiscal(int IdNotaFiscalItem, int IdTipoImposto)
        {
            db.Configuration.LazyLoadingEnabled = true;
            return (from i in db.NotaFiscalItemApuracaoImposto
                    join c in db.CodigoImposto on i.IdCodigoImposto equals c.IdCodigoImposto
                    where i.IdNotaFiscalItem == IdNotaFiscalItem
                    && i.TipoImposto == IdTipoImposto
                    select c).FirstOrDefault();
        }

        public NotaFiscalItemApuracaoImposto GetApuracaoImpostoItem(int IdNotaFiscalItem, int IdTipoImposto)
        {
            return (from i in db.NotaFiscalItemApuracaoImposto
                    where i.IdNotaFiscalItem == IdNotaFiscalItem
                    && i.TipoImposto == IdTipoImposto
                    select i).FirstOrDefault();
        }


        public bool ContemTipoImposto(int IdNotaFiscalItem, int IdTipoImposto)
        {
            bool achou = false;

            var itens = (from i in db.NotaFiscalItemApuracaoImposto
                         where i.IdNotaFiscalItem == IdNotaFiscalItem
                         && i.TipoImposto == IdTipoImposto
                         select i).FirstOrDefault();
            if (itens != null)
            {
                if (Convert.ToDecimal(itens.ValorImposto) > 0)
                {
                    return true;
                }
            }

            return achou;
        }


        public void ApagaImpostos(int pId)
        {
            List<NotaFiscalItemApuracaoImposto> lista = (from d in db.NotaFiscalItemApuracaoImposto
                                                         where d.IdNotaFiscalItem == pId
                                                         select d).ToList();
            foreach (NotaFiscalItemApuracaoImposto i in lista)
            {
                this.Delete(i.IdNotaFiscalItemApuracaoImposto);
                this.Save();
            }
        }

        public List<ApuracaoImpostosModelView> GetListaImpostos(int pIdNotaFiscalItem)
        {
            List<ApuracaoImpostosModelView> lista = (from p in db.NotaFiscalItemApuracaoImposto
                                                     where p.IdNotaFiscalItem == pIdNotaFiscalItem

                                                     from ci in db.CodigoImposto.Where(x => x.IdCodigoImposto == p.IdCodigoImposto).DefaultIfEmpty()
                                                     from ct in db.CodigoTributacao.Where(x => x.IdCodigoTributacao == p.IdCodigoTributacao).DefaultIfEmpty()
                                                     from cta in db.CodigoTributacao.Where(x => x.IdCodigoTributacao == p.IdCodigoTributacaoAjustado).DefaultIfEmpty()
                                                     select new ApuracaoImpostosModelView
                                                     {
                                                         Id = p.IdNotaFiscalItemApuracaoImposto,
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
