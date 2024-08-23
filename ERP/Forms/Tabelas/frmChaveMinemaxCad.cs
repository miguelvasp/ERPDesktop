using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmChaveMinemaxCad : RibbonForm
    {
        public ChaveMinemaxDAL dal;
        ChaveMinemax cm = new ChaveMinemax();

        public frmChaveMinemaxCad(ChaveMinemax pCM)
        {
            cm = pCM;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmChaveMinemaxCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            LimparCamposDatas();
            CarregarUnidade();

            if (cm.IdChaveMinemax == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmChaveMinemaxCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void LimparCamposDatas()
        {
            dtpDataInicial.Checked = true;
            dtpDataInicial.CustomFormat = " ";
            dtpDataInicial.Format = DateTimePickerFormat.Custom;

            dtpDe.Checked = true;
            dtpDe.CustomFormat = " ";
            dtpDe.Format = DateTimePickerFormat.Custom;

            dtpAte.Checked = true;
            dtpAte.CustomFormat = " ";
            dtpAte.Format = DateTimePickerFormat.Custom;
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = cm.IdChaveMinemax.ToString();
            txtCodigo.Text = cm.Codigo;
            txtDescricao.Text = cm.Descricao;
            chkFixo.Checked = cm.Fixo;
            if (cm.Unidade != null)
                cboUnidade.SelectedValue = cm.Unidade.ToString();

            txtFator.Text = cm.Fator.ToString("N4");

            if (cm.DataInicial != null && cm.DataInicial != DateTime.MinValue)
                dtpDataInicial.Value = cm.DataInicial;

            if (cm.De != null && cm.De != DateTime.MinValue)
                dtpDe.Value = cm.De;

            if (cm.Ate != null && cm.Ate != DateTime.MinValue)
                dtpAte.Value = cm.Ate;

            txtMes.Text = cm.Mes.ToString();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarUnidade()
        {
            List<DropList> lista = Util.EnumERP.CarregarPagamentoPor();

            cboUnidade.DisplayMember = "Text";
            cboUnidade.ValueMember = "Value";
            cboUnidade.DataSource = lista;
            cboUnidade.SelectedIndex = -1;
        }


        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cm = new ChaveMinemax();
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

                    cm.Codigo = txtCodigo.Text;
                    cm.Descricao = txtDescricao.Text;
                    cm.Fixo = chkFixo.Checked;
                    cm.DataInicial = DateTime.Parse(dtpDataInicial.Value.ToString("dd/MM/yyyy"));
                    if (!String.IsNullOrEmpty(cboUnidade.Text))
                        cm.Unidade = Convert.ToInt32(cboUnidade.SelectedValue);

                    cm.Fator = Convert.ToDecimal(txtFator.Text);

                    cm.De = DateTime.Parse(dtpDe.Value.ToString("dd/MM/yyyy"));
                    cm.Ate = DateTime.Parse(dtpAte.Value.ToString("dd/MM/yyyy"));

                    cm.Mes = Convert.ToInt32(txtMes.Text);

                    if (cm.IdChaveMinemax == 0)
                    {
                        dal.Insert(cm);
                    }
                    else
                    {
                        dal.Update(cm);
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
            if (Util.Aplicacao.ShowQuestionMessage("Qualquer alteração efetuada será perdida, deseja continuar?") == DialogResult.Yes)
            {
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == DialogResult.Yes)
            {
                try
                {
                    int id = cm.IdChaveMinemax;
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

        private void txtFator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtFator.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dtpDataInicial_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpDataInicial.Checked)
            {
                dtpDataInicial.CustomFormat = " ";
                dtpDataInicial.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpDataInicial.CustomFormat = null;
                dtpDataInicial.Format = DateTimePickerFormat.Short;
            }

        }

        private void dtpDe_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpDe.Checked)
            {
                dtpDe.CustomFormat = " ";
                dtpDe.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpDe.CustomFormat = null;
                dtpDe.Format = DateTimePickerFormat.Short;
            }
        }

        private void dtpAte_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpAte.Checked)
            {
                dtpAte.CustomFormat = " ";
                dtpAte.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpAte.CustomFormat = null;
                dtpAte.Format = DateTimePickerFormat.Short;
            }
        }
    }
}