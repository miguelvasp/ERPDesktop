using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.Models;
using ERP.DAL;

namespace ERP.Forms.VendasBalcao
{
    public partial class frmDevolucaoBalcao : Form
    {
        PedidoBalcao p;
        List<int> Itens;
        public frmDevolucaoBalcao(PedidoBalcao pp, List<int> pItens)
        {
            p = pp;
            Itens = pItens;
            InitializeComponent();
        }

        private void CarregaGrid()
        {
            var listaprod = new PedidoBalcaoProdutoDAL().getByPedidoId(p.IdPedidoBalcao);
            var produtosl = listaprod.Select(x =>
                   new
                   {
                       IdPedidoBalcaoProduto = x.IdPedidoBalcaoProduto,
                       Codigo = x.Produto == null ? "" : x.Produto.Codigo,
                       NomeProduto = x.Produto == null ? "" : x.Produto.NomeProduto,
                       Qtde = 0,
                       ValorUnitario = x.ValorUnitario,
                       Desconto = x.Desconto,
                       ValorTotal = x.ValorTotal
                   }
                ).ToList();
            dgvProdutos.AutoGenerateColumns = false;
            dgvProdutos.DataSource = produtosl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Confirma o pedido de devolução?") == DialogResult.Yes)
            {
                PedidoBalcao np = new PedidoBalcao();
               // np.CondicaoPagamento = 1;
                np.Data = DateTime.Now;
                //np.Total
            }
        }
    }
}
