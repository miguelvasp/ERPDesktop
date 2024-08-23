using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class GeraComissaoModelView
    {
        public int? IdVendedor { get; set; }
        public int? IdTelevendas { get; set; }
        public decimal? ComissaoVendedor { get; set; }
        public decimal? ComissaoVendedorExtra { get; set; }
        public decimal? ComissaoTelevendas { get; set; }
        public decimal? ComissaoTelevendasExtra { get; set; }
        public decimal? ComissaoNegativa { get; set; }
        public decimal? PercentualVendedor { get; set; }
        public decimal? PercentualTelevendas { get; set; }
    }
}
