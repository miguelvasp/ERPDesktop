
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("GRUPOIMPOSTOCODIGOS", Schema = "DBO")]
    public class GrupoImpostoCodigos
    {
        [Key]
        [DisplayName("IdGrupoImpostoCodigo")]
        [Column("IDGRUPOIMPOSTOCODIGO")]
        public int IdGrupoImpostoCodigo { get; set; }
 
        [DisplayName("IdGrupoImposto")]
        [Column("IDGRUPOIMPOSTO")]
        public int IdGrupoImposto { get; set; }
 
        [DisplayName("IdCodigoImposto")]
        [Column("IDCODIGOIMPOSTO")]
        public int IdCodigoImposto { get; set; }

        public virtual CodigoImposto CodigoImposto { get; set; }

    }
}
