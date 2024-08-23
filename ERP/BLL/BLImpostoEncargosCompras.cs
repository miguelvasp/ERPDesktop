using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.DAL;
using ERP.Models;
using ERP.ModelView;

namespace ERP.BLL
{
    public class BLImpostoEncargosCompras
    {
        DB_ERPContext db = new DB_ERPContext();
        public PedidoCompraItemApuracaoImpostoDAL dal;

        public PedidoCompraDAL pedidoDal;
        public PedidoCompraItemDAL pedidoItemDal;



        public void GeraEncargos(int pIdPedidoCompra)
        {
            //Pega o valor total dos encargos
            decimal? EncargosPorUnidade = 0;
            decimal? TotalEncargos = 0;
            var enc = db.PedidoCompraEncargos.Where(x => x.IdPedidoCompra == pIdPedidoCompra).ToList();
            foreach (PedidoCompraEncargos e in enc)
            {
                TotalEncargos = TotalEncargos + e.Valor;
            }

            //pega a configuraçao da alocação de encargos
            PedidoCompraAlocacaoEncargos al = new PedidoCompraAlocacaoEncargosDAL().GetByPedidoCompra(pIdPedidoCompra);
            if (al != null)
            {
                if (al.DistribuirPor == 1)
                    if (al.Linhas == 1)
                        if (Convert.ToBoolean(al.DistribuirTudo))
                        {
                            //pega a quantidade total dos itens do pedido
                            //pega a quantidade total dos itens do pedido
                            decimal? QtdeTotal = 0;

                            var itensSoma = (from p in db.PedidoCompraItem
                                             where p.IdPedidoCompra == pIdPedidoCompra
                                             select p.Quantidade).ToList();

                            foreach (decimal? ii in itensSoma)
                            {
                                QtdeTotal = QtdeTotal + (decimal)ii;
                            }

                            if (QtdeTotal != null && QtdeTotal > 0)
                            {
                                if (TotalEncargos != null && TotalEncargos > 0)
                                {
                                    //Calcula o valor dos encargos por cada unidade
                                    EncargosPorUnidade = TotalEncargos / QtdeTotal;
                                    List<PedidoCompraItem> itens = pedidoDal.GetItensByPedido(pIdPedidoCompra);
                                    foreach (PedidoCompraItem i in itens)
                                    {
                                        i.ValorEncargos = i.Quantidade * (decimal)EncargosPorUnidade;
                                        pedidoDal.PCIRepository.Update(i);
                                        pedidoDal.Save();
                                    }
                                }
                            }
                        }
            }
        }

        public void GeraImpostos(int pIdPedidoItem)
        {
            PedidoCompraItem item = new PedidoCompraItemDAL().GetByID(pIdPedidoItem);
            Produto produto = new ProdutoDAL().ProdutoRepository.GetByID(item.IdProduto);
            PedidoCompra ped = new PedidoCompraDAL().PCRepository.GetByID(item.IdPedidoCompra);

            //Gera os encargos antes de calcular os impostos
            GeraEncargos(item.IdPedidoCompra);

            //Valores
            decimal Encargos = (decimal)item.ValorEncargos;
            decimal Descontos = (decimal)item.DescontoValor;
            decimal TotalItem = (decimal)item.Quantidade * (decimal)item.PrecoUnitario;
            TotalItem = TotalItem - Descontos;



            //pesquisa os impostos em comun entre o pedido e o item
            var impostosPedido = (from cf in db.ConfGrupoImposto
                                  join cd in db.CodigoImposto on cf.IdCodigoImposto equals cd.IdCodigoImposto
                                  where cf.IdGrupoImposto == item.IdGrupoImposto
                                  select cd.IdCodigoImposto).ToList();

            var impostosItem = (from cf in db.ConfGrupoImpostoItem
                                join cd in db.CodigoImposto on cf.IdCodigoImposto equals cd.IdCodigoImposto
                                where cf.IdGrupoImpostoItem == item.IdGrupoImpostosItem
                                select cd.IdCodigoImposto).ToList();

            List<int> TiposImpostoEmComun = new List<int>();
            foreach (int id in impostosPedido)
            {
                if (impostosItem.Contains(id))
                {
                    if (!TiposImpostoEmComun.Contains(id))
                    {
                        TiposImpostoEmComun.Add(id);
                    }
                }
            }

            //Gera os itens na tabela de apuração
            //dal.ApagaApuracaoImpostos(item.IdPedidoCompraItem);
            List<PedidoCompraItemApuracaoImposto> impostosApurados = dal.GetByPedidoItem(item.IdPedidoCompraItem);
            if (impostosApurados == null || impostosApurados.Count == 0)
            {
                //Pesquisa os codigos de faturamento do grupo do pedido.
                List<ImpostosCalcularModelView> Impostosgerar = new List<ImpostosCalcularModelView>();

                var codigosImposto = (from cd in db.CodigoImposto
                                      where TiposImpostoEmComun.Contains(cd.IdCodigoImposto)
                                      select cd).ToList();
                foreach (CodigoImposto cd in codigosImposto)
                {
                    ImpostosCalcularModelView i = new ImpostosCalcularModelView();
                    i.IdCodigoImposto = cd.IdCodigoImposto;
                    i.IdJuridicaoImposto = cd.IdJuridicaoImposto;
                    i.ParametrosCalculos = cd.ParametrosCalculos;
                    i.BaseMarginal = cd.BaseMarginal;
                    i.TipoImposto = cd.TipoImposto;
                    i.ImpostoIncluso = cd.ImpostoIncluso;
                    i.DataCalculo = cd.DataCalculo;
                    i.PorcentagemNegativaImposto = cd.PorcentagemNegativaImposto;
                    i.ImpostoRetidoRecuperavel = cd.ImpostoRetidoRecuperavel;
                    i.MetodoCalculo = cd.MetodoCalculo;

                    ConfGrupoImposto cf = (from c in db.ConfGrupoImposto
                                           where c.IdGrupoImposto == item.IdGrupoImposto
                                           && c.IdCodigoImposto == cd.IdCodigoImposto
                                           select c).FirstOrDefault();
                    if (cf != null)
                    {
                        i.IdCodigoIsencao = cf.IdCodigoIsencao;
                        if (cf.IdCodigoTributacao != null)
                        {
                            CodigoTributacao ct = new CodigoTributacaoDAL().GetByID((int)cf.IdCodigoTributacao);
                            i.IdCodigoTributacao = cd.IdCodigoTributacao;
                            i.ValorFiscal = ct.ValorFiscal;
                        }
                    }
                    Impostosgerar.Add(i);

                }

                //var Impostosgerar = (from cf in db.ConfGrupoImposto
                //                     join cd in db.CodigoImposto on cf.IdCodigoImposto equals cd.IdCodigoImposto

                //                     where cf.IdGrupoImposto == item.IdGrupoImposto
                //                     && TiposImpostoEmComun.Contains(cd.IdCodigoImposto) //impostos em comun entre os grupos

                //                     from ct in db.CodigoTributacao
                //                     .Where(x => x.IdCodigoTributacao == cf.IdCodigoTributacao)
                //                     .DefaultIfEmpty()

                //                     select new
                //                     {
                //                         cd.IdCodigoImposto,
                //                         cf.IdCodigoIsencao,
                //                         ct.IdCodigoTributacao,
                //                         cd.IdJuridicaoImposto,
                //                         cd.ParametrosCalculos,
                //                         cd.BaseMarginal,
                //                         cd.TipoImposto,
                //                         cd.ImpostoIncluso,
                //                         cd.DataCalculo,
                //                         ct.ValorFiscal,
                //                         cd.PorcentagemNegativaImposto,
                //                         cd.ImpostoRetidoRecuperavel,
                //                         cd.MetodoCalculo
                //                     }).ToList();

                foreach (var imposto in Impostosgerar)
                {
                    PedidoCompraItemApuracaoImposto aiv = new PedidoCompraItemApuracaoImposto();
                    if (aiv == null) aiv = new PedidoCompraItemApuracaoImposto();
                    aiv.IdPedidoCompraItem = item.IdPedidoCompraItem;
                    aiv.IdCodigoImposto = imposto.IdCodigoImposto;
                    aiv.IdCodigoTributacao = imposto.IdCodigoTributacao;
                    aiv.IdCodigoTributacaoAjustado = imposto.IdCodigoTributacao;
                    aiv.Quantidade = item.Quantidade;
                    aiv.IdMoeda = ped.IdMoeda;
                    aiv.IdCodigoIsencao = imposto.IdCodigoIsencao;
                    aiv.IdJurisdicaoImposto = imposto.IdJuridicaoImposto;
                    //aiv.DirecaoImposto =
                    //aiv.Automatico =
                    if (ped.IdOperacao != null)
                    {
                        Operacao op = new OperacaoDAL().GetByID((int)ped.IdOperacao);
                        if (op != null)
                        {
                            aiv.IdContaContabil = op.IdContaContabil;
                        }
                    }

                    aiv.IdGrupoImposto = item.IdGrupoImposto;
                    aiv.IdGrupoImpostoItem = item.IdGrupoImpostosItem;
                    aiv.IdMoedaComprovante = ped.IdMoeda;
                    aiv.Origem = 1; //pedido Compra 
                    aiv.FiscalOrigem = db.Produto.Where(x => x.IdProduto == item.IdProduto).Select(x => x.FiscalOrigem).FirstOrDefault();
                    aiv.TipoImposto = imposto.TipoImposto;
                    dal.Insert(aiv);
                    dal.Save();
                }
            }

            List<ImpostosCalcularModelView> Impostos = new List<ImpostosCalcularModelView>();

            var ItensAux = (from p in db.PedidoCompraItemApuracaoImposto
                            where p.IdPedidoCompraItem == item.IdPedidoCompraItem
                            && (p.ManterDadosAjustados == null || p.ManterDadosAjustados == false)
                            select p).ToList();

            foreach (var iAux in ItensAux)
            {
                ImpostosCalcularModelView icmv = new ImpostosCalcularModelView();
                icmv.id = iAux.IdPedidoCompraItemApuracaoImposto;
                if (iAux.IdCodigoImposto != null)
                {
                    icmv.IdCodigoImposto = iAux.IdCodigoImposto;
                    CodigoImposto cd = new CodigoImpostoDAL().GetByID((int)iAux.IdCodigoImposto);
                    icmv.IdJuridicaoImposto = cd.IdJuridicaoImposto;
                    icmv.ParametrosCalculos = cd.ParametrosCalculos;
                    icmv.BaseMarginal = cd.BaseMarginal;
                    icmv.TipoImposto = cd.TipoImposto;
                    icmv.ImpostoIncluso = cd.ImpostoIncluso;
                    icmv.DataCalculo = cd.DataCalculo;
                    icmv.PorcentagemNegativaImposto = cd.PorcentagemNegativaImposto;
                    icmv.ImpostoRetidoRecuperavel = cd.ImpostoRetidoRecuperavel;
                    icmv.MetodoCalculo = cd.MetodoCalculo;
                }



                ConfGrupoImposto cf = (from c in db.ConfGrupoImposto
                                       where c.IdGrupoImposto == iAux.IdGrupoImposto
                                       && c.IdCodigoImposto == iAux.IdCodigoImposto
                                       select c).FirstOrDefault();
                if (cf != null)
                {
                    icmv.IdCodigoIsencao = cf.IdCodigoIsencao;
                    if (cf.IdCodigoTributacao != null)
                    {
                        CodigoTributacao ct = new CodigoTributacaoDAL().GetByID((int)cf.IdCodigoTributacao);
                        icmv.IdCodigoTributacao = cf.IdCodigoTributacao;
                        icmv.ValorFiscal = ct.ValorFiscal;

                    }
                }
                Impostos.Add(icmv);
            }

            //Tipos de impostos
            //{ iValue = 1, Text = "IPI" });
            //{ iValue = 2, Text = "PIS" });
            //{ iValue = 3, Text = "ICMS" });
            //{ iValue = 4, Text = "COFINS" });
            //{ iValue = 5, Text = "ISS" });
            //{ iValue = 6, Text = "IRRF" });
            //{ iValue = 7, Text = "INSS" });
            //{ iValue = 8, Text = "Imposto de importação" });
            //{ iValue = 9, Text = "Outros Impostos" });
            //{ iValue = 10, Text = "CSLL" });
            //{ iValue = 11, Text = "ICMSST" });
            //{ iValue = 12, Text = "ICMSDiff" }); 
            foreach (var imposto in Impostos)
            {
                //Procura o item de apuração de impostos
                PedidoCompraItemApuracaoImposto pvai = dal.GetByID((int)imposto.id);
                pvai.BaseValor = null;
                pvai.ValorImposto = null;
                pvai.Aliquota = null;
                pvai.PercentualDeReducaoImposto = null;
                #region Calculo IPI
                if (imposto.TipoImposto == 1)
                {
                    //Primeira Forma (imposto.ValorFiscal == 1) //Com Crédito/Débito
                    if (imposto.ParametrosCalculos == 1)//Porcentagem do Valor Líquido 
                        if (imposto.BaseMarginal == 1)  //Valor Líquido por Linha
                            if (!(bool)imposto.ImpostoIncluso) //imposto incluso = Nao
                                if (imposto.DataCalculo == 1) //data do lançamento
                                    if (imposto.ValorFiscal == 1) //Com Crédito/Débito
                                        if (!(bool)imposto.PorcentagemNegativaImposto) // Porcentagem negativa = Não
                                            if (!(bool)imposto.ImpostoRetidoRecuperavel) // imposto recuperado = Nao
                                                if (imposto.MetodoCalculo == 2) // Metodo = Valor total
                                                {
                                                    var aliquotas = new CodigoImpostoDAL().ConsultaPercentualPorData((int)imposto.IdCodigoImposto);
                                                    if (aliquotas != null)
                                                    {
                                                        decimal ValorTotal = (TotalItem - Descontos + Encargos);
                                                        pvai.BaseValor = ValorTotal - ((aliquotas.PercentualReducao * ValorTotal) / 100.00M);
                                                        pvai.ValorImposto = ((aliquotas.Aliquota * pvai.BaseValor) / 100.00M);
                                                        pvai.Aliquota = aliquotas.Aliquota;
                                                        pvai.PercentualDeReducaoImposto = aliquotas.PercentualReducao;
                                                    }
                                                }

                    //Segunda Forma (imposto.ValorFiscal != 1) //Sem Crédito/Débito
                    if (imposto.ParametrosCalculos == 1)//Porcentagem do Valor Líquido 
                        if (imposto.BaseMarginal == 1)  //Valor Líquido por Linha
                            if (!(bool)imposto.ImpostoIncluso) //imposto incluso = Nao
                                if (imposto.DataCalculo == 1) //data do lançamento
                                    if (imposto.ValorFiscal == 2 || imposto.ValorFiscal == 3) //Sem Crédito/Débito
                                        if (!(bool)imposto.PorcentagemNegativaImposto) // Porcentagem negativa = Não
                                            if (!(bool)imposto.ImpostoRetidoRecuperavel) // imposto recuperado = Nao
                                                if (imposto.MetodoCalculo == 2) // Metodo = Valor total
                                                {
                                                    var aliquotas = new CodigoImpostoDAL().ConsultaPercentualPorData((int)imposto.IdCodigoImposto);
                                                    if (aliquotas != null)
                                                    {
                                                        decimal ValorTotal = (TotalItem - Descontos + Encargos);
                                                        pvai.BaseValor = ValorTotal - ((aliquotas.PercentualReducao * ValorTotal) / 100.00M);
                                                        pvai.ValorImposto = ((aliquotas.Aliquota * pvai.BaseValor) / 100.00M);
                                                        pvai.Aliquota = aliquotas.Aliquota;
                                                        pvai.PercentualDeReducaoImposto = aliquotas.PercentualReducao;
                                                    }
                                                }

                }
                #endregion


                #region Calculo PIS
                if (imposto.TipoImposto == 2)
                {
                    if (imposto.ParametrosCalculos == 1)//Porcentagem do Valor Líquido 
                        if (imposto.BaseMarginal == 1)  //Valor Líquido por Linha
                            if ((bool)imposto.ImpostoIncluso) //imposto incluso = sim
                                if (imposto.DataCalculo == 1) //data do lançamento
                                    if (imposto.ValorFiscal == 1) //Com Crédito/Débito
                                        if (!(bool)imposto.PorcentagemNegativaImposto) // Porcentagem negativa = Não
                                            if (!(bool)imposto.ImpostoRetidoRecuperavel) // imposto recuperado = Nao
                                                if (imposto.MetodoCalculo == 2) // Metodo = Valor total
                                                {
                                                    var aliquotas = new CodigoImpostoDAL().ConsultaPercentualPorData((int)imposto.IdCodigoImposto);
                                                    if (aliquotas != null)
                                                    {
                                                        decimal ValorTotal = (TotalItem - Descontos + Encargos);
                                                        pvai.BaseValor = ValorTotal - ((aliquotas.PercentualReducao * ValorTotal) / 100.00M);
                                                        pvai.ValorImposto = ((aliquotas.Aliquota * pvai.BaseValor) / 100.00M);
                                                        pvai.Aliquota = aliquotas.Aliquota;
                                                        pvai.PercentualDeReducaoImposto = aliquotas.PercentualReducao;
                                                    }
                                                }

                }
                #endregion

                #region Calculo ICMS
                if (imposto.TipoImposto == 3)
                {
                    //Combinação A de ICMS
                    if (imposto.ParametrosCalculos == 1)//Porcentagem do Valor Líquido 
                        if (imposto.BaseMarginal == 1)  //Valor Líquido por Linha
                            if ((bool)imposto.ImpostoIncluso) //imposto incluso = sim
                                if (imposto.DataCalculo == 1) //data do lançamento
                                    if (imposto.ValorFiscal == 1) //Com Crédito/Débito
                                        if (!(bool)imposto.PorcentagemNegativaImposto) // Porcentagem negativa = Não
                                            if (!(bool)imposto.ImpostoRetidoRecuperavel) // imposto recuperado = Nao
                                                if (imposto.MetodoCalculo == 2) // Metodo = Valor total
                                                {
                                                    var aliquotas = new CodigoImpostoDAL().ConsultaPercentualPorData((int)imposto.IdCodigoImposto);
                                                    if (aliquotas != null)
                                                    {
                                                        decimal ValorTotal = (TotalItem - Descontos + Encargos);
                                                        pvai.BaseValor = ValorTotal - ((aliquotas.PercentualReducao * ValorTotal) / 100.00M);
                                                        pvai.ValorImposto = ((aliquotas.Aliquota * pvai.BaseValor) / 100.00M);
                                                        pvai.Aliquota = aliquotas.Aliquota;
                                                        pvai.PercentualDeReducaoImposto = aliquotas.PercentualReducao;
                                                    }
                                                }

                }
                #endregion

                #region Calculo COFINS
                if (imposto.TipoImposto == 4)
                {
                    //Combinação A de ICMS
                    if (imposto.ParametrosCalculos == 1)//Porcentagem do Valor Líquido 
                        if (imposto.BaseMarginal == 1)  //Valor Líquido por Linha
                            if ((bool)imposto.ImpostoIncluso) //imposto incluso = sim
                                if (imposto.DataCalculo == 1) //data do lançamento
                                    if (imposto.ValorFiscal == 1) //Com Crédito/Débito
                                        if (!(bool)imposto.PorcentagemNegativaImposto) // Porcentagem negativa = Não
                                            if (!(bool)imposto.ImpostoRetidoRecuperavel) // imposto recuperado = Nao
                                                if (imposto.MetodoCalculo == 2) // Metodo = Valor total
                                                {
                                                    var aliquotas = new CodigoImpostoDAL().ConsultaPercentualPorData((int)imposto.IdCodigoImposto);
                                                    if (aliquotas != null)
                                                    {
                                                        decimal ValorTotal = (TotalItem - Descontos + Encargos);
                                                        pvai.BaseValor = ValorTotal - ((aliquotas.PercentualReducao * ValorTotal) / 100.00M);
                                                        pvai.ValorImposto = ((aliquotas.Aliquota * pvai.BaseValor) / 100.00M);
                                                        pvai.Aliquota = aliquotas.Aliquota;
                                                        pvai.PercentualDeReducaoImposto = aliquotas.PercentualReducao;
                                                    }
                                                }

                }
                #endregion



                //Depois de efetuar os calculos para o tipo de imposto especifico salva os dados
                dal.Update(pvai);
                dal.Save();
            }
        }
    }
}
