using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmListaImpostosCompras : Form
    {
        public PedidoCompraItemApuracaoImpostoDAL dal;
        int IdPedidoCompraItem;
        public frmListaImpostosCompras(int pIdPedidoCompraItem)
        {
            IdPedidoCompraItem = pIdPedidoCompraItem;
            InitializeComponent(); 
        }
            

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0 && e.RowIndex > -1)
            {
                int Id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value);
                frmPedidoCompraApuracaoImposto frm = new frmPedidoCompraApuracaoImposto(Id);
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
            var lista = dal.GetListaImpostos(IdPedidoCompraItem);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista;
        }
    }
}
