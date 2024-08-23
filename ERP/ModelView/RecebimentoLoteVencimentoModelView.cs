using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class RecebimentoLoteVencimentoModelView
    {
        public int? IdContasreceber { get; set; }
        public int? IdContasReceberAberto { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime? Vencimento { get; set; }
        public decimal? ValorLiquido { get; set; }
        public decimal? Saldo { get; set; }
        public string MetodoPagamento { get; set; }
        public string Documento { get; set; }
    }
}
