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
    [Table("ROYALTIES", Schema = "DBO")]
    public class Royalties
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDROYALTIES")]
        public int IdRoyalties { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Percentual")]
        [Column("PERCENTUAL")]
        public decimal Percentual { get; set; }

        [DisplayName("Cálculo")]
        [Column("CALCULO")]
        public int? Calculo { get; set; }

        [DisplayName("De")]
        [Column("DE")]
        public DateTime? De { get; set; }

        [DisplayName("Até")]
        [Column("ATE")]
        public DateTime? Ate { get; set; }
    }
}
