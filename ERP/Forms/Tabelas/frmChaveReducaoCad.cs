using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmChaveReducaoCad : RibbonForm
    {
        public ChaveReducaoDAL dal;
        ChaveReducao cr = new ChaveReducao();

        public frmChaveReducaoCad(ChaveReducao pCR)
        {
            cr = pCR;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmChaveReducaoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            LimparCamposDatas();
            CarregarUnidade();

            if (cr.IdChaveReducao == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmChaveReducaoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = cr.IdChaveReducao.ToString();
            txtCodigo.Text = cr.Codigo;
            txtDescricao.Text = cr.Descricao;
            chkFixo.Checked = cr.Fixo;
            if (cr.Unidade != null)
                cboUnidade.SelectedValue = cr.Unidade.ToString();

            txtFator.Text = cr.Fator.ToString("N4");

            if (cr.DataInicial != null && cr.DataInicial != DateTime.MinValue)
                dtpDataInicial.Value = cr.DataInicial;

            if (cr.De != null && cr.De != DateTime.MinValue)
                dtpDe.Value = cr.De;

            if (cr.Ate != null && cr.Ate != DateTime.MinValue)
                dtpAte.Value = cr.Ate;

            txtMes.Text = cr.Mes.ToString();

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

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cr = new ChaveReducao();
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

                    cr.Codigo = txtCodigo.Text;
                    cr.Descricao = txtDescricao.Text;
                    cr.Fixo = chkFixo.Checked;
                    cr.DataInicial = DateTime.Parse(dtpDataInicial.Value.ToString("dd/MM/yyyy"));
                    if (!String.IsNullOrEmpty(cboUnidade.Text))
                        cr.Unidade = Convert.ToInt32(cboUnidade.SelectedValue);

                    cr.Fator = Convert.ToDecimal(txtFator.Text);

                    cr.De = DateTime.Parse(dtpDe.Value.ToString("dd/MM/yyyy"));
                    cr.Ate = DateTime.Parse(dtpAte.Value.ToString("dd/MM/yyyy"));

                    cr.Mes = Convert.ToInt32(txtMes.Text);

                    if (cr.IdChaveReducao == 0)
                    {
                        dal.Insert(cr);
                    }
                    else
                    {
                        dal.Update(cr);
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
                    int id = cr.IdChaveReducao;
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