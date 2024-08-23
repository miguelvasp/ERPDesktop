
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CONFGRUPOIMPOSTORETIDO", Schema = "DBO")]
    public class ConfGrupoImpostoRetido
    {
        [Key]
        [DisplayName("IdConfGrupoImpostoRetido")]
        [Column("IDCONFGRUPOIMPOSTORETIDO")]
        public int IdConfGrupoImpostoRetido { get; set; }
 
        [DisplayName("IdGrupoImpostoRetido")]
        [Column("IDGRUPOIMPOSTORETIDO")]
        public int IdGrupoImpostoRetido { get; set; }
 
        [DisplayName("IdCodigoImposto")]
        [Column("IDCODIGOIMPOSTORETIDO")]
        public int IdCodigoImpostoRetido { get; set; }
 
    }
}
