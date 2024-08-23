using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmTipoTelefone : Form
    {

        TipoTelefoneDAL dal = new TipoTelefoneDAL(new DB_ERPContext());
        public frmTipoTelefone()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmTipoTelefoneCad cad = new frmTipoTelefoneCad(new TipoTelefone());
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmTipoTelefon_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmTipoTelefoneCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.Get().OrderBy(x => x.Descricao).ToList();

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
                    TipoTelefone tf = dal.GetByID(id);
                    frmTipoTelefoneCad cad = new frmTipoTelefoneCad(tf);
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch { }
        }
    }
}
