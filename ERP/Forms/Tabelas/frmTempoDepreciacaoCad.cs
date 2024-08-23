using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmTempoDepreciacaoCad : RibbonForm
    {
        public TempoDepreciacaoDAL dal;
        TempoDepreciacao td = new TempoDepreciacao();

        public frmTempoDepreciacaoCad(TempoDepreciacao pTD)
        {
            td = pTD;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmTempoDepreciacaoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaGrupoAtivo();
            CarregarNivelDeLancamento();
            CarregaPDComum();
            CarregaPDAlternativa();
            CarregaPDExtraordinaria();
            CarregarConvencao();

            if (td.IdTempoDepreciacao == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmTempoDepreciacaoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = td.IdTempoDepreciacao.ToString();
            if (td.IdGrupoAtivo != null)
                cboGrupoAtivo.SelectedValue = td.IdGrupoAtivo;

            if (td.NivelLancamento != null)
                cboNivelLancamento.SelectedValue = td.NivelLancamento.ToString();

            if (td.IdPerfilDepreciacaoComum != null)
                cboPDComum.SelectedValue = td.IdPerfilDepreciacaoComum;

            if (td.IdPerfilDepreciacaoAlternativa != null)
                cboPDAlternativa.SelectedValue = td.IdPerfilDepreciacaoAlternativa;

            if (td.IdPerfilDepreciacaoExtraordinaria != null)
                cboPDExtraordinaria.SelectedValue = td.IdPerfilDepreciacaoExtraordinaria;

            txtArredondamento.Text = td.Arredondamento.ToString("N4");

            if (td.Convencao != null)
                cboConvencao.SelectedValue = td.Convencao.ToString();

            chkDepreciacao.Checked = td.Depreciacao;
            txtPeriodo.Text = td.Periodo.ToString();
            txtVidaUtil.Text = td.VidaUtil.ToString();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        protected void CarregaGrupoAtivo()
        {
            cboGrupoAtivo.DataSource = new GrupoAtivoDAL().GetCombo();
            cboGrupoAtivo.DisplayMember = "Text";
            cboGrupoAtivo.ValueMember = "iValue";
            cboGrupoAtivo.SelectedIndex = -1;
        }

        private void CarregarNivelDeLancamento()
        {
            List<DropList> lista = Util.EnumERP.CarregarNivelDeLancamento();

            cboNivelLancamento.DisplayMember = "Text";
            cboNivelLancamento.ValueMember = "Value";
            cboNivelLancamento.DataSource = lista;
            cboNivelLancamento.SelectedIndex = -1;
        }

        protected void CarregaPDComum()
        {
            cboPDComum.DataSource = new PerfilDepreciacaoDAL().GetCombo();
            cboPDComum.DisplayMember = "Text";
            cboPDComum.ValueMember = "iValue";
            cboPDComum.SelectedIndex = -1;
        }

        protected void CarregaPDAlternativa()
        {
            cboPDAlternativa.DataSource = new PerfilDepreciacaoDAL().GetCombo();
            cboPDAlternativa.DisplayMember = "Text";
            cboPDAlternativa.ValueMember = "iValue";
            cboPDAlternativa.SelectedIndex = -1;
        }

        protected void CarregaPDExtraordinaria()
        {
            cboPDExtraordinaria.DataSource = new PerfilDepreciacaoDAL().GetCombo();
            cboPDExtraordinaria.DisplayMember = "Text";
            cboPDExtraordinaria.ValueMember = "iValue";
            cboPDExtraordinaria.SelectedIndex = -1;
        }

        private void CarregarConvencao()
        {
            List<DropList> lista = Util.EnumERP.CarregarConvencao();

            cboConvencao.DisplayMember = "Text";
            cboConvencao.ValueMember = "Value";
            cboConvencao.DataSource = lista;
            cboConvencao.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            td = new TempoDepreciacao();
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

                    if (!String.IsNullOrEmpty(cboGrupoAtivo.Text))
                        td.IdGrupoAtivo = Convert.ToInt32(cboGrupoAtivo.SelectedValue);

                    if (!String.IsNullOrEmpty(cboNivelLancamento.Text))
                        td.NivelLancamento = Convert.ToInt32(cboNivelLancamento.SelectedValue);
                    else
                        td.NivelLancamento = null;

                    if (!String.IsNullOrEmpty(cboPDComum.Text))
                        td.IdPerfilDepreciacaoComum = Convert.ToInt32(cboPDComum.SelectedValue);
                    else
                        td.IdPerfilDepreciacaoComum = null;

                    if (!String.IsNullOrEmpty(cboPDAlternativa.Text))
                        td.IdPerfilDepreciacaoAlternativa = Convert.ToInt32(cboPDAlternativa.SelectedValue);
                    else
                        td.IdPerfilDepreciacaoAlternativa = null;

                    if (!String.IsNullOrEmpty(cboPDExtraordinaria.Text))
                        td.IdPerfilDepreciacaoExtraordinaria = Convert.ToInt32(cboPDExtraordinaria.SelectedValue);
                    else
                        td.IdPerfilDepreciacaoExtraordinaria = null;

                    td.Arredondamento = Convert.ToDecimal(txtArredondamento.Text);

                    if (!String.IsNullOrEmpty(cboConvencao.Text))
                        td.Convencao = Convert.ToInt32(cboConvencao.SelectedValue);
                    else
                        td.Convencao = null;

                    td.Depreciacao = chkDepreciacao.Checked;
                    td.Periodo = Convert.ToInt32(txtPeriodo.Text);
                    td.VidaUtil = Convert.ToInt32(txtVidaUtil.Text);

                    if (td.IdTempoDepreciacao == 0)
                    {
                        dal.Insert(td);
                    }
                    else
                    {
                        dal.Update(td);
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
                    int id = td.IdTempoDepreciacao;
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

        private void txtArredondamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtArredondamento.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtPeriodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtVidaUtil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
