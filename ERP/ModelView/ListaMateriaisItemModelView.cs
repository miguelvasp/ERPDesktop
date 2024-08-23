using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ListaMateriaisItemModelView
    {
        public int IdListaMateriaisItem { get; set; }
        public string Produto { get; set; }
        public string Config { get; set; }
        public string Estilo { get; set; }
        public string Cor { get; set; }
        public string Tamanho { get; set; }
        public DateTime? De { get; set; }
        public DateTime? Ate { get; set; }
    }
}
