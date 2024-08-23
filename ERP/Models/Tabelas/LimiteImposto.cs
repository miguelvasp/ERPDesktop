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
    [Table("LIMITEIMPOSTO", Schema = "DBO")]
    public class LimiteImposto
    {
        [Key]
        [DisplayName("Id Limte Imposto")]
        [Column("IDLIMITEIMPOSTO")]
        public int IdLimiteImposto { get; set; }

        [DisplayName("Limite Máximo")]
        [Column("LIMITEMAXIMO")]
        public decimal LimiteMaximo { get; set; }

        [DisplayName("Limite Mínimo")]
        [Column("LIMITEMINIMO")]
        public decimal LimiteMinimo { get; set; }

        [DisplayName("De")]
        [Column("DE")]
        public DateTime? De { get; set; }

        [DisplayName("Até")]
        [Column("ATE")]
        public DateTime? Ate { get; set; }

        public int? IdCodigoImposto { get; set; }
    }
}
