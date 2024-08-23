
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("LIMITEIMPOSTORETIDO", Schema = "DBO")]
    public class LimiteImpostoRetido
    {
        [Key]
        [DisplayName("IdLimiteImpostoRetido")]
        [Column("IDLIMITEIMPOSTORETIDO")]
        public int IdLimiteImpostoRetido { get; set; }
 
        [DisplayName("LimiteMaximo")]
        [Column("LIMITEMAXIMO")]
        public decimal? LimiteMaximo { get; set; }
 
        [DisplayName("LimiteMinimo")]
        [Column("LIMITEMINIMO")]
        public decimal? LimiteMinimo { get; set; }
 
        [DisplayName("De")]
        [Column("DE")]
        public DateTime? De { get; set; }
 
        [DisplayName("Ate")]
        [Column("ATE")]
        public DateTime? Ate { get; set; }
 
        [DisplayName("IdCodigoImpostoretido")]
        [Column("IDCODIGOIMPOSTORETIDO")]
        public int? IdCodigoImpostoretido { get; set; }
 
    }
}
