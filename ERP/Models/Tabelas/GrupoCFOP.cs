using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("GRUPOCFOP", Schema = "DBO")]
    public class GrupoCFOP
    {
        [Key]
        [DisplayName("IdGrupoCFOP")]
        [Column("IDGRUPOCFOP")]
        public int IdGrupoCFOP { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
