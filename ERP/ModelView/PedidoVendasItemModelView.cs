using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class PedidoVendasItemModelView
    {
        public int IdPedidoVenda { get; set; }
        public int IdPedidoVendaItem { get; set; }
        public int? Pedidonumero { get; set; }
        public string Codigo { get; set; }
        public string NomeProduto { get; set; }
        public decimal? Quantidade { get; set; }
        public decimal? Saldo { get; set; }
        public decimal? Ipi { get; set; }
        public decimal? PrecoUnitario { get; set; }
        public decimal? DescontoPercentual { get; set; }
        public decimal? DescontoValor { get; set; }
        public decimal? Total { get; set; }
        public string Cor { get; set; }
        public string Config { get; set; }
        public string Tamanho { get; set; }
        public string Estilo { get; set; }
    }
}
