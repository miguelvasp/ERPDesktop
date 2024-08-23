using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("GRUPOIMPOSTORETIDOITEM", Schema = "DBO")]
    public class GrupoImpostoRetidoItem
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDGRUPOIMPOSTORETIDOITEM")]
        public int IdGrupoImpostoRetidoItem { get; set; }

        [DisplayName("Descri��o")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("C�digo")]
        [Column("CODIGO")]
        public string Codigo { get; set; }
     }
}
