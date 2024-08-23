using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoClienteCad : RibbonForm
    {
        public GrupoClienteDAL dal;
        GrupoCliente gc = new GrupoCliente();
        GrupoImpostoDAL gidal = new GrupoImpostoDAL();

        public frmGrupoClienteCad(GrupoCliente gCliente)
        {
            gc = gCliente;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmGrupoClienteCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var gis = gidal.Get().OrderBy(o => o.Descricao).ToList();
            cboGrupoImpostos.DataSource = gis;
            cboGrupoImpostos.ValueMember = "IdGrupoImposto";
            cboGrupoImpostos.DisplayMember = "Descricao";
            cboGrupoImpostos.SelectedIndex = -1;

            CarregarCondicaoPagamento();
            CarregaPeriodoLiquidacaoImposto();

            if (gc.IdGrupoCliente == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmGrupoClienteCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = gc.IdGrupoCliente.ToString();
            txtDescricao.Text = gc.Descricao;
            cboCondicaoPgto.SelectedValue = gc.IdCondicaoPagamento == null ? 0 : Convert.ToInt32(gc.IdCondicaoPagamento);
            cboGrupoImpostos.SelectedValue = gc.IdGrupoImposto == null ? 0 : Convert.ToInt32(gc.IdGrupoImposto);
            if (gc.IdPeriodoLiquidacaoImposto != null)
                cboPeriodoLiquidacaoImposto.SelectedValue = gc.IdPeriodoLiquidacaoImposto;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            txtPercentualDesconto.Text = gc.PercentualDesconto.ToString();
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
            gc = new GrupoCliente();
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

                    gc.IdCondicaoPagamento = null;
                    gc.IdGrupoImposto = null;
                    gc.IdPeriodoLiquidacaoImposto = null;
                    gc.Descricao = txtDescricao.Text;
                    gc.PercentualDesconto = Convert.ToDecimal(txtPercentualDesconto.Text);

                    if (!String.IsNullOrEmpty(cboCondicaoPgto.Text)) gc.IdCondicaoPagamento = Convert.ToInt32(cboCondicaoPgto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoImpostos.Text)) gc.IdGrupoImposto = Convert.ToInt32(cboGrupoImpostos.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPeriodoLiquidacaoImposto.Text))
                        gc.IdPeriodoLiquidacaoImposto = Convert.ToInt32(cboPeriodoLiquidacaoImposto.SelectedValue);

                    if (gc.IdGrupoCliente == 0)
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
                    int id = gc.IdGrupoCliente;

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