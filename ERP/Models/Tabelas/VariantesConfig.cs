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

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }
 
    }
}
