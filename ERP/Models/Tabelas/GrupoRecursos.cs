using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("GRUPORECURSOS", Schema = "DBO")]
    public class GrupoRecursos
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDGRUPORECURSOS")]
        public int IdGrupoRecursos { get; set; }

        [DisplayName("Descri��o")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Id Armaz�m")]
        [Column("IDARMAZEM")]
        public int? IdArmazem { get; set; }
     }
}
