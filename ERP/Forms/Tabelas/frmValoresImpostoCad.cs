using ERP.DAL;
using ERP.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmValoresImpostoCad : RibbonForm
    {
        public ValoresImpostoDAL dal;
        ValoresImposto vi = new ValoresImposto();

        public frmValoresImpostoCad(ValoresImposto pVI)
        {
            vi = pVI;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmValoresImpostoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarCodigoImposto();

            if (vi.IdValoresImposto == 0)
            {
                if (Convert.ToInt32(vi.IdCodigoImposto) > 0)
                {
                    cboCodigoImposto.SelectedValue = vi.IdCodigoImposto;
                }
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmValoresImpostoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = vi.IdValoresImposto.ToString();
            if (vi.IdCodigoImposto != null)
                cboCodigoImposto.SelectedValue = vi.IdCodigoImposto;

            if (vi.De != null && vi.De != DateTime.MinValue)
                txtDe.Text = vi.De.ToString();

            if (vi.Ate != null && vi.Ate != DateTime.MinValue)
                txtAte.Text = vi.Ate.ToString();

            txtLimiteMinimo.Text = vi.LimiteMinimo.ToString("N4");
            txtLimiteMaximo.Text = vi.LimiteMaximo.ToString("N4");
            txtAliquota.Text = vi.Aliquota.ToString("N4");
            txtPercentualReducao.Text = vi.PercentualReducao.ToString("N4");
            txtPercentualIsencao.Text = vi.PercentualIsencao.ToString("N4");
            txtMarkup.Text = vi.Markup.ToString("N4");

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarCodigoImposto()
        {
            cboCodigoImposto.DataSource = new CodigoImpostoDAL().GetCombo();
            cboCodigoImposto.DisplayMember = "Text";
            cboCodigoImposto.ValueMember = "iValue";
            cboCodigoImposto.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            vi = new ValoresImposto();
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

                    if (!String.IsNullOrEmpty(cboCodigoImposto.Text))
                    vi.IdCodigoImposto = Convert.ToInt32(cboCodigoImposto.SelectedValue);
                    vi.LimiteMinimo = Convert.ToDecimal(txtLimiteMinimo.Text);
                    vi.LimiteMaximo = Convert.ToDecimal(txtLimiteMaximo.Text);
                    vi.Aliquota = Convert.ToDecimal(txtAliquota.Text);
                    vi.PercentualReducao = Convert.ToDecimal(txtPercentualReducao.Text);
                    vi.PercentualIsencao = Convert.ToDecimal(txtPercentualIsencao.Text);
                    vi.Markup = Convert.ToDecimal(txtMarkup.Text);
                    vi.De = Convert.ToDateTime(txtDe.Text);
                    vi.Ate = Convert.ToDateTime(txtAte.Text);

                    if (!dal.VerificaDatas(Convert.ToDateTime(vi.De), Convert.ToDateTime(vi.Ate), Convert.ToInt32(vi.IdCodigoImposto)))
                    {
                        Util.Aplicacao.ShowMessage("O período informado ja está em uso.");
                        return;
                    }

                    if (vi.IdValoresImposto == 0)
                    {
                        dal.Insert(vi);
                    }
                    else
                    {
                        dal.Update(vi);
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
                    int id = vi.IdValoresImposto;
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

        private void txtLimiteMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtLimiteMinimo.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtLimiteMaximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtLimiteMaximo.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtMarkup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtMarkup.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtPercentualIsencao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtPercentualIsencao.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtAliquota_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtAliquota.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtPercentualReducao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtPercentualReducao.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
    }
}