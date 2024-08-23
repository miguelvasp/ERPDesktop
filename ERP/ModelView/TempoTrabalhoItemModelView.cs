using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class TempoTrabalhoItemModelView
    {
        public int Id { get; set; }
        public string Dia { get; set; }
        public TimeSpan? De { get; set; }
        public TimeSpan? Ate { get; set; }
    }
}
