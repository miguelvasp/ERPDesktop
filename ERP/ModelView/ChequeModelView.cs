using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ChequeModelView
    {
        public int? Id { get; set; }
        public DateTime? Data { get; set; }
        public int? NumeroCheque { get; set; }
        public string ContaBancaria { get; set; }
        public string Fornecedor { get; set; }
        public string Cliente { get; set; }
        public decimal? Valor { get; set; }
        public string Status { get; set; }
    }
}
