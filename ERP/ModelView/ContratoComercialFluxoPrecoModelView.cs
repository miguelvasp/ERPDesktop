using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ContratoComercialFluxoPrecoModelView
    {
        public string TipoRelacao { get; set; }
        public decimal Valor { get; set; }
        public decimal PercentualDesconto { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorDescontoVarejista { get; set; }
        public bool ExisteContrato { get; set; }
        public decimal? PercentualDescontoVarejista { get; set; }
        public decimal? ValorOriginal { get; set; }
        public decimal ValorTabela { get; set; }
        public decimal Juros { get; set; }
    }
}

