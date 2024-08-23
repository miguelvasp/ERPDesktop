using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCodigoProdutoExternoCad : RibbonForm
    {
        public CodigoProdutoExternoDAL dal;
        CodigoProdutoExterno cpe = new CodigoProdutoExterno();

        public frmCodigoProdutoExternoCad(CodigoProdutoExterno pCPE)
        {
            cpe = pCPE;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCodigoProdutoExternoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaCliente();
            CarregaFornecedor();
            CarregaProduto();
            CarregaCor();
            CarregaTamanho();

            if (cpe.IdCodigoProdutoExterno == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmCodigoProdutoExternoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = cpe.IdCodigoProdutoExterno.ToString();
            txtNumeroExterno.Text = cpe.NumeroExterno;
            txtDescricao.Text = cpe.Descricao;

            if (cpe.IdCliente != null)
                cboCliente.SelectedValue = cpe.IdCliente;
            if (cpe.IdFornecedor != null)
                cboFornecedor.SelectedValue = cpe.IdFornecedor;
            chkCodigoPadrao.Checked = cpe.CodigoPadrao;
            if (cpe.IdProduto != null)
                cboProduto.SelectedValue = cpe.IdProduto;
            if (cpe.IdVariantesCor != null)
                cboCor.SelectedValue = cpe.IdVariantesCor;
            if (cpe.IdVariantesTamanho != null)
                cboTamanho.SelectedValue = cpe.IdVariantesTamanho;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        protected void CarregaCliente()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboCliente.DataSource = new ClienteDAL().GetCombo(sEmpresa);
            cboCliente.DisplayMember = "Text";
            cboCliente.ValueMember = "iValue";
            cboCliente.SelectedIndex = -1;
        }

        protected void CarregaFornecedor()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(sEmpresa);
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;
        }

        protected void CarregaProduto()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboProduto.DataSource = new ProdutoDAL().getProdutosCombo(1, sEmpresa);
            cboProduto.DisplayMember = "Codigo";
            cboProduto.ValueMember = "IdProduto";
            cboProduto.SelectedIndex = -1;
        }

        protected void CarregaCor()
        {
            cboCor.DataSource = new VariantesCorDAL().GetCombo();
            cboCor.DisplayMember = "Text";
            cboCor.ValueMember = "iValue";
            cboCor.SelectedIndex = -1;
        }

        protected void CarregaTamanho()
        {
            cboTamanho.DataSource = new VariantesTamanhoDAL().GetCombo();
            cboTamanho.DisplayMember = "Text";
            cboTamanho.ValueMember = "iValue";
            cboTamanho.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cpe = new CodigoProdutoExterno();
            lbCodigo.Text = "0";
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    cpe.NumeroExterno = txtNumeroExterno.Text;
                    cpe.Descricao = txtDescricao.Text;

                    if (!String.IsNullOrEmpty(cboCliente.Text))
                        cpe.IdCliente = Convert.ToInt32(cboCliente.SelectedValue);
                    else
                        cpe.IdCliente = null;

                    if (!String.IsNullOrEmpty(cboFornecedor.Text))
                        cpe.IdFornecedor = Convert.ToInt32(cboFornecedor.SelectedValue);


                    cpe.CodigoPadrao = chkCodigoPadrao.Checked;

                    if (!String.IsNullOrEmpty(cboProduto.Text))
                        cpe.IdProduto = Convert.ToInt32(cboProduto.SelectedValue);

                    if (!String.IsNullOrEmpty(cboCor.Text))
                        cpe.IdVariantesCor = Convert.ToInt32(cboCor.SelectedValue);
                    else
                        cpe.IdVariantesCor = null;

                    if (!String.IsNullOrEmpty(cboTamanho.Text))
                        cpe.IdVariantesTamanho = Convert.ToInt32(cboTamanho.SelectedValue);
                    else
                        cpe.IdVariantesTamanho = null;

                    if (cpe.IdCodigoProdutoExterno == 0)
                    {
                        dal.Insert(cpe);
                    }
                    else
                    {
                        dal.Update(cpe);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
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
            if (Util.Aplicacao.ShowQuestionMessage("Qualquer alteração efetuada será perdida, deseja continuar?") == System.Windows.Forms.DialogResult.Yes)
            {
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    int id = cpe.IdCodigoProdutoExterno;
                    dal.Delete(id);
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
}
