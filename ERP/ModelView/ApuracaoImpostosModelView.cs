using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ApuracaoImpostosModelView
    {
        public int Id { get; set; }
        public string CodigoImposto { get; set; }
        public string CodigoTributacao { get; set; }
        public string CodigoTributacaoAjustada { get; set; }
        public decimal? ValorFiscal { get; set; }
        public decimal? ValorFiscalAjustado { get; set; }
        public decimal? Aliquota { get; set; }
        public decimal? BaseValor { get; set; }
        public decimal? BaseValorAjustado { get; set; }
        public decimal? OutroValorBase { get; set; }
        public decimal? OutroValorImposto { get; set; }
        public decimal? ValorBaseIsencao { get; set; }
        public decimal? ValorIsencaoImposto { get; set; }
        public decimal? ValorImposto { get; set; }
        public decimal? ValorAjustado { get; set; }
        public string DirecaoImposto { get; set; }
        public string FiscalOrigem { get; set; }
        public string TipoImposto { get; set; } 
    }
}
