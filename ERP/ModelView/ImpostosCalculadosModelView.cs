using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ImpostosCalculadosModelView
    {
        public int IdCodidoImposto { get; set; }
        public int? TipoImposto { get; set; }
        public decimal BaseCalculo { get; set; }
        public decimal ValorImposto { get; set; }
        public int IdCodigoTributacao { get; set; }
        public decimal Aliquota { get; set; }
        public decimal PercentualReducao { get; set; }

    }
}
