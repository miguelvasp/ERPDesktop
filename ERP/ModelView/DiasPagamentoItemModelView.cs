using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class DiasPagamentoItemModelView
    {
        public int IdDiasPagamentoItem { get; set; }
        public string SemanaMes { get; set; }
        public string DiaSemana { get; set; }
        public int? DiaMes { get; set; }
    }
}
