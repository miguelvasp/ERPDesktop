
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("TEMPOTRABALHO", Schema = "DBO")]
    public class TempoTrabalho
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDTEMPOTRABALHO")]
        public int IdTempoTrabalho { get; set; }
 
        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Fechado")]
        [Column("FECHADO")]
        public bool Fechado { get; set; }
 
    }
}
