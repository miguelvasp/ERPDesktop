using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmJuridicaoImpostoCad : RibbonForm
    {
        public JuridicaoImpostoDAL dal;
        JuridicaoImposto ji = new JuridicaoImposto();

        public frmJuridicaoImpostoCad(JuridicaoImposto pJI)
        {
            ji = pJI;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmJuridicaoImpostoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarPeriodoLiquidacaoImposto();
            CarregarGrupoLancamentoContabil();
            CarregarMoeda();

            if (ji.IdJuridicaoImposto == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmJuridicaoImpostoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = ji.IdJuridicaoImposto.ToString();
            txtCodigo.Text = ji.Codigo;
            txtDescricao.Text = ji.Codigo;
            if (ji.IdPeriodoLiquidacaoImposto != null)
                cboPeriodoLiquidacaoImposto.SelectedValue = ji.IdPeriodoLiquidacaoImposto;
            if (ji.IdGrupoLancamentoContabil != null)
                cboGrupoLancamentoContabil.SelectedValue = ji.IdGrupoLancamentoContabil;
            if (ji.IdMoeda != null)
                cboMoeda.SelectedValue = ji.IdMoeda;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarPeriodoLiquidacaoImposto()
        {
            cboPeriodoLiquidacaoImposto.DataSource = new PeriodoLiquidacaoImpostoDAL().GetCombo();
            cboPeriodoLiquidacaoImposto.DisplayMember = "Text";
            cboPeriodoLiquidacaoImposto.ValueMember = "iValue";
            cboPeriodoLiquidacaoImposto.SelectedIndex = -1;
        }

        private void CarregarGrupoLancamentoContabil()
        {
            cboGrupoLancamentoContabil.DataSource = new GrupoLancamentoContabilDAL().GetCombo();
            cboGrupoLancamentoContabil.DisplayMember = "Text";
            cboGrupoLancamentoContabil.ValueMember = "iValue";
            cboGrupoLancamentoContabil.SelectedIndex = -1;
        }

        private void CarregarMoeda()
        {
            cboMoeda.DataSource = new MoedaDAL().GetCombo();
            cboMoeda.DisplayMember = "Text";
            cboMoeda.ValueMember = "iValue";
            cboMoeda.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            ji = new JuridicaoImposto();
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

                    ji.Codigo = txtCodigo.Text;
                    ji.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboPeriodoLiquidacaoImposto.Text))
                        ji.IdPeriodoLiquidacaoImposto = Convert.ToInt32(cboPeriodoLiquidacaoImposto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoLancamentoContabil.Text))
                        ji.IdGrupoLancamentoContabil = Convert.ToInt32(cboGrupoLancamentoContabil.SelectedValue);
                    if (!String.IsNullOrEmpty(cboMoeda.Text))
                        ji.IdMoeda = Convert.ToInt32(cboMoeda.SelectedValue);

                    if (ji.IdJuridicaoImposto == 0)
                    {
                        dal.Insert(ji);
                    }
                    else
                    {
                        dal.Update(ji);
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
                    int id = ji.IdJuridicaoImposto;
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
