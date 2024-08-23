using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ContasPagarAbertoModelView
    {
        public int? Id { get; set; }
        public DateTime? Vencimento { get; set; }
        public int? NumeroParcela { get; set;}
        public decimal? ValorLiquido { get; set; }
        public decimal? ValorPago { get; set; }
    }
}
