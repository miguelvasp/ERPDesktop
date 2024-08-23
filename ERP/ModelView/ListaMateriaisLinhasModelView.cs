using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ListaMateriaisLinhasModelView
    {
        public int IdListaMateriaisLinhas { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal? Quantidade { get; set; }
    }
}
