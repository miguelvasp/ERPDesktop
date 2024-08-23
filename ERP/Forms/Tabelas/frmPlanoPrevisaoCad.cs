using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPlanoPrevisaoCad : RibbonForm
    {
        public PlanoPrevisaoDAL dal;
        PlanoPrevisao pp = new PlanoPrevisao();

        public frmPlanoPrevisaoCad(PlanoPrevisao pPP)
        {
            pp = pPP;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmPlanoPrevisaoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarReducao();

            if (pp.IdPlanoPrevisao == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmPlanoPrevisaoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = pp.IdPlanoPrevisao.ToString();
            txtCodigo.Text = pp.Codigo;
            txtDescricao.Text = pp.Descricao;
            chkIncluirPrevisaoFornecimento.Checked = pp.IncluirPrevisaoFornecimento;
            chkIncluirPrevisaoDemanda.Checked = pp.IncluirPrevisaoDemanda;
            txtLimiteTempoCobertura.Text = pp.LimiteTempoCobertura.ToString();
            txtLimiteTempoCapacidade.Text = pp.LimiteTempoCapacidade.ToString();
            txtLimiteTempoDetalhamento.Text = pp.LimiteTempoDetalhamento.ToString();
            txtSequenciaOrdensPlanejada.Text = pp.SequenciaOrdemPlanejadas;

            if (pp.Reducao != null)
                cboReducao.SelectedValue = pp.Reducao.ToString();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarReducao()
        {
            List<DropList> lista = Util.EnumERP.CarregarReducao();

            cboReducao.DisplayMember = "Text";
            cboReducao.ValueMember = "Value";
            cboReducao.DataSource = lista;
            cboReducao.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            pp = new PlanoPrevisao();
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

                    pp.Codigo = txtCodigo.Text;
                    pp.Descricao = txtDescricao.Text;
                    pp.IncluirPrevisaoFornecimento = chkIncluirPrevisaoFornecimento.Checked;
                    pp.IncluirPrevisaoDemanda = chkIncluirPrevisaoDemanda.Checked;
                    pp.LimiteTempoCobertura = Convert.ToInt32(txtLimiteTempoCobertura.Text);
                    pp.LimiteTempoCapacidade = Convert.ToInt32(txtLimiteTempoCapacidade.Text);
                    pp.LimiteTempoDetalhamento = Convert.ToInt32(txtLimiteTempoDetalhamento.Text);
                    pp.SequenciaOrdemPlanejadas = txtSequenciaOrdensPlanejada.Text;

                    if (!String.IsNullOrEmpty(cboReducao.Text))
                        pp.Reducao = Convert.ToInt32(cboReducao.SelectedValue);

                    if (pp.IdPlanoPrevisao == 0)
                    {
                        dal.Insert(pp);
                    }
                    else
                    {
                        dal.Update(pp);
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
                    int id = pp.IdPlanoPrevisao;
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

        private void txtLimiteTempoDetalhamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}