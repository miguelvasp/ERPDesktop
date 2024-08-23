using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class PedidosTotaisModelView
    {
        public decimal TotalValorReal { get; set; }
        public decimal TotalProdutos { get; set; }
        public decimal TotalImpostosNaoInclusos { get; set; }
        public decimal TotalEncargos { get; set; }
        public decimal TotalImpostos { get; set; }
        public decimal TotalPedido { get; set; }
        public decimal TotalDesconto { get; set; }
        public decimal TotalDescontoVarejista { get; set; }
        public decimal IPI { get; set; }
        public decimal PIS { get; set; }
        public decimal ICMS { get; set; }
        public decimal COFINS { get; set; }
        public decimal ISS { get; set; }
        public decimal IRRF { get; set; }
        public decimal INSS { get; set; }
        public decimal ImpostoImportacao { get; set; }
        public decimal OutrosImpostos { get; set; }
        public decimal CSLL { get; set; }
        public decimal ICMSST { get; set; }
        public decimal ICMSDiff { get; set; } 

    }
}
