using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("EMBALAGEM", Schema = "DBO")]
    public class Embalagem
    {
        [Key]
        [DisplayName("IdEmbalagem")]
        [Column("IDEMBALAGEM")]
        public int IdEmbalagem { get; set; }

        [DisplayName("Descri��o")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; } 
    }
}
