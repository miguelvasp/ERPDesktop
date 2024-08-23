using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoFornecedorCad : RibbonForm
    {
        public GrupoFornecedorDAL dal;
        GrupoFornecedor gf = new GrupoFornecedor();
        GrupoImpostoDAL gidal = new GrupoImpostoDAL();

        public frmGrupoFornecedorCad(GrupoFornecedor pGF)
        {
            gf = pGF;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmGrupoFornecedorCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var gis = gidal.Get().OrderBy(o => o.Descricao).ToList();
            cboGrupoImpostos.DataSource = gis;
            cboGrupoImpostos.ValueMember = "IdGrupoImposto";
            cboGrupoImpostos.DisplayMember = "Descricao";
            cboGrupoImpostos.SelectedIndex = -1;

            CarregarCondicaoPagamento();
            CarregaPeriodoLiquidacaoImposto();

            if (gf.IdGrupoFornecedor == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmGrupoFornecedorCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = gf.IdGrupoFornecedor.ToString();
            txtDescricao.Text = gf.Descricao;
            cboCondicaoPgto.SelectedValue = gf.IdCondicaoPagamento == null ? 0 : Convert.ToInt32(gf.IdCondicaoPagamento);
            cboGrupoImpostos.SelectedValue = gf.IdGrupoImposto == null ? 0 : Convert.ToInt32(gf.IdGrupoImposto);
            if (gf.IdPeriodoLiquidacaoImposto != null)
                cboPeriodoLiquidacaoImposto.SelectedValue = gf.IdPeriodoLiquidacaoImposto;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarCondicaoPagamento()
        {
            cboCondicaoPgto.DataSource = new CondicaoPagamentoDAL().GetCombo();
            cboCondicaoPgto.DisplayMember = "Text";
            cboCondicaoPgto.ValueMember = "iValue";
            cboCondicaoPgto.SelectedIndex = -1;
        }

        protected void CarregaPeriodoLiquidacaoImposto()
        {
            cboPeriodoLiquidacaoImposto.DataSource = new PeriodoLiquidacaoImpostoDAL().GetCombo();
            cboPeriodoLiquidacaoImposto.DisplayMember = "Text";
            cboPeriodoLiquidacaoImposto.ValueMember = "iValue";
            cboPeriodoLiquidacaoImposto.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            gf = new GrupoFornecedor();
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

                    gf.IdCondicaoPagamento = null;
                    gf.IdGrupoImposto = null;
                    gf.IdPeriodoLiquidacaoImposto = null;
                    gf.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboCondicaoPgto.Text)) gf.IdCondicaoPagamento = Convert.ToInt32(cboCondicaoPgto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoImpostos.Text)) gf.IdGrupoImposto = Convert.ToInt32(cboGrupoImpostos.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPeriodoLiquidacaoImposto.Text)) gf.IdPeriodoLiquidacaoImposto = Convert.ToInt32(cboPeriodoLiquidacaoImposto.SelectedValue);

                    if (gf.IdGrupoFornecedor == 0)
                    {
                        dal.Insert(gf);
                    }
                    else
                    {
                        dal.Update(gf);
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
                    int id = gf.IdGrupoFornecedor;

                    dal.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    this.Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
            }
        }
    }
}