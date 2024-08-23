
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("MOVIMENTACAOATIVO", Schema = "DBO")]
    public class MovimentacaoAtivo
    {
        [Key]
        [DisplayName("IdMovimentacaoAtivo")]
        [Column("IDMOVIMENTACAOATIVO")]
        public int IdMovimentacaoAtivo { get; set; }
 
        [DisplayName("IdMovimentacaoAtivoStatus")]
        [Column("IDMOVIMENTACAOATIVOSTATUS")]
        public int? IdMovimentacaoAtivoStatus { get; set; }
 
        [DisplayName("IDTransacaoAtivo")]
        [Column("IDTRANSACAOATIVO")]
        public int? IDTransacaoAtivo { get; set; }
 
        [DisplayName("IDAtivo")]
        [Column("IDATIVO")]
        public int? IDAtivo { get; set; }
 
        [DisplayName("IDPerfilLan?amento")]
        [Column("IDPERFILLAN?AMENTO")]
        public int? IDPerfilLanamento { get; set; }
 
        [DisplayName("IDCliente")]
        [Column("IDCLIENTE")]
        public int? IDCliente { get; set; }
 
        [DisplayName("IDFornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IDFornecedor { get; set; }
 
        [DisplayName("Convencao")]
        [Column("CONVENCAO")]
        public int? Convencao { get; set; }
 
        [DisplayName("DataUltimaDepreciacao")]
        [Column("DATAULTIMADEPRECIACAO")]
        public DateTime? DataUltimaDepreciacao { get; set; }
 
        [DisplayName("DataExecucaoDepreciacao")]
        [Column("DATAEXECUCAODEPRECIACAO")]
        public DateTime? DataExecucaoDepreciacao { get; set; }
 
        [DisplayName("Depreciacao")]
        [Column("DEPRECIACAO")]
        public int? Depreciacao { get; set; }
 
        [DisplayName("IDGrupoAtivo")]
        [Column("IDGRUPOATIVO")]
        public int? IDGrupoAtivo { get; set; }
 
        [DisplayName("PermitirValorNegativo")]
        [Column("PERMITIRVALORNEGATIVO")]
        public int? PermitirValorNegativo { get; set; }
 
        [DisplayName("Periodo")]
        [Column("PERIODO")]
        public int? Periodo { get; set; }
 
        [DisplayName("PeriodoDepreciacaoRestante")]
        [Column("PERIODODEPRECIACAORESTANTE")]
        public int? PeriodoDepreciacaoRestante { get; set; }
 
        [DisplayName("ValorAquisicao")]
        [Column("VALORAQUISICAO")]
        public decimal? ValorAquisicao { get; set; }
 
        [DisplayName("RevisaoAquisicao")]
        [Column("REVISAOAQUISICAO")]
        public decimal? RevisaoAquisicao { get; set; }
 
        [DisplayName("StatusAtivo")]
        [Column("STATUSATIVO")]
        public int? StatusAtivo { get; set; }
 
        [DisplayName("ValorSucata")]
        [Column("VALORSUCATA")]
        public decimal? ValorSucata { get; set; }
 
        [DisplayName("ValorVenda")]
        [Column("VALORVENDA")]
        public decimal? ValorVenda { get; set; }
 
        [DisplayName("ValorICMS")]
        [Column("VALORICMS")]
        public decimal? ValorICMS { get; set; }
 
        [DisplayName("VidaUtil")]
        [Column("VIDAUTIL")]
        public decimal? VidaUtil { get; set; }
 
        [DisplayName("DataTrasacao")]
        [Column("DATATRASACAO")]
        public DateTime? DataTrasacao { get; set; }
 
        [DisplayName("DataDocumento")]
        [Column("DATADOCUMENTO")]
        public DateTime? DataDocumento { get; set; }
 
        [DisplayName("NotaFiscal")]
        [Column("NOTAFISCAL")]
        public string NotaFiscal { get; set; }
 
        [DisplayName("NivelLancamento")]
        [Column("NIVELLANCAMENTO")]
        public int? NivelLancamento { get; set; }
 
    }
}
