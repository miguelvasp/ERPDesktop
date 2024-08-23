
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("VARIANTESGRUPOITEM", Schema = "DBO")]
    public class VariantesGrupoItem
    {
        [Key]
        [DisplayName("IdVariantesGrupoItem")]
        [Column("IDVARIANTESGRUPOITEM")]
        public int IdVariantesGrupoItem { get; set; }
 
        [DisplayName("IdVariantesGrupo")]
        [Column("IDVARIANTESGRUPO")]
        public int? IdVariantesGrupo { get; set; }
 
        [DisplayName("IdCor")]
        [Column("IDCOR")]
        public int? IdCor { get; set; }
 
        [DisplayName("IdEstilo")]
        [Column("IDESTILO")]
        public int? IdEstilo { get; set; }
 
        [DisplayName("IdTamanho")]
        [Column("IDTAMANHO")]
        public int? IdTamanho { get; set; }
 
        [DisplayName("IdConfiguracao")]
        [Column("IDCONFIGURACAO")]
        public int? IdConfiguracao { get; set; }
 
    }
}
