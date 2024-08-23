
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("NOTAFISCALVENCIMENTOS", Schema = "DBO")]
    public class NotaFiscalVencimentos
    {
        [Key]
        [DisplayName("IdNotaFiscalVencimento")]
        [Column("IDNOTAFISCALVENCIMENTO")]
        public int IdNotaFiscalVencimento { get; set; }
 
        [DisplayName("IdNotaFiscal")]
        [Column("IDNOTAFISCAL")]
        public int? IdNotaFiscal { get; set; }
 
        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime? Data { get; set; }
 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }
 
    }
}
