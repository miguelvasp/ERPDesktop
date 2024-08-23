using ERP.Auxiliares;
using ERP.DAL;
using ERP.BLL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ERP.DAL.Fiscal;
using ERP.DAL.Cadastros;

namespace ERP
{
    public partial class frmPedidoVendasAddItem : Form
    {
        PedidoVendaDAL dal = new PedidoVendaDAL();
        PedidoVendaItemCentroCustoDAL pvDal = new PedidoVendaItemCentroCustoDAL();
        ContratoComercialDAL ccDal = new ContratoComercialDAL();
        PedidoVendaItem p = new PedidoVendaItem();
        decimal Valor = 0;
        bool AlterouPreco = false;

        //Pega as configurações da empresa
        Configuracao confEmpresa = new ConfiguracaoDAL().GetByEmpresa(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
        string CasasDecimais = "F2";

        public PedidoVendaItemApuracaoImpostoDAL impostoDal;

        int idCodProduto = 0;
        int IdPedidoVenda = 0;
        int IdCliente = 0;
        int IdCFOP = 0;
        public frmPedidoVendasAddItem()
        { 
            InitializeComponent();
        }

        public frmPedidoVendasAddItem(PedidoVendaDAL pDal, PedidoVendaItem pedidoItem, int pIdCFOP)
        {
            IdCFOP = pIdCFOP;
            dal = pDal;
            p = pedidoItem;
            IdPedidoVenda = p.IdPedidoVenda;
            InitializeComponent();
        }

        private void frmPedidoVendasAddItem_Load(object sender, EventArgs e)
        {
            //Configura as casas decimais da empresa
            if(confEmpresa.CasasDecimais != null)
            {
                CasasDecimais = "F" + confEmpresa.CasasDecimais.ToString();
            }


            CarregaCombos();
            if (p.IdPedidoVendaItem != 0)
            {
                CarregaDados();
            }
            else
            {
                
                CarregaNovoItem();
                //cboCFOP.SelectedValue = IdCFOP;
            }

            if(String.IsNullOrEmpty(cboProduto.Text))
            {
                // cboProduto.Focus();
                txtQuantidade.Focus();
            }
            else
            {
                tabPage1.Controls.Find("txtQuantidade", true)[0].Focus();
                txtQuantidade.Focus();
            }
            CalculaValorTotalPedido();
        }

        private void frmPedidoVendasAddItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            LimpaControles();
            tabControl1.SelectedIndex = 0;
            p = new PedidoVendaItem();
            p.IdPedidoVenda = IdPedidoVenda;
            p.IdPedidoVendaItem = 0;
            CarregaNovoItem();
            txtQuantidade.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (p.IdPedidoVendaItem > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == DialogResult.Yes)
                {
                    try
                    {
                        dal.ApagarItemDependencias(p.IdPedidoVendaItem);
                        dal.PVIRepository.Delete(p.IdPedidoVendaItem);
                        dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                        Close();
                    }
                    catch (Exception ex)
                    {
                        Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
                    }
                }
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            { 

                if (Util.Validacao.ValidaCampos(this))
                {
                    p.DescontoPercentual = 0;
                    p.DescontoValor = 0;
                    p.DescontoVarejista = 0;
                    p.IdArmazem = null;
                    p.IdAtivoFixo = null;
                    p.IdCest = null;
                    p.IdCFOP = null;
                    p.IdCodigoExternoCliente = null;
                    p.IdCodigoServico = null;
                    p.IdVariantesCor = null;
                    p.IdDeposito = null;
                    p.IdVariantesEstilo = null;
                    p.IdGrupoAtivo = null;
                    p.IdGrupoImposto = null;
                    p.IdGrupoImpostosItem = null;
                    p.IdGrupoImpostoItemRetido = null;
                    p.IdGrupoImpostoRetido = null;
                    p.IdGrupoLotes = null;
                    p.IdGrupoSeries = null;
                    p.IdLocalizacao = null;
                    p.IdMetodoDepreciacao= null;
                    p.IdNCM = null; 
                    p.IdVariantesTamanho = null;
                    p.IdTipoDocumentoFiscal = null;
                    p.IdUnidade = null;
                    p.IdVariantesConfig = null;
                

                    p.IdProduto = Convert.ToInt32(cboProduto.SelectedValue);
                    p.Quantidade = Convert.ToDecimal(txtQuantidade.Text);
                    if (!String.IsNullOrEmpty(cboUnidade.Text)) p.IdUnidade = Convert.ToInt32(cboUnidade.SelectedValue);
                    if (!String.IsNullOrEmpty(txtPrecoTabela.Text)) p.PrecoTabela = Convert.ToDecimal(txtPrecoTabela.Text);
                    p.PrecoUnitario = Convert.ToDecimal(txtPrecoUnitario.Text); 
                    if (!String.IsNullOrEmpty(txtDescontoPercentual.Text)) p.DescontoPercentual = Convert.ToDecimal(txtDescontoPercentual.Text);
                    if (!String.IsNullOrEmpty(txtDescontoValor.Text)) p.DescontoValor = Convert.ToDecimal(txtDescontoValor.Text);
                    if (!String.IsNullOrEmpty(txtValorEncargos.Text)) p.ValorEncargos = Convert.ToDecimal(txtValorEncargos.Text);
                    if (!String.IsNullOrEmpty(txtValorLiquido.Text)) p.ValorLiquido = Convert.ToDecimal(txtValorLiquido.Text);
                    //if (!String.IsNullOrEmpty(cboCFOP.Text))
                    //{
                    //    if(Convert.ToInt32(cboCFOP.SelectedValue) > 0)
                    //    {
                    //         = Convert.ToInt32(cboCFOP.SelectedValue);
                    //        IdCFOP = Convert.ToInt32(p.IdCFOP);
                    //    }
                    //}

                    p.IdCFOP = IdCFOP;

                    if (!String.IsNullOrEmpty(cboCodigoServico.Text)) p.IdCodigoServico = Convert.ToInt32(cboCodigoServico.SelectedValue);



                    if (!String.IsNullOrEmpty(cboVariantesConfig.Text)) p.IdVariantesConfig = Convert.ToInt32(cboVariantesConfig.SelectedValue);
                    if (!String.IsNullOrEmpty(cboEstilo.Text)) p.IdVariantesEstilo = Convert.ToInt32(cboEstilo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCor.Text)) p.IdVariantesCor = Convert.ToInt32(cboCor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTamanho.Text)) p.IdVariantesTamanho = Convert.ToInt32(cboTamanho.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoLotes.Text)) p.IdGrupoLotes = Convert.ToInt32(cboGrupoLotes.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoSeries.Text)) p.IdGrupoSeries = Convert.ToInt32(cboGrupoSeries.SelectedValue);
                    if (!String.IsNullOrEmpty(cboArmazem.Text)) p.IdArmazem = Convert.ToInt32(cboArmazem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDeposito.Text)) p.IdDeposito = Convert.ToInt32(cboDeposito.SelectedValue);
                    if (!String.IsNullOrEmpty(cboLocalizacao.Text)) p.IdLocalizacao = Convert.ToInt32(cboLocalizacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCodigoExternoCliente.Text)) p.IdCodigoExternoCliente = Convert.ToInt32(cboCodigoExternoCliente.SelectedValue);
                    p.AtivoFixo = chkAtivoFixo.Checked;
                    if (!String.IsNullOrEmpty(cboGrupoAtivo.Text)) p.IdGrupoAtivo = Convert.ToInt32(cboGrupoAtivo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboMetodoPreciacao.Text)) p.IdMetodoDepreciacao = Convert.ToInt32(cboMetodoPreciacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboAtivoFixo.Text)) p.IdAtivoFixo = Convert.ToInt32(cboAtivoFixo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoTransacaoAtivo.Text)) p.TipoTransacaoAtivo = Convert.ToInt32(cboTipoTransacaoAtivo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoImposto.Text)) p.IdGrupoImposto = Convert.ToInt32(cboGrupoImposto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoImpostoItem.Text)) p.IdGrupoImpostosItem = Convert.ToInt32(cboGrupoImpostoItem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoImpostoRetido.Text)) p.IdGrupoImpostoRetido = Convert.ToInt32(cboGrupoImpostoRetido.SelectedValue);
                    if (!String.IsNullOrEmpty(cboNCM.Text)) p.IdNCM = Convert.ToInt32(cboNCM.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCest.Text)) p.IdCest = Convert.ToInt32(cboCest.SelectedValue);
                    //if (!String.IsNullOrEmpty(cboGrupoEncargos.Text)) p.IdGrupoEncargos = Convert.ToInt32(cboGrupoEncargos.SelectedValue);
                    //if (!String.IsNullOrEmpty(cboGrupoDescontos.Text)) p.IdGrupoDescontos = Convert.ToInt32(cboGrupoDescontos.SelectedValue);
                    if (!String.IsNullOrEmpty(txtPesoUnitario.Text)) p.PesoUnitario = Convert.ToDecimal(txtPesoUnitario.Text);
                    if (txtDescVarejista.Text != "") p.DescontoVarejista = Convert.ToDecimal(txtDescVarejista.Text);


                    if (p.IdPedidoVendaItem == 0)
                    {
                        p.QuantidadeEntregue = 0;
                        p.QuantidadeSeparacao = p.Quantidade;
                        p.StatusLinha = (int)Util.EnumERP.StatusPedido.Aberto;
                        dal.PVIRepository.Insert(p);
                        dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                        ImportaCentroCusto();
                    }
                    else
                    {
                        
                        if (idCodProduto == Convert.ToInt32(cboProduto.SelectedValue))
                        {
                            dal.PVIRepository.Update(p);
                            dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                        }
                        else
                        {
                            ExcluirCentroCusto();
                            dal.PVIRepository.Update(p);
                            dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                            ImportaCentroCusto();
                        }
                    }
                    
                    //geraImpostos
                    BLImpostoEncargosVendas blImpostos = new BLImpostoEncargosVendas();
                    blImpostos.dal = impostoDal;
                    blImpostos.pedidoDal = dal;
                    blImpostos.GeraEncargos(p.IdPedidoVenda);
                    blImpostos.GeraImpostos(p.IdPedidoVendaItem);

                    BLContabilidade blContabilidade = new BLContabilidade();
                        //Gera Contabilidade
                    blContabilidade.pvDal = dal;
                    blContabilidade.pvContabilidadeDal = new PedidoVendaContabilidadeDAL();
                    blContabilidade.GeraContabilidadeVenda(p.IdPedidoVenda);

                    LimpaControles();
                    tabControl1.SelectedIndex = 0;
                    p = new PedidoVendaItem();
                    p.IdPedidoVenda = IdPedidoVenda;
                    p.IdPedidoVendaItem = 0;
                    if (p.IdPedidoVendaItem == 0)
                    {
                        PedidoVenda pc = new PedidoVendaDAL().PVRepository.GetByID(p.IdPedidoVenda);
                        if (pc != null)
                        {
                            cboGrupoImposto.SelectedValue = pc.IdGrupoImposto == null ? 0 : pc.IdGrupoImposto;
                            cboGrupoImpostoRetido.SelectedValue = pc.IdGrupoImpostoRetido == null ? 0 : pc.IdGrupoImpostoRetido;
                            cboArmazem.SelectedValue = pc.IdArmazem == null ? 0 : pc.IdArmazem;
                            p.TipoOrdem = pc.TipoOrdem == null ? 0 : pc.TipoOrdem;
                            cboDeposito.SelectedValue = pc.IdDeposito == null ? 0 : pc.IdDeposito; 
                        }
                    }
                    CalculaValorTotalPedido();
                    //if(IdCFOP != null && IdCFOP > 0)
                    //{
                    //    cboCFOP.SelectedValue = IdCFOP;
                    //}
                }
                else
                {
                    Util.Aplicacao.ShowMessage("Por favor verifique as informações faltantes.");
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void ExcluirCentroCusto()
        {            
            PedidoVendaItemCentroCustoDAL pvccDal = new PedidoVendaItemCentroCustoDAL();
            var lista = pvccDal.GetIdsPedidoVendasItemCentroCusto(p.IdPedidoVendaItem);
            if (lista != null && lista.Count > 0)
            {
                foreach (var item in lista)
                {
                    pvccDal.Delete(item);
                    pvccDal.Save();
                }
            }
        }

        private void ImportaCentroCusto()
        {
            //Importa o centro de custo do produto, caso produto não tenha
            //centro de custo cadastrado, importar o centro de custo do pedido de vendas

            PedidoVendaItemCentroCusto pvicc = new PedidoVendaItemCentroCusto();
            PedidoVendaItemCentroCustoDAL pviccDal = new PedidoVendaItemCentroCustoDAL();

            //importa do produto.
            ProdutoCentroCustoDAL prDal = new ProdutoCentroCustoDAL();
            var lista = prDal.GetValoresCadastrados(Convert.ToInt32(cboProduto.SelectedValue));

            if (lista != null && lista.Count > 0)
            {
                
                foreach (var item in lista)
                {
                    pvicc.IdPedidoVendaItem = p.IdPedidoVendaItem;
                    pvicc.IdValoresCentroCusto = item.Value;

                    pviccDal.Insert(pvicc);
                    pviccDal.Save();
                }
            }
            else
            {
                //importa do pedido de venda.
                PedidoVendaCentroCustoDAL pedDal = new PedidoVendaCentroCustoDAL();
                var listapedido = pedDal.GetValoresCadastrados(p.IdPedidoVenda);
                
                if(listapedido != null && listapedido.Count > 0)
                {
                    foreach (var item in listapedido)
                    {
                        pvicc.IdPedidoVendaItem = p.IdPedidoVendaItem;
                        pvicc.IdValoresCentroCusto = item.Value;

                        pviccDal.Insert(pvicc);
                        pviccDal.Save();
                    }
                }
            }            
        }

        private void cboProduto_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboProduto.Text))
            {
                //Produto pr = new ProdutoDAL().ProdutoRepository.GetByID(Convert.ToInt32(cboProduto.SelectedValue));
                //if (pr != null)
                //{
                //    cboUnidade.SelectedValue = pr.VendaIdUnidade == null ? 0 : pr.VendaIdUnidade;
                //    cboCodigoServico.SelectedValue = pr.FiscalIdCodigoServico == null ? 0 : pr.FiscalIdCodigoServico;
                //    txtPesoUnitario.Text = pr.EstoquePeso.ToString();

                //    cboVariantesConfig.SelectedValue = pr.IdVariantesConfig == null ? 0 : pr.IdVariantesConfig;

                //    cboEstilo.SelectedValue = pr.IdVariantesEstilo == null ? 0 : pr.IdVariantesEstilo;
                //    cboCor.SelectedValue = pr.IdVariantesCor == null ? 0 : pr.IdVariantesCor;
                //    cboTamanho.SelectedValue = pr.IdVariantesTamanho == null ? 0 : pr.IdVariantesTamanho;

                //    if (pr.VendaIdGrupoImposto != null)
                //        cboGrupoImposto.SelectedValue = pr.VendaIdGrupoImposto;

                //    if (pr.VendaGrupoImpostoRetido != null)
                //        cboGrupoImpostoRetido.SelectedValue = pr.VendaGrupoImpostoRetido;

                //   // if (pr.VendaIdGrupoEncargos != null)
                //   //     cboGrupoEncargos.SelectedValue = pr.VendaIdGrupoEncargos;

                //   // if (pr.VendaIdGrupoDesconto != null)
                //   //     cboGrupoDescontos.SelectedValue = pr.VendaIdGrupoDesconto;


                //    cboGrupoLotes.SelectedValue = pr.EstoqueIdGrupoLotes == null ? 0 : pr.EstoqueIdGrupoLotes;
                //    cboGrupoSeries.SelectedValue = pr.EstoqueIdGrupoSeries == null ? 0 : pr.EstoqueIdGrupoSeries;
                //    cboNCM.SelectedValue = pr.FiscalIdNCM == null ? 0 : pr.FiscalIdNCM;

                //    //procura codigo externo
                //    PedidoVenda pv = new PedidoVendaDAL().PVRepository.GetByID(p.IdPedidoVenda);

                //    IdCliente = pv.IdCliente;

                //    cboCodigoExternoCliente.DataSource = new CodigoProdutoExternoDAL().GetCombo(Convert.ToInt32(pv.IdCliente), p.IdProduto);
                //    cboCodigoExternoCliente.DisplayMember = "Text";
                //    cboCodigoExternoCliente.ValueMember = "iValue";
                //    cboCodigoExternoCliente.SelectedIndex = -1;

                //    // Verifica Contrato Comercial //
                //    ContratoComercialFluxoPrecoModelView cc = ccDal.ContratoComercialFluxoPrecoVendas(pv.IdEmpresa.ToString(), pr.IdProduto.ToString(), IdCliente.ToString(), pv.IdPedidoVenda, p.IdVariantesCor, p.IdVariantesEstilo, p.IdVariantesTamanho, p.IdVariantesConfig);
                //    if (cc.ExisteContrato)
                //    {
                //        txtPrecoUnitario.Text = cc.Valor.ToString("N4");
                //        txtDescontoPercentual.Text = cc.PercentualDesconto.ToString("N4");
                //        txtDescontoValor.Text = cc.ValorDesconto.ToString("N4");
                //    }
                //}
            }
        }

        private void txtPrecoUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            //{
            //    if (Regex.IsMatch(txtPrecoUnitario.Text, "^\\d*\\,\\d{2}$"))
            //        e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = e.KeyChar != (char)Keys.Back;
            //}
        }

        private void txtDescontoPercentual_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            //{
            //    if (Regex.IsMatch(txtDescontoPercentual.Text, "^\\d*\\,\\d{4}$"))
            //        e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = e.KeyChar != (char)Keys.Back;
            //}
        }

        private void txtDescontoValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            //{
            //    if (Regex.IsMatch(txtDescontoValor.Text, "^\\d*\\,\\d{4}$"))
            //        e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = e.KeyChar != (char)Keys.Back;
            //}
        }

        private void txtIPI_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            //{
            //    if (Regex.IsMatch(txtIPI.Text, "^\\d*\\,\\d{4}$"))
            //        e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = e.KeyChar != (char)Keys.Back;
            //}
        }

        private void txtValorLiquido_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            //{
            //    if (Regex.IsMatch(txtValorLiquido.Text, "^\\d*\\,\\d{4}$"))
            //        e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = e.KeyChar != (char)Keys.Back;
            //}
        }

        private void txtValorEncargos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            //{
            //    if (Regex.IsMatch(txtValorEncargos.Text, "^\\d*\\,\\d{4}$"))
            //        e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = e.KeyChar != (char)Keys.Back;
            //}
        }

        private void txtPesoUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            //{
            //    if (Regex.IsMatch(txtPesoUnitario.Text, "^\\d*\\,\\d{4}$"))
            //        e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = e.KeyChar != (char)Keys.Back;
            //}
        }

        private void CarregaDados()
        {
            idCodProduto = p.IdProduto;
            cboProduto.SelectedValue = p.IdProduto;
            txtQuantidade.Text = p.Quantidade.ToString(CasasDecimais);
            cboUnidade.SelectedValue = p.IdUnidade == null ? 0 : p.IdUnidade;
            txtPrecoTabela.Text = p.PrecoTabela.ToString(CasasDecimais);
            txtPrecoUnitario.Text = p.PrecoUnitario.ToString(CasasDecimais);
            //txtIPI.Text = p.Ipi.ToString();
            txtDescontoPercentual.Text = p.DescontoPercentual.ToString(CasasDecimais);
            txtDescontoValor.Text = p.DescontoValor.ToString(CasasDecimais);
            txtDescVarejista.Text = p.DescontoVarejista.ToString(CasasDecimais);
            txtValorEncargos.Text = p.ValorEncargos.ToString(CasasDecimais);
            txtValorLiquido.Text = p.ValorLiquido.ToString(CasasDecimais);
            //cboCFOP.SelectedValue = p.IdCFOP == null ? 0 : p.IdCFOP;

            CFOP cfop = new CFOPDAL().GetByID(p.IdCFOP == null ? 0 : Convert.ToInt32(p.IdCFOP));

            cboCodigoServico.SelectedValue = p.IdCodigoServico == null ? 0 : p.IdCodigoServico;

            cboVariantesConfig.SelectedValue = p.IdVariantesConfig == null ? 0 : p.IdVariantesConfig;
            cboEstilo.SelectedValue = p.IdVariantesEstilo == null ? 0 : p.IdVariantesEstilo;
            cboCor.SelectedValue = p.IdVariantesCor == null ? 0 : p.IdVariantesCor;
            cboTamanho.SelectedValue = p.IdVariantesTamanho == null ? 0 : p.IdVariantesTamanho;
            cboGrupoLotes.SelectedValue = p.IdGrupoLotes == null ? 0 : p.IdGrupoLotes;
            cboGrupoSeries.SelectedValue = p.IdGrupoSeries == null ? 0 : p.IdGrupoSeries;
            cboArmazem.SelectedValue = p.IdArmazem == null ? 0 : p.IdArmazem;
            cboDeposito.SelectedValue = p.IdDeposito == null ? 0 : p.IdDeposito;
            cboLocalizacao.SelectedValue = p.IdLocalizacao == null ? 0 : p.IdLocalizacao;
            cboCodigoExternoCliente.SelectedValue = p.IdCodigoExternoCliente == null ? 0 : p.IdCodigoExternoCliente;
            chkAtivoFixo.Checked = Convert.ToBoolean(p.AtivoFixo);
            cboGrupoAtivo.SelectedValue = p.IdGrupoAtivo == null ? 0 : p.IdGrupoAtivo;
            cboMetodoPreciacao.SelectedValue = p.IdMetodoDepreciacao == null ? 0 : p.IdMetodoDepreciacao;
            cboAtivoFixo.SelectedValue = p.IdAtivoFixo == null ? 0 : p.IdAtivoFixo;
            cboTipoTransacaoAtivo.SelectedValue = p.TipoTransacaoAtivo == null ? 0 : p.TipoTransacaoAtivo;
            cboGrupoImposto.SelectedValue = p.IdGrupoImposto == null ? 0 : p.IdGrupoImposto;
            cboGrupoImpostoItem.SelectedValue = p.IdGrupoImpostosItem == null ? 0 : p.IdGrupoImpostosItem;
            cboGrupoImpostoRetido.SelectedValue = p.IdGrupoImpostoRetido == null ? 0 : p.IdGrupoImpostoRetido;
            cboNCM.SelectedValue = p.IdNCM == null ? 0 : p.IdNCM;

            Produto pro = new ProdutoDAL().GetByID(p.IdProduto);
            if(p.IdCest !=null)
                cboCest.SelectedValue = p.IdCest == null ? 0 : p.IdCest;
            else
                cboCest.SelectedValue = pro.IdCest == null ? 0 : pro.IdCest;
            

            //cboGrupoEncargos.SelectedValue = p.IdGrupoEncargos == null ? 0 : p.IdGrupoEncargos;
            //cboGrupoDescontos.SelectedValue = p.IdGrupoDescontos == null ? 0 : p.IdGrupoDescontos;
            txtPesoUnitario.Text = p.PesoUnitario.ToString(CasasDecimais);
            
            CarregaNovoItem();
        }

        private void CarregaNovoItem()
        {
            if (p.IdPedidoVendaItem == 0)
            {
                PedidoVenda pc = new PedidoVendaDAL().PVRepository.GetByID(p.IdPedidoVenda);
                if (pc != null)
                {
                    cboGrupoImposto.SelectedValue = pc.IdGrupoImposto == null ? 0 : pc.IdGrupoImposto;
                    cboGrupoImpostoRetido.SelectedValue = pc.IdGrupoImpostoRetido == null ? 0 : pc.IdGrupoImpostoRetido;
                    cboArmazem.SelectedValue = pc.IdArmazem == null ? 0 : pc.IdArmazem;
                    p.TipoOrdem = pc.TipoOrdem == null ? 0 : pc.TipoOrdem;
                    cboDeposito.SelectedValue = pc.IdDeposito == null ? 0 : pc.IdDeposito;
                    // cboGrupoEncargos.SelectedValue = pc.IdGrupoEncargos == null ? 0 : pc.IdGrupoEncargos;
                    // cboGrupoDescontos.SelectedValue = pc.IdGrupoDesconto == null ? 0 : pc.IdGrupoDesconto;
                    BuscaProduto();
                    tabControl1.Focus();
                    tabPage1.Focus();
                    txtQuantidade.Focus();
                }
            }
        }

        private void CarregaCombos()
        {
            #region Produto
            cboProduto.DataSource = new ProdutoDAL().GetComboVendas();
            cboProduto.DisplayMember = "Text";
            cboProduto.ValueMember = "iValue";
            cboProduto.SelectedIndex = -1;

            cboUnidade.DataSource = new UnidadeDAL().GetCombo();
            cboUnidade.DisplayMember = "Text";
            cboUnidade.ValueMember = "iValue";
            cboUnidade.SelectedIndex = -1;

            CarregaValidaCFOP();

            cboNCM.DataSource = new ClassificacaoFiscalDAL().GetCombo();
            cboNCM.DisplayMember = "Text";
            cboNCM.ValueMember = "iValue";
            cboNCM.SelectedIndex = -1;

            cboCodigoServico.DataSource = new CodigoServicoDAL().GetCombo();
            cboCodigoServico.DisplayMember = "Text";
            cboCodigoServico.ValueMember = "iValue";
            cboCodigoServico.SelectedIndex = -1;

            cboVariantesConfig.DataSource = new VariantesConfigDAL().Get();
            cboVariantesConfig.ValueMember = "IdVariantesConfig";
            cboVariantesConfig.DisplayMember = "Descricao";
            cboVariantesConfig.SelectedIndex = -1;

            cboEstilo.DataSource = new VariantesEstiloDAL().GetCombo();
            cboEstilo.DisplayMember = "Text";
            cboEstilo.ValueMember = "iValue";
            cboEstilo.SelectedIndex = -1;

            cboCor.DataSource = new VariantesCorDAL().GetCombo();
            cboCor.DisplayMember = "Text";
            cboCor.ValueMember = "iValue";
            cboCor.SelectedIndex = -1;

            cboTamanho.DataSource = new VariantesTamanhoDAL().GetCombo();
            cboTamanho.DisplayMember = "Text";
            cboTamanho.ValueMember = "iValue";
            cboTamanho.SelectedIndex = -1;
            #endregion

            #region Estoque
            cboGrupoLotes.DataSource = new GrupoLotesDAL().GetCombo();
            cboGrupoLotes.DisplayMember = "Text";
            cboGrupoLotes.ValueMember = "iValue";
            cboGrupoLotes.SelectedIndex = -1;

            cboGrupoSeries.DataSource = new GrupoSeriesDAL().GetCombo();
            cboGrupoSeries.DisplayMember = "Text";
            cboGrupoSeries.ValueMember = "iValue";
            cboGrupoSeries.SelectedIndex = -1;

            cboArmazem.DataSource = new ArmazemDAL().GetCombo();
            cboArmazem.DisplayMember = "Text";
            cboArmazem.ValueMember = "iValue";
            cboArmazem.SelectedIndex = -1;

            cboDeposito.DataSource = new DepositoDAL().GetCombo();
            cboDeposito.DisplayMember = "Text";
            cboDeposito.ValueMember = "iValue";
            cboDeposito.SelectedIndex = -1;

            cboLocalizacao.DataSource = new LocalizacaoDAL().GetCombo();
            cboLocalizacao.DisplayMember = "Text";
            cboLocalizacao.ValueMember = "iValue";
            cboLocalizacao.SelectedIndex = -1;
            #endregion

            #region Ativo
            cboGrupoAtivo.DataSource = new GrupoAtivoDAL().GetCombo();
            cboGrupoAtivo.DisplayMember = "Text";
            cboGrupoAtivo.ValueMember = "iValue";
            cboGrupoAtivo.SelectedIndex = -1;

            cboMetodoPreciacao.DataSource = new MetodoDepreciacaoDAL().GetCombo();
            cboMetodoPreciacao.DisplayMember = "Text";
            cboMetodoPreciacao.ValueMember = "iValue";
            cboMetodoPreciacao.SelectedIndex = -1;

            cboAtivoFixo.DataSource = new AtivoImobilizadoDAL().GetCombo();
            cboAtivoFixo.DisplayMember = "Text";
            cboAtivoFixo.ValueMember = "iValue";
            cboAtivoFixo.SelectedIndex = -1;

            List<ComboItem> TpTransacaoAtivo = new List<ComboItem>();
            TpTransacaoAtivo.Add(new ComboItem() { iValue = 1, Text = "Venda" });
            TpTransacaoAtivo.Add(new ComboItem() { iValue = 2, Text = "Empréstimo" });
            TpTransacaoAtivo.Add(new ComboItem() { iValue = 3, Text = "Conserto" });
            TpTransacaoAtivo.Add(new ComboItem() { iValue = 3, Text = "Locação" });
            cboTipoTransacaoAtivo.DataSource = TpTransacaoAtivo;
            cboTipoTransacaoAtivo.DisplayMember = "Text";
            cboTipoTransacaoAtivo.ValueMember = "iValue";
            cboTipoTransacaoAtivo.SelectedIndex = -1;
            #endregion

            #region Configuracoes
            cboGrupoImposto.DataSource = new GrupoImpostoDAL().getCombo();
            cboGrupoImposto.DisplayMember = "Text";
            cboGrupoImposto.ValueMember = "iValue";
            cboGrupoImposto.SelectedIndex = -1;

            cboGrupoImpostoItem.DataSource = new GrupoImpostoItemDAL().GetCombo();
            cboGrupoImpostoItem.DisplayMember = "Text";
            cboGrupoImpostoItem.ValueMember = "iValue";
            cboGrupoImpostoItem.SelectedIndex = -1;

            cboGrupoImpostoRetido.DataSource = new GrupoImpostoRetidoDAL().GetCombo();
            cboGrupoImpostoRetido.DisplayMember = "Text";
            cboGrupoImpostoRetido.ValueMember = "iValue";
            cboGrupoImpostoRetido.SelectedIndex = -1;

            cboGrupoImpostoItemRetido.DataSource = new GrupoImpostoRetidoDAL().GetCombo();
            cboGrupoImpostoItemRetido.DisplayMember = "Text";
            cboGrupoImpostoItemRetido.ValueMember = "iValue";
            cboGrupoImpostoItemRetido.SelectedIndex = -1;

            //cboGrupoEncargos.DataSource = new GrupoEncargosDAL().getCombo();
            //cboGrupoEncargos.DisplayMember = "Text";
            //cboGrupoEncargos.ValueMember = "iValue";
            //cboGrupoEncargos.SelectedIndex = -1;

            //cboGrupoDescontos.DataSource = new GrupoDescontosDAL().GetCombo();
            //cboGrupoDescontos.DisplayMember = "Text";
            //cboGrupoDescontos.ValueMember = "iValue";
            //cboGrupoDescontos.SelectedIndex = -1;
            #endregion

            CarregaCentrosdeCusto();

            CarregaCest();
        }

        private void CarregaValidaCFOP()
        {
            PedidoVendaDAL ped = new PedidoVendaDAL();
            var pedidovenda = ped.PVRepository.GetByID(p.IdPedidoVenda);

            var idOperacao = pedidovenda.IdOperacao == null ? 0 : (int)pedidovenda.IdOperacao;

            var ope = new OperacaoDAL().GetByID(idOperacao);
            //if(ope != null)
            //{
            //    if (ope.IdTipoDirecaoNF == 3 && ope.IdDirecaoNF == 2)//Somente os CFOP com inicio 5,6,7
            //    {
            //        cboCFOP.DataSource = new CFOPDAL().GetComboValido(new[] { "5.", "6.", "7." });
            //        cboCFOP.DisplayMember = "Text";
            //        cboCFOP.ValueMember = "iValue";
            //        cboCFOP.SelectedIndex = -1;
            //    }
            //    else if (ope.IdTipoDirecaoNF == 4 && ope.IdDirecaoNF == 1)//Somente os CFOP com inicio 1, 2, 3
            //    {
            //        cboCFOP.DataSource = new CFOPDAL().GetComboValido(new[] { "1.", "2.", "3." });
            //        cboCFOP.DisplayMember = "Text";
            //        cboCFOP.ValueMember = "iValue";
            //        cboCFOP.SelectedIndex = -1;
            //    }
            //    else
            //    {
            //        cboCFOP.DataSource = new CFOPDAL().GetCombo();
            //        cboCFOP.DisplayMember = "Text";
            //        cboCFOP.ValueMember = "iValue";
            //        cboCFOP.SelectedIndex = -1;
            //    }
            //}
            
        }

        protected void CarregaCentrosdeCusto()
        {
            var lista = pvDal.GetByPedidoVendaItem(p.IdPedidoVendaItem);
            dgCentros.AutoGenerateColumns = false;
            dgCentros.DataSource = lista;
        }

        protected void CarregaCest()
        {
            cboCest.DataSource = new CESTDAL().GetCombo();
            cboCest.ValueMember = "iValue";
            cboCest.DisplayMember = "Text";
            cboCest.SelectedIndex = -1;
        }

        private void LimpaControles()
        {
            cboProduto.Text = "";
            cboProduto.SelectedValue = 0;
            txtQuantidade.Text = "";
            cboUnidade.Text = "";
            cboUnidade.SelectedValue = 0;
            txtPrecoTabela.Text = "0,00";
            txtPrecoUnitario.Text = "0,00";
           // txtIPI.Text = "";
            txtDescontoPercentual.Text = "0,00";
            txtDescontoValor.Text = "0,00";
            txtValorEncargos.Text = "0,00";
            txtValorLiquido.Text = "0,00";
            //cboCFOP.Text = "";
            //cboCFOP.SelectedValue = 0;

            cboCodigoServico.Text = "";
            cboCodigoServico.SelectedValue = 0;

            cboVariantesConfig.Text = "";
            cboEstilo.Text = "";
            cboCor.Text = "";
            cboTamanho.Text = "";
            cboGrupoLotes.Text = "";
            cboGrupoSeries.Text = "";
            cboArmazem.Text = "";
            cboDeposito.Text = "";
            cboLocalizacao.Text = "";
            cboCodigoExternoCliente.Text = "";

            cboVariantesConfig.SelectedValue = 0;
            cboEstilo.SelectedValue = 0;
            cboCor.SelectedValue = 0;
            cboTamanho.SelectedValue = 0;
            cboGrupoLotes.SelectedValue = 0;
            cboGrupoSeries.SelectedValue = 0;
            cboArmazem.SelectedValue = 0;
            cboDeposito.SelectedValue = 0;
            cboLocalizacao.SelectedValue = 0;
            cboCodigoExternoCliente.SelectedValue = 0;

            chkAtivoFixo.Checked = false;
            cboGrupoAtivo.Text = "";
            cboMetodoPreciacao.Text = "";
            cboAtivoFixo.Text = "";
            cboTipoTransacaoAtivo.Text = "";
            cboGrupoImposto.Text = "";
            cboGrupoImpostoItem.Text = "";
            cboGrupoImpostoRetido.Text = "";
            cboNCM.Text = "";
            cboCest.Text = "";
            cboGrupoAtivo.SelectedValue = 0;
            cboMetodoPreciacao.SelectedValue = 0;
            cboAtivoFixo.SelectedValue = 0;
            cboTipoTransacaoAtivo.SelectedValue = 0;
            cboGrupoImposto.SelectedValue = 0;
            cboGrupoImpostoItem.SelectedValue = 0;
            cboGrupoImpostoRetido.SelectedValue = 0;
            cboNCM.SelectedValue = 0;
            cboCest.SelectedValue = 0;
            txtDescVarejista.Text = "0,00";
            //cboGrupoEncargos.Text = "";
            //cboGrupoDescontos.Text = "";
            txtPesoUnitario.Text = "0,00";
            Valor = 0;
            AlterouPreco = false;
        }

        private bool ValidaCampos()
        {
            bool ok = true;
            if (cboProduto.Text == "") ok = false;
           // if (txtIPI.Text == "") ok = false;
            if (txtPrecoUnitario.Text == "") ok = false;
            if (txtQuantidade.Text == "") ok = false;
            return ok;
        }

        private void tsbAddCentroCusto_Click(object sender, EventArgs e)
        {
            if (p.IdPedidoVendaItem == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados dos itens do pedido de venda antes de adicionar centros de custo.");
                return;
            }
            frmCentroCustoAux frmCC = new frmCentroCustoAux("PVI", p.IdPedidoVendaItem);
            frmCC.pvidal = pvDal;
            frmCC.ShowDialog();
            CarregaCentrosdeCusto();
        }

        private void tsbExcluirCentroCusto_Click(object sender, EventArgs e)
        {
            if (dgCentros.Rows.Count > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir o centro de custo selecionado?") == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgCentros.Rows[dgCentros.SelectedRows[0].Index].Cells[0].Value);
                    try
                    {
                        pvDal.Delete(id);
                        pvDal.Save();
                        CarregaCentrosdeCusto();
                    }
                    catch (Exception ex)
                    {
                        Util.Aplicacao.ShowErrorMessage(ex);
                    }
                }
            }
        }

        private void BuscaProduto()
        {
            using (frmBuscaProduto frmBusca = new frmBuscaProduto())
            {
                frmBusca.ShowDialog();
                if (frmBusca.ProdutoSelecionado != null)
                {
                    Produto pr = new ProdutoDAL().ProdutoRepository.GetByID(frmBusca.ProdutoSelecionado.IdProduto);
                    if (pr != null)
                    {
                        p.IdProduto = pr.IdProduto;
                        cboProduto.SelectedValue = pr.IdProduto;
                        cboUnidade.SelectedValue = pr.VendaIdUnidade == null ? 0 : pr.VendaIdUnidade;
                        cboCodigoServico.SelectedValue = pr.FiscalIdCodigoServico == null ? 0 : pr.FiscalIdCodigoServico;
                        txtPesoUnitario.Text = Convert.ToDecimal(pr.EstoquePeso).ToString(CasasDecimais);

                        cboVariantesConfig.SelectedValue = frmBusca.ProdutoSelecionado.IdVariantesConfig == null ? 0 : frmBusca.ProdutoSelecionado.IdVariantesConfig;
                        p.IdVariantesConfig = frmBusca.ProdutoSelecionado.IdVariantesConfig;
                        cboEstilo.SelectedValue = frmBusca.ProdutoSelecionado.IdVariantesEstilo == null ? 0 : frmBusca.ProdutoSelecionado.IdVariantesEstilo;
                        p.IdVariantesEstilo = frmBusca.ProdutoSelecionado.IdVariantesEstilo;
                        cboCor.SelectedValue = frmBusca.ProdutoSelecionado.IdVariantesCor == null ? 0 : frmBusca.ProdutoSelecionado.IdVariantesCor;
                        p.IdVariantesCor = frmBusca.ProdutoSelecionado.IdVariantesCor;
                        cboTamanho.SelectedValue = frmBusca.ProdutoSelecionado.IdVariantesTamanho == null ? 0 : frmBusca.ProdutoSelecionado.IdVariantesTamanho;
                        p.IdVariantesTamanho = frmBusca.ProdutoSelecionado.IdVariantesTamanho;

                        if (pr.VendaIdGrupoImposto != null)
                            cboGrupoImpostoItem.SelectedValue = pr.VendaIdGrupoImposto;

                        if (pr.VendaGrupoImpostoRetido != null)
                            cboGrupoImpostoRetido.SelectedValue = pr.VendaGrupoImpostoRetido;

                        //if (pr.IdTipoProduto == 1)//item
                        //{
                        //    cboCFOP.Tag = "1";
                        //}
                        //else
                        //{
                        //    cboCFOP.Tag = "";
                        //}

                        // if (pr.VendaIdGrupoEncargos != null)
                        //     cboGrupoEncargos.SelectedValue = pr.VendaIdGrupoEncargos;

                        //  if (pr.VendaIdGrupoDesconto != null)
                        //      cboGrupoDescontos.SelectedValue = pr.VendaIdGrupoDesconto;

                        cboGrupoImpostoItem.SelectedValue = pr.VendaIdGrupoImposto == null ? 0 : pr.VendaIdGrupoImposto;
                        cboGrupoLotes.SelectedValue = pr.EstoqueIdGrupoLotes == null ? 0 : pr.EstoqueIdGrupoLotes;
                        cboGrupoSeries.SelectedValue = pr.EstoqueIdGrupoSeries == null ? 0 : pr.EstoqueIdGrupoSeries;
                        cboNCM.SelectedValue = pr.FiscalIdNCM == null ? 0 : pr.FiscalIdNCM;
                        cboCest.SelectedValue = pr.IdCest == null ? 0 : pr.IdCest;
                        //cboCFOP.SelectedValue = IdCFOP;
                        //procura codigo externo
                        PedidoVenda pv = new PedidoVendaDAL().PVRepository.GetByID(p.IdPedidoVenda);

                        IdCliente = pv.IdCliente;

                        p.IdGrupoEncargos = new ClienteDAL().CRepository.GetByID(IdCliente).IdGrupoEncargos;

                        cboCodigoExternoCliente.DataSource = new CodigoProdutoExternoDAL().GetCombo(Convert.ToInt32(pv.IdCliente), p.IdProduto);
                        cboCodigoExternoCliente.DisplayMember = "Text";
                        cboCodigoExternoCliente.ValueMember = "iValue";
                        cboCodigoExternoCliente.SelectedIndex = -1;

                        // Verifica Contrato Comercial //
                        ContratoComercialFluxoPrecoModelView cc = ccDal.ContratoComercialFluxoPrecoVendas(pv.IdEmpresa.ToString(), pr.IdProduto.ToString(), IdCliente.ToString(), pv.IdPedidoVenda, p.IdVariantesCor, p.IdVariantesEstilo, p.IdVariantesTamanho, p.IdVariantesConfig, null, true);
                        if (cc.ExisteContrato)
                        {
                            txtPrecoTabela.Text = cc.ValorTabela.ToString(CasasDecimais);
                            txtPrecoUnitario.Text = cc.Valor.ToString(CasasDecimais);
                            Valor = cc.Valor;
                            txtDescontoPercentual.Text = cc.PercentualDesconto.ToString(CasasDecimais);
                            txtDescontoValor.Text = cc.ValorDesconto.ToString(CasasDecimais);
                            p.ValorOriginal = cc.ValorOriginal;
                            p.JurosCondicaoPagamento = cc.Juros; 
                            txtDescVarejista.Text = cc.ValorDescontoVarejista.ToString(CasasDecimais);
                        }
                    }
                }
            }
            txtQuantidade.Focus();
        }

        private void RecalculaValorContratoComercial()
        {
            //decimal? Valor = null;
            //if(!String.IsNullOrEmpty(txtPrecoUnitario.Text))
            //{
            //    Valor = Convert.ToDecimal(txtPrecoUnitario.Text);
            //} 
            decimal DescontoVarejista = String.IsNullOrEmpty(txtDescVarejista.Text) ? 0 : Convert.ToDecimal(txtDescVarejista.Text);
            ContratoComercialFluxoPrecoModelView cc = ccDal.ContratoComercialFluxoPrecoVendas(Util.Util.GetAppSettings("IdEmpresa"), p.IdProduto.ToString(), IdCliente.ToString(), p.IdPedidoVenda, p.IdVariantesCor, p.IdVariantesEstilo, p.IdVariantesTamanho, p.IdVariantesConfig, Valor, AlterouPreco, DescontoVarejista);//Envia o valor caso o valor do produto tenha sido alterado
            if (cc.ExisteContrato)
            {
                //txtPrecoTabela.Text = cc.ValorTabela.ToString("N4");
                txtPrecoUnitario.Text = cc.Valor.ToString(CasasDecimais);
                if (Valor == 0) Valor = cc.Valor;
                txtDescontoPercentual.Text = cc.PercentualDesconto.ToString(CasasDecimais);
                txtDescontoValor.Text = cc.ValorDesconto.ToString(CasasDecimais);
                p.ValorOriginal = cc.ValorOriginal;
                //p.JurosCondicaoPagamento = cc.Juros;
                txtDescVarejista.Text = cc.ValorDescontoVarejista.ToString(CasasDecimais);
            }
            AlterouPreco = false;
        }

        private void btnBuscaProduto_Click(object sender, EventArgs e)
        {
            BuscaProduto();
        }

        private void txtPrecoUnitario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Valor > 0 && Valor != Convert.ToDecimal(txtPrecoUnitario.Text))
                {
                    AlterouPreco = true;
                }
            }
            catch  
            { 
            }
            
            
            CalcularValorLiquido();
        }

        private void txtDescontoPercentual_TextChanged(object sender, EventArgs e)
        {
            CalcularValorLiquido();
        }

        private void txtDescontoValor_TextChanged(object sender, EventArgs e)
        {
            CalcularValorLiquido();
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            CalcularValorLiquido();
        }

        private void CalcularValorLiquido()
        {
            decimal lPrecoUnitario = 0;
            decimal lDescontoPercentual = 0;
            decimal lDescontoValor = 0;
            decimal lValorDescontoPercentual = 0;
            decimal lQuantidade = 0;
            decimal lValorLiquido = 0;

            if (!string.IsNullOrEmpty(txtQuantidade.Text))
            {
                lQuantidade = Convert.ToDecimal(txtQuantidade.Text);
            }

            if (!string.IsNullOrEmpty(txtPrecoUnitario.Text))
            {
                lPrecoUnitario = Convert.ToDecimal(txtPrecoUnitario.Text);
            }

            if (!string.IsNullOrEmpty(txtDescontoPercentual.Text))
            {
                lDescontoPercentual = Convert.ToDecimal(txtDescontoPercentual.Text);
                if (lDescontoPercentual > 0)
                {
                    lValorDescontoPercentual = lQuantidade * lPrecoUnitario * (lDescontoPercentual / 100);
                }
            }

            if (!string.IsNullOrEmpty(txtDescontoValor.Text))
            {
                lDescontoValor = Convert.ToDecimal(txtDescontoValor.Text);
            }

            lValorLiquido = ((lQuantidade * lPrecoUnitario) - (lValorDescontoPercentual + lDescontoValor));
            if (lValorLiquido <= 0)
            {
                lValorLiquido = 0;
            }

            txtValorLiquido.Text = lValorLiquido.ToString(CasasDecimais);
        }

        private void txtPrecoUnitario_Leave(object sender, EventArgs e)
        {
            //Efetua o recalculo com o valor mostrado em tela.
            Valor = Convert.ToDecimal(txtPrecoUnitario.Text);
            RecalculaValorContratoComercial();
        }

        private void cboNCM_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboNCM.Text))
            {
                if(String.IsNullOrEmpty(cboCest.Text))
                {
                    int IdNCM = Convert.ToInt32(cboNCM.SelectedValue);
                    ClassificacaoFiscal cl = new ClassificacaoFiscal();
                    cl = new ClassificacaoFiscalDAL().GetByID(IdNCM);
                    cboCest.SelectedValue = cl.IdCest == null ? 0 : cl.IdCest;
                }
                

            }
        }

        private void CalculaValorTotalPedido()
        {
            PedidosTotaisModelView totais = dal.getTotaisPedido(p.IdPedidoVenda);
            lbValorTotal.Text = "Valor total das mercadorias: R$ " + totais.TotalProdutos.ToString("N2");
        }
    }
}
