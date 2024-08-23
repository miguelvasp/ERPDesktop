using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmListaImpostosVendas : Form
    {
        public PedidoVendaItemApuracaoImpostoDAL dal;
        int IdPedidoVendaItem;
        public frmListaImpostosVendas(int pIdPedidoVendaItem)
        {
            IdPedidoVendaItem = pIdPedidoVendaItem;
            InitializeComponent(); 
        }
            

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0 && e.RowIndex > -1)
            {
                int Id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value);
                frmPedidoVendaApuracaoImposto frm = new frmPedidoVendaApuracaoImposto(Id);
                frm.dal = dal;
                frm.ShowDialog();
                CarregaGrid();
            }
        }
         
        private void frmBuscaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
          

        private void frmBuscaProduto_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            //carrega os clientes
            var lista = dal.GetListaImpostos(IdPedidoVendaItem);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista;
        }
    }
}
