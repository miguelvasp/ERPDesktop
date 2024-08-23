using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmListaContabilidadeCompras : Form
    {
        public PedidoCompraContabilidadeDAL dal = new PedidoCompraContabilidadeDAL();
        int IdPedidoCompraItem;
        public frmListaContabilidadeCompras(int pIdPedidoCompraItem)
        {
            IdPedidoCompraItem = pIdPedidoCompraItem;
            InitializeComponent(); 
        }
            

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0 && e.RowIndex > -1)
            {
                int Id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value);
                frmPedidoCompraContabilidade frm = new frmPedidoCompraContabilidade(Id);
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
            var lista = new PedidoCompraContabilidadeDAL().GetByPedidoItem(IdPedidoCompraItem);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista.Select(x => new
                                            {
                                                Id = x.IdPedidoCompraContabilidade,
                                                Origem = x.OrigemLancamento.Descricao,
                                                Conta = x.ContaContabil.Codigo,
                                                Credito = x.ValorCredito,
                                                Debito = x.ValorDebito,
                                                Data = x.Data,
                                                Moeda = x.Moeda.Codigo,
                                                CreditoAjustado = x.ValorAjusteCredito,
                                                DebitoAjustado = x.ValorAjusteDebito,
                                                Historico = x.Historico 
                                            }).ToList();
        }
    }
}
