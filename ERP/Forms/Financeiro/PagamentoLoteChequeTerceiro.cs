
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PAGAMENTOLOTECHEQUETERCEIRO", Schema = "DBO")]
    public class PagamentoLoteChequeTerceiro
    {
        [Key]
        [DisplayName("IdPagamentoLoteChequeTerceiro")]
        [Column("IDPAGAMENTOLOTECHEQUETERCEIRO")]
        public int IdPagamentoLoteChequeTerceiro { get; set; }
 
        [DisplayName("IdPagamentoLote")]
        [Column("IDPAGAMENTOLOTE")]
        public int? IdPagamentoLote { get; set; }
 
        [DisplayName("IdChequeTerceiro")]
        [Column("IDCHEQUETERCEIRO")]
        public int? IdChequeTerceiro { get; set; }
 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }
 
    }
}
