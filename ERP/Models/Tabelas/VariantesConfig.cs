using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("VARIANTESCONFIG", Schema = "DBO")]
    public class VariantesConfig
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDVARIANTESCONFIG")]
        public int IdVariantesConfig { get; set; }

        [DisplayName("Descri��o")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("C�digo")]
        [Column("CODIGO")]
        public string Codigo { get; set; }
 
    }
}
