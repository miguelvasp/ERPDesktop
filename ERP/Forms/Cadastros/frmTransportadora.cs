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
    public partial class frmTransportadora : Form
    {
        TransportadoraDAL dal = new TransportadoraDAL();
        public frmTransportadora()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = !pnlPesquisa.Visible;
            txtCNPJ.Text = "";
            txtRazao.Text = "";
            txtUF.Text = "";
        }

        
     

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmTransportadoraCad cad = new frmTransportadoraCad(new Transportadora());
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmTransportadora_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            //dal = new TransportadoraDAL();
            var lista = dal.getByParams(txtRazao.Text, txtCNPJ.Text).Select(x => new { x.IdTransportadora, x.RazaoSocial, x.NomeFantasia, x.CNPJ }).ToList();
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.DataSource = lista;

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
                    Transportadora tr = dal.TRepository.GetByID(id);
                    frmTransportadoraCad cad = new frmTransportadoraCad(tr);
                    cad.dal = dal;
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch { }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void txtRazao_TextChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }
    }
}
