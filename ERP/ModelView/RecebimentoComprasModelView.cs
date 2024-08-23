using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class RecebimentoComprasModelView
    {
        public int IdRecebimento { get; set; }
        public DateTime DataFisica { get; set; }
        public string Fantasia { get; set; }
        public string NomeFantasia { get; set; }
        public DateTime DataEntrega { get; set; }
        public int? RecebimentoNumero { get; set; }
        public string Status { get; set; }
    }
}
