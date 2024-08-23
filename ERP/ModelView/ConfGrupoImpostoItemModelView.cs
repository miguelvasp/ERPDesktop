using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ConfGrupoImpostoItemModelView
    {
        public int IdConfGrupoImpostoItem { get; set; }
        public string CodigoImposto { get; set; }
        public string CodigoTributacao { get; set; }
        public string Isento { get; set; }
        public string SemCredito { get; set; }
    }
}
