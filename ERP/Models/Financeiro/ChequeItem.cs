
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CHEQUEITEM", Schema = "DBO")]
    public class ChequeItem
    {
        [Key]
        [DisplayName("IdChequeItem")]
        [Column("IDCHEQUEITEM")]
        public int? IdChequeItem { get; set; }
 
        [DisplayName("IdCheque")]
        [Column("IDCHEQUE")]
        public int? IdCheque { get; set; }
 
        [DisplayName("IdCliente")]
        [Column("IDCLIENTE")]
        public int? IdCliente { get; set; }
 
        [DisplayName("IdFornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }
 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }

        [Column("FORNECEDOR")]
        public string Fornecedor { get; set; }
 
    }
}
