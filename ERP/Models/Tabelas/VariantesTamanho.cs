using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("VARIANTESTAMANHO", Schema = "DBO")]
    public class VariantesTamanho
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDVARIANTESTAMANHO")]
        public int IdVariantesTamanho { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; } 

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Código de Barras")]
        [Column("CODIGOBARRAS")]
        public string CodigoBarras { get; set; }
    }
}
