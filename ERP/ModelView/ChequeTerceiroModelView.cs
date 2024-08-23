using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ChequeTerceiroModelView
    {
        public int Id { get; set; }
        public string Banco { get; set; }
        public string Nome { get; set; }
        public string Cheque { get; set; }
        public DateTime? Data { get; set; }
        public decimal? Valor { get; set; }
        public string Status { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
    }
}
