using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ContratoComercialConfPgtoModelView
    {
        public int IdContratoComercialCondPgto { get; set; }
        public int IdContratoComercial { get; set; }
        public string CondicaoPagamento { get; set; }
        public decimal Juros { get; set; }
    }
}
