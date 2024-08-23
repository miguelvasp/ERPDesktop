using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    [Table("IMPOSTORETIDO", Schema = "DBO")]
    public class ImpostoRetido
    {
        [Key]
        [DisplayName("IdImpostoRetido")]
        [Column("IDIMPOSTORETIDO")]
        public int IdImpostoRetido { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
