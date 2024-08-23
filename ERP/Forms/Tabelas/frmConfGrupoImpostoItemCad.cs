using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmConfGrupoImpostoItemCad : RibbonForm
    {
        public ConfGrupoImpostoItemDAL dal;
        ConfGrupoImpostoItem cgi = new ConfGrupoImpostoItem();

        public frmConfGrupoImpostoItemCad(ConfGrupoImpostoItem pCGI)
        {
            cgi = pCGI;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmConfGrupoImpostoItemCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarCodigoTributacao();
            CarregarPercentualValor();

            cboCodigoImposto.DataSource = new CodigoImpostoDAL().GetCombo();
            cboCodigoImposto.DisplayMember = "Text";
            cboCodigoImposto.ValueMember = "iValue";
            cboCodigoImposto.SelectedIndex = -1;

            if (cgi.IdConfGrupoImpostoItem == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmConfGrupoImpostoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            cboCodigoImposto.SelectedValue = cgi.IdCodigoImposto == null ? 0 : Convert.ToInt32(cgi.IdCodigoImposto);

            if (cgi.CodigoTributacao != null)
                cboCodigoTributacao.SelectedValue = cgi.IdCodigoTributacao;
            chkSemCreditoImposto.Checked = cgi.SemCreditoImposto;
            chkIsento.Checked = cgi.Isento;
            txtPercentual.Text = cgi.PercentualValor.ToString();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarCodigoTributacao()
        {
            cboCodigoTributacao.DataSource = new CodigoTributacaoDAL().GetCombo();
            cboCodigoTributacao.DisplayMember = "Text";
            cboCodigoTributacao.ValueMember = "iValue";
            cboCodigoTributacao.SelectedIndex = -1;
        }

        private void CarregarPercentualValor()
        {
            //cboPercentualValor.DataSource = new ValoresImpostoDAL().GetCombo();
            //cboPercentualValor.DisplayMember = "Text";
            //cboPercentualValor.ValueMember = "iValue";
            //cboPercentualValor.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cgi = new ConfGrupoImpostoItem();
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

                    if (!String.IsNullOrEmpty(cboCodigoImposto.Text)) cgi.IdCodigoImposto = Convert.ToInt32(cboCodigoImposto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCodigoTributacao.Text)) cgi.IdCodigoTributacao = Convert.ToInt32(cboCodigoTributacao.SelectedValue);
                    cgi.SemCreditoImposto = chkSemCreditoImposto.Checked;
                    cgi.Isento = chkIsento.Checked;
                    if (!String.IsNullOrEmpty(txtPercentual.Text)) cgi.PercentualValor = Convert.ToDecimal(txtPercentual.Text);

                    if (cgi.IdConfGrupoImpostoItem == 0)
                    {
                        dal.Insert(cgi);
                    }
                    else
                    {
                        dal.Update(cgi);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    this.Close();
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
                    int id = cgi.IdConfGrupoImpostoItem;
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

        private void cboCodigoImposto_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboCodigoImposto.Text))
            {
                CodigoImposto c = new CodigoImpostoDAL().GetByID(Convert.ToInt32(cboCodigoImposto.SelectedValue));
                if (c != null)
                {
                    txtPercentual.Text = c.PercentualValor == null ? "" : c.PercentualValor.ToString();
                }
            }
        }
    }
}
