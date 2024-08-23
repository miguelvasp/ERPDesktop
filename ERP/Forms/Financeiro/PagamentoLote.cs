
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PAGAMENTOLOTE", Schema = "DBO")]
    public class PagamentoLote
    {
        [Key]
        [DisplayName("IdPagamentoLote")]
        [Column("IDPAGAMENTOLOTE")]
        public int IdPagamentoLote { get; set; }
 
        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime? Data { get; set; }
 
        [DisplayName("IdContaBancaria")]
        [Column("IDCONTABANCARIA")]
        public int? IdContaBancaria { get; set; }
         

        [DisplayName("IdFornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }
         

        [DisplayName("IdCliente")]
        [Column("IDCLIENTE")]
        public int? IdCliente { get; set; }
         

        [DisplayName("IdContaContabil")]
        [Column("IDCONTACONTABIL")]
        public int? IdContaContabil { get; set; }
         

        [DisplayName("IdMetodoPagamento")]
        [Column("IDMETODOPAGAMENTO")]
        public int? IdMetodoPagamento { get; set; }
         
 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }
 
        [DisplayName("StatusPagamento")]
        [Column("STATUSPAGAMENTO")]
        public int? StatusPagamento { get; set; }

        [Column("CHEQUE")]
        public int? Cheque { get; set; }

        [Column("IDCHEQUE")]
        public int? IdCheque { get; set; }
    }
}
