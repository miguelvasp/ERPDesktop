
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("MOVIMENTACAOBANCARIA", Schema = "DBO")]
    public class MovimentacaoBancaria
    {
        [Key]
        [DisplayName("IdMovimentacao")]
        [Column("IDMOVIMENTACAO")]
        public int IdMovimentacao { get; set; }
 
        [DisplayName("IdEmpresa")]
        [Column("IDEMPRESA")]
        public int? IdEmpresa { get; set; }
 
        [DisplayName("IdBanco")]
        [Column("IDBANCO")]
        public int? IdBanco { get; set; }
 
        [DisplayName("IdContaBancaria")]
        [Column("IDCONTABANCARIA")]
        public int? IdContaBancaria { get; set; }
 
        [DisplayName("DataMovimentacao")]
        [Column("DATAMOVIMENTACAO")]
        public DateTime? DataMovimentacao { get; set; }
 
        [DisplayName("TipoMovimento")]
        [Column("TIPOMOVIMENTO")]
        public int? TipoMovimento { get; set; }
 
        [DisplayName("NumeroDocumento")]
        [Column("NUMERODOCUMENTO")]
        public string NumeroDocumento { get; set; }
 
        [DisplayName("IdPagamento")]
        [Column("IDCONTASPAGARBAIXA")]
        public int? IdContasPagarBaixa { get; set; }
 
        [DisplayName("IdRecebimento")]
        [Column("IDCONTASRECEBERBAIXA")]
        public int? IdContasReceberBaixa { get; set; }
 
        [DisplayName("Historico")]
        [Column("HISTORICO")]
        public string Historico { get; set; }
 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }
 
        [DisplayName("IdContaContabil")]
        [Column("IDCONTACONTABIL")]
        public int? IdContaContabil { get; set; }
 
        [DisplayName("Conciliado")]
        [Column("CONCILIADO")]
        public bool Conciliado { get; set; }
 
    }
}
