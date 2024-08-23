
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("UNIDADEPRODUCAO", Schema = "DBO")]
    public class UnidadeProducao
    {
        [Key]
        [DisplayName("IdUnidadeProducao")]
        [Column("IDUNIDADEPRODUCAO")]
        public int? IdUnidadeProducao { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
        [DisplayName("QuantidadeProducao")]
        [Column("QUANTIDADEPRODUCAO")]
        public decimal? QuantidadeProducao { get; set; }
 
    }
}
