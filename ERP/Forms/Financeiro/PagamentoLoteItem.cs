
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PAGAMENTOLOTEITEM", Schema = "DBO")]
    public class PagamentoLoteItem
    {
        [Key]
        [DisplayName("IdPagamentoLoteItem")]
        [Column("IDPAGAMENTOLOTEITEM")]
        public int IdPagamentoLoteItem { get; set; }
 
        [DisplayName("IdPagamentoLote")]
        [Column("IDPAGAMENTOLOTE")]
        public int? IdPagamentoLote { get; set; }
 
        [DisplayName("IdContasPagarAberto")]
        [Column("IDCONTASPAGARABERTO")]
        public int? IdContasPagarAberto { get; set; }
 
        [DisplayName("IdContasPagarBaixa")]
        [Column("IDCONTASPAGARBAIXA")]
        public int? IdContasPagarBaixa { get; set; }
 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }
 
        [DisplayName("StatusBaixa")]
        [Column("STATUSBAIXA")]
        public int? StatusBaixa { get; set; }
 
    }
}
