
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CONTASRECEBERABERTO", Schema = "DBO")]
    public class ContasReceberAberto
    {
        [Key]
        [DisplayName("IdContasReceberAberto")]
        [Column("IDCONTASRECEBERABERTO")]
        public int IdContasReceberAberto { get; set; }
 
        [DisplayName("IdContasReceber")]
        [Column("IDCONTASRECEBER")]
        public int? IdContasReceber { get; set; }
 
        [DisplayName("IdCodigoMulta")]
        [Column("IDCODIGOMULTA")]
        public int? IdCodigoMulta { get; set; }
 
        [DisplayName("IdCodigoJuros")]
        [Column("IDCODIGOJUROS")]
        public int? IdCodigoJuros { get; set; }
 
        [DisplayName("Correcao")]
        [Column("CORRECAO")]
        public bool Correcao { get; set; }
 
        [DisplayName("Vencimento")]
        [Column("VENCIMENTO")]
        public DateTime? Vencimento { get; set; }
 
        [DisplayName("VencimentoOriginal")]
        [Column("VENCIMENTOORIGINAL")]
        public DateTime? VencimentoOriginal { get; set; }
 
        [DisplayName("NumeroParcela")]
        [Column("NUMEROPARCELA")]
        public int? NumeroParcela { get; set; }
 
        [DisplayName("NumeroParcelaOriginal")]
        [Column("NUMEROPARCELAORIGINAL")]
        public int? NumeroParcelaOriginal { get; set; }
 
        [DisplayName("Liquidada")]
        [Column("LIQUIDADA")]
        public bool Liquidada { get; set; }
 
        [DisplayName("NumeroRemessa")]
        [Column("NUMEROREMESSA")]
        public string NumeroRemessa { get; set; }
 
        [DisplayName("NumeroDocumentoBancario")]
        [Column("NUMERODOCUMENTOBANCARIO")]
        public string NumeroDocumentoBancario { get; set; }
 
        [DisplayName("ValorTitulo")]
        [Column("VALORTITULO")]
        public decimal? ValorTitulo { get; set; }
 
        [DisplayName("Desconto")]
        [Column("DESCONTO")]
        public decimal? Desconto { get; set; }
 
        [DisplayName("ValorJuros")]
        [Column("VALORJUROS")]
        public decimal? ValorJuros { get; set; }
 
        [DisplayName("ValorMulta")]
        [Column("VALORMULTA")]
        public decimal? ValorMulta { get; set; }
 
        [DisplayName("ValorDescontoVista")]
        [Column("VALORDESCONTOVISTA")]
        public decimal? ValorDescontoVista { get; set; }
 
        [DisplayName("ValorLiquido")]
        [Column("VALORLIQUIDO")]
        public decimal? ValorLiquido { get; set; }
 
        [DisplayName("Retencao")]
        [Column("RETENCAO")]
        public bool Retencao { get; set; }
 
        [DisplayName("Historico")]
        [Column("HISTORICO")]
        public string Historico { get; set; }
 
    }
}
