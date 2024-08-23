using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class PagamentoLoteModelView
    { 
        public int IdPagamentoLote { get; set; }
         
        public DateTime? Data { get; set; }
         
        public int? IdContaBancaria { get; set; }
         
        public string ContaBancaria { get; set; }
         
        public int? IdFornecedor { get; set; }
         
        public string Fornecedor { get; set; }
         
        public int? IdCliente { get; set; }
         
        public string Cliente { get; set; }
         
        public int? IdContaContabil { get; set; }
         
        public string ContaContabil { get; set; }
         
        public int? IdMetodoPagamento { get; set; }
         
        public string MetodoPagamento { get; set; }
         
        public decimal? Valor { get; set; }
 
        public int? StatusPagamento { get; set; }
 
        public int? Cheque { get; set; }
    }
}
