using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmEmpresaConfiguracao : RibbonForm
    {
        Configuracao c = new Configuracao();
        ConfiguracaoDAL dal = new ConfiguracaoDAL();
        int IdEmpresa = 0;
        bool registroNovo = true;

        public frmEmpresaConfiguracao(int prtIdEmpresa)
        {
            IdEmpresa = prtIdEmpresa;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmEmpresaConfiguracao_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CarregaCombos();
            c = dal.GetByEmpresa(IdEmpresa);

            if (c != null)
            {
                CarregaDados();
                registroNovo = false;
            }
            else
            {
                c = new Configuracao();
            }

            Cursor.Current = Cursors.Default;
        }

        private void CarregaCombos()
        {
            cboModoEntregaVendas.DataSource = new ModoEntregaDAL().GetCombo();
            cboModoEntregaVendas.DisplayMember = "Text";
            cboModoEntregaVendas.ValueMember = "iValue";
            cboModoEntregaVendas.SelectedIndex = -1;

            cboModoEntregaCompras.DataSource = new ModoEntregaDAL().GetCombo();
            cboModoEntregaCompras.DisplayMember = "Text";
            cboModoEntregaCompras.ValueMember = "iValue";
            cboModoEntregaCompras.SelectedIndex = -1;

            cboGrupoArmazenamento.DataSource = new GrupoArmazenamentoDAL().GetCombo();
            cboGrupoArmazenamento.DisplayMember = "Text";
            cboGrupoArmazenamento.ValueMember = "iValue";
            cboGrupoArmazenamento.SelectedIndex = -1;

            cboGrupoArmazenamentoServico.DataSource = new GrupoArmazenamentoDAL().GetCombo();
            cboGrupoArmazenamentoServico.DisplayMember = "Text";
            cboGrupoArmazenamentoServico.ValueMember = "iValue";
            cboGrupoArmazenamentoServico.SelectedIndex = -1;

            cboGrupoEstoque.DataSource = new GrupoEstoqueDAL().GetCombo();
            cboGrupoEstoque.DisplayMember = "Text";
            cboGrupoEstoque.ValueMember = "iValue";
            cboGrupoEstoque.SelectedIndex = -1;

            cboGrupoEstoqueServico.DataSource = new GrupoEstoqueDAL().GetCombo();
            cboGrupoEstoqueServico.DisplayMember = "Text";
            cboGrupoEstoqueServico.ValueMember = "iValue";
            cboGrupoEstoqueServico.SelectedIndex = -1;

            cboGrupoRastreamento.DataSource = new GrupoRastreamentoDAL().GetCombo();
            cboGrupoRastreamento.DisplayMember = "Text";
            cboGrupoRastreamento.ValueMember = "iValue";
            cboGrupoRastreamento.SelectedIndex = -1;

            cboGrupoRastreamentoServico.DataSource = new GrupoRastreamentoDAL().GetCombo();
            cboGrupoRastreamentoServico.DisplayMember = "Text";
            cboGrupoRastreamentoServico.ValueMember = "iValue";
            cboGrupoRastreamentoServico.SelectedIndex = -1;

            cboArmazemVendas.DataSource = new ArmazemDAL().GetCombo();
            cboArmazemVendas.DisplayMember = "Text";
            cboArmazemVendas.ValueMember = "iValue";
            cboArmazemVendas.SelectedIndex = -1;

            cboArmazemCompras.DataSource = new ArmazemDAL().GetCombo();
            cboArmazemCompras.DisplayMember = "Text";
            cboArmazemCompras.ValueMember = "iValue";
            cboArmazemCompras.SelectedIndex = -1;

            cboDepositoCompras.DataSource = new DepositoDAL().GetCombo();
            cboDepositoCompras.DisplayMember = "Text";
            cboDepositoCompras.ValueMember = "iValue";
            cboDepositoCompras.SelectedIndex = -1;

            cboDepositoVendas.DataSource = new DepositoDAL().GetCombo();
            cboDepositoVendas.DisplayMember = "Text";
            cboDepositoVendas.ValueMember = "iValue";
            cboDepositoVendas.SelectedIndex = -1;

            List<ComboItem> nfAmbiente = new List<ComboItem>();
            nfAmbiente.Add(new ComboItem() { iValue = 1, Text = "Ambiente de Produção" });
            nfAmbiente.Add(new ComboItem() { iValue = 2, Text = "Ambiente de Homologação" });
            cboAmbienteNFe.DataSource = nfAmbiente;
            cboAmbienteNFe.DisplayMember = "Text";
            cboAmbienteNFe.ValueMember = "iValue";
            cboAmbienteNFe.SelectedIndex = -1;


        }

        private void frmEmpresaConfiguracao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            txtUserName.Text = c.EMailUserName;
            txtSenha.Text = c.EMailPassword;
            txtSMTP.Text = c.EMailSMTP;
            txtPort.Text = c.EMailPort;
            chkSSL.Checked = c.EMailSSL;
            cboGrupoArmazenamento.SelectedValue = c.IdGrupoArmazenamentoProduto == null ? 0 : c.IdGrupoArmazenamentoProduto;
            cboGrupoEstoque.SelectedValue = c.IdGrupoEstoqueProduto == null ? 0 : c.IdGrupoEstoqueProduto;
            cboGrupoRastreamento.SelectedValue = c.IdGrupoRastreabilidadeProduto == null ? 0 : c.IdGrupoRastreabilidadeProduto;
            cboModoEntregaVendas.SelectedValue = c.IdModoEntregaVendas == null ? 0 : c.IdModoEntregaVendas;

            cboArmazemCompras.SelectedValue = c.IdArmazemCompras == null ? 0 : c.IdArmazemCompras;
            cboDepositoCompras.SelectedValue = c.IdDepositoCompras == null ? 0 : c.IdDepositoCompras;
            cboArmazemVendas.SelectedValue = c.IdArmazemVendas == null ? 0 : c.IdArmazemVendas;
            cboDepositoVendas.SelectedValue = c.IdDepositoVendas == null ? 0 : c.IdDepositoVendas;


            cboGrupoArmazenamentoServico.SelectedValue = c.IdGrupoArmazemServico == null ? 0 : c.IdGrupoArmazemServico;
            cboGrupoEstoqueServico.SelectedValue = c.IdGrupoEstoqueServico == null ? 0 : c.IdGrupoEstoqueServico;
            cboGrupoRastreamentoServico.SelectedValue = c.IdGrupoRastreabilidadeServico == null ? 0 : c.IdGrupoRastreabilidadeServico;
            cboModoEntregaCompras.SelectedValue = c.IdModoEntregaCompras == null ? 0 : c.IdModoEntregaCompras;

            chkUsarCompras.Checked = Convert.ToBoolean(c.UsarPadraoCompras);
            chkUsarEstoque.Checked = Convert.ToBoolean(c.UsarPadraoEstoque);
            chkUsarVendas.Checked = Convert.ToBoolean(c.UsarPadraoVendas);

            txtCasasDecimais.Text = c.CasasDecimais == null ? "": c.CasasDecimais.ToString();

            txtPrazoEntrega.Text = c.PrazoEntrega == null ? "" : c.PrazoEntrega.ToString();
            chkVendasRelValorTotal.Checked = Convert.ToBoolean(c.VendasRelValorTotal);
            chkVendasRelDescontoVarejista.Checked = Convert.ToBoolean(c.VendasRelDescontoVarejista);
            chkVendasRelTotalProdutos.Checked = Convert.ToBoolean(c.VendasRelTotalProdutos);
            chkVendasRelPeso.Checked = Convert.ToBoolean(c.VendasRelPeso);
            chkVendasRelVendedor.Checked = Convert.ToBoolean(c.VendasRelVendedor);
            chkVendasRelTelevendas.Checked = Convert.ToBoolean(c.VendasRelTelevendas);

            cboAmbienteNFe.SelectedValue = c.AmbienteNFe == null ? 0 : c.AmbienteNFe;
            txtSiglaWS.Text = c.NFeSiglaWS;
            txtLicenca.Text = c.NFeLicenca;
            Cursor.Current = Cursors.Default;
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    c.IdEmpresa = IdEmpresa;
                    c.EMailUserName = txtUserName.Text;
                    c.EMailPassword = txtSenha.Text;
                    c.EMailSMTP = txtSMTP.Text;
                    c.EMailPort = txtPort.Text;
                    c.EMailSSL = chkSSL.Checked;
                    c.IdGrupoArmazenamentoProduto = null;
                    c.IdGrupoEstoqueProduto = null;
                    c.IdGrupoRastreabilidadeProduto = null;
                    c.IdModoEntregaVendas = null;

                    c.IdGrupoArmazemServico = null;
                    c.IdGrupoEstoqueServico = null;
                    c.IdGrupoRastreabilidadeServico = null;
                    c.IdModoEntregaCompras = null;
                    c.IdDepositoVendas = null;
                    c.IdDepositoCompras = null;
                    c.IdArmazemVendas = null;
                    c.IdArmazemCompras = null;


                    c.UsarPadraoCompras = chkUsarCompras.Checked;
                    c.UsarPadraoEstoque = chkUsarEstoque.Checked;
                    c.UsarPadraoVendas = chkUsarVendas.Checked;

                    c.VendasRelValorTotal = chkVendasRelValorTotal.Checked;
                    c.VendasRelDescontoVarejista = chkVendasRelDescontoVarejista.Checked;
                    c.VendasRelTotalProdutos = chkVendasRelTotalProdutos.Checked;
                    c.VendasRelPeso = chkVendasRelPeso.Checked;
                    c.VendasRelVendedor = chkVendasRelVendedor.Checked;
                    c.VendasRelTelevendas = chkVendasRelTelevendas.Checked;
                    c.AmbienteNFe = null;

                    try
                    {
                        int casas = 0;
                        if(txtCasasDecimais.Text != "")
                        {
                            casas = Convert.ToInt32(txtCasasDecimais.Text);
                            if(casas > 4)
                            {
                                Util.Aplicacao.ShowMessage("Informe ate 4 casas decimais");
                                return;
                            }
                            c.CasasDecimais = casas;
                        }
                    }
                    catch
                    {
                        Util.Aplicacao.ShowMessage("O valor informado para as casas decimais é inválido.");
                        return;
                    }



                    c.PrazoEntrega = null;
                    if (!String.IsNullOrEmpty(cboGrupoArmazenamento.Text)) c.IdGrupoArmazenamentoProduto = Convert.ToInt32(cboGrupoArmazenamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoEstoque.Text)) c.IdGrupoEstoqueProduto = Convert.ToInt32(cboGrupoEstoque.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoRastreamento.Text)) c.IdGrupoRastreabilidadeProduto = Convert.ToInt32(cboGrupoRastreamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboModoEntregaVendas.Text)) c.IdModoEntregaVendas = Convert.ToInt32(cboModoEntregaVendas.SelectedValue);

                    if (!String.IsNullOrEmpty(cboGrupoArmazenamentoServico.Text)) c.IdGrupoArmazemServico = Convert.ToInt32(cboGrupoArmazenamentoServico.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoEstoqueServico.Text)) c.IdGrupoEstoqueServico = Convert.ToInt32(cboGrupoEstoqueServico.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoRastreamentoServico.Text)) c.IdGrupoRastreabilidadeServico = Convert.ToInt32(cboGrupoRastreamentoServico.SelectedValue);
                    if (!String.IsNullOrEmpty(cboModoEntregaCompras.Text)) c.IdModoEntregaCompras = Convert.ToInt32(cboModoEntregaCompras.SelectedValue);

                    if (!String.IsNullOrEmpty(cboArmazemVendas.Text)) c.IdArmazemVendas = Convert.ToInt32(cboArmazemVendas.SelectedValue);
                    if (!String.IsNullOrEmpty(cboArmazemCompras.Text)) c.IdArmazemCompras= Convert.ToInt32(cboArmazemCompras.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDepositoVendas.Text)) c.IdDepositoVendas = Convert.ToInt32(cboDepositoVendas.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDepositoCompras.Text)) c.IdDepositoCompras = Convert.ToInt32(cboDepositoCompras.SelectedValue);
                    if (!String.IsNullOrEmpty(cboAmbienteNFe.Text))
                    {
                        c.AmbienteNFe = Convert.ToInt32(cboAmbienteNFe.SelectedValue);
                    }
                    else
                    {
                        c.AmbienteNFe = 2;
                    }

                    c.NFeSiglaWS = txtSiglaWS.Text;
                    c.NFeLicenca = txtLicenca.Text;
                    if (!String.IsNullOrEmpty(txtPrazoEntrega.Text)) c.PrazoEntrega = Convert.ToInt32(txtPrazoEntrega.Text);
                    if (registroNovo)
                    {
                        dal.Insert(c);
                    }
                    else
                    {
                        dal.Update(c);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                Util.Aplicacao.ShowMessage("Por favor verifique as informações faltantes.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
