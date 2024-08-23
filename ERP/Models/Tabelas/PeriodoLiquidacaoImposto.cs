using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("PERIODOLIQUIDACAOIMPOSTO", Schema = "DBO")]
    public class PeriodoLiquidacaoImposto
    {
        [Key]
        [DisplayName("Id Período Liquidação Imposto")]
        [Column("IDPERIODOLIQUIDACAOIMPOSTO")]
        public int IdPeriodoLiquidacaoImposto { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Id Condição de Pagamento")]
        [Column("IDCONDICAOPAGAMENTO")]
        public int? IdCondicaoPagamento { get; set; }
        public virtual CondicaoPagamento CondicaoPagamento { get; set; }

        [DisplayName("Id Autoridade")]
        [Column("IDAUTORIDADE")]
        public int? IdAutoridade { get; set; }
        public virtual Autoridade Autoridade { get; set; }

        [DisplayName("Intervalo do Período")]
        [Column("INTERVALOPERIODO")]
        public int IntervaloPeriodo { get; set; }

        [DisplayName("Número Unidade")]
        [Column("NUMEROUNIDADE")]
        public int? NumeroUnidade { get; set; }
    }
}
