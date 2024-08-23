
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("GRUPOITENSSUPLEMENTARES", Schema = "DBO")]
    public class GrupoItensSuplementares
    {
        [Key]
        [DisplayName("IdGrupoItensSuplementares")]
        [Column("IDGRUPOITENSSUPLEMENTARES")]
        public int IdGrupoItensSuplementares { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; } 
    }
}
