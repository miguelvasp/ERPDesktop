using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmRecurso : Form
    {
        RecursosDAL dal = new RecursosDAL();

        public frmRecurso()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmRecursoCad cad = new frmRecursoCad(new Recursos());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmAutoridade_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmRecursoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            var lista = dal.getByParams(txtDescricao.Text);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dataGridView1);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dataGridView1, "Recurso.csv");
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Recursos r = dal.GetByID(id);
                    frmRecursoCad cad = new frmRecursoCad(r);
                    cad.dal = dal;
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = !pnlPesquisa.Visible;
            txtDescricao.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {

        }

        private void btnPesquisa_Click_1(object sender, EventArgs e)
        {
            CarregaGrid();
        }
    }
}