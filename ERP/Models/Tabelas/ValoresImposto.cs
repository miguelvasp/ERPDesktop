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
    [Table("VALORESIMPOSTO", Schema = "DBO")]
    public class ValoresImposto
    {
        [Key]
        [DisplayName("Id Valores Imposto")]
        [Column("IDVALORESIMPOSTO")]
        public int IdValoresImposto { get; set; }

        [DisplayName("Id Código Imposto")]
        [Column("IDCODIGOIMPOSTO")]
        public int? IdCodigoImposto { get; set; }
        public virtual CodigoImposto CodigoImposto { get; set; }

        [DisplayName("De")]
        [Column("DE")]
        public DateTime? De { get; set; }

        [DisplayName("Até")]
        [Column("ATE")]
        public DateTime? Ate { get; set; }

        [DisplayName("Limite Máximo")]
        [Column("LIMITEMAXIMO")]
        public decimal LimiteMaximo { get; set; }

        [DisplayName("Limite Mínimo")]
        [Column("LIMITEMINIMO")]
        public decimal LimiteMinimo { get; set; }
        
        [DisplayName("Alíquota")]
        [Column("ALIQUOTA")]
        public decimal Aliquota { get; set; }

        [DisplayName("Percentual de Redução")]
        [Column("PERCENTUALREDUCAO")]
        public decimal PercentualReducao { get; set; }

        [DisplayName("Markup")]
        [Column("MARKUP")]
        public decimal Markup { get; set; }

        [DisplayName("Percentual Isenção")]
        [Column("PERCENTUALISENCAO")]
        public decimal PercentualIsencao { get; set; }
    }
}
