using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("ARMAZEM", Schema = "DBO")]
    public class Armazem
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDARMAZEM")]
        public int IdArmazem { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; } 

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; } 
    }
}
