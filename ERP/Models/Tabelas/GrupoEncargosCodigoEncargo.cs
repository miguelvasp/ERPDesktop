
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("GRUPOENCARGOSCODIGOENCARGO", Schema = "DBO")]
    public class GrupoEncargosCodigoEncargo
    {
        [Key]
        [DisplayName("IdGrupoEncargosCodigoEncargo")]
        [Column("IDGRUPOENCARGOSCODIGOENCARGO")]
        public int IdGrupoEncargosCodigoEncargo { get; set; }
 
        [DisplayName("IdGrupoEncargos")]
        [Column("IDGRUPOENCARGOS")]
        public int IdGrupoEncargos { get; set; }
 
        [DisplayName("IdCodigoEncargo")]
        [Column("IDCODIGOENCARGO")]
        public int IdCodigoEncargo { get; set; }
 
    }
}
