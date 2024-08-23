using ERP.DAL;
using ERP.Models;
using ERP.Relatorios;
using ERP.Vendas;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPedidoVendaSeparacao : Form
    {
        PedidoVendaDAL dal = new PedidoVendaDAL();

        public frmPedidoVendaSeparacao()
        {
            InitializeComponent();
            txtDataFim.Text = DateTime.Now.ToShortDateString();
            txtDataInicio.Text = DateTime.Now.AddDays(-7).ToShortDateString();
        }
        
        private void frmPedidoVendas_Load(object sender, EventArgs e)
        {
            CarregaCombos();
        }

        private void CarregaCombos()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboCliente.DataSource = new ClienteDAL().GetCombo(sEmpresa);
            cboCliente.DisplayMember = "Text";
            cboCliente.ValueMember = "iValue";
            cboCliente.SelectedIndex = -1; 
        }


        private void CarregaGrid()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");
            string sCliente = ""; if (cboCliente.SelectedValue != null) sCliente = cboCliente.SelectedValue.ToString();
           
            var lista = dal.GetPedidosSeparacao(txtDataInicio.Text, txtDataFim.Text, sEmpresa, sCliente).ToList();

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lista;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

         

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }


        private void txtDataInicio_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void txtDataFim_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboCliente_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value);
                frmRepPedidoVendasSeparacao rep = new frmRepPedidoVendasSeparacao(id);
                rep.ShowDialog(); 
            }
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            using(frmConfirmaSeparacao confirm = new frmConfirmaSeparacao())
            {
                confirm.ShowDialog();
                CarregaGrid();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value);
                frmRepPedidoVendasViewer viewer = new frmRepPedidoVendasViewer(id, true);//Imprime somente os itens liberados para faturamento
                viewer.ShowDialog();
            }
        }
    }
}
