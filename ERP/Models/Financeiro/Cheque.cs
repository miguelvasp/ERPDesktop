
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CHEQUE", Schema = "DBO")]
    public class Cheque
    {
        [Key]
        [DisplayName("IdCheque")]
        [Column("IDCHEQUE")]
        public int? IdCheque { get; set; }
 
        [DisplayName("NumeroCheque")]
        [Column("NUMEROCHEQUE")]
        public int? NumeroCheque { get; set; }
 
        [DisplayName("IdContaBancaria")]
        [Column("IDCONTABANCARIA")]
        public int? IdContaBancaria { get; set; }
 
        [DisplayName("Status")]
        [Column("STATUS")]
        public int? Status { get; set; }
 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }
 
        [DisplayName("Vencimento")]
        [Column("VENCIMENTO")]
        public DateTime? Vencimento { get; set; }
 
        [DisplayName("Emissao")]
        [Column("EMISSAO")]
        public DateTime? Emissao { get; set; }
 
        [DisplayName("IdFornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }
 
        [DisplayName("ComprovantePagamento")]
        [Column("COMPROVANTEPAGAMENTO")]
        public string ComprovantePagamento { get; set; }
 
    }
}
