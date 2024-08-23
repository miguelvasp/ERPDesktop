using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class RecebimentoItemModelView
    {
       
        public int IdRecebimentoItem { get; set; }
        public int? IdPedidoCompra { get; set; }
        public int? IdPedidoCompraItem { get; set; }
        public string Codigo { get; set; }
        public string NomeProduto { get; set; }
        public decimal? Quantidade { get; set; }
        public decimal? QuantidadeRecebida { get; set; }
        public decimal? PrecoUnitario { get; set; }
        public decimal? Total { get; set; }
    }
}
