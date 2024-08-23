using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("DIARIOBOMLINHA", Schema = "DBO")]
    public class DiarioBomLinha
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDDIARIOBOMLINHA")]
        public int IdDiarioBomLinha { get; set; }
 
        [DisplayName("Id Diário Bom")]
        [Column("IDDIARIOBOM")]
        public int? IdDiarioBom { get; set; }
 
        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime? Data { get; set; }
 
        [DisplayName("Número Linha")]
        [Column("NUMEROLINHA")]
        public int? NumeroLinha { get; set; }
 
        [DisplayName("Número Item")]
        [Column("NUMEROITEM")]
        public int? NumeroItem { get; set; }
 
        [DisplayName("IdOrdemProducao")]
        [Column("IDORDEMPRODUCAO")]
        public int? IdOrdemProducao { get; set; }
 
        [DisplayName("IdUnidade")]
        [Column("IDUNIDADE")]
        public int? IdUnidade { get; set; }
 
        [DisplayName("IdSequenciaComprovante")]
        [Column("IDSEQUENCIACOMPROVANTE")]
        public int? IdSequenciaComprovante { get; set; }
 
        [DisplayName("QtdeConsumo")]
        [Column("QTDECONSUMO")]
        public decimal? QtdeConsumo { get; set; }
 
        [DisplayName("QtdeConsumoEstoque")]
        [Column("QTDECONSUMOESTOQUE")]
        public decimal? QtdeConsumoEstoque { get; set; }
 
        [DisplayName("QtdeDevolucao")]
        [Column("QTDEDEVOLUCAO")]
        public decimal? QtdeDevolucao { get; set; }
 
        [DisplayName("Fim")]
        [Column("FIM")]
        public bool Fim { get; set; }
 
        [DisplayName("Devolução")]
        [Column("DEVOLUCAO")]
        public bool Devolucao { get; set; }
 
        [DisplayName("IdConfiguracao")]
        [Column("IDCONFIGURACAO")]
        public int? IdConfiguracao { get; set; }
 
        [DisplayName("IdTamanho")]
        [Column("IDTAMANHO")]
        public int? IdTamanho { get; set; }
 
        [DisplayName("IdCor")]
        [Column("IDCOR")]
        public int? IdCor { get; set; }
 
        [DisplayName("IdEstilo")]
        [Column("IDESTILO")]
        public int? IdEstilo { get; set; }
 
        [DisplayName("IdLote")]
        [Column("IDLOTE")]
        public int? IdLote { get; set; }
 
        [DisplayName("IdLocalizacao")]
        [Column("IDLOCALIZACAO")]
        public int? IdLocalizacao { get; set; }
 
        [DisplayName("Série")]
        [Column("SERIE")]
        public string Serie { get; set; }
 
        [DisplayName("Id Armazém")]
        [Column("IDARMAZEM")]
        public int? IdArmazem { get; set; }
 
        [DisplayName("IdDeposito")]
        [Column("IDDEPOSITO")]
        public int? IdDeposito { get; set; }
 
        [DisplayName("Id Diário Estoque")]
        [Column("IDDIARIOESTOQUE")]
        public int? IdDiarioEstoque { get; set; }
 
        [DisplayName("Qtde Proposta")]
        [Column("QTDEPROPOSTA")]
        public decimal? QtdeProposta { get; set; }
 
        [DisplayName("Preço Custo")]
        [Column("PRECOCUSTO")]
        public decimal? PrecoCusto { get; set; }
 
        [DisplayName("Preço Venda")]
        [Column("PRECOVENDA")]
        public decimal? PrecoVenda { get; set; }
 
        [DisplayName("Referencia Estoque")]
        [Column("REFERENCIAESTOQUE")]
        public int? ReferenciaEstoque { get; set; }
 
        [DisplayName("Sucata")]
        [Column("SUCATA")]
        public decimal? Sucata { get; set; }
 
        [DisplayName("ValorCusto")]
        [Column("VALORCUSTO")]
        public decimal? ValorCusto { get; set; } 
    }
}
