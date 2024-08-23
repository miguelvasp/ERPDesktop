using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("PEDIDOVENDAITEM", Schema = "DBO")]
    public class PedidoVendaItem
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDPEDIDOVENDAITEM")]
        public int IdPedidoVendaItem { get; set; }

        [DisplayName("Id Pedido Venda")]
        [Column("IDPEDIDOVENDA")]
        public int IdPedidoVenda { get; set; }

        [DisplayName("IdProduto")]
        [Column("IDPRODUTO")]
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal Quantidade { get; set; }

        [DisplayName("Quantidade Entregue")]
        [Column("QUANTIDADEENTREGUE")]
        public decimal QuantidadeEntregue { get; set; }

        [DisplayName("Quantidade Separação")]
        [Column("QUANTIDADESEPARACAO")]
        public decimal QuantidadeSeparacao { get; set; }

        [DisplayName("IdUnidade")]
        [Column("IDUNIDADE")]
        public int? IdUnidade { get; set; }

        [DisplayName("Ipi")]
        [Column("IPI")]
        public decimal Ipi { get; set; }

        [DisplayName("PrecoTabela")]
        [Column("PRECOTABELA")]
        public decimal PrecoTabela { get; set; }

        [DisplayName("PrecoUnitario")]
        [Column("PRECOUNITARIO")]
        public decimal PrecoUnitario { get; set; }

        [DisplayName("Desconto Varejista")]
        [Column("DESCONTOVAREJISTA")]
        public decimal DescontoVarejista { get; set; }

        [DisplayName("Desconto Percentual")]
        [Column("DESCONTOPERCENTUAL")]
        public decimal DescontoPercentual { get; set; }

        [DisplayName("Desconto Valor")]
        [Column("DESCONTOVALOR")]
        public decimal DescontoValor { get; set; }

        [DisplayName("Desconto Suframa")]
        [Column("DESCONTOSUFRAMA")]
        public decimal DescontoSuframa { get; set; }

        [DisplayName("Valor Líquido")]
        [Column("VALORLIQUIDO")]
        public decimal ValorLiquido { get; set; }

        [DisplayName("Valor Encargos")]
        [Column("VALORENCARGOS")]
        public decimal ValorEncargos { get; set; }

        [DisplayName("Tipo Ordem")]
        [Column("TIPOORDEM")]
        public int? TipoOrdem { get; set; }

        [DisplayName("Id CFOP")]
        [Column("IDCFOP")]
        public int? IdCFOP { get; set; }

        [DisplayName("Id Código Serviço")]
        [Column("IDCODIGOSERVICO")]
        public int? IdCodigoServico { get; set; }

        [DisplayName("Id Tipo Documento Fiscal")]
        [Column("IDTIPODOCUMENTOFISCAL")]
        public int? IdTipoDocumentoFiscal { get; set; }

        [DisplayName("IdVariantesConfig")]
        [Column("IDVARIANTESCONFIG")]
        public int? IdVariantesConfig { get; set; }

        [DisplayName("Id Variantes Estilo")]
        [Column("IDVARIANTESESTILO")]
        public int? IdVariantesEstilo { get; set; }

        [DisplayName("Id Variantes Cor")]
        [Column("IDVARIANTESCOR")]
        public int? IdVariantesCor { get; set; }

        [DisplayName("Id Variantes Tamanho")]
        [Column("IDVARIANTESTAMANHO")]
        public int? IdVariantesTamanho { get; set; }

        [DisplayName("Id Grupo Lotes")]
        [Column("IDGRUPOLOTES")]
        public int? IdGrupoLotes { get; set; }

        [DisplayName("Id Grupo Séries")]
        [Column("IDGRUPOSERIES")]
        public int? IdGrupoSeries { get; set; }

        [DisplayName("IdArmazém")]
        [Column("IDARMAZEM")]
        public int? IdArmazem { get; set; }

        [DisplayName("IdDepósito")]
        [Column("IDDEPOSITO")]
        public int? IdDeposito { get; set; }

        [DisplayName("Id Localização")]
        [Column("IDLOCALIZACAO")]
        public int? IdLocalizacao { get; set; }

        [DisplayName("Id Código Externo Cliente")]
        [Column("IDCODIGOEXTERNOCLIENTE")]
        public int? IdCodigoExternoCliente { get; set; }

        [DisplayName("Id Ordem Devolvida")]
        [Column("IDORDEMDEVOLVIDA")]
        public int? IdOrdemDevolvida { get; set; }

        [DisplayName("StatusLinha")]
        [Column("STATUSLINHA")]
        public int? StatusLinha { get; set; }

        [DisplayName("Origem Tributação")]
        [Column("ORIGEMTRIBUTACAO")]
        public string OrigemTributacao { get; set; }

        [DisplayName("Ativo Fixo")]
        [Column("ATIVOFIXO")]
        public bool AtivoFixo { get; set; }

        [DisplayName("Id Grupo Ativo")]
        [Column("IDGRUPOATIVO")]
        public int? IdGrupoAtivo { get; set; }

        [DisplayName("Id Ativo Fixo")]
        [Column("IDATIVOFIXO")]
        public int? IdAtivoFixo { get; set; }

        [DisplayName("Id Grupo Imposto")]
        [Column("IDGRUPOIMPOSTO")]
        public int? IdGrupoImposto { get; set; }

        [DisplayName("Id Método Depreciação")]
        [Column("IDMETODODEPRECIACAO")]
        public int? IdMetodoDepreciacao { get; set; }

        [DisplayName("Tipo Transação Ativo")]
        [Column("TIPOTRANSACAOATIVO")]
        public int? TipoTransacaoAtivo { get; set; }

        [DisplayName("Id Grupo Impostos Item")]
        [Column("IDGRUPOIMPOSTOSITEM")]
        public int? IdGrupoImpostosItem { get; set; }

        [DisplayName("Id Grupo Imposto Retido")]
        [Column("IDGRUPOIMPOSTORETIDO")]
        public int? IdGrupoImpostoRetido { get; set; }

        [DisplayName("IdGrupoImpostoItemRetido")]
        [Column("IDGRUPOIMPOSTOITEMRETIDO")]
        public int? IdGrupoImpostoItemRetido { get; set; }

        [DisplayName("IdNCM")]
        [Column("IDNCM")]
        public int? IdNCM { get; set; }

        [DisplayName("Id Grupo Encargos")]
        [Column("IDGRUPOENCARGOS")]
        public int? IdGrupoEncargos { get; set; }

        [DisplayName("Id Grupo Descontos")]
        [Column("IDGRUPODESCONTOS")]
        public int? IdGrupoDescontos { get; set; }

        [DisplayName("Peso Unitário")]
        [Column("PESOUNITARIO")]
        public decimal PesoUnitario { get; set; }

        [DisplayName("QuantidadeFaturada")]
        [Column("QUANTIDADEFATURADA")]
        public decimal? QuantidadeFaturada { get; set; }

        [DisplayName("QuantidadePorFaturar")]
        [Column("QUANTIDADEPORFATURAR")]
        public decimal? QuantidadePorFaturar { get; set; }

        [Column("VALORORIGINAL")]
        public decimal? ValorOriginal { get; set; }

        [DisplayName("Id Cest")]
        [Column("IDCEST")]
        public int? IdCest { get; set; }

        [Column("JUROSCONDICAOPAGAMENTO")]
        public decimal? JurosCondicaoPagamento { get; set; }
    }
}
