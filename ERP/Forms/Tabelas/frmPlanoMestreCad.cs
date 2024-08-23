using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPlanoMestreCad : RibbonForm
    {
        public PlanoMestreDAL dal;
        PlanoMestre pm = new PlanoMestre();

        public frmPlanoMestreCad(PlanoMestre pPM)
        {
            pm = pPM;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmPlanoMestreCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (pm.IdPlanoMestre == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmPlanoMestreCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = pm.IdPlanoMestre.ToString();
            txtCodigo.Text = pm.Codigo;
            txtDescricao.Text = pm.Descricao;

            chkIncluirEstoqueDisponivel.Checked = pm.IncluirEstoqueDisponivel;
            chkIncluirTransacoesEstoque.Checked = pm.IncluirTransacoesEstoque;
            chkIncluirCotacaoVenda.Checked = pm.IncluirCotacaoVenda;
            chkIncluirCotacaoCompra.Checked = pm.IncluirCotacaoCompra;
            chkIncluirRequisicoes.Checked = pm.IncluirRequisicoes;
            chkIncluirPrevisaoDemanda.Checked = pm.IncluirPrevisaoDemanda;
            chkIncluirPrevisaoFornecimento.Checked = pm.IncluirPrevisaoFornecimento;

            txtLimiteTempoCobertura.Text = pm.LimiteTempoCobertura.ToString();
            txtLimiteTempoCapacidade.Text = pm.LimiteTempoCapacidade.ToString();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            pm = new PlanoMestre();
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

                    pm.Codigo = txtCodigo.Text;
                    pm.Descricao = txtDescricao.Text;

                    pm.IncluirEstoqueDisponivel = chkIncluirEstoqueDisponivel.Checked;
                    pm.IncluirTransacoesEstoque = chkIncluirTransacoesEstoque.Checked;
                    pm.IncluirCotacaoVenda = chkIncluirCotacaoVenda.Checked;
                    pm.IncluirCotacaoCompra = chkIncluirCotacaoCompra.Checked;
                    pm.IncluirRequisicoes = chkIncluirRequisicoes.Checked;
                    pm.IncluirPrevisaoDemanda = chkIncluirPrevisaoDemanda.Checked;
                    pm.IncluirPrevisaoFornecimento = chkIncluirPrevisaoFornecimento.Checked;

                    pm.LimiteTempoCobertura = Convert.ToInt32(txtLimiteTempoCobertura.Text);
                    pm.LimiteTempoCapacidade = Convert.ToInt32(txtLimiteTempoCapacidade.Text);

                    if (pm.IdPlanoMestre == 0)
                    {
                        dal.Insert(pm);
                    }
                    else
                    {
                        dal.Update(pm);
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
                    int id = pm.IdPlanoMestre;
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

        private void txtLimiteTempoCobertura_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
