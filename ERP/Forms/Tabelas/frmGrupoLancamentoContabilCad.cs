using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoLancamentoContabilCad : RibbonForm
    {
        public GrupoLancamentoContabilDAL dal;
        GrupoLancamentoContabil glc = new GrupoLancamentoContabil();

        public frmGrupoLancamentoContabilCad(GrupoLancamentoContabil pGLC)
        {
            glc = pGLC;
            InitializeComponent();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmGrupoLancamentoContabilCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarImpostoPagar();
            CarregarDespesaImposto();
            CarregarImpostoReceber();
            CarregarDespesaImpostoUso();
            CarregarImpostoUsoPagar();
            CarregarContaLiquidacao();
            CarregarImpostoReceberLongoPrazo();
            CarregarImpostoReceberCurtoPrazo();

            if (glc.IdGrupoLancamentoContabil == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmGrupoLancamentoContabilCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = glc.IdGrupoLancamentoContabil.ToString();
            txtDescricao.Text = glc.Descricao;
            if (glc.IdImpostoAPagar != null)
                cboImpostoPagar.SelectedValue = glc.IdImpostoAPagar;
            if (glc.IdDespesaComImposto != null)
                cboDespesaImposto.SelectedValue = glc.IdDespesaComImposto;
            if (glc.IdImpostoAReceber != null)
                cboImpostoReceber.SelectedValue = glc.IdImpostoAReceber;
            if (glc.IdDespesasImpostoUso != null)
                cboDespesaImpostoUso.SelectedValue = glc.IdDespesasImpostoUso;
            if (glc.IdImpostoSobreOUsoPagar != null)
                cboImpostoUsoPagar.SelectedValue = glc.IdImpostoSobreOUsoPagar;
            if (glc.IdContaLiquidacao != null)
                cboContaLiquidacao.SelectedValue = glc.IdContaLiquidacao;
            if (glc.IdImpostoReceberLongoPrazo != null)
                cboImpostoReceberLongoPrazo.SelectedValue = glc.IdImpostoReceberLongoPrazo;
            if (glc.IdImpostoReceberCurtoPrazo != null)
                cboImpostoReceberCurtoPrazo.SelectedValue = glc.IdImpostoReceberCurtoPrazo;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarImpostoPagar()
        {
            cboImpostoPagar.DataSource = new ContaContabilDAL().GetComboByTipo(1);
            cboImpostoPagar.DisplayMember = "Text";
            cboImpostoPagar.ValueMember = "iValue";
            cboImpostoPagar.SelectedIndex = -1;
        }

        private void CarregarDespesaImposto()
        {
            cboDespesaImposto.DataSource = new ContaContabilDAL().GetComboByTipo(1);
            cboDespesaImposto.DisplayMember = "Text";
            cboDespesaImposto.ValueMember = "iValue";
            cboDespesaImposto.SelectedIndex = -1;
        }

        private void CarregarImpostoReceber()
        {
            cboImpostoReceber.DataSource = new ContaContabilDAL().GetComboByTipo(1);
            cboImpostoReceber.DisplayMember = "Text";
            cboImpostoReceber.ValueMember = "iValue";
            cboImpostoReceber.SelectedIndex = -1;
        }

        private void CarregarDespesaImpostoUso()
        {
            cboDespesaImpostoUso.DataSource = new ContaContabilDAL().GetComboByTipo(1);
            cboDespesaImpostoUso.DisplayMember = "Text";
            cboDespesaImpostoUso.ValueMember = "iValue";
            cboDespesaImpostoUso.SelectedIndex = -1;
        }

        private void CarregarImpostoUsoPagar()
        {
            cboImpostoUsoPagar.DataSource = new ContaContabilDAL().GetComboByTipo(1);
            cboImpostoUsoPagar.DisplayMember = "Text";
            cboImpostoUsoPagar.ValueMember = "iValue";
            cboImpostoUsoPagar.SelectedIndex = -1;
        }

        private void CarregarContaLiquidacao()
        {
            cboContaLiquidacao.DataSource = new ContaContabilDAL().GetComboByTipo(1);
            cboContaLiquidacao.DisplayMember = "Text";
            cboContaLiquidacao.ValueMember = "iValue";
            cboContaLiquidacao.SelectedIndex = -1;
        }

        private void CarregarImpostoReceberLongoPrazo()
        {
            cboImpostoReceberLongoPrazo.DataSource = new ContaContabilDAL().GetComboByTipo(1);
            cboImpostoReceberLongoPrazo.DisplayMember = "Text";
            cboImpostoReceberLongoPrazo.ValueMember = "iValue";
            cboImpostoReceberLongoPrazo.SelectedIndex = -1;
        }

        private void CarregarImpostoReceberCurtoPrazo()
        {
            cboImpostoReceberCurtoPrazo.DataSource = new ContaContabilDAL().GetComboByTipo(1);
            cboImpostoReceberCurtoPrazo.DisplayMember = "Text";
            cboImpostoReceberCurtoPrazo.ValueMember = "iValue";
            cboImpostoReceberCurtoPrazo.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            glc = new GrupoLancamentoContabil();
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

                    glc.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboImpostoPagar.Text))
                        glc.IdImpostoAPagar = Convert.ToInt32(cboImpostoPagar.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDespesaImposto.Text))
                        glc.IdDespesaComImposto = Convert.ToInt32(cboDespesaImposto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboImpostoReceber.Text))
                        glc.IdImpostoAReceber = Convert.ToInt32(cboImpostoReceber.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDespesaImpostoUso.Text))
                        glc.IdDespesasImpostoUso = Convert.ToInt32(cboDespesaImpostoUso.SelectedValue);
                    if (!String.IsNullOrEmpty(cboImpostoUsoPagar.Text))
                        glc.IdImpostoSobreOUsoPagar = Convert.ToInt32(cboImpostoUsoPagar.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContaLiquidacao.Text))
                        glc.IdContaLiquidacao = Convert.ToInt32(cboContaLiquidacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboImpostoReceberLongoPrazo.Text))
                        glc.IdImpostoReceberLongoPrazo = Convert.ToInt32(cboImpostoReceberLongoPrazo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboImpostoReceberCurtoPrazo.Text))
                        glc.IdImpostoReceberCurtoPrazo = Convert.ToInt32(cboImpostoReceberCurtoPrazo.SelectedValue);

                    if (glc.IdGrupoLancamentoContabil == 0)
                    {
                        dal.Insert(glc);
                    }
                    else
                    {
                        dal.Update(glc);
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
                    int id = glc.IdGrupoLancamentoContabil;
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
