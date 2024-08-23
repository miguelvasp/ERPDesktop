
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("DIASPAGAMENTO", Schema = "DBO")]
    public class DiasPagamento
    {
        [Key]
        [DisplayName("IdDiasPagamento")]
        [Column("IDDIASPAGAMENTO")]
        public int IdDiasPagamento { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
    }
}
