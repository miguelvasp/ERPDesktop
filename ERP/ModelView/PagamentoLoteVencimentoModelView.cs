using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class PagamentoLoteVencimentoModelView
    {
        public int? IdContasPagar { get; set; }
        public int? IdContasPagarAberto { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime? Vencimento { get; set; }
        public decimal? ValorLiquido { get; set; }
        public decimal? Saldo { get; set; }
        public string MetodoPagamento { get; set; }
        public string Documento { get; set; }
    }
}
