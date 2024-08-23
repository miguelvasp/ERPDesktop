using ERP.Auxiliares;
using ERP.BLL;
using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using ERP.Relatorios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ERP.Compras
{
    public partial class frmPedidoComprasCad : RibbonForm
    {
        PedidoCompraDAL dal = new PedidoCompraDAL();
        PedidoCompraCentroCustoDAL pcDal = new PedidoCompraCentroCustoDAL();
        PedidoCompra p = new PedidoCompra();
        PedidoCompraAlocacaoEncargosDAL alocalDal = new PedidoCompraAlocacaoEncargosDAL();
        PedidoCompraItemApuracaoImpostoDAL impostosDal = new PedidoCompraItemApuracaoImpostoDAL();
        PedidoCompraEncargosDAL encargosDal = new PedidoCompraEncargosDAL();
        Configuracao confEmpresa = new ConfiguracaoDAL().GetByEmpresa(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
        Empresa emp = new EmpresaDAL().getByIdEmpresa(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));

        int IdCodFornecedor = 0;

        public frmPedidoComprasCad(PedidoCompraDAL pDal, PedidoCompra pPedido)
        {
            dal = pDal;
            p = pPedido;

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmPedidoComprasCad_Load(object sender, EventArgs e)
        {
            CarregaCombos();

            if (p.IdPedidoCompra == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

                TratarCorCampoDesabilitado();
            }
            else
            {
                CarregaDados();
            }
        }

        private void frmPedidoComprasCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaCombos()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");



            #region DadosPedido
            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(sEmpresa);
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;

            cboGrupoFornecedor.DataSource = new GrupoFornecedorDAL().GetCombo();
            cboGrupoFornecedor.DisplayMember = "Text";
            cboGrupoFornecedor.ValueMember = "iValue";
            cboGrupoFornecedor.SelectedIndex = -1;

            List<ComboItem> TipoOrdem = new List<ComboItem>();
            TipoOrdem.Add(new ComboItem() { iValue = 1, Text = "Ordem de Compra" });
            TipoOrdem.Add(new ComboItem() { iValue = 2, Text = "Ordem Devolvida" });
            cboTipoOrdem.DataSource = TipoOrdem;
            cboTipoOrdem.DisplayMember = "Text";
            cboTipoOrdem.ValueMember = "iValue";

            cboMoeda.DataSource = new MoedaDAL().MRepository.Get();
            cboMoeda.DisplayMember = "Codigo";
            cboMoeda.ValueMember = "IdMoeda";
            cboMoeda.SelectedIndex = -1;

            cboGrupoImposto.DataSource = new GrupoImpostoDAL().getCombo();
            cboGrupoImposto.DisplayMember = "Text";
            cboGrupoImposto.ValueMember = "iValue";
            cboGrupoImposto.SelectedIndex = -1;

            cboGrupoImpostoRetido.DataSource = new GrupoImpostoRetidoDAL().GetCombo();
            cboGrupoImpostoRetido.DisplayMember = "Text";
            cboGrupoImpostoRetido.ValueMember = "iValue";
            cboGrupoImpostoRetido.SelectedIndex = -1;

            cboOperacao.DataSource = new OperacaoDAL().GetCombo();
            cboOperacao.DisplayMember = "Text";
            cboOperacao.ValueMember = "iValue";
            cboOperacao.SelectedIndex = -1;

            cboPerfilFornecedor.DataSource = new PerfilFornecedorDAL().GetCombo();
            cboPerfilFornecedor.DisplayMember = "Text";
            cboPerfilFornecedor.ValueMember = "iValue";
            cboPerfilFornecedor.SelectedIndex = -1;

            cboCFPS.DataSource = new CFPSDAL().GetCombo();
            cboCFPS.DisplayMember = "Text";
            cboCFPS.ValueMember = "iValue";
            cboCFPS.SelectedIndex = -1;
            #endregion

            #region Entrega
            cboTransportadora.DataSource = new TransportadoraDAL().GetCombo();
            cboTransportadora.DisplayMember = "Text";
            cboTransportadora.ValueMember = "iValue";
            cboTransportadora.SelectedIndex = -1;

            List<ComboItem> TipoFrete = new List<ComboItem>();
            TipoFrete.Add(new ComboItem() { iValue = 1, Text = "CIF" });
            TipoFrete.Add(new ComboItem() { iValue = 2, Text = "FOB" });
            cboTipoFrete.DataSource = TipoFrete;
            cboTipoFrete.DisplayMember = "Text";
            cboTipoFrete.ValueMember = "iValue";
            cboTipoFrete.SelectedIndex = -1;

            cboArmazem.DataSource = new ArmazemDAL().GetCombo();
            cboArmazem.DisplayMember = "Text";
            cboArmazem.ValueMember = "iValue";
            cboArmazem.SelectedIndex = -1;

            cboDeposito.DataSource = new DepositoDAL().GetCombo();
            cboDeposito.DisplayMember = "Text";
            cboDeposito.ValueMember = "iValue";
            cboDeposito.SelectedIndex = -1;

            cboModoEntrega.DataSource = new ModoEntregaDAL().GetCombo();
            cboModoEntrega.DisplayMember = "Text";
            cboModoEntrega.ValueMember = "iValue";
            cboModoEntrega.SelectedIndex = -1;

            //cboCondicaoEntrega.DataSource = new ModoEntregaDAL().GetCombo();
            //cboCondicaoEntrega.DisplayMember = "Text";
            //cboCondicaoEntrega.ValueMember = "iValue";
            //cboCondicaoEntrega.SelectedIndex = -1;

            cboTextoPadrao.DataSource = new TextoPadraoDAL().GetCombo();
            cboTextoPadrao.DisplayMember = "Text";
            cboTextoPadrao.ValueMember = "iValue";
            cboTextoPadrao.SelectedIndex = -1;
            #endregion

            #region Financeiro
            cboCondicao.DataSource = new CondicaoPagamentoDAL().GetCombo();
            cboCondicao.DisplayMember = "Text";
            cboCondicao.ValueMember = "iValue";
            cboCondicao.SelectedIndex = -1;

            cboMetodoPagamento.DataSource = new MetodoPagamentoDAL().GetCombo();
            cboMetodoPagamento.DisplayMember = "Text";
            cboMetodoPagamento.ValueMember = "iValue";
            cboMetodoPagamento.SelectedIndex = -1;

            cboPlanoPagamento.DataSource = new PlanoPagamentoDAL().GetCombo();
            cboPlanoPagamento.DisplayMember = "Text";
            cboPlanoPagamento.ValueMember = "iValue";
            cboPlanoPagamento.SelectedIndex = -1;

            cboContratoComercial.DataSource = new ContratoComercialDAL().GetCombo("compras", sEmpresa);
            cboContratoComercial.DisplayMember = "Text";
            cboContratoComercial.ValueMember = "iValue";
            cboContratoComercial.SelectedIndex = -1;

            cboGrupoEncargos.DataSource = new GrupoEncargosDAL().getCombo();
            cboGrupoEncargos.DisplayMember = "Text";
            cboGrupoEncargos.ValueMember = "iValue";
            cboGrupoEncargos.SelectedIndex = -1;

            cboGrupoDesconto.DataSource = new GrupoDescontosDAL().GetCombo();
            cboGrupoDesconto.DisplayMember = "Text";
            cboGrupoDesconto.ValueMember = "iValue";
            cboGrupoDesconto.SelectedIndex = -1;

            cboRoyalties.DataSource = new RoyaltiesDAL().GetCombo();
            cboRoyalties.DisplayMember = "Text";
            cboRoyalties.ValueMember = "iValue";
            cboRoyalties.SelectedIndex = -1;

            CarregaDiasPagamento();

            #endregion

            //cboGrupoImpostoRetido.DataSource = new ModoEntregaDAL().GetCombo();
            //cboGrupoImpostoRetido.DisplayMember = "Text";
            //cboGrupoImpostoRetido.ValueMember = "iValue";
            //cboGrupoImpostoRetido.SelectedIndex = -1;

            //List<ComboItem> StatusAprovacao = new List<ComboItem>();
            //StatusAprovacao.Add(new ComboItem() { iValue = 1, Text = "Rascunho" });
            //StatusAprovacao.Add(new ComboItem() { iValue = 2, Text = "Revisao" });
            //StatusAprovacao.Add(new ComboItem() { iValue = 3, Text = "Rejeitado" });
            //StatusAprovacao.Add(new ComboItem() { iValue = 4, Text = "Finalizado" });
            //cboStatusAprovacao.DataSource = StatusAprovacao;
            //cboStatusAprovacao.DisplayMember = "Text";
            //cboStatusAprovacao.ValueMember = "iValue";
            //cboStatusAprovacao.SelectedIndex = -1;
        }

        protected void CarregaDiasPagamento()
        {
            cboDiasPagamento.DataSource = new DiasPagamentoDAL().GetCombo();
            cboDiasPagamento.DisplayMember = "Text";
            cboDiasPagamento.ValueMember = "iValue";
            cboDiasPagamento.SelectedIndex = -1;
        }

        private void CarregaDados()
        {
            try
            {
                //verifica se o pedido já foi liberado
                if (p.PedidoNumero != null && p.PedidoNumero > 0)
                {
                    btnLibera.Enabled = false;
                }
                else
                {
                    btnLibera.Enabled = true;
                }

                if (p.StatusAprovacao != null)
                {
                    AprovacaoNivelDAL anDal = new AprovacaoNivelDAL();
                    AprovacaoNivel an = anDal.GetByID(Convert.ToInt32(p.StatusAprovacao));
                    if (an != null)
                        txtStatusAprovacao.Text = an.Nome;
                }

                txtNumeroPedido.Text = p.PedidoNumero == null ? "" : p.PedidoNumero.Value.ToString();
                txtIdCodigo.Text = p.IdPedidoCompra.ToString();

                if (p.Data == DateTime.MinValue)
                {
                    txtData.Text = DateTime.Now.ToShortDateString();
                }
                else
                {
                    txtData.Text = p.Data.ToShortDateString();
                }

                cboFornecedor.SelectedValue = p.IdFornecedor == null ? 0 : p.IdFornecedor;

                Fornecedor f = new FornecedorDAL().FRepository.GetByID(Convert.ToInt32(cboFornecedor.SelectedValue));
                if (f != null)
                {
                    if (f.Tipo == 1)
                    {
                        lblCNPJ.Text = "CPF";
                        txtCNPJ.Mask = "999.999.999-99";
                    }
                    else
                    {
                        lblCNPJ.Text = "CNPJ";
                        txtCNPJ.Mask = "99.999.999/9999-99";
                    }

                    txtCNPJ.Text = f.CNPJ;
                }

                cboMoeda.SelectedValue = p.IdMoeda == null ? 0 : p.IdMoeda;
                txtPrazo.Text = p.PrazoEntrega;
                if (p.Emissao == DateTime.MinValue)
                {
                    txtEmissao.Text = DateTime.Now.ToShortDateString();
                }
                else
                {
                    txtEmissao.Text = p.Emissao.ToShortDateString();
                }

                cboCondicao.SelectedValue = p.IdCondicaoPagamento == null ? 0 : p.IdCondicaoPagamento;

                if (p.Emissao == DateTime.MinValue)
                {
                    txtDataEntrega.Text = DateTime.Now.ToShortDateString();
                }
                else
                {
                    txtDataEntrega.Text = p.DataEntrega.ToShortDateString();
                }

                Usuario u = new UsuarioDAL().URepository.GetByID(p.IdComprador);
                txtComprador.Text = "";
                if (u != null)
                {
                    txtComprador.Text = u.NomeCompleto;
                }

                txtObservacao.Text = p.Observacao;
                cboGrupoFornecedor.SelectedValue = p.IdGrupoFornecedor == null ? 0 : p.IdGrupoFornecedor;
                cboPerfilFornecedor.SelectedValue = p.IdPerfilFornecedor == null ? 0 : p.IdPerfilFornecedor;
                cboCFPS.SelectedValue = p.IdCFPS == null ? 0 : p.IdCFPS;
                cboGrupoEncargos.SelectedValue = p.IdGrupoEncargos == null ? 0 : p.IdGrupoEncargos;
                cboGrupoDesconto.SelectedValue = p.IdGrupoDesconto == null ? 0 : p.IdGrupoDesconto;
                cboTransportadora.SelectedValue = p.IdGrupoFretes == null ? 0 : p.IdGrupoFretes;
                cboRoyalties.SelectedValue = p.IdRoyalties == null ? 0 : p.IdRoyalties;
                cboTextoPadrao.SelectedValue = p.IdTextoPadrao == null ? 0 : p.IdTextoPadrao;
                cboTipoOrdem.SelectedValue = p.TipoOrdem == null ? 0 : p.TipoOrdem;
                cboMetodoPagamento.SelectedValue = p.IdMetodoPagamento == null ? 0 : p.IdMetodoPagamento;
                cboPlanoPagamento.SelectedValue = p.IdPlanoPagamento == null ? 0 : p.IdPlanoPagamento;

                cboGrupoImposto.SelectedValue = p.IdGrupoImposto == null ? 0 : p.IdGrupoImposto;
                cboGrupoImpostoRetido.SelectedValue = p.IdGrupoImpostoRetido == null ? 0 : p.IdGrupoImpostoRetido;
                cboTransportadora.SelectedValue = p.IdTransportadora == null ? 0 : p.IdTransportadora;
                cboArmazem.SelectedValue = p.IdArmazem == null ? 0 : p.IdArmazem;
                cboDeposito.SelectedValue = p.IdDeposito == null ? 0 : p.IdDeposito;
                txtMotivoDevolucao.Text = p.MotivoDevolucao;
                cboContratoComercial.SelectedValue = p.IdContratoComercial == null ? 0 : p.IdContratoComercial;
                txtPedidoReferencia.Text = p.IdOrdemReferencia.ToString();
                chkNFSE.Checked = p.NFSE;
                txtStatus.Text = p.Status;

                cboModoEntrega.SelectedValue = p.IdModoEntrega == null ? 0 : p.IdModoEntrega;
                cboCondicaoEntrega.SelectedValue = p.IdCondicaoEntrega == null ? 0 : p.IdCondicaoEntrega;
                cboTipoFrete.SelectedValue = p.TipoFrete == null ? 0 : p.TipoFrete;
                txtStatus.Text = p.Status;
                cboOperacao.SelectedValue = p.IdOperacao == null ? 0 : p.IdOperacao;
                
                cboDiasPagamento.SelectedValue = p.IdDiasPagamento == null ? 0 : p.IdDiasPagamento;

                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

                if (p.IdPedidoCompra != 0)
                {
                    btnAdd.Enabled = true;
                    dgv.Enabled = true;
                }
                else
                {
                    txtEmissao.Text = DateTime.Now.ToShortDateString();
                    btnAdd.Enabled = false;
                    dgv.Enabled = false;
                }

                //se o pedido foi finalizado nao deixa alterar
                if (p.Status == "Atendido" || p.Status == "Cancelado" || p.Status == "Cancelado Saldo")
                {
                    btnAlterar.Enabled = false;
                    btnAdd.Enabled = false;
                    dgv.Enabled = false;
                }
                CarregaGrid();
                CarregaAprovacoes();
                CarregaCentrosdeCusto();
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {

            p = new PedidoCompra();
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            TratarCorCampoDesabilitado();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            IdCodFornecedor = Convert.ToInt32(cboFornecedor.SelectedValue);

            if (p.IdPedidoCompra == 0)
            {
                Util.Aplicacao.ShowMessage("O pedido não se encontra disponível para edição.");
                return;
            }

            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            TratarCorCampoDesabilitado();
        }

        private void TratarCorCampoDesabilitado()
        {
            txtNumeroPedido.BackColor = SystemColors.Control;
            txtIdCodigo.BackColor = SystemColors.Control;
            txtData.BackColor = SystemColors.Control;
            txtStatus.BackColor = SystemColors.Control;
            txtStatusAprovacao.BackColor = SystemColors.Control;
            txtComprador.BackColor = SystemColors.Control;
            txtEmissao.BackColor = SystemColors.Control;
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboTipoOrdem.Text != null)
                {
                    if (cboTipoOrdem.SelectedValue.ToString() == "2")
                    {
                        txtMotivoDevolucao.Tag = 1;
                        if (dal.ConsultaPedidoReferencia(Convert.ToInt32(p.IdOrdemReferencia), Convert.ToInt32(p.IdFornecedor)) == 0)
                        {
                            Util.Aplicacao.ShowMessage("Pedido de referência não encontrado");
                            return;
                        }
                    }
                    else
                    {
                        txtMotivoDevolucao.Tag = "";
                    }
                }

                //se a condiação de pagamento esta em branco o plani de pagamento é obrigatorio
                if (String.IsNullOrEmpty(cboCondicao.Text))
                {
                    cboPlanoPagamento.Tag = "1";
                }
                else
                {
                    cboPlanoPagamento.Tag = "";
                }


                if (Util.Validacao.ValidaCampos(this))
                {
                    p.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                    p.IdFornecedor = Convert.ToInt32(cboFornecedor.SelectedValue);
                    p.IdMoeda = Convert.ToInt32(cboMoeda.SelectedValue);
                    p.PrazoEntrega = txtPrazo.Text;

                    p.IdCondicaoPagamento = Convert.ToInt32(cboCondicao.SelectedValue);
                    p.DataEntrega = Convert.ToDateTime(txtDataEntrega.Text);
                    p.Observacao = txtObservacao.Text;
                    if (!String.IsNullOrEmpty(cboGrupoFornecedor.Text)) p.IdGrupoFornecedor = Convert.ToInt32(cboGrupoFornecedor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPerfilFornecedor.Text)) p.IdPerfilFornecedor = Convert.ToInt32(cboPerfilFornecedor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboOperacao.Text)) p.IdOperacao = Convert.ToInt32(cboOperacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCFPS.Text)) p.IdCFPS = Convert.ToInt32(cboCFPS.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoEncargos.Text)) p.IdGrupoEncargos = Convert.ToInt32(cboGrupoEncargos.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoDesconto.Text)) p.IdGrupoDesconto = Convert.ToInt32(cboGrupoDesconto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTransportadora.Text)) p.IdGrupoFretes = Convert.ToInt32(cboTransportadora.SelectedValue);
                    if (!String.IsNullOrEmpty(cboRoyalties.Text)) p.IdRoyalties = Convert.ToInt32(cboRoyalties.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTextoPadrao.Text)) p.IdTextoPadrao = Convert.ToInt32(cboTextoPadrao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoOrdem.Text)) p.TipoOrdem = Convert.ToInt32(cboTipoOrdem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboMetodoPagamento.Text)) p.IdMetodoPagamento = Convert.ToInt32(cboMetodoPagamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPlanoPagamento.Text)) p.IdPlanoPagamento = Convert.ToInt32(cboPlanoPagamento.SelectedValue);

                    if (!String.IsNullOrEmpty(cboGrupoImposto.Text)) p.IdGrupoImposto = Convert.ToInt32(cboGrupoImposto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoImpostoRetido.Text)) p.IdGrupoImpostoRetido = Convert.ToInt32(cboGrupoImpostoRetido.SelectedValue);

                    if (!String.IsNullOrEmpty(cboTransportadora.Text)) p.IdTransportadora = Convert.ToInt32(cboTransportadora.SelectedValue);
                    if (!String.IsNullOrEmpty(cboArmazem.Text)) p.IdArmazem = Convert.ToInt32(cboArmazem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDeposito.Text)) p.IdDeposito = Convert.ToInt32(cboDeposito.SelectedValue);

                    p.MotivoDevolucao = txtMotivoDevolucao.Text;
                    if (!String.IsNullOrEmpty(cboContratoComercial.Text)) p.IdContratoComercial = Convert.ToInt32(cboContratoComercial.SelectedValue);
                    if (!String.IsNullOrEmpty(txtPedidoReferencia.Text)) p.IdOrdemReferencia = Convert.ToInt32(txtPedidoReferencia.Text);

                    p.NFSE = chkNFSE.Checked;

                    if (!String.IsNullOrEmpty(cboModoEntrega.Text)) p.IdModoEntrega = Convert.ToInt32(cboModoEntrega.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCondicaoEntrega.Text)) p.IdCondicaoEntrega = Convert.ToInt32(cboCondicaoEntrega.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoFrete.Text)) p.TipoFrete = Convert.ToInt32(cboTipoFrete.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDiasPagamento.Text)) p.IdDiasPagamento = Convert.ToInt32(cboDiasPagamento.SelectedValue);

                    if (p.IdPedidoCompra == 0)
                    {
                        p.Data = DateTime.Now;
                        p.Status = "Em aberto";
                        p.IdComprador = Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"));
                        p.Emissao = DateTime.Now;

                        dal.PCRepository.Insert(p);
                        dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                        ImportaCentroCusto();
                    }
                    else
                    {
                        //dal.PCRepository.Update(p);
                        //dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                        if (IdCodFornecedor == Convert.ToInt32(cboFornecedor.SelectedValue))
                        {
                            dal.PCRepository.Update(p);
                            dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                        }
                        else
                        {
                            ExcluirCentroCusto();

                            dal.PCRepository.Update(p);
                            dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                            ImportaCentroCusto();
                        }

                    }


                    encargosDal.GeraEncargos(p.IdPedidoCompra, p.IdGrupoEncargos);
                    CalculaEncargos();
                    CarregaDados();
                    tabControl1.SelectedTab = tabPage2;
                    //Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Qualquer alteração efetuada será perdida, deseja continuar?") == DialogResult.Yes)
            {
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (p.IdPedidoCompra > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja cancelar este pedido?") == DialogResult.Yes)
                {
                    try
                    {
                        p.Status = "Cancelado";
                        dal.PCRepository.Update(p);
                        dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                        Close();
                    }
                    catch (Exception ex)
                    {
                        Util.Aplicacao.ShowErrorMessage(ex);
                    }
                }
            }
        }

        private void CarregaGrid()
        {
            var lista = dal.GetItens(p.IdPedidoCompra).ToList();
            dgv.DataSource = lista;
            dgv.AutoGenerateColumns = false;
            if (lista.Count > 0)
            {
                btnVerImpostos.Visible = true;
                btnVerImpostos.Enabled = true;
                btnContabilidade.Visible = true;
                btnContabilidade.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (p.IdPedidoCompra == 0)
            {
                Util.Aplicacao.ShowMessage("O pedido não se encontra disponível para edição.");
                return;
            }
            PedidoCompraItem pi = new PedidoCompraItem();
            pi.IdPedidoCompra = p.IdPedidoCompra;
            frmPedidoComprasAddItem addItem = new frmPedidoComprasAddItem(dal, pi);
            addItem.impostoDal = impostosDal;
            addItem.ShowDialog();
            CarregaGrid();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[1].Value.ToString());
                    PedidoCompraItem pi = dal.PCIRepository.GetByID(id);
                    frmPedidoComprasAddItem cad = new frmPedidoComprasAddItem(dal, pi);
                    cad.impostoDal = impostosDal;
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //frmRepPedidoComprasViewer viewer = new frmRepPedidoComprasViewer(p.IdPedidoCompra);
            //viewer.ShowDialog();
            CrystalReports.frmCrystalReportViewer frmv = new CrystalReports.frmCrystalReportViewer("OrdemCompra");
            List<FiltroRelatorio> FiltrosRelatorio = new List<FiltroRelatorio>();
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "Id", Valor = p.IdPedidoCompra.ToString() });
            frmv.FiltrosRelatorio = FiltrosRelatorio;
            frmv.ShowDialog();
        }

        private void btnCancelarSaldo_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja cancelar o saldo deste pedido?") == DialogResult.Yes)
            {
                try
                {
                    p.Status = "Cancelado Saldo";
                    dal.PCRepository.Update(p);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    List<PedidoCompraItem> lista = dal.GetItensByPedido(p.IdPedidoCompra);
                    foreach (PedidoCompraItem i in lista)
                    {
                        i.Status = "Cancelado";
                        dal.PCIRepository.Update(i);
                        dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
            }
        }

        private void cboFornecedor_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboFornecedor.Text))
            {
                Fornecedor f = new FornecedorDAL().FRepository.GetByID(Convert.ToInt32(cboFornecedor.SelectedValue));

                if (f.Tipo == 1)
                {
                    lblCNPJ.Text = "CPF";
                    txtCNPJ.Mask = "999.999.999-99";
                }
                else
                {
                    lblCNPJ.Text = "CNPJ";
                    txtCNPJ.Mask = "99.999.999/9999-99";
                }

                txtCNPJ.Text = f.CNPJ;

                if (f.IdTextoPadrao != null) { cboGrupoFornecedor.SelectedValue = f.IdTextoPadrao; }
                if (f.IdGrupoFornecedor != null) { cboGrupoFornecedor.SelectedValue = f.IdGrupoFornecedor; }
                if (f.IdMoeda != null) { cboMoeda.SelectedValue = f.IdMoeda; }
                if (f.IdGrupoImposto != null) { cboGrupoImposto.SelectedValue = f.IdGrupoImposto; }
                if (f.IdImpostoRetido != null) { cboGrupoImpostoRetido.SelectedValue = f.IdImpostoRetido; }
                if (f.IdCondicaoPagamento != null) { cboCondicao.SelectedValue = f.IdCondicaoPagamento; }
                if (f.IdMetodoPagamento != null) { cboMetodoPagamento.SelectedValue = f.IdMetodoPagamento; }
                if (f.IdPlanoPagamento != null) { cboPlanoPagamento.SelectedValue = f.IdPlanoPagamento; }

                if (f.IdTextoPadrao != null) { cboTextoPadrao.SelectedValue = f.IdTextoPadrao; }
                p.RPA = Convert.ToBoolean(f.RPA);

                //Pega as configurações padrao
                if (confEmpresa == null) confEmpresa = new Configuracao();
                if (Convert.ToBoolean(confEmpresa.UsarPadraoCompras))
                {
                    cboArmazem.SelectedValue = confEmpresa.IdArmazemCompras == null ? 0 : Convert.ToInt32(confEmpresa.IdArmazemCompras);
                    cboDeposito.SelectedValue = confEmpresa.IdDepositoCompras == null ? 0 : Convert.ToInt32(confEmpresa.IdDepositoCompras);
                    cboModoEntrega.SelectedValue = confEmpresa.IdModoEntregaCompras == null ? 0 : Convert.ToInt32(confEmpresa.IdModoEntregaCompras);
                    cboMoeda.SelectedValue = emp.IdMoeda == null ? 0 : Convert.ToInt32(emp.IdMoeda);
                }

            }
        }

        private void cboOperacao_Leave(object sender, EventArgs e)
        {
            if (cboOperacao.Text != "")
            {
                var op = new OperacaoDAL().GetByID(Convert.ToInt32(cboOperacao.SelectedValue));
                if (op != null)
                {
                    cboPerfilFornecedor.SelectedValue = op.IdPerfilFornecedor == null ? 0 : Convert.ToInt32(op.IdPerfilFornecedor);
                    p.CriaTransContabeis = Convert.ToBoolean(op.TransacoesContabeis);
                    p.CriaTransFinanceiras = Convert.ToBoolean(op.TransacoesFinanceiras);
                    p.MovimentaEstoque = Convert.ToBoolean(op.MovimentaEstoque);
                }
            }
        }

        private void txtPrazo_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPrazo.Text))
            {
                if (Util.Validacao.IsNumber(txtPrazo.Text))
                {
                    txtDataEntrega.Value = DateTime.Now.AddDays(Convert.ToInt32(txtPrazo.Text));
                }
            }
        }

        private void CarregaAprovacoes()
        {
            var lista = new PedidoCompraAprovacaoDAL().GetByIdPedido(p.IdPedidoCompra);
            dgAprovacao.AutoGenerateColumns = false;
            dgAprovacao.DataSource = lista;
        }

        protected void CarregaCentrosdeCusto()
        {
            var lista = pcDal.GetByPedidoCompra(p.IdPedidoCompra);
            dgCentros.AutoGenerateColumns = false;
            dgCentros.DataSource = lista;
        }

        private void ExcluirCentroCusto()
        {
            //Excluir centro de custo caso seja alterado o fornecedor.
            PedidoCompraCentroCustoDAL pcccDal = new PedidoCompraCentroCustoDAL();
            var lista = pcccDal.GetIdsPedidoCompraCentroCusto(p.IdPedidoCompra);
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
            //Importa centro de custo cadastrado no Fornecedor.

            FornecedorCentroCustoDAL cliDal = new FornecedorCentroCustoDAL();
            var lista = cliDal.GetValoresCadastrados(Convert.ToInt32(cboFornecedor.SelectedValue));

            if (lista != null && lista.Count > 0)
            {
                PedidoCompraCentroCusto pccc = new PedidoCompraCentroCusto();
                PedidoCompraCentroCustoDAL pcccDal = new PedidoCompraCentroCustoDAL();
                foreach (var item in lista)
                {
                    pccc.IdPedidoCompra = p.IdPedidoCompra;
                    pccc.IdValoresCentroCusto = item.Value;

                    pcccDal.Insert(pccc);
                    pcccDal.Save();
                }
            }
        }

        private void btnLibera_Click(object sender, EventArgs e)
        {
            //verifica se o PC tem itens
            if (dgv.Rows.Count == 0)
            {
                Util.Aplicacao.ShowMessage("Informe os itens do pedido de compras.");
                return;
            }

            if (Util.Aplicacao.ShowQuestionMessage("Deseja finalizar e liberar o Pedido de Compras?") == DialogResult.Yes)
            {
                int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));

                //procura o primeiro status de aprovaçao
                AprovacaoNivel an = new AprovacaoDocumentoDAL().GetFirtsByNivel("PC");
                if (an == null)
                {
                    Util.Aplicacao.ShowMessage("Não existe plano de aprovação de documentos para os pedidos de compras. \n Efetue o cadastro e tente liberar o pedido de compras novamente.");
                    return;
                }

                p.StatusAprovacao = an.IdAprovacaoNivel;
                txtStatusAprovacao.Text = an.Nome;

                EmpresaDAL empDal = new EmpresaDAL();
                Empresa empresa = empDal.ERepository.GetByID(idEmpresa);
                int ultimoPedidoCompra = empresa.UltimoPedidoCompras.HasValue ? empresa.UltimoPedidoCompras.Value + 1 : 1;
                empresa.UltimoPedidoCompras = ultimoPedidoCompra;
                empDal.ERepository.Update(empresa);
                empDal.Save();

                p.PedidoNumero = ultimoPedidoCompra;
                dal.PCRepository.Update(p);
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                Usuario usu = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario")));

                //guarda o historico da aprovação
                PedidoCompraAprovacao pa = new PedidoCompraAprovacao();
                pa.IdPedidoCompra = p.IdPedidoCompra;
                pa.Data = DateTime.Now;
                pa.NovoStatus = txtStatusAprovacao.Text;
                pa.Usuario = usu.NomeCompleto;

                PedidoCompraAprovacaoDAL paDal = new PedidoCompraAprovacaoDAL();
                paDal.Insert(pa);
                paDal.Save();

                List<PedidoCompraItem> itensPCI = new List<PedidoCompraItem>();
                itensPCI = dal.GetPedidoCompraItens(p.IdPedidoCompra).ToList();

                CarregaDados();
            }
        }

        private void tsbAddCentroCusto_Click(object sender, EventArgs e)
        {
            if (p.IdPedidoCompra == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados do pedido de compra antes de adicionar centros de custo.");
                return;
            }
            frmCentroCustoAux frmCC = new frmCentroCustoAux("PC", p.IdPedidoCompra);
            frmCC.pcdal = pcDal;
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

        private void rbEncargos_Click(object sender, EventArgs e)
        {
            if (p.IdPedidoCompra == 0)
            {
                Util.Aplicacao.ShowMessage("Por favor salve os dados do pedido antes de visualizar os encargos");
                return;
            }

            frmPedidoComprasAlocaEncargos frmAloc = new frmPedidoComprasAlocaEncargos(p.IdPedidoCompra);
            frmAloc.encargoDal = encargosDal;
            frmAloc.alocalDal = alocalDal;
            frmAloc.ShowDialog();
            CalculaEncargos();
        }

        private void btnVerImpostos_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value);
                frmListaImpostosCompras frmimpostos = new frmListaImpostosCompras(id);
                frmimpostos.dal = impostosDal;
                frmimpostos.ShowDialog();
            }
        }

        private void CalculaEncargos()
        {
            BLImpostoEncargosCompras blImpostos = new BLImpostoEncargosCompras();
            blImpostos.dal = new PedidoCompraItemApuracaoImpostoDAL();
            blImpostos.pedidoDal = dal;
            blImpostos.GeraEncargos(p.IdPedidoCompra);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value);
                frmListaContabilidadeCompras frmcontabilidade = new frmListaContabilidadeCompras(id);
                frmcontabilidade.ShowDialog();
            }
        }
    }
}
