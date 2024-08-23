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
    public partial class frmPagamentoLote : Form
    {
        PagamentoLoteDAL dal = new PagamentoLoteDAL();

        public frmPagamentoLote()
        {
            InitializeComponent(); 
        }
        
        private void CarregaGrid()
        {
            DateTime De = Convert.ToDateTime(txtVencimentoDe.Text + " 00:00:00");
            DateTime Ate = Convert.ToDateTime(txtVencimentoAte.Text + " 23:59:00");
            int IdFornecedor = String.IsNullOrEmpty(cboFornecedor.Text) ? 0 : Convert.ToInt32(cboFornecedor.SelectedValue);
            int IdContaBancaria = String.IsNullOrEmpty(cboContaBancaria.Text) ? 0 : Convert.ToInt32(cboContaBancaria.SelectedValue);
            int IdContaContabil = String.IsNullOrEmpty(cboContaContabil.Text) ? 0 : Convert.ToInt32(cboContaContabil.SelectedValue);
            int IdCliente = String.IsNullOrEmpty(cboCliente.Text) ? 0 : Convert.ToInt32(cboCliente.SelectedValue);
            int Situacao = 0;
            var lista = dal.GetByParams(De, Ate, IdFornecedor, IdContaBancaria, IdContaContabil, IdCliente, Situacao);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista;


        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmPagamentoLotePreparacao preparacao = new frmPagamentoLotePreparacao();
            preparacao.ShowDialog();
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
            //CarregaGrid();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CarregaCombos()
        {
            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(Util.Util.GetAppSettings("IdEmpresa"));
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;

            cboCliente.DataSource = new ClienteDAL().GetCombo(Util.Util.GetAppSettings("IdEmpresa"));
            cboCliente.DisplayMember = "Text";
            cboCliente.ValueMember = "iValue";
            cboCliente.SelectedIndex = -1;

            cboContaBancaria.DataSource = new EmpresaDAL().GetContasBancarias(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
            cboContaBancaria.ValueMember = "iValue";
            cboContaBancaria.DisplayMember = "Text";
            cboContaBancaria.SelectedIndex = -1;

            cboContaContabil.DataSource = new ContaContabilDAL().GetComboByTipo(1);
            cboContaContabil.ValueMember = "iValue";
            cboContaContabil.DisplayMember = "Text";
            cboContaContabil.SelectedIndex = -1;

             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value);
                using (frmPagamentoLoteCad frmcad = new frmPagamentoLoteCad(id))
                {
                    frmcad.ShowDialog();
                }
                CarregaGrid();
            }
        }
    }
}
