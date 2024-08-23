using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ComissaoVendedorContaCorrenteModelView
    {
        public int IdComissaoContaCorrente { get; set; } 
        public string Vendedor { get; set; }
        public int IdVendedor { get; set; } 
        public string NotaFiscal { get; set; } 
        public DateTime? Data { get; set; }  
        public decimal Comissao { get; set; } 
        public decimal ValorAPagar { get; set; }  
        public decimal? ValorPago { get; set; } 
        public string TipoComissao { get; set; } 
        public string Observacao { get; set; } 
        public string TipoLancamento { get; set; }
    }
}
