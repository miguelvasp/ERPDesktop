
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CONFGRUPOIMPOSTOSITEMRETIDO", Schema = "DBO")]
    public class ConfGrupoImpostosItemRetido
    {
        [Key]
        [DisplayName("IdConfGrupoImpostosItemRetido")]
        [Column("IDCONFGRUPOIMPOSTOSITEMRETIDO")]
        public int IdConfGrupoImpostosItemRetido { get; set; }
 
        [DisplayName("IdGrupoImpostoRetido")]
        [Column("IDGRUPOIMPOSTORETIDO")]
        public int IdGrupoImpostoRetido { get; set; }
 
        [DisplayName("IdCodigoImpostoRetido")]
        [Column("IDCODIGOIMPOSTORETIDO")]
        public int IdCodigoImpostoRetido { get; set; }
 
    }
}
