using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPlanoPagamentoCad : RibbonForm
    {
        public PlanoPagamentoDAL dal;
        PlanoPagamentoItemDAL idal = new PlanoPagamentoItemDAL();
        PlanoPagamento pp = new PlanoPagamento();

        public frmPlanoPagamentoCad(PlanoPagamento pPag)
        {
            pp = pPag;
            InitializeComponent();

            CarregarTipoDeDistribuicao();
            CarregarPagamentoPor();
            CarregarAlocacaoImpostos();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCidadeCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (pp.IdPlanoPagamento == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmPlanoPagamentoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            txtNome.Text = pp.Nome;
            txtDescricao.Text = pp.Descricao;
            if (pp.TipoDistribuicao != null)
                cboTipoDistribuicao.SelectedValue = pp.TipoDistribuicao.ToString();
            if (pp.PagamentoPor != null)
                cboPagamentoPor.SelectedValue = pp.PagamentoPor.ToString();
            txtPeriodo.Text = pp.Periodo.ToString();
            txtNumeroPagamentos.Text = pp.NumeroPagamentos.ToString();
            txtValor.Text = pp.Valor.ToString();
            txtValorMinimo.Text = pp.ValorMinimo.ToString();
            if (pp.AlocacaoImpostos != null)
                cboAlocacaoImpostos.SelectedValue = pp.AlocacaoImpostos.ToString();

            CarregaGrid();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            pp = new PlanoPagamento();
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

                    pp.Nome = txtNome.Text;
                    pp.Descricao = txtDescricao.Text;
                    pp.TipoDistribuicao = Convert.ToInt32(cboTipoDistribuicao.SelectedValue);
                    pp.PagamentoPor = Convert.ToInt32(cboPagamentoPor.SelectedValue);
                    pp.Periodo = Convert.ToInt32(txtPeriodo.Text);
                    pp.NumeroPagamentos = Convert.ToInt32(txtNumeroPagamentos.Text);
                    pp.Valor = Convert.ToDecimal(txtValor.Text);
                    pp.ValorMinimo = Convert.ToDecimal(txtValorMinimo.Text);
                    pp.AlocacaoImpostos = Convert.ToInt32(cboAlocacaoImpostos.SelectedValue);

                    if (pp.IdPlanoPagamento == 0)
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
                    int id = pp.IdPlanoPagamento;

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

        private void CarregarTipoDeDistribuicao()
        {
            List<DropList> lista = Util.EnumERP.CarregarTipoDeDistribuicao();

            cboTipoDistribuicao.DisplayMember = "Text";
            cboTipoDistribuicao.ValueMember = "Value";
            cboTipoDistribuicao.DataSource = lista;
            cboTipoDistribuicao.SelectedIndex = -1;
        }

        private void CarregarPagamentoPor()
        {
            List<DropList> lista = Util.EnumERP.CarregarPagamentoPor();

            cboPagamentoPor.DisplayMember = "Text";
            cboPagamentoPor.ValueMember = "Value";
            cboPagamentoPor.DataSource = lista;
            cboPagamentoPor.SelectedIndex = -1;
        }

        private void CarregarAlocacaoImpostos()
        {
            List<DropList> lista = Util.EnumERP.CarregarAlocacaoImpostos();

            cboAlocacaoImpostos.DisplayMember = "Text";
            cboAlocacaoImpostos.ValueMember = "Value";
            cboAlocacaoImpostos.DataSource = lista;
            cboAlocacaoImpostos.SelectedIndex = -1;
        }

        private void txtPeriodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNumeroPagamentos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtValor.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtValorMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtValorMinimo.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtValorTransacao_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlanoPagamentoItem pi = new PlanoPagamentoItem();
            pi.IdPlanoPagamento = pp.IdPlanoPagamento;
            frmPlanoPagamentoCadAux f = new frmPlanoPagamentoCadAux(pi);
            f.dal = idal;
            f.ShowDialog();
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = idal.GetByPlanoId(pp.IdPlanoPagamento);
            dgValores.AutoGenerateColumns = false;
            dgValores.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }

        private void dgValores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgValores.Rows[dgValores.SelectedRows[0].Index].Cells[0].Value);
            PlanoPagamentoItem pi = idal.GetByID(id);
            pi.IdPlanoPagamento = pp.IdPlanoPagamento;
            frmPlanoPagamentoCadAux f = new frmPlanoPagamentoCadAux(pi);
            f.dal = idal;
            f.ShowDialog();
            CarregaGrid();
        }
    }
}
