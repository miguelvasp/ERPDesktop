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
    public class BLImpostoEncargosVendas
    {
        DB_ERPContext db = new DB_ERPContext();
        public PedidoVendaItemApuracaoImpostoDAL dal;

        public PedidoVendaDAL pedidoDal;
        public PedidoVendaItemDAL pedidoItemDal;



        public void GeraEncargos(int pIdPedidoVenda)
        {
            //Pega o valor total dos encargos
            decimal? EncargosPorUnidade = 0;
            decimal? TotalEncargos = 0;
            var enc = db.PedidoVendaEncargos.Where(x => x.IdPedidoVenda == pIdPedidoVenda).ToList();
            foreach(PedidoVendaEncargos e in enc)
            {
                TotalEncargos = TotalEncargos + e.Valor;
            }

            //pega a configuraçao da alocação de encargos
            PedidoVendaAlocacaoEncargos al = new PedidoVendaAlocacaoEncargosDAL().GetByPedidoVenda(pIdPedidoVenda);
            if (al != null)
            {
                if (al.DistribuirPor == 1)
                    if (al.Linhas == 1)
                        if (Convert.ToBoolean(al.DistribuirTudo))
                        {
                            //pega a quantidade total dos itens do pedido
                            decimal? QtdeTotal = 0;

                            var itensSoma = (from p in db.PedidoVendaItem
                                             where p.IdPedidoVenda == pIdPedidoVenda
                                             select p.Quantidade).ToList();

                            foreach(decimal? ii in itensSoma)
                            {
                                QtdeTotal = QtdeTotal + (decimal)ii;
                            }

                            if(QtdeTotal != null && QtdeTotal > 0)
                            {
                                if(TotalEncargos != null && TotalEncargos > 0)
                                {
                                    //Calcula o valor dos encargos por cada unidade
                                    EncargosPorUnidade = TotalEncargos / QtdeTotal;
                                    List<PedidoVendaItem> itens = pedidoDal.GetItensByPedido(pIdPedidoVenda);
                                    foreach (PedidoVendaItem i in itens)
                                    {
                                        i.ValorEncargos = i.Quantidade * (decimal)EncargosPorUnidade;
                                        pedidoDal.PVIRepository.Update(i);
                                        pedidoDal.Save();
                                    }
                                }
                            }
                        }
            } 
        }

        public void GeraImpostos(int pIdPedidoItem)
        {
            PedidoVendaItem item = new PedidoVendaItemDAL().GetByID(pIdPedidoItem);
            Produto produto = new ProdutoDAL().ProdutoRepository.GetByID(item.IdProduto);
            PedidoVenda ped = new PedidoVendaDAL().PVRepository.GetByID(item.IdPedidoVenda);

            //Gera os encargos antes de calcular os impostos
            GeraEncargos(item.IdPedidoVenda);

            //Valores
            decimal Encargos = item.ValorEncargos; 
            decimal Descontos = item.DescontoValor;
            decimal TotalItem = item.Quantidade * item.PrecoUnitario;
            decimal PercentualDesconto = item.DescontoPercentual;
            decimal ValorDescontoPercentual = 0;
            if(PercentualDesconto > 0)
            {
                ValorDescontoPercentual = (TotalItem * PercentualDesconto) / 100M;
                Descontos += ValorDescontoPercentual;
            }

            //TotalItem = TotalItem - Descontos;



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
            //dal.ApagaApuracaoImpostos(item.IdPedidoVendaItem);
            List<PedidoVendaItemApuracaoImposto> impostosApurados = dal.GetByPedidoItem(item.IdPedidoVendaItem);
            if (impostosApurados == null || impostosApurados.Count == 0)
            {
                //Pesquisa os codigos de faturamento do grupo do pedido.
                List<ImpostosCalcularModelView> Impostosgerar = new List<ImpostosCalcularModelView>();

                var codigosImposto = (from cd in db.CodigoImposto
                                      where TiposImpostoEmComun.Contains(cd.IdCodigoImposto)
                                      select cd).ToList();
                foreach(CodigoImposto cd in codigosImposto)
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
                    PedidoVendaItemApuracaoImposto aiv = new PedidoVendaItemApuracaoImposto();
                    if (aiv == null) aiv = new PedidoVendaItemApuracaoImposto();
                    aiv.IdPedidoVendaItem = item.IdPedidoVendaItem;
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
                    aiv.Origem = 1; //pedido venda 
                    aiv.FiscalOrigem = db.Produto.Where(x => x.IdProduto == item.IdProduto).Select(x => x.FiscalOrigem).FirstOrDefault();
                    aiv.TipoImposto = imposto.TipoImposto;
                    dal.Insert(aiv);
                    dal.Save();
                }
            }

            List<ImpostosCalcularModelView> Impostos = new List<ImpostosCalcularModelView>();

            var ItensAux = (from p in db.PedidoVendaItemApuracaoImposto
                            where p.IdPedidoVendaItem == item.IdPedidoVendaItem
                            && (p.ManterDadosAjustados == null || p.ManterDadosAjustados == false)
                            select p).ToList();

            foreach(var iAux in ItensAux)
            {
                ImpostosCalcularModelView icmv = new ImpostosCalcularModelView();
                icmv.id = iAux.IdPedidoVendaItemApuracaoImposto;
                if(iAux.IdCodigoImposto != null)
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
                    icmv.MetodoSubstituicaoTributaria = cd.MetodoSubstituicaoTributaria;
                }
                

                
                ConfGrupoImposto cf = (from c in db.ConfGrupoImposto
                                       where c.IdGrupoImposto == iAux.IdGrupoImposto
                                       && c.IdCodigoImposto == iAux.IdCodigoImposto
                                       select c).FirstOrDefault();
                if(cf != null)
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
            foreach (var imposto in Impostos.OrderBy(x => x.TipoImposto).ToList())
            {
                //Procura o item de apuração de impostos
                PedidoVendaItemApuracaoImposto pvai = dal.GetByID((int)imposto.id);
                pvai.BaseValor = null;
                pvai.ValorImposto = null;
                pvai.Aliquota = null;
                pvai.PercentualDeReducaoImposto = null;
                pvai.ImpostoIncluso = imposto.ImpostoIncluso;


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

                #region Calculo ICMSST
                if (imposto.TipoImposto == 11)
                {
                    //Combinação A de ICMS
                    if (imposto.ParametrosCalculos == 2)//Porcentagem do Valor Bruto 
                        if (imposto.BaseMarginal == 4)  //Valor bruto por Linha
                            if ((bool)imposto.ImpostoIncluso == false) //imposto incluso = Nao
                                if (imposto.DataCalculo == 1) //data do lançamento
                                    if (imposto.ValorFiscal == 2) //Sem Crédito/Débito (Isento ou Não Tributável)
                                        if(imposto.MetodoSubstituicaoTributaria == 4)//metodo substituição markup
                                            if (!(bool)imposto.PorcentagemNegativaImposto) // Porcentagem negativa = Não
                                                if (!(bool)imposto.ImpostoRetidoRecuperavel) // imposto recuperado = Nao
                                                    if (imposto.MetodoCalculo == 2) // Metodo = Valor total
                                                    {
                                                        var aliquotas = new CodigoImpostoDAL().ConsultaPercentualPorData((int)imposto.IdCodigoImposto);
                                                        if (aliquotas != null)
                                                        { 
                                                            decimal ImpostosNaoInclusos = pedidoDal.getImpostosNaoInclusosPorItem((int)pvai.IdPedidoVendaItem);
                                                            decimal ICMSNormal = pedidoDal.GetValorImpostoByTipo((int)pvai.IdPedidoVendaItem, 3);
                                                            //Base de Calculo: (Valor Item – Descontos + encargos+ impostos não inclusos– a Redução % descrita no campo redução no parâmetro de valor) * 1+%descrito no campo Mark-up 
                                                            decimal ValorTotal = (TotalItem - Descontos + Encargos + ImpostosNaoInclusos);
                                                            ValorTotal = ValorTotal - ((aliquotas.PercentualReducao * ValorTotal) / 100.00M);
                                                            ValorTotal = ValorTotal * 1 + ((ValorTotal * aliquotas.Markup) / 100.00M);
                                                            pvai.BaseValor = ValorTotal;
                                                            pvai.ValorImposto = ((aliquotas.Aliquota * pvai.BaseValor) / 100.00M) - ICMSNormal;
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
