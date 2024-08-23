using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("GRUPODESCONTOS", Schema = "DBO")]
    public class GrupoDescontos
    {
        [Key]
        [DisplayName("IdGrupoDescontos")]
        [Column("IDGRUPODESCONTOS")]
        public int IdGrupoDescontos { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
    }
}
