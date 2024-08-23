using ERP.Auxiliares;
using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmDiasPagamentoCad : RibbonForm
    {
        public DiasPagamentoDAL dal;
        DiasPagamentoItemDAL idal = new DiasPagamentoItemDAL();
        DiasPagamento dp = new DiasPagamento();


        public frmDiasPagamentoCad(DiasPagamento dPgto)
        {
            dp = dPgto;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmDiasPagamentoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (dp.IdDiasPagamento == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmDiasPagamentoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            txtNome.Text = dp.Nome;
            CarregaGrid();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            dp = new DiasPagamento();

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

                    dp.Nome = txtNome.Text;

                    if (dp.IdDiasPagamento == 0)
                    {
                        dal.Insert(dp);
                    }
                    else
                    {
                        dal.Update(dp);
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
                    int id = dp.IdDiasPagamento;

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


        private void txtDiaMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DiasPagamentoItem i = new DiasPagamentoItem();
            i.IdDiasPagamento = dp.IdDiasPagamento;
            frmDiasPagamentoCadAux f = new frmDiasPagamentoCadAux(i);
            f.dal = idal;
            f.ShowDialog();
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = idal.GetByDiaId(dp.IdDiasPagamento);
            dgDias.AutoGenerateColumns = false;
            dgDias.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }

        private void dgDias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgDias.Rows[dgDias.SelectedRows[0].Index].Cells[0].Value);
            DiasPagamentoItem i = idal.GetByID(id);
            i.IdDiasPagamento = dp.IdDiasPagamento;
            frmDiasPagamentoCadAux f = new frmDiasPagamentoCadAux(i);
            f.dal = idal;
            f.ShowDialog();
            CarregaGrid();
        }
    }
}
