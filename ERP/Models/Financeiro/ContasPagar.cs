using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("CONTASPAGAR", Schema = "DBO")]
    public class ContasPagar
    {
        [Key]
        [DisplayName("IdContasPagar")]
        [Column("IDCONTASPAGAR")]
        public int IdContasPagar { get; set; }
 
        [DisplayName("PedidoCompras")]
        [Column("PEDIDOCOMPRAS")]
        public string PedidoCompras { get; set; }
 
        [DisplayName("Documento")]
        [Column("DOCUMENTO")]
        public string Documento { get; set; }
 
        [DisplayName("IdContaContabil")]
        [Column("IDCONTACONTABIL")]
        public int? IdContaContabil { get; set; }
 
        [DisplayName("IdDiario")]
        [Column("IDDIARIO")]
        public int? IdDiario { get; set; }
 
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
 
        [DisplayName("IdFornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }
 
        [DisplayName("Observação")]
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
 
        [DisplayName("IdPerfilFornecedor")]
        [Column("IDPERFILFORNECEDOR")]
        public int? IdPerfilFornecedor { get; set; }
 
        [DisplayName("Status")]
        [Column("STATUS")]
        public int? Status { get; set; }
 
        [DisplayName("TipoTransacao")]
        [Column("TIPOTRANSACAO")]
        public int? TipoTransacao { get; set; }
 
        [DisplayName("NFSE")]
        [Column("NFSE")]
        public string NFSE { get; set; }
 
        [DisplayName("ValorTotalServico")]
        [Column("VALORTOTALSERVICO")]
        public decimal? ValorTotalServico { get; set; }

        [Column("IDNOTAFISCAL")]
        public int? IdNotaFiscal { get; set; }

        [Column("PARCELAS")]
        public int? Parcelas { get; set; }

        [Column("PARCELASPAGAS")]
        public int? ParcelasPagas { get; set; }

        [Column("IDCONDICAOPAGAMENTO")]
        public int? IdCondicaoPagamento { get; set; }

    }
}
