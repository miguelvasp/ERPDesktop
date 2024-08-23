using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCapacidadeRecursosCad : RibbonForm
    {
        public CapacidadeRecursosDAL dal = new CapacidadeRecursosDAL();
        CapacidadeRecursosLinhasDAL idal = new CapacidadeRecursosLinhasDAL();
        CapacidadeRecursos c = new CapacidadeRecursos();

        public frmCapacidadeRecursosCad(CapacidadeRecursos pC)
        {
            c = pC;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmAutoridadeCad_Load(object sender, EventArgs e)
        {


            if (c.IdCapacidadeRecursos == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void frmAutoridadeCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            txtDescricao.Text = c.Descricao;
            CarregaGrid();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new CapacidadeRecursos();
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
                    c.Descricao = txtDescricao.Text;
                    if (c.IdCapacidadeRecursos == 0)
                    {
                        dal.Insert(c);
                    }
                    else
                    {
                        dal.Update(c);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
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
                int id = c.IdCapacidadeRecursos;
                dal.Delete(id);
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c.IdCapacidadeRecursos == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados do calendário antes de adicionar datas.");
                return;
            }

            CapacidadeRecursosLinhas cd = new CapacidadeRecursosLinhas();
            cd.IdCapacidadeRecursos = c.IdCapacidadeRecursos;
            frmCapacidadeRecursosLinhas frmdata = new frmCapacidadeRecursosLinhas(cd);
            frmdata.dal = idal;
            frmdata.ShowDialog();
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            var lista = idal.GetByCapacidadeId(c.IdCapacidadeRecursos);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["id"].Value);
                    CapacidadeRecursosLinhas cd = idal.GetByID(id);
                    cd.IdCapacidadeRecursos = c.IdCapacidadeRecursos;
                    frmCapacidadeRecursosLinhas frmdata = new frmCapacidadeRecursosLinhas(cd);
                    frmdata.dal = idal;
                    frmdata.ShowDialog();
                    CarregaGrid();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }
    }
}

