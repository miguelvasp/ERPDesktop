using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmTipoProduto : Form
    {

        TipoProdutoDAL dal = new TipoProdutoDAL();
        public frmTipoProduto()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmTipoProdutoCad cad = new frmTipoProdutoCad(new TipoProduto());
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmTipoProduto_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmTipoProdutoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var Lista = dal.Get();
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.DataSource = Lista;

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
                    TipoProduto tp = dal.GetByID(id);
                    frmTipoProdutoCad cad = new frmTipoProdutoCad(tp);
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch { }
        }
    }
}
