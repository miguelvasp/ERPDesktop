using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class RoteiroOperacaoRecursoModelView
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Recurso { get; set; }
        public string CapacidadeRecurso { get; set; }
        public string GrupoRecurso { get; set; }
    }
}
