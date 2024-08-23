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
    public partial class frmBoletoBancario : Form
    {
        BoletoBancarioDAL dal = new BoletoBancarioDAL();
        public int IdContasReceber = 0;
        public frmBoletoBancario()
        {
            InitializeComponent(); 
        }
        
        private void CarregaGrid()
        {
            List<BoletoBancario> lista = new List<BoletoBancario>();
            if(IdContasReceber == 0)
            {
                lista = dal.getByParams(txtVencimentoDe.Text, txtVencimentoAte.Text, cboSituacao.Text);
            }
            else
            {
                lista = dal.getByIdConta(IdContasReceber);
                IdContasReceber = 0;
            }
            
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    BoletoBancario c = dal.GetByID(id);
                    frmBoletoBancarioCad cad = new frmBoletoBancarioCad(c);
                    cad.dal = dal;
                    cad.Show();
                    CarregaGrid();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
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
            Util.Util.ExpotaGridToCsv(dgv, "Calendario.csv");
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void frmPedidoCompras_Load(object sender, EventArgs e)
        {
            txtVencimentoDe.Text = DateTime.Now.Subtract(TimeSpan.FromDays(30)).ToShortDateString();
            txtVencimentoAte.Text = DateTime.Now.ToShortDateString();
            CarregaCombos(); 
            CarregaGrid();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CarregaCombos()
        { 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }
         
    }
}
