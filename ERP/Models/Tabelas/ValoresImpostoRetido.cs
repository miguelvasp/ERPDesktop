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
    [Table("VALORESIMPOSTORETIDO", Schema = "DBO")]
    public class ValoresImpostoRetido
    {
        [Key]
        [DisplayName("Id Valores Imposto Retido")]
        [Column("IDVALORESIMPOSTORETIDO")]
        public int IdValoresImpostoRetido { get; set; }

        [DisplayName("Id Código Imposto Retido")]
        [Column("IDCODIGOIMPOSTORETIDO")]
        public int? IdCodigoImpostoRetido { get; set; }
        public virtual CodigoImpostoRetido CodigoImpostoRetido { get; set; }

        [DisplayName("De")]
        [Column("DE")]
        public DateTime? De { get; set; }

        [DisplayName("Até")]
        [Column("ATE")]
        public DateTime? Ate { get; set; }

        [DisplayName("Limite Máximo")]
        [Column("LIMITEMAXIMO")]
        public decimal? LimiteMaximo { get; set; }

        [DisplayName("Limite Mínimo")]
        [Column("LIMITEMINIMO")]
        public decimal? LimiteMinimo { get; set; }

        [DisplayName("Alíquota")]
        [Column("ALIQUOTA")]
        public decimal? Aliquota { get; set; }

        [DisplayName("Percentual Exclusão")]
        [Column("PERCENTUALEXCLUSAO")]
        public decimal? PercentualExclusao { get; set; }

        [DisplayName("Dedução IRRF")]
        [Column("DEDUCAOIRRF")]
        public decimal? DeducaoIRRF { get; set; }
    }
}
