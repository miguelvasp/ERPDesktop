using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("VARIANTESESTILO", Schema = "DBO")]
    public class VariantesEstilo
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDVARIANTESESTILO")]
        public int IdVariantesEstilo { get; set; }

        [DisplayName("C�digo")]
        [Column("CODIGO")]
        public string Codigo { get; set; } 

        [DisplayName("Descri��o")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("C�digo de Barras")]
        [Column("CODIGOBARRAS")]
        public string CodigoBarras { get; set; }
    }
}
