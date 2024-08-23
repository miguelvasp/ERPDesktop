using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class EspecificacaoModelView
    {
        public int IdEspecificacaoPagamento { get; set; }
        public string Nome { get; set; }
        public string ControleExportacao { get; set; }
        public string TipoPagamento { get; set; }
        public string FormaPagamento { get; set; }
        public string Segmento { get; set; }
    }
}
