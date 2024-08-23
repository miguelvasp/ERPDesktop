using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ConfImpostoRetidoModelView
    {
        public int? IdConfGrupoImpostoRetido { get; set; }
        public string CodigoImposto { get; set; }
        public decimal? Aliquota { get; set; }
        public decimal? Exclusao { get; set; }
    }
}
