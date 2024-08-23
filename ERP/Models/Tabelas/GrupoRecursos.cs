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

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Id Armazém")]
        [Column("IDARMAZEM")]
        public int? IdArmazem { get; set; }
     }
}
