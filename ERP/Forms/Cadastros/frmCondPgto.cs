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

namespace ERP
{
    public partial class frmCondPgto : Form
    {
        
        CondicaoPagamentoDAL dal = new CondicaoPagamentoDAL();
        public frmCondPgto()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCondPgtoCad cad = new frmCondPgtoCad(new CondicaoPagamento());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmCondPgto_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmCondPgtoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            var lista = dal.Get().OrderBy(x =>x.Descricao).ToList();

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.DataSource = lista;

        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dataGridView2);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dataGridView2, "CondicaoPagamento.csv");
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
                    CondicaoPagamento cp = dal.GetByID(id);
                    frmCondPgtoCad cad = new frmCondPgtoCad(cp);
                    cad.dal = dal;
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch { }
        }
    }
}
