
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CONTASRECEBER", Schema = "DBO")]
    public class ContasReceber
    {
        [Key]
        [DisplayName("IdContasReceber")]
        [Column("IDCONTASRECEBER")]
        public int IdContasReceber { get; set; }
 
        [DisplayName("Documento")]
        [Column("DOCUMENTO")]
        public string Documento { get; set; }
 
        [DisplayName("IdContaContabil")]
        [Column("IDCONTACONTABIL")]
        public int? IdContaContabil { get; set; }
 
        [DisplayName("ValorTitulo")]
        [Column("VALORTITULO")]
        public decimal? ValorTitulo { get; set; }
 
        [DisplayName("Desconto")]
        [Column("DESCONTO")]
        public decimal? Desconto { get; set; }
 
        [DisplayName("ValorLiquido")]
        [Column("VALORLIQUIDO")]
        public decimal? ValorLiquido { get; set; }
 
        [DisplayName("Vencimento")]
        [Column("VENCIMENTO")]
        public DateTime? Vencimento { get; set; }
 
        [DisplayName("VencimentoOriginal")]
        [Column("VENCIMENTOORIGINAL")]
        public DateTime? VencimentoOriginal { get; set; }
 
        [DisplayName("Emissao")]
        [Column("EMISSAO")]
        public DateTime? Emissao { get; set; }
 
        [DisplayName("Saldo")]
        [Column("SALDO")]
        public decimal? Saldo { get; set; }
 
        [DisplayName("Correcao")]
        [Column("CORRECAO")]
        public bool Correcao { get; set; }
 
        [DisplayName("DataDocumento")]
        [Column("DATADOCUMENTO")]
        public DateTime? DataDocumento { get; set; }
 
        [DisplayName("IdCliente")]
        [Column("IDCLIENTE")]
        public int? IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        [DisplayName("Observacao")]
        [Column("OBSERVACAO")]
        public string Observacao { get; set; }
 
        [DisplayName("Acrecimo")]
        [Column("ACRECIMO")]
        public decimal? Acrecimo { get; set; }
 
        [DisplayName("ValorPago")]
        [Column("VALORPAGO")]
        public decimal? ValorPago { get; set; }
 
        [DisplayName("Cancelamento")]
        [Column("CANCELAMENTO")]
        public bool Cancelamento { get; set; }
 
        [DisplayName("Cancelado")]
        [Column("CANCELADO")]
        public bool Cancelado { get; set; }
 
        [DisplayName("IdMoeda")]
        [Column("IDMOEDA")]
        public int? IdMoeda { get; set; }
 
        [DisplayName("UltimoPagamento")]
        [Column("ULTIMOPAGAMENTO")]
        public DateTime? UltimoPagamento { get; set; }
 
        [DisplayName("CalculaRetencao")]
        [Column("CALCULARETENCAO")]
        public bool CalculaRetencao { get; set; }
 
        [DisplayName("IdMetodoPagamento")]
        [Column("IDMETODOPAGAMENTO")]
        public int? IdMetodoPagamento { get; set; }
 
        [DisplayName("IdEspecificacaoPagamento")]
        [Column("IDESPECIFICACAOPAGAMENTO")]
        public int? IdEspecificacaoPagamento { get; set; }
 
        [DisplayName("IdPerfilCliente")]
        [Column("IDPERFILCLIENTE")]
        public int? IdPerfilCliente { get; set; }
 
        [DisplayName("Status")]
        [Column("STATUS")]
        public int? Status { get; set; }
 
        [DisplayName("TipoTransacao")]
        [Column("TIPOTRANSACAO")]
        public int? TipoTransacao { get; set; }
 
        [DisplayName("IdNotaFiscal")]
        [Column("IDNOTAFISCAL")]
        public int? IdNotaFiscal { get; set; }
 
        [DisplayName("Parcelas")]
        [Column("PARCELAS")]
        public int? Parcelas { get; set; }
 
        [DisplayName("ParcelasPagas")]
        [Column("PARCELASPAGAS")]
        public int? ParcelasPagas { get; set; }

        [Column("IDCONDICAOPAGAMENTO")]
        public int? IdCondicaoPagamento { get; set; }


    }
}
