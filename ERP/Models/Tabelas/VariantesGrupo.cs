using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("VARIANTESGRUPO", Schema = "DBO")]
    public class VariantesGrupo
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDVARIANTESGRUPO")]
        public int IdVariantesGrupo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; } 
    }
}
