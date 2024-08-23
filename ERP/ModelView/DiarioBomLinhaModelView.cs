using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class DiarioBomLinhaModelView
    {
        public int id { get; set; }
        public DateTime? Data { get; set; }
        public int? OrdemProducao { get; set; }
        public int? SequenciaComprovante { get; set; }
        public decimal? Qtde { get; set; }
    }
}
