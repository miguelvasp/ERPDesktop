using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoCoberturaCad : RibbonForm
    {
        public GrupoCoberturaDAL dal;
        GrupoCobertura gc = new GrupoCobertura();

        public frmGrupoCoberturaCad(GrupoCobertura pGC)
        {
            gc = pGC;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmGrupoCoberturaCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarCobertura();
            CarregarReduzirPrevisao();
            CarregarStatusProducao();

            if (gc.IdGrupoCobertura == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmGrupoCoberturaCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = gc.IdGrupoCobertura.ToString();
            txtCodigo.Text = gc.Codigo;
            txtDescricao.Text = gc.Descricao;
            if (gc.Cobertura != null)
                cboCobertura.SelectedValue = gc.Cobertura.ToString();

            txtPeriodo.Text = gc.Periodo.ToString();
            txtLimiteTempo.Text = gc.LimiteTempo.ToString();
            txtDiasNegativo.Text = gc.DiasNegativo.ToString();
            txtDiasPositivo.Text = gc.DiasPositivo.ToString();
            if (gc.StatusProducao != null)
                cboStatusProducao.SelectedValue = gc.StatusProducao.ToString();

            txtLimiteTempoCobertura.Text = gc.LimiteTempoCobertura.ToString();
            txtLimiteTempoDetalhamento.Text = gc.LimiteTempoDetalhamento.ToString();
            txtLimiteTempoCapacidade.Text = gc.LimiteTempoCapacidade.ToString();
            txtLimitePlanoPrevisao.Text = gc.LimitePlanoPrevisao.ToString();
            if (gc.ReduziPrevisao != null)
                cboReduzirPrevisao.SelectedValue = gc.ReduziPrevisao.ToString();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarCobertura()
        {
            List<DropList> lista = Util.EnumERP.CarregarCobertura();

            cboCobertura.DisplayMember = "Text";
            cboCobertura.ValueMember = "Value";
            cboCobertura.DataSource = lista;
            cboCobertura.SelectedIndex = -1;
        }

        private void CarregarReduzirPrevisao()
        {
            List<DropList> lista = Util.EnumERP.CarregarReduzirPrevisao();

            cboReduzirPrevisao.DisplayMember = "Text";
            cboReduzirPrevisao.ValueMember = "Value";
            cboReduzirPrevisao.DataSource = lista;
            cboReduzirPrevisao.SelectedIndex = -1;
        }

        private void CarregarStatusProducao()
        {
            List<DropList> lista = Util.EnumERP.CarregarStatusProducao();

            cboStatusProducao.DisplayMember = "Text";
            cboStatusProducao.ValueMember = "Value";
            cboStatusProducao.DataSource = lista;
            cboStatusProducao.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            gc = new GrupoCobertura();
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

                    gc.Codigo = txtCodigo.Text;
                    gc.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboCobertura.Text))
                        gc.Cobertura = Convert.ToInt32(cboCobertura.SelectedValue);
                    gc.Periodo = Convert.ToInt32(txtPeriodo.Text);
                    gc.LimiteTempo = Convert.ToInt32(txtLimiteTempo.Text);
                    gc.DiasNegativo = Convert.ToInt32(txtDiasNegativo.Text);
                    gc.DiasPositivo = Convert.ToInt32(txtDiasPositivo.Text);
                    if (!String.IsNullOrEmpty(cboStatusProducao.Text))
                        gc.StatusProducao = Convert.ToInt32(cboStatusProducao.SelectedValue);

                    gc.LimiteTempoCobertura = Convert.ToInt32(txtLimiteTempoCobertura.Text);
                    gc.LimiteTempoDetalhamento = Convert.ToInt32(txtLimiteTempoDetalhamento.Text);
                    gc.LimiteTempoCapacidade = Convert.ToInt32(txtLimiteTempoCapacidade.Text);
                    gc.LimitePlanoPrevisao = Convert.ToInt32(txtLimitePlanoPrevisao.Text);
                    if (!String.IsNullOrEmpty(cboReduzirPrevisao.Text))
                        gc.ReduziPrevisao = Convert.ToInt32(cboReduzirPrevisao.SelectedValue);

                    if (gc.IdGrupoCobertura == 0)
                    {
                        dal.Insert(gc);
                    }
                    else
                    {
                        dal.Update(gc);
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
                    int id = gc.IdGrupoCobertura;
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

        private void txtPeriodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLimiteTempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDiasNegativo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDiasPositivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLimiteTempoCobertura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLimiteTempoDetalhamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLimiteTempoCapacidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLimitePlanoPrevisao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
