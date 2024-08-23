using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    [Table("GRUPOCUSTO", Schema = "DBO")]
    public class GrupoCusto
    {
        [Key]
        [DisplayName("IdGrupoCusto")]
        [Column("IDGRUPOCUSTO")]
        public int IdGrupoCusto { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; } 
    }
}
