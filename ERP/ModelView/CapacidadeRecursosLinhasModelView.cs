using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class CapacidadeRecursosLinhasModelView
    {
        public int Id { get; set; }
        public string Recurso { get; set; }
        public DateTime? DataEfetivacao { get; set; }
        public DateTime? DataVencimento { get; set; }
        public int? Prioridade { get; set; }
        public int? Nivel { get; set; }
    }
}
