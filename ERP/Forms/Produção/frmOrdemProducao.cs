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
    public partial class frmOrdemProducao : Form
    {
        OrdemProducaoDAL dal = new OrdemProducaoDAL();

        public frmOrdemProducao()
        {
            InitializeComponent(); 
        }
        
        private void CarregaGrid()
        {
            try
            {
                int NumeroOP = string.IsNullOrEmpty(txtOP.Text) ? 0 : Convert.ToInt32(txtOP.Text);
                int IdProduto = string.IsNullOrEmpty(cboProduto.Text) ? 0 : Convert.ToInt32(cboProduto.SelectedValue);
                int IdStatus = string.IsNullOrEmpty(cboStatus.Text) ? 0 : Convert.ToInt32(cboStatus.SelectedValue);
                var lista = new OrdemProducaoDAL().getByParams(NumeroOP, IdProduto, IdStatus);
                dgv.AutoGenerateColumns = false;
                dgv.RowHeadersVisible = false; 
                dgv.DataSource = lista;
            }
            catch (Exception ex)
            {
                 
            }
            
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    var p = dal.GetByID(id);
                    frmOrdemProducaoCad cad = new frmOrdemProducaoCad(p);
                    cad.dal = dal;
                    cad.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmOrdemProducaoCad cad = new frmOrdemProducaoCad(new OrdemProducao());
            cad.dal = dal;
            cad.ShowDialog();
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
            cboStatus.DataSource = dal.getStatus();
            cboStatus.ValueMember = "iValue";
            cboStatus.DisplayMember = "Text";
            cboStatus.SelectedIndex = -1;

            cboProduto.DataSource = new ProdutoDAL().getProdutosAcabados(0);
            cboProduto.ValueMember = "iValue";
            cboProduto.DisplayMember = "Text";
            cboProduto.SelectedIndex = -1;

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }
    }
}
