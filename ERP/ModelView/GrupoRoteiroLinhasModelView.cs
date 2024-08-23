using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class GrupoRoteiroLinhasModelView
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Ativacao { get; set; }
        public string Capacidade { get; set; }
        public string Gerenciamento { get; set; }
        public string Horario { get; set; }
    }
}
