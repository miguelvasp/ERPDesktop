using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("GRUPOLOTES", Schema = "DBO")]
    public class GrupoLotes
    {
        [Key]
        [DisplayName("IdGrupoLotes")]
        [Column("IDGRUPOLOTES")]
        public int IdGrupoLotes { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
     }
}
