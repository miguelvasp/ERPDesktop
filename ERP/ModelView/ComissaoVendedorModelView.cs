using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ComissaoVendedorModelView
    {
        public int? IdVendedor { get; set; }
        public int? IdTeleVendas { get; set; } 
        public int? IdCondicaoPagamento { get; set; }  
        public decimal? ValorDeTabela { get; set; }
        public decimal? ValorDeContratoComJuros { get; set; }
        public decimal? ValorUnitarioDeVenda { get; set; }
        public decimal? ValorTotalPedido { get; set; }
        public decimal? ValorLiquido { get; set; }
        public decimal? Quantidade { get; set; } 
        public string Observacao { get; set; }
    }
}
