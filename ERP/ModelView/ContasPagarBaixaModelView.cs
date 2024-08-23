using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ContasPagarBaixaModelView
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public string Documento { get; set; }
        public string Cheque { get; set; }
        public string ContaBancaria { get; set; }
        public decimal? Valor { get; set; }
    }
}
