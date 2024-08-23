using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmListaContabilidadeVendas : Form
    {
        public PedidoVendaContabilidadeDAL dal = new PedidoVendaContabilidadeDAL();
        int IdPedidoVendaItem;
        public frmListaContabilidadeVendas(int pIdPedidoVendaItem)
        {
            IdPedidoVendaItem = pIdPedidoVendaItem;
            InitializeComponent(); 
        }
            

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0 && e.RowIndex > -1)
            {
                int Id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value);
                frmPedidoVendaContabilidade frm = new frmPedidoVendaContabilidade(Id);
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
            var lista = new PedidoVendaContabilidadeDAL().GetByPedidoItem(IdPedidoVendaItem);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista.Select(x => new
                                            {
                                                Id = x.IdPedidoVendaContabilidade,
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
