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
    [Table("JURIDICAOIMPOSTO", Schema = "DBO")]
    public class JuridicaoImposto
    {
        [Key]
        [DisplayName("Id Juridição Imposto")]
        [Column("IDJURIDICAOIMPOSTO")]
        public int IdJuridicaoImposto { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Id Período Liquidação Imposto")]
        [Column("IDPERIODOLIQUIDACAOIMPOSTO")]
        public int? IdPeriodoLiquidacaoImposto { get; set; }
        public virtual PeriodoLiquidacaoImposto PeriodoLiquidacaoImposto { get; set; }

        [DisplayName("Id Grupo Lançamento Contábil")]
        [Column("IDGRUPOLANCAMENTOCONTABIL")]
        public int? IdGrupoLancamentoContabil { get; set; }
        public virtual GrupoLancamentoContabil GrupoLancamentoContabil { get; set; }

        [DisplayName("Id Moeda")]
        [Column("IDMOEDA")]
        public int? IdMoeda { get; set; }
        public virtual Moeda Moeda { get; set; }

    }
}
