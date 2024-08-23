using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ConfGrupoImpostoModalView
    {
        public int IdConfGrupoImposto {get;set;}
        public string CodigoImposto {get;set;}
        public string CodigoIsencao {get;set;}
        public string CodigoTributqacao {get;set;}
        public decimal? Percentual { get; set; }
        public string ImpostoSobreUso { get; set; }
        public string Isento { get; set; }
        public int idCodigoImposto { get; set; }
    }
}
