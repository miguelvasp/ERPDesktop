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
    public class PeriodoLiquidacaoImpostoVenc
    {
        [Key]
        [DisplayName("Id Período Liquidação Imposto Venc")]
        [Column("IDPERIODOLIQUIDACAOIMPOSTOVENC")]
        public int IdPeriodoLiquidacaoImpostoVenc { get; set; }

        [DisplayName("Id Período Liquidação Imposto")]
        [Column("IDPERIODOLIQUIDACAOIMPOSTO")]
        public int IdPeriodoLiquidacaoImposto { get; set; }
        public virtual PeriodoLiquidacaoImposto PeriodoLiquidacaoImposto { get; set; }

        [DisplayName("De")]
        [Column("DE")]
        public DateTime? De { get; set; }

        [DisplayName("Até")]
        [Column("ATE")]
        public DateTime? Ate { get; set; }
    }
}
