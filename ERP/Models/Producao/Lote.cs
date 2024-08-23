
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("LOTE", Schema = "DBO")]
    public class Lote
    {
        [Key]
        [DisplayName("IdLote")]
        [Column("IDLOTE")]
        public int IdLote { get; set; }
 
        [DisplayName("Ano")]
        [Column("ANO")]
        public int? Ano { get; set; }
 
        [DisplayName("numero")]
        [Column("NUMERO")]
        public int? numero { get; set; }
 
    }
}
