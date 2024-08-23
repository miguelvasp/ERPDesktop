using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ContasPagarModelView
    {
        public int IdContasPagar { get; set; } 
        public string RazaoSocial { get; set; }
        public string Documento { get; set; }
        public DateTime? Vencimento { get; set; }
        public decimal? ValorTitulo { get; set; }
        public decimal? Desconto { get; set; }
        public decimal? Acrescimo { get; set; }
        public decimal? ValorLiquido { get; set; }
        public decimal? ValorPago { get; set; }
        public decimal? Saldo { get; set; }
        public string Historico { get; set; }
        public int? Parcelas { get; set; }
        public int? ParcelasPagas { get; set; }
    }
}
