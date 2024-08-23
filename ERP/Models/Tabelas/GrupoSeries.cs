using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("GRUPOSERIES", Schema = "DBO")]
    public class GrupoSeries
    {
        [Key]
        [DisplayName("IdGrupoSeries")]
        [Column("IDGRUPOSERIES")]
        public int IdGrupoSeries { get; set; }

        [DisplayName("Descri��o")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; } 
    }
}
