
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PEDIDOCOMPRAITEMAPURACAOIMPOSTO", Schema = "DBO")]
    public class PedidoCompraItemApuracaoImposto
    {
        [Key]
        [DisplayName("IdPedidoCompraItemApuracaoImposto")]
        [Column("IDPEDIDOCOMPRAITEMAPURACAOIMPOSTO")]
        public int IdPedidoCompraItemApuracaoImposto { get; set; }
 
        [DisplayName("IdPedidoCompraItem")]
        [Column("IDPEDIDOCOMPRAITEM")]
        public int? IdPedidoCompraItem { get; set; }
 
        [DisplayName("DataLancamento")]
        [Column("DATALANCAMENTO")]
        public DateTime? DataLancamento { get; set; }
 
        [DisplayName("DataDocumento")]
        [Column("DATADOCUMENTO")]
        public DateTime? DataDocumento { get; set; }
 
        [DisplayName("IdNotaFiscal")]
        [Column("IDNOTAFISCAL")]
        public int? IdNotaFiscal { get; set; }
 
        [DisplayName("NotaFiscalNumero")]
        [Column("NOTAFISCALNUMERO")]
        public string NotaFiscalNumero { get; set; }
 
        [DisplayName("DataVencimentoImposto")]
        [Column("DATAVENCIMENTOIMPOSTO")]
        public DateTime? DataVencimentoImposto { get; set; }
 
        [DisplayName("DataRegistroIVA")]
        [Column("DATAREGISTROIVA")]
        public DateTime? DataRegistroIVA { get; set; }
 
        [DisplayName("IdCodigoImposto")]
        [Column("IDCODIGOIMPOSTO")]
        public int? IdCodigoImposto { get; set; }
 
        [DisplayName("IdCodigoTributacao")]
        [Column("IDCODIGOTRIBUTACAO")]
        public int? IdCodigoTributacao { get; set; }
 
        [DisplayName("IdCodigoTributacaoAjustado")]
        [Column("IDCODIGOTRIBUTACAOAJUSTADO")]
        public int? IdCodigoTributacaoAjustado { get; set; }
 
        [DisplayName("ValorFiscal")]
        [Column("VALORFISCAL")]
        public decimal? ValorFiscal { get; set; }
 
        [DisplayName("ValorFiscalAjustado")]
        [Column("VALORFISCALAJUSTADO")]
        public decimal? ValorFiscalAjustado { get; set; }
 
        [DisplayName("Aliquota")]
        [Column("ALIQUOTA")]
        public decimal? Aliquota { get; set; }
 
        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal? Quantidade { get; set; }
 
        [DisplayName("IdMoeda")]
        [Column("IDMOEDA")]
        public int? IdMoeda { get; set; }
 
        [DisplayName("PercentualDaDiferencaICMS")]
        [Column("PERCENTUALDADIFERENCAICMS")]
        public decimal? PercentualDaDiferencaICMS { get; set; }
 
        [DisplayName("PercentualDeReducaoImposto")]
        [Column("PERCENTUALDEREDUCAOIMPOSTO")]
        public decimal? PercentualDeReducaoImposto { get; set; }
 
        [DisplayName("EncargoImposto")]
        [Column("ENCARGOIMPOSTO")]
        public decimal? EncargoImposto { get; set; }
 
        [DisplayName("BaseValor")]
        [Column("BASEVALOR")]
        public decimal? BaseValor { get; set; }
 
        [DisplayName("BaseValorAjustado")]
        [Column("BASEVALORAJUSTADO")]
        public decimal? BaseValorAjustado { get; set; }
 
        [DisplayName("OutroValorBase")]
        [Column("OUTROVALORBASE")]
        public decimal? OutroValorBase { get; set; }
 
        [DisplayName("OutroValorImposto")]
        [Column("OUTROVALORIMPOSTO")]
        public decimal? OutroValorImposto { get; set; }
 
        [DisplayName("ValorBaseIsencao")]
        [Column("VALORBASEISENCAO")]
        public decimal? ValorBaseIsencao { get; set; }
 
        [DisplayName("ValorIsencaoImposto")]
        [Column("VALORISENCAOIMPOSTO")]
        public decimal? ValorIsencaoImposto { get; set; }
 
        [DisplayName("ValorImposto")]
        [Column("VALORIMPOSTO")]
        public decimal? ValorImposto { get; set; }
 
        [DisplayName("ValorAjustado")]
        [Column("VALORAJUSTADO")]
        public decimal? ValorAjustado { get; set; }
 
        [DisplayName("IdCodigoIsencao")]
        [Column("IDCODIGOISENCAO")]
        public int? IdCodigoIsencao { get; set; }
 
        [DisplayName("IdJurisdicaoImposto")]
        [Column("IDJURISDICAOIMPOSTO")]
        public int? IdJurisdicaoImposto { get; set; }
 
        [DisplayName("DirecaoImposto")]
        [Column("DIRECAOIMPOSTO")]
        public int? DirecaoImposto { get; set; }
 
        [DisplayName("Automatico")]
        [Column("AUTOMATICO")]
        public bool Automatico { get; set; }
 
        [DisplayName("IdContaContabil")]
        [Column("IDCONTACONTABIL")]
        public int? IdContaContabil { get; set; }
 
        [DisplayName("ImpostoRetido")]
        [Column("IMPOSTORETIDO")]
        public bool ImpostoRetido { get; set; }
 
        [DisplayName("ImpostoImportacaoDireta")]
        [Column("IMPOSTOIMPORTACAODIRETA")]
        public bool ImpostoImportacaoDireta { get; set; }
 
        [DisplayName("EntidadeLancamentoImpostoIntercompanhia")]
        [Column("ENTIDADELANCAMENTOIMPOSTOINTERCOMPANHIA")]
        public int? EntidadeLancamentoImpostoIntercompanhia { get; set; }
 
        [DisplayName("IdGrupoImposto")]
        [Column("IDGRUPOIMPOSTO")]
        public int? IdGrupoImposto { get; set; }
 
        [DisplayName("IdGrupoImpostoItem")]
        [Column("IDGRUPOIMPOSTOITEM")]
        public int? IdGrupoImpostoItem { get; set; }
 
        [DisplayName("GST_HST")]
        [Column("GST_HST")]
        public int? GST_HST { get; set; }
 
        [DisplayName("Isencao")]
        [Column("ISENCAO")]
        public bool Isencao { get; set; }
 
        [DisplayName("LancarImpostoAReceberLongoPrazo")]
        [Column("LANCARIMPOSTOARECEBERLONGOPRAZO")]
        public bool LancarImpostoAReceberLongoPrazo { get; set; }
 
        [DisplayName("MetodoSubstituicaoTributaria")]
        [Column("METODOSUBSTITUICAOTRIBUTARIA")]
        public int? MetodoSubstituicaoTributaria { get; set; }
 
        [DisplayName("DiferencialICMS")]
        [Column("DIFERENCIALICMS")]
        public bool DiferencialICMS { get; set; }
 
        [DisplayName("IdMoedaComprovante")]
        [Column("IDMOEDACOMPROVANTE")]
        public int? IdMoedaComprovante { get; set; }
 
        [DisplayName("Origem")]
        [Column("ORIGEM")]
        public int? Origem { get; set; }
 
        [DisplayName("FiscalOrigem")]
        [Column("FISCALORIGEM")]
        public int? FiscalOrigem { get; set; }
 
        [DisplayName("IdPeriodoLiquidacaoImposto")]
        [Column("IDPERIODOLIQUIDACAOIMPOSTO")]
        public int? IdPeriodoLiquidacaoImposto { get; set; }
 
        [DisplayName("TipoImposto")]
        [Column("TIPOIMPOSTO")]
        public int? TipoImposto { get; set; }
 
        [DisplayName("UsuarioFinal")]
        [Column("USUARIOFINAL")]
        public bool UsuarioFinal { get; set; }

        [Column("MANTERDADOSAJUSTADOS")]
        public bool? ManterDadosAjustados { get; set; }


    }
}
