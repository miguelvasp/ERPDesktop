using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.Compras;

namespace ERP
{
    public partial class frmCapacidadeRecursos : Form
    {
        CapacidadeRecursosDAL dal = new CapacidadeRecursosDAL();

        public frmCapacidadeRecursos()
        {
            InitializeComponent(); 
        }
        
        private void CarregaGrid()
        {
            var lista = dal.Get();
            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lista;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    CapacidadeRecursos c = dal.GetByID(id);
                    frmCapacidadeRecursosCad cad = new frmCapacidadeRecursosCad(c);
                    cad.dal = dal;
                    cad.Show();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCapacidadeRecursosCad cad = new frmCapacidadeRecursosCad(new CapacidadeRecursos());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "Capacidade.csv");
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmCapacidadeRecursos_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }
    }
}
