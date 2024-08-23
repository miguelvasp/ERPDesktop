using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmUnidade : Form
    {
        UnidadeDAL dal = new UnidadeDAL();
        public frmUnidade()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmUnidadeCad cad = new frmUnidadeCad(new Unidade());
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmUnidade_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmUnidadeCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.Get();

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dataGridView2);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }


        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Unidade u = dal.GetByID(id);
                    frmUnidadeCad cad = new frmUnidadeCad(u);
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch { }
        }
    }
}
