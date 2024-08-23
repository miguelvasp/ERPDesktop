
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("RECEBIMENTOLOTE", Schema = "DBO")]
    public class RecebimentoLote
    {
        [Key]
        [DisplayName("IdRecebimentoLote")]
        [Column("IDRECEBIMENTOLOTE")]
        public int IdRecebimentoLote { get; set; }
 
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
 
        [DisplayName("StatusRecebimento")]
        [Column("STATUSRECEBIMENTO")]
        public int? StatusRecebimento { get; set; }
 
        [DisplayName("Cheque")]
        [Column("CHEQUE")]
        public int? Cheque { get; set; }
 
        [DisplayName("IdCheque")]
        [Column("IDCHEQUE")]
        public int? IdCheque { get; set; }
 
    }
}
