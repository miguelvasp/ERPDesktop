using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmRoyaltiesCad : RibbonForm
    {
        public RoyaltiesDAL dal;
        Royalties ryl = new Royalties();

        public frmRoyaltiesCad(Royalties pRyl)
        {
            ryl = pRyl;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmRoyaltiesCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            LimparCamposDatas();
            CarregarCalculo();

            if (ryl.IdRoyalties == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmRoyaltiesCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = ryl.IdRoyalties.ToString();
            txtDescricao.Text = ryl.Descricao;
            if (ryl.Calculo != null)
                cboCalculo.SelectedValue = ryl.Calculo.ToString();

            txtPercentual.Text = ryl.Percentual.ToString("N4");

            if (ryl.De != null && ryl.De != DateTime.MinValue)
                dtpDe.Value = ryl.De.Value;


            if (ryl.Ate != null && ryl.Ate != DateTime.MinValue)
                dtpAte.Value = ryl.Ate.Value;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarCalculo()
        {
            List<DropList> lista = Util.EnumERP.CarregarCalculoDeComissaoDesconto();

            cboCalculo.DisplayMember = "Text";
            cboCalculo.ValueMember = "Value";
            cboCalculo.DataSource = lista;
            cboCalculo.SelectedIndex = -1;
        }

        private void LimparCamposDatas()
        {
            dtpDe.Checked = false;
            // dtpDe.CustomFormat = " ";
            // dtpDe.Format = DateTimePickerFormat.Custom;

            dtpAte.Checked = false;
            //dtpAte.CustomFormat = " ";
            //dtpAte.Format = DateTimePickerFormat.Custom;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            ryl = new Royalties();
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

                    ryl.Descricao = txtDescricao.Text;

                    if (!String.IsNullOrEmpty(cboCalculo.Text))
                        ryl.Calculo = Convert.ToInt32(cboCalculo.SelectedValue);

                    ryl.Percentual = Convert.ToDecimal(txtPercentual.Text);

                    if (dtpDe.Checked)
                        ryl.De = dtpDe.Value;

                    if (dtpAte.Checked)
                        ryl.Ate = dtpAte.Value;

                    if (ryl.IdRoyalties == 0)
                    {
                        dal.Insert(ryl);
                    }
                    else
                    {
                        dal.Update(ryl);
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
                    int id = ryl.IdRoyalties;
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

        private void txtPercentual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtPercentual.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void dtpDe_ValueChanged(object sender, EventArgs e)
        {
            //if (!dtpDe.Checked)
            //{
            //    dtpDe.CustomFormat = " ";
            //    dtpDe.Format = DateTimePickerFormat.Custom;
            //}
            //else
            //{
            //    dtpDe.CustomFormat = null;
            //    dtpDe.Format = DateTimePickerFormat.Short;
            //}
        }

        private void dtpAte_ValueChanged(object sender, EventArgs e)
        {
            //if (!dtpAte.Checked)
            //{
            //    dtpAte.CustomFormat = " ";
            //    dtpAte.Format = DateTimePickerFormat.Custom;
            //}
            //else
            //{
            //    dtpAte.CustomFormat = null;
            //    dtpAte.Format = DateTimePickerFormat.Short;
            //}
        }
    }
}
