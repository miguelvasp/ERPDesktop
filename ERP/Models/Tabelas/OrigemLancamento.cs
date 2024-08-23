
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("ORIGEMLANCAMENTO", Schema = "DBO")]
    public class OrigemLancamento
    {
        [Key]
        [DisplayName("IdOrigemLancamento")]
        [Column("IDORIGEMLANCAMENTO")]
        public int IdOrigemLancamento { get; set; }
 
        [DisplayName("Descricao")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
    }
}
