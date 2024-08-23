using ERP.Auxiliares;
using ERP.BLL;
using ERP.DAL;
using ERP.DAL.Cadastros;
using ERP.DAL.Fiscal;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP.Compras
{
    public partial class frmPedidoComprasAddItem : Form
    {
        PedidoCompraDAL dal = new PedidoCompraDAL();
        PedidoCompraItemCentroCustoDAL pcDal = new PedidoCompraItemCentroCustoDAL();
        ContratoComercialDAL ccDal = new ContratoComercialDAL();
        public PedidoCompraItemApuracaoImpostoDAL impostoDal;
        PedidoCompraItem p = new PedidoCompraItem();
        PedidoCompraContabilidadeDAL contabilidadeDal = new PedidoCompraContabilidadeDAL();
        BLContabilidade blContabilidade = new BLContabilidade();

        int idCodProduto = 0;
        int IdPedidoCompra = 0;
        int IdFornecedor = 0;

        public frmPedidoComprasAddItem(PedidoCompraDAL pDal, PedidoCompraItem pedidoItem)
        {
            dal = pDal;
            p = pedidoItem;
            IdPedidoCompra = p.IdPedidoCompra;
            InitializeComponent();
        }

        private void frmPedidoComprasAddItem_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            if (p.IdPedidoCompraItem != 0)
            {
                CarregaDados();
            }
            else
            {
                CarregaNovoItem();
            }

            cboProduto.Focus();
        }

        private bool ValidaCampos()
        {
            bool ok = true;
            if (cboProduto.Text == "") ok = false;
            //if (txtIPI.Text == "") ok = false;
            if (txtPrecoUnitario.Text == "") ok = false;
            if (txtQuantidade.Text == "") ok = false;
            return ok;
        }

        private void CarregaDados()
        {
            idCodProduto = p.IdProduto;
            cboProduto.SelectedValue = p.IdProduto;
            txtQuantidade.Text = p.Quantidade.ToString();
            cboUnidade.SelectedValue = p.IdUnidade == null ? 0 : p.IdUnidade;
            txtPrecoTabela.Text = p.PrecoTabela.ToString();
            txtPrecoUnitario.Text = p.PrecoUnitario.ToString();
            //txtIPI.Text = p.Ipi.ToString();
            txtDescontoPercentual.Text = p.DescontoPercentual.ToString();
            txtDescontoValor.Text = p.DescontoValor.ToString();
            cboRoyalties.SelectedValue = p.IdRoyalties == null ? 0 : p.IdRoyalties;
            txtValorEncargos.Text = p.ValorEncargos.ToString();
            txtValorLiquido.Text = p.ValorLiquido.ToString();
            cboCFOP.SelectedValue = p.IdCFOP == null ? 0 : p.IdCFOP;

            CFOP cfop = new CFOPDAL().GetByID(p.IdCFOP == null ? 0 : Convert.ToInt32(p.IdCFOP));

            cboCodigoServico.SelectedValue = p.IdCodigoServico == null ? 0 : p.IdCodigoServico;

            //cboTipoOrdem.SelectedValue = p.TipoOrdem == null ? 0 : p.TipoOrdem;
            //chkMovimentaEstoque.Checked = Convert.ToBoolean(p.MovimentaEstoque);

            cboVariantesConfig.SelectedValue = p.IdVariantesConfig == null ? 0 : p.IdVariantesConfig;
            cboEstilo.SelectedValue = p.IdVariantesEstilo == null ? 0 : p.IdVariantesEstilo;
            cboCor.SelectedValue = p.IdVariantesCor == null ? 0 : p.IdVariantesCor;
            cboTamanho.SelectedValue = p.IdVariantesTamanho == null ? 0 : p.IdVariantesTamanho;
            cboGrupoLotes.SelectedValue = p.IdGrupoLotes == null ? 0 : p.IdGrupoLotes;
            cboGrupoSeries.SelectedValue = p.IdGrupoSeries == null ? 0 : p.IdGrupoSeries;
            cboArmazem.SelectedValue = p.IdArmazem == null ? 0 : p.IdArmazem;
            cboDeposito.SelectedValue = p.IdDeposito == null ? 0 : p.IdDeposito;
            cboLocalizacao.SelectedValue = p.IdLocalizacao == null ? 0 : p.IdLocalizacao;
            cboCodigoExterno.SelectedValue = p.IdCodigoExternoFornecedor == null ? 0 : p.IdCodigoExternoFornecedor;
            chkAtivoFixo.Checked = Convert.ToBoolean(p.AtivoFixo);
            cboGrupoAtivo.SelectedValue = p.IdGrupodeAtivo == null ? 0 : p.IdGrupodeAtivo;
            cboMetodoPreciacao.SelectedValue = p.IdMetodoPreciacao == null ? 0 : p.IdMetodoPreciacao;
            cboAtivoFixo.SelectedValue = p.IdAtivoFixo == null ? 0 : p.IdAtivoFixo;
            chkCreditoICMSAtivo.Checked = Convert.ToBoolean(p.CreditoICMSAtivo);
            chkCreditoPisCofins.Checked = Convert.ToBoolean(p.CreditoPisCofins);
            txtParcelaICMS.Text = p.ParcelaICMS.ToString();
            cboTipoTransacaoAtivo.SelectedValue = p.TipoTransacaoAtivo == null ? 0 : p.TipoTransacaoAtivo;
            cboGrupoImposto.SelectedValue = p.IdGrupoImposto == null ? 0 : p.IdGrupoImposto;
            cboGrupoImpostoItem.SelectedValue = p.IdGrupoImpostosItem == null ? 0 : p.IdGrupoImpostosItem;
            cboGrupoImpostoRetido.SelectedValue = p.IdGrupoImpostoRetido == null ? 0 : p.IdGrupoImpostoRetido;
            cboNCM.SelectedValue = p.IdNCM == null ? 0 : p.IdNCM;
            cboGrupoEncargos.SelectedValue = p.IdGrupoEncargos == null ? 0 : p.IdGrupoEncargos;
            cboGrupoDescontos.SelectedValue = p.IdGrupoDescontos == null ? 0 : p.IdGrupoDescontos;
            txtPesoUnitario.Text = p.PesoUnitario.ToString();

            Produto pro = new ProdutoDAL().GetByID(p.IdProduto);
            cboCest.SelectedValue = p.IdCest != null ? p.IdCest : (pro.IdCest == null ? 0 : pro.IdCest);

            //txtOrdemPlanejada.Text = p.IdOrdemPlanejada.ToString();
            //cboPlanoMestre.SelectedValue = p.IdPlanoMestre == null ? 0 : p.IdPlanoMestre;
            //txtOrdemDevolvida.Text = p.IdOrdemDevolvida.ToString();
            //cboStatusLinha.SelectedValue = p.StatusLinha == null ? 0 : p.StatusLinha;

            CarregaNovoItem();
        }

        private void CarregaNovoItem()
        {
            if (p.IdPedidoCompraItem == 0)
            {
                PedidoCompra pc = new PedidoCompraDAL().PCRepository.GetByID(p.IdPedidoCompra);
                if (pc != null)
                {
                    cboGrupoImposto.SelectedValue = pc.IdGrupoImposto == null ? 0 : pc.IdGrupoImposto;
                    cboGrupoImpostoRetido.SelectedValue = pc.IdGrupoImpostoRetido == null ? 0 : pc.IdGrupoImpostoRetido;
                    cboArmazem.SelectedValue = pc.IdArmazem == null ? 0 : pc.IdArmazem;
                    p.TipoOrdem = pc.TipoOrdem == null ? 0 : pc.TipoOrdem;
                    cboDeposito.SelectedValue = pc.IdDeposito == null ? 0 : pc.IdDeposito;
                    cboGrupoEncargos.SelectedValue = pc.IdGrupoEncargos == null ? 0 : pc.IdGrupoEncargos;
                    cboGrupoDescontos.SelectedValue = pc.IdGrupoDesconto == null ? 0 : pc.IdGrupoDesconto;
                    cboRoyalties.SelectedValue = pc.IdRoyalties == null ? 0 : pc.IdRoyalties;
                }
            }
        }

        private void CarregaCombos()
        {
            #region Produto
            cboProduto.DataSource = new ProdutoDAL().GetComboCompras();
            cboProduto.DisplayMember = "Text";
            cboProduto.ValueMember = "iValue";
            cboProduto.SelectedIndex = -1;

            //cboMultiProduto.Table = new ProdutoDAL().getMulticomboCompras();
            //cboMultiProduto.DisplayMember = "Codigo";
            //cboMultiProduto.ColumnsToDisplay = new string[] { "Codigo", "NomeProduto", "Descricao" }; ;
            //cboMultiProduto.ValueMember = "IdProduto";
            //cboMultiProduto.SelectedIndex = -1;

            cboUnidade.DataSource = new UnidadeDAL().GetCombo();
            cboUnidade.DisplayMember = "Text";
            cboUnidade.ValueMember = "iValue";
            cboUnidade.SelectedIndex = -1;

            //cboCFOP.DataSource = new CFOPDAL().GetComboValido();
            //cboCFOP.DisplayMember = "Text";
            //cboCFOP.ValueMember = "iValue";
            //cboCFOP.SelectedIndex = -1;
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
            TpTransacaoAtivo.Add(new ComboItem() { iValue = 1, Text = "Aquisição" });
            TpTransacaoAtivo.Add(new ComboItem() { iValue = 2, Text = "Ajuste de Aquisição" });
            TpTransacaoAtivo.Add(new ComboItem() { iValue = 3, Text = "Ret. Conserto/Emprestimo/Locação" });
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

            cboRoyalties.DataSource = new RoyaltiesDAL().GetCombo();
            cboRoyalties.DisplayMember = "Text";
            cboRoyalties.ValueMember = "iValue";
            cboRoyalties.SelectedIndex = -1;

            cboGrupoEncargos.DataSource = new GrupoEncargosDAL().getCombo();
            cboGrupoEncargos.DisplayMember = "Text";
            cboGrupoEncargos.ValueMember = "iValue";
            cboGrupoEncargos.SelectedIndex = -1;

            cboGrupoDescontos.DataSource = new GrupoDescontosDAL().GetCombo();
            cboGrupoDescontos.DisplayMember = "Text";
            cboGrupoDescontos.ValueMember = "iValue";
            cboGrupoDescontos.SelectedIndex = -1;
            #endregion

            CarregaCentrosdeCusto();

            CarregaCest();
        }

        private void CarregaValidaCFOP()
        {
            PedidoCompraDAL ped = new PedidoCompraDAL();
            var pedidocompra = ped.PCRepository.GetByID(p.IdPedidoCompra);

            var idOperacao = pedidocompra.IdOperacao == null ? 0 : (int)pedidocompra.IdOperacao;

            var ope = new OperacaoDAL().GetByID(idOperacao);
            if (ope.IdTipoDirecaoNF == 1 && ope.IdDirecaoNF == 1)//Somente os CFOP com inicio 1, 2, 3
            {
                cboCFOP.DataSource = new CFOPDAL().GetComboValido(new[] { "1.", "2.", "3." });
                cboCFOP.DisplayMember = "Text";
                cboCFOP.ValueMember = "iValue";
                cboCFOP.SelectedIndex = -1;
            }
            else if (ope.IdTipoDirecaoNF == 2 && ope.IdDirecaoNF == 1)//Somente os CFOP com inicio 1, 2, 3
            {
                cboCFOP.DataSource = new CFOPDAL().GetComboValido(new[] { "1.", "2.", "3." });
                cboCFOP.DisplayMember = "Text";
                cboCFOP.ValueMember = "iValue";
                cboCFOP.SelectedIndex = -1;
            }
            else if (ope.IdTipoDirecaoNF == 5 && ope.IdDirecaoNF == 2)//Somente os CFOP com inicio 5,6,7
            {
                cboCFOP.DataSource = new CFOPDAL().GetComboValido(new[] { "5.", "6.", "7." });
                cboCFOP.DisplayMember = "Text";
                cboCFOP.ValueMember = "iValue";
                cboCFOP.SelectedIndex = -1;
            }
            else
            {
                cboCFOP.DataSource = new CFOPDAL().GetCombo();
                cboCFOP.DisplayMember = "Text";
                cboCFOP.ValueMember = "iValue";
                cboCFOP.SelectedIndex = -1;
            }
        }

        protected void CarregaCentrosdeCusto()
        {
            var lista = pcDal.GetByPedidoCompraItem(p.IdPedidoCompraItem);
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

        private void frmPedidoComprasAddItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaControles();
            p = new PedidoCompraItem();
            p.IdPedidoCompra = IdPedidoCompra;
            p.IdPedidoCompraItem = 0;
            CarregaNovoItem();
            cboProduto.Focus();
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            try
            {
                if (Util.Validacao.ValidaCampos(this))
                {
                    p.IdProduto = Convert.ToInt32(cboProduto.SelectedValue);
                    p.Quantidade = Convert.ToDecimal(txtQuantidade.Text);
                    p.QuantidadeAReceber = Convert.ToDecimal(txtQuantidade.Text);
                    if (!String.IsNullOrEmpty(cboUnidade.Text)) p.IdUnidade = Convert.ToInt32(cboUnidade.SelectedValue);
                    if (!String.IsNullOrEmpty(txtPrecoTabela.Text)) p.PrecoTabela = Convert.ToDecimal(txtPrecoTabela.Text);
                    p.PrecoUnitario = Convert.ToDecimal(txtPrecoUnitario.Text);
                    // p.Ipi = Convert.ToDecimal(txtIPI.Text);
                    if (!String.IsNullOrEmpty(txtDescontoPercentual.Text)) p.DescontoPercentual = Convert.ToDecimal(txtDescontoPercentual.Text);
                    if (!String.IsNullOrEmpty(txtDescontoValor.Text)) p.DescontoValor = Convert.ToDecimal(txtDescontoValor.Text);
                    if (!String.IsNullOrEmpty(cboRoyalties.Text)) p.IdRoyalties = Convert.ToInt32(cboRoyalties.SelectedValue);
                    if (!String.IsNullOrEmpty(txtValorEncargos.Text)) p.ValorEncargos = Convert.ToDecimal(txtValorEncargos.Text);
                    if (!String.IsNullOrEmpty(txtValorLiquido.Text)) p.ValorLiquido = Convert.ToDecimal(txtValorLiquido.Text);
                    if (!String.IsNullOrEmpty(cboCFOP.Text)) p.IdCFOP = Convert.ToInt32(cboCFOP.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCodigoServico.Text)) p.IdCodigoServico = Convert.ToInt32(cboCodigoServico.SelectedValue);


                    //if (!String.IsNullOrEmpty(cboDocumento.Text)) p.IdTipoDocumentoFiscal = Convert.ToInt32(cboDocumento.SelectedValue);
                    //if (!String.IsNullOrEmpty(cboTipoOrdem.Text)) p.TipoOrdem = Convert.ToInt32(cboTipoOrdem.SelectedValue);
                    //p.MovimentaEstoque = chkMovimentaEstoque.Checked;
                    //if (!String.IsNullOrEmpty(cboPlanoMestre.Text)) p.IdPlanoMestre = Convert.ToInt32(cboPlanoMestre.SelectedValue);
                    //if (!String.IsNullOrEmpty(txtOrdemPlanejada.Text)) p.IdOrdemPlanejada = Convert.ToInt32(txtOrdemPlanejada.Text);
                    //if (!String.IsNullOrEmpty(txtOrdemDevolvida.Text)) p.IdOrdemDevolvida = Convert.ToInt32(txtOrdemDevolvida.Text);
                    //if (!String.IsNullOrEmpty(cboStatusLinha.Text)) p.StatusLinha = Convert.ToInt32(cboStatusLinha.SelectedValue);   

                    if (!String.IsNullOrEmpty(cboVariantesConfig.Text)) p.IdVariantesConfig = Convert.ToInt32(cboVariantesConfig.SelectedValue);
                    if (!String.IsNullOrEmpty(cboEstilo.Text)) p.IdVariantesEstilo = Convert.ToInt32(cboEstilo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCor.Text)) p.IdVariantesCor = Convert.ToInt32(cboCor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTamanho.Text)) p.IdVariantesTamanho = Convert.ToInt32(cboTamanho.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoLotes.Text)) p.IdGrupoLotes = Convert.ToInt32(cboGrupoLotes.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoSeries.Text)) p.IdGrupoSeries = Convert.ToInt32(cboGrupoSeries.SelectedValue);
                    if (!String.IsNullOrEmpty(cboArmazem.Text)) p.IdArmazem = Convert.ToInt32(cboArmazem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDeposito.Text)) p.IdDeposito = Convert.ToInt32(cboDeposito.SelectedValue);
                    if (!String.IsNullOrEmpty(cboLocalizacao.Text)) p.IdLocalizacao = Convert.ToInt32(cboLocalizacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCodigoExterno.Text)) p.IdCodigoExternoFornecedor = Convert.ToInt32(cboCodigoExterno.SelectedValue);
                    p.AtivoFixo = chkAtivoFixo.Checked;
                    if (!String.IsNullOrEmpty(cboGrupoAtivo.Text)) p.IdGrupodeAtivo = Convert.ToInt32(cboGrupoAtivo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboMetodoPreciacao.Text)) p.IdMetodoPreciacao = Convert.ToInt32(cboMetodoPreciacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboAtivoFixo.Text)) p.IdAtivoFixo = Convert.ToInt32(cboAtivoFixo.SelectedValue);
                    p.CreditoICMSAtivo = chkCreditoICMSAtivo.Checked;
                    p.CreditoPisCofins = chkCreditoPisCofins.Checked;
                    if (!String.IsNullOrEmpty(txtParcelaICMS.Text)) p.ParcelaICMS = Convert.ToInt32(txtParcelaICMS.Text);
                    if (!String.IsNullOrEmpty(cboTipoTransacaoAtivo.Text)) p.TipoTransacaoAtivo = Convert.ToInt32(cboTipoTransacaoAtivo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoImposto.Text)) p.IdGrupoImposto = Convert.ToInt32(cboGrupoImposto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoImpostoItem.Text)) p.IdGrupoImpostosItem = Convert.ToInt32(cboGrupoImpostoItem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoImpostoRetido.Text)) p.IdGrupoImpostoRetido = Convert.ToInt32(cboGrupoImpostoRetido.SelectedValue);
                    if (!String.IsNullOrEmpty(cboNCM.Text)) p.IdNCM = Convert.ToInt32(cboNCM.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoEncargos.Text)) p.IdGrupoEncargos = Convert.ToInt32(cboGrupoEncargos.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoDescontos.Text)) p.IdGrupoDescontos = Convert.ToInt32(cboGrupoDescontos.SelectedValue);
                    if (!String.IsNullOrEmpty(txtPesoUnitario.Text)) p.PesoUnitario = Convert.ToDecimal(txtPesoUnitario.Text);
                    if (!String.IsNullOrEmpty(cboCest.Text)) p.IdCest = Convert.ToInt32(cboCest.SelectedValue);

                    if (p.IdPedidoCompraItem == 0)
                    {
                        p.Status = "A";
                        dal.PCIRepository.Insert(p);
                        dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                        ImportaCentroCusto();
                    }
                    else
                    {
                        if (idCodProduto == Convert.ToInt32(cboProduto.SelectedValue))
                        {
                            dal.PCIRepository.Update(p);
                            dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                        }
                        else
                        {
                            ExcluirCentroCusto();
                            dal.PCIRepository.Update(p);
                            dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                            ImportaCentroCusto();
                        }
                    }


                    //geraImpostos
                    BLImpostoEncargosCompras blImpostos = new BLImpostoEncargosCompras();
                    blImpostos.dal = impostoDal;
                    blImpostos.pedidoDal = dal;
                    blImpostos.GeraEncargos(p.IdPedidoCompra);
                    blImpostos.GeraImpostos(p.IdPedidoCompraItem);

                    //Gera Contabilidade
                    blContabilidade.pcDal = dal;
                    blContabilidade.pcContabilidadeDal = contabilidadeDal;
                    blContabilidade.GeraContabilidadeCompras(p.IdPedidoCompra);

                    this.Close();
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

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpaControles()
        {
            cboProduto.Text = "";
            txtQuantidade.Text = "";
            cboUnidade.Text = "";
            txtPrecoTabela.Text = "";
            txtPrecoUnitario.Text = "";
            //txtIPI.Text = "";
            txtDescontoPercentual.Text = "";
            txtDescontoValor.Text = "";
            cboRoyalties.Text = "";
            txtValorEncargos.Text = "";
            txtValorLiquido.Text = "";
            cboCFOP.Text = "";
            cboCodigoServico.Text = "";
            cboVariantesConfig.Text = "";
            cboEstilo.Text = "";
            cboCor.Text = "";
            cboTamanho.Text = "";
            cboGrupoLotes.Text = "";
            cboGrupoSeries.Text = "";
            cboArmazem.Text = "";
            cboDeposito.Text = "";
            cboLocalizacao.Text = "";
            cboCodigoExterno.Text = "";
            chkAtivoFixo.Checked = false;
            cboGrupoAtivo.Text = "";
            cboMetodoPreciacao.Text = "";
            cboAtivoFixo.Text = "";
            chkCreditoICMSAtivo.Checked = false;
            chkCreditoPisCofins.Checked = false;
            txtParcelaICMS.Text = "";
            cboTipoTransacaoAtivo.Text = "";
            cboGrupoImposto.Text = "";
            cboGrupoImpostoItem.Text = "";
            cboGrupoImpostoRetido.Text = "";
            cboNCM.Text = "";
            cboGrupoEncargos.Text = "";
            cboGrupoDescontos.Text = "";
            txtPesoUnitario.Text = "";
            cboCest.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (p.IdPedidoCompraItem > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == DialogResult.Yes)
                {
                    try
                    {
                        dal.PCIRepository.Delete(p.IdPedidoCompraItem);
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

        private void cboProduto_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboProduto.Text))
            {
                Produto pr = new ProdutoDAL().ProdutoRepository.GetByID(Convert.ToInt32(cboProduto.SelectedValue));
                if (pr != null)
                {
                    cboUnidade.SelectedValue = pr.ComprasIdUnidade == null ? 0 : pr.ComprasIdUnidade;
                    cboCodigoServico.SelectedValue = pr.FiscalIdCodigoServico == null ? 0 : pr.FiscalIdCodigoServico;
                    txtPesoUnitario.Text = pr.EstoquePeso.ToString();

                    cboVariantesConfig.SelectedValue = pr.IdVariantesConfig == null ? 0 : pr.IdVariantesConfig;
                    cboEstilo.SelectedValue = pr.IdVariantesEstilo == null ? 0 : pr.IdVariantesEstilo;
                    cboCor.SelectedValue = pr.IdVariantesCor == null ? 0 : pr.IdVariantesCor;
                    cboTamanho.SelectedValue = pr.IdVariantesTamanho == null ? 0 : pr.IdVariantesTamanho;

                    if (pr.ComprasIdGrupoImposto != null)
                        cboGrupoImposto.SelectedValue = pr.ComprasIdGrupoImposto;

                    if (pr.ComprasIdGrupoImpostoRetiro != null)
                        cboGrupoImpostoRetido.SelectedValue = pr.ComprasIdGrupoImpostoRetiro;

                    if (pr.ComprasIdGrupoEncargos != null)
                        cboGrupoEncargos.SelectedValue = pr.ComprasIdGrupoEncargos;

                    if (pr.ComprasIdGrupoDesconto != null)
                        cboGrupoDescontos.SelectedValue = pr.ComprasIdGrupoDesconto;


                    cboGrupoLotes.SelectedValue = pr.EstoqueIdGrupoLotes == null ? 0 : pr.EstoqueIdGrupoLotes;
                    cboGrupoSeries.SelectedValue = pr.EstoqueIdGrupoSeries == null ? 0 : pr.EstoqueIdGrupoSeries;
                    p.IdPlanoMestre = pr.ProducaoIdPlanoMestre == null ? 0 : pr.ProducaoIdPlanoMestre;
                    cboNCM.SelectedValue = pr.FiscalIdNCM == null ? 0 : pr.FiscalIdNCM;

                    //procura codigo externo
                    PedidoCompra pc = new PedidoCompraDAL().PCRepository.GetByID(p.IdPedidoCompra);

                    IdFornecedor = pc.IdFornecedor.Value;

                    cboCodigoExterno.DataSource = new CodigoProdutoExternoDAL().GetCombo(Convert.ToInt32(pc.IdFornecedor), p.IdProduto);
                    cboCodigoExterno.DisplayMember = "Text";
                    cboCodigoExterno.ValueMember = "iValue";
                    cboCodigoExterno.SelectedIndex = -1;

                    // Verifica Contrato Comercial //
                    ContratoComercialFluxoPrecoModelView cc = ccDal.ContratoComercialFluxoPrecoCompras(pc.IdEmpresa.Value.ToString(), pr.IdProduto.ToString(), IdFornecedor.ToString());
                    if (cc.ExisteContrato)
                    {
                        txtPrecoUnitario.Text = cc.Valor.ToString();
                        txtPrecoTabela.Text = cc.Valor.ToString();
                        txtDescontoPercentual.Text = cc.PercentualDesconto.ToString();
                        txtDescontoValor.Text = cc.ValorDesconto.ToString();
                    }
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecoUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtPrecoUnitario.Text, "^\\d*\\,\\d{2}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtDescontoPercentual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtDescontoPercentual.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtDescontoValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtDescontoValor.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        //private void txtIPI_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
        //    {
        //        if (Regex.IsMatch(txtIPI.Text, "^\\d*\\,\\d{4}$"))
        //            e.Handled = true;
        //    }
        //    else
        //    {
        //        e.Handled = e.KeyChar != (char)Keys.Back;
        //    }
        //}

        private void txtValorEncargos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtValorEncargos.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtValorLiquido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtValorLiquido.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtPesoUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtPesoUnitario.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void tsbAddCentroCusto_Click(object sender, EventArgs e)
        {
            if (p.IdPedidoCompraItem == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados do itens do pedido de compra antes de adicionar centros de custo.");
                return;
            }
            frmCentroCustoAux frmCC = new frmCentroCustoAux("PCI", p.IdPedidoCompraItem);
            frmCC.pcidal = pcDal;
            frmCC.ShowDialog();
            CarregaCentrosdeCusto();
        }

        private void tsbExcluirCentroCusto_Click(object sender, EventArgs e)
        {
            if (dgCentros.Rows.Count > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir o centro de custo selecionado?") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgCentros.Rows[dgCentros.SelectedRows[0].Index].Cells[0].Value);
                    try
                    {
                        pcDal.Delete(id);
                        pcDal.Save();
                        CarregaCentrosdeCusto();
                    }
                    catch (Exception ex)
                    {
                        Util.Aplicacao.ShowErrorMessage(ex);
                    }
                }
            }
        }

        private void btnBuscaProduto_Click(object sender, EventArgs e)
        {
            using (frmBuscaProduto frmBusca = new frmBuscaProduto("S"))
            {
                frmBusca.ShowDialog();
                if (frmBusca.ProdutoSelecionado != null)
                {
                    Produto pr = new ProdutoDAL().ProdutoRepository.GetByID(frmBusca.ProdutoSelecionado.IdProduto);
                    if (pr != null)
                    {
                        cboProduto.SelectedValue = frmBusca.ProdutoSelecionado.IdProduto;
                        cboUnidade.SelectedValue = pr.ComprasIdUnidade == null ? 0 : pr.ComprasIdUnidade;
                        cboCodigoServico.SelectedValue = pr.FiscalIdCodigoServico == null ? 0 : pr.FiscalIdCodigoServico;
                        txtPesoUnitario.Text = pr.EstoquePeso.ToString();

                        cboVariantesConfig.SelectedValue = frmBusca.ProdutoSelecionado.IdVariantesConfig == null ? 0 : frmBusca.ProdutoSelecionado.IdVariantesConfig;
                        cboEstilo.SelectedValue = frmBusca.ProdutoSelecionado.IdVariantesEstilo == null ? 0 : frmBusca.ProdutoSelecionado.IdVariantesEstilo;
                        cboCor.SelectedValue = frmBusca.ProdutoSelecionado.IdVariantesCor == null ? 0 : frmBusca.ProdutoSelecionado.IdVariantesCor;
                        cboTamanho.SelectedValue = frmBusca.ProdutoSelecionado.IdVariantesTamanho == null ? 0 : frmBusca.ProdutoSelecionado.IdVariantesTamanho;

                        if (pr.ComprasIdGrupoImposto != null)
                            cboGrupoImposto.SelectedValue = pr.ComprasIdGrupoImposto;

                        if (pr.ComprasIdGrupoImpostoRetiro != null)
                            cboGrupoImpostoRetido.SelectedValue = pr.ComprasIdGrupoImpostoRetiro;

                        if (pr.ComprasIdGrupoEncargos != null)
                            cboGrupoEncargos.SelectedValue = pr.ComprasIdGrupoEncargos;

                        if (pr.ComprasIdGrupoDesconto != null)
                            cboGrupoDescontos.SelectedValue = pr.ComprasIdGrupoDesconto;


                        cboGrupoLotes.SelectedValue = pr.EstoqueIdGrupoLotes == null ? 0 : pr.EstoqueIdGrupoLotes;
                        cboGrupoSeries.SelectedValue = pr.EstoqueIdGrupoSeries == null ? 0 : pr.EstoqueIdGrupoSeries;
                        p.IdPlanoMestre = pr.ProducaoIdPlanoMestre == null ? 0 : pr.ProducaoIdPlanoMestre;
                        cboNCM.SelectedValue = pr.FiscalIdNCM == null ? 0 : pr.FiscalIdNCM;
                        cboCest.SelectedValue = pr.IdCest == null ? 0 : pr.IdCest;
                        //procura codigo externo
                        PedidoCompra pc = new PedidoCompraDAL().PCRepository.GetByID(p.IdPedidoCompra);

                        IdFornecedor = pc.IdFornecedor.Value;

                        cboCodigoExterno.DataSource = new CodigoProdutoExternoDAL().GetCombo(Convert.ToInt32(pc.IdFornecedor), p.IdProduto);
                        cboCodigoExterno.DisplayMember = "Text";
                        cboCodigoExterno.ValueMember = "iValue";
                        cboCodigoExterno.SelectedIndex = -1;

                        // Verifica Contrato Comercial //
                        ContratoComercialFluxoPrecoModelView cc = ccDal.ContratoComercialFluxoPrecoCompras(pc.IdEmpresa.Value.ToString(), pr.IdProduto.ToString(), IdFornecedor.ToString());
                        if (cc.ExisteContrato)
                        {
                            txtPrecoUnitario.Text = cc.Valor.ToString();
                            txtPrecoTabela.Text = cc.Valor.ToString();
                            txtDescontoPercentual.Text = cc.PercentualDesconto.ToString();
                            txtDescontoValor.Text = cc.ValorDesconto.ToString();
                        }
                    }
                }
            }
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

            txtValorLiquido.Text = lValorLiquido.ToString();
        }

        private void txtPrecoUnitario_TextChanged(object sender, EventArgs e)
        {
            CalcularValorLiquido();
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
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

        private void ExcluirCentroCusto()
        {
            PedidoCompraItemCentroCustoDAL pcccDal = new PedidoCompraItemCentroCustoDAL();
            var lista = pcccDal.GetIdsPedidoCompraItemCentroCusto(p.IdPedidoCompraItem);
            if (lista != null && lista.Count > 0)
            {
                foreach (var item in lista)
                {
                    pcccDal.Delete(item);
                    pcccDal.Save();
                }
            }
        }

        private void ImportaCentroCusto()
        {
            //Importa o centro de custo do produto, caso produto não tenha
            //centro de custo cadastrado, importar o centro de custo do pedido de Compra

            PedidoCompraItemCentroCusto pcicc = new PedidoCompraItemCentroCusto();
            PedidoCompraItemCentroCustoDAL pciccDal = new PedidoCompraItemCentroCustoDAL();

            //importa do produto.
            ProdutoCentroCustoDAL prDal = new ProdutoCentroCustoDAL();
            var lista = prDal.GetValoresCadastrados(Convert.ToInt32(cboProduto.SelectedValue));

            if (lista != null && lista.Count > 0)
            {

                foreach (var item in lista)
                {
                    pcicc.IdPedidoCompraItem = p.IdPedidoCompraItem;
                    pcicc.IdValoresCentroCusto = item.Value;

                    pciccDal.Insert(pcicc);
                    pciccDal.Save();
                }
            }
            else
            {
                //importa do pedido de Compra.
                PedidoCompraCentroCustoDAL pedDal = new PedidoCompraCentroCustoDAL();
                var listapc = pedDal.GetValoresCadastrados(p.IdPedidoCompra);

                if (listapc != null && listapc.Count > 0)
                {
                    foreach (var item in listapc)
                    {
                        pcicc.IdPedidoCompraItem = p.IdPedidoCompraItem;
                        pcicc.IdValoresCentroCusto = item.Value;

                        pciccDal.Insert(pcicc);
                        pciccDal.Save();
                    }
                }
            }
        }

        private void cboNCM_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboNCM.Text))
            {
                if (String.IsNullOrEmpty(cboCest.Text))
                {
                    int IdNCM = Convert.ToInt32(cboNCM.SelectedValue);
                    ClassificacaoFiscal cl = new ClassificacaoFiscal();
                    cl = new ClassificacaoFiscalDAL().GetByID(IdNCM);
                    cboCest.SelectedValue = cl.IdCest == null ? 0 : cl.IdCest;
                }

            }
        }
    }
}
