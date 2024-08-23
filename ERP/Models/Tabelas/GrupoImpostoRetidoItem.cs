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

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }
     }
}
