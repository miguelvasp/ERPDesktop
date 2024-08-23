
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("VWVENCIMENTOS", Schema = "DBO")]
    public class vwVencimentos
    {
        [Key]
        [DisplayName("IdContasPagarAberto")]
        [Column("IDCONTASPAGARABERTO")]
        public int? IdContasPagarAberto { get; set; }
 
        [DisplayName("RazaoSocial")]
        [Column("RAZAOSOCIAL")]
        public string RazaoSocial { get; set; }
 
        [DisplayName("Vencimento")]
        [Column("VENCIMENTO")]
        public DateTime Vencimento { get; set; }
 
        [DisplayName("ValorLiquido")]
        [Column("VALORLIQUIDO")]
        public decimal? ValorLiquido { get; set; }
 
        [DisplayName("IdMetodoPagamento")]
        [Column("IDMETODOPAGAMENTO")]
        public int? IdMetodoPagamento { get; set; }
 
        [DisplayName("Documento")]
        [Column("DOCUMENTO")]
        public string Documento { get; set; }
 
        [DisplayName("Saldo")]
        [Column("SALDO")]
        public decimal? Saldo { get; set; }

        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }

        [Column("IDCONTASPAGAR")]
        public int? IdContasPagar { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }
    }
}
