using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ListaMateriaisModelView
    {
        public int? IdListaMateriais { get; set; }
        public string Nome { get; set; }
        public bool Aprovado { get; set; }
        public string Tipo { get; set; }
        public string GrupoLancamento { get; set; }
        public string Armazem { get; set; }
    }
}
