using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ImpostosCalcularModelView
    {
        public int? id { get; set; }
        public int? IdCodigoImposto { get; set; }
        public int? IdCodigoIsencao { get; set; }
        public int? IdCodigoTributacao { get; set; }
        public int? IdJuridicaoImposto { get; set; }
        public int? ParametrosCalculos { get; set; }
        public int? BaseMarginal { get; set; }
        public int? TipoImposto { get; set; }
        public bool? ImpostoIncluso { get; set; }
        public int? DataCalculo { get; set; }
        public int? ValorFiscal { get; set; }
        public bool? PorcentagemNegativaImposto { get; set; }
        public bool? ImpostoRetidoRecuperavel { get; set; }
        public int? MetodoCalculo { get; set; }
        public int? MetodoSubstituicaoTributaria { get; set; }
    }
}
