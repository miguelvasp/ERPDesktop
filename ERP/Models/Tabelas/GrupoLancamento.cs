using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("GRUPOLANCAMENTO", Schema = "DBO")]
    public class GrupoLancamento
    {
        [Key]
        [DisplayName("IdGrupoLancamento")]
        [Column("IDGRUPOLANCAMENTO")]
        public int IdGrupoLancamento { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; } 
    }
}
