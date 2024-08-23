using ERP.DAL;
using ERP.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmValoresImpostoRetidoCad : RibbonForm
    {
        public ValoresImpostoRetidoDAL dal;
        ValoresImpostoRetido vi = new ValoresImpostoRetido();

        public frmValoresImpostoRetidoCad(ValoresImpostoRetido pVIR)
        {
            vi = pVIR;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmValoresImpostoRetidoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (vi.IdValoresImpostoRetido == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmValoresImpostoRetidoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (vi.De != null && vi.De != DateTime.MinValue)
                dtpDe.Value = vi.De.Value;

            if (vi.Ate != null && vi.Ate != DateTime.MinValue)
                dtpAte.Value = vi.Ate.Value;

            txtLimiteMinimo.Text = vi.LimiteMinimo.Value.ToString("N4");
            txtLimiteMaximo.Text = vi.LimiteMaximo.Value.ToString("N4");
            txtAliquota.Text = vi.Aliquota.Value.ToString("N4");
            txtPercentualExclusao.Text = vi.PercentualExclusao.Value.ToString("N4");
            txtDeducaoIRRF.Text = vi.DeducaoIRRF.Value.ToString("N4");

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            vi = new ValoresImpostoRetido();

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

                    vi.LimiteMinimo = Convert.ToDecimal(txtLimiteMinimo.Text);
                    vi.LimiteMaximo = Convert.ToDecimal(txtLimiteMaximo.Text);
                    vi.Aliquota = Convert.ToDecimal(txtAliquota.Text);
                    vi.PercentualExclusao = Convert.ToDecimal(txtPercentualExclusao.Text);
                    vi.DeducaoIRRF = Convert.ToDecimal(txtDeducaoIRRF.Text);
                    if (dtpDe.Checked)
                    {
                        vi.De = Convert.ToDateTime(dtpDe.Value.ToShortDateString() + " 00:00:00");
                    }
                    else
                    {
                        vi.De = null;
                    }

                    if (dtpAte.Checked)
                    {
                        vi.Ate = Convert.ToDateTime(dtpAte.Value.ToShortDateString() + " 23:59:00");
                    }
                    else
                    {
                        vi.Ate = null;
                    }

                    if (vi.De != null && vi.Ate != null)
                    {
                        if (vi.De > vi.Ate || vi.De == vi.Ate)
                        {
                            Util.Aplicacao.ShowMessage("Verifique as datas informadas!");
                            return;
                        }

                        if (!dal.VerificaDatas(Convert.ToDateTime(vi.De), Convert.ToDateTime(vi.Ate), Convert.ToInt32(vi.IdCodigoImpostoRetido)))
                        {
                            Util.Aplicacao.ShowMessage("O período informado ja está em uso.");
                            return;
                        }
                    }

                    if (vi.IdValoresImpostoRetido == 0)
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
                    int id = vi.IdValoresImpostoRetido;
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

        private void txtPercentualExclusao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtPercentualExclusao.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtDeducaoIRRF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtDeducaoIRRF.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
    }
}