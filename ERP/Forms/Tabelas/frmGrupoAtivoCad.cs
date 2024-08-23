using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoAtivoCad : RibbonForm
    {
        public GrupoAtivoDAL dal;
        GrupoAtivo ga = new GrupoAtivo();

        public frmGrupoAtivoCad(GrupoAtivo pGA)
        {
            ga = pGA;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmGrupoAtivoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarTipoGrupoAtivo();
            CarregarTipoPropriedade();

            if (ga.IdGrupoAtivo == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmGrupoAtivoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = ga.IdGrupoAtivo.ToString();
            txtCodigo.Text = ga.Codigo;
            txtDescricao.Text = ga.Descricao;
            txtSequenciaNumerica.Text = ga.SequenciaAtivo;
            txtSequenciaNumericaCodigoBarras.Text = ga.SequenciaCodigoBarras;
            chkNumerarCodigoBarras.Checked = ga.NumerarCodigoBarras;

            if (ga.Tipo != null)
                cboTipo.SelectedValue = ga.Tipo.ToString();

            if (ga.TipoPropriedade != null)
                cboTipoPropriedade.SelectedValue = ga.TipoPropriedade.ToString();

            txtParcelasDoCredito.Text = ga.ParcelasDoCredito.ToString();

            if (ga.LimiteCapitalizacao != null)
                txtLimiteCapitalizacao.Text = ga.LimiteCapitalizacao.Value.ToString("N4");

            chkCreditoICMS.Checked = ga.CreditoICMS;
            chkCreditoPisCofins.Checked = ga.CreditoPisCofins;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarTipoGrupoAtivo()
        {
            List<DropList> lista = Util.EnumERP.CarregarTipoGrupoAtivo();

            cboTipo.DisplayMember = "Text";
            cboTipo.ValueMember = "Value";
            cboTipo.DataSource = lista;
            cboTipo.SelectedIndex = -1;
        }

        private void CarregarTipoPropriedade()
        {
            List<DropList> lista = Util.EnumERP.CarregarTipoPropriedade();

            cboTipoPropriedade.DisplayMember = "Text";
            cboTipoPropriedade.ValueMember = "Value";
            cboTipoPropriedade.DataSource = lista;
            cboTipoPropriedade.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            ga = new GrupoAtivo();
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

                    ga.Codigo = txtCodigo.Text;
                    ga.Descricao = txtDescricao.Text;
                    ga.SequenciaAtivo = txtSequenciaNumerica.Text;
                    ga.SequenciaCodigoBarras = txtSequenciaNumericaCodigoBarras.Text;
                    ga.NumerarCodigoBarras = chkNumerarCodigoBarras.Checked;

                    if (!String.IsNullOrEmpty(cboTipo.Text))
                        ga.Tipo = Convert.ToInt32(cboTipo.SelectedValue);

                    if (!String.IsNullOrEmpty(cboTipoPropriedade.Text))
                        ga.TipoPropriedade = Convert.ToInt32(cboTipoPropriedade.SelectedValue);

                    ga.ParcelasDoCredito = Convert.ToInt32(txtParcelasDoCredito.Text);

                    if (!String.IsNullOrEmpty(txtLimiteCapitalizacao.Text))
                        ga.LimiteCapitalizacao = Convert.ToDecimal(txtLimiteCapitalizacao.Text);

                    ga.CreditoICMS = chkCreditoICMS.Checked;
                    ga.CreditoPisCofins = chkCreditoPisCofins.Checked;

                    if (ga.IdGrupoAtivo == 0)
                    {
                        dal.Insert(ga);
                    }
                    else
                    {
                        dal.Update(ga);
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
                    int id = ga.IdGrupoAtivo;
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

        private void txtLimiteCapitalizacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtLimiteCapitalizacao.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtParcelasDoCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
