using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("PEDIDOCOMPRAITEM", Schema = "DBO")]
    public class PedidoCompraItem
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDPEDIDOCOMPRAITEM")]
        public int IdPedidoCompraItem { get; set; }

        [DisplayName("Id Pedido Compra")]
        [Column("IDPEDIDOCOMPRA")]
        public int IdPedidoCompra { get; set; }

        [DisplayName("Id Produto")]
        [Column("IDPRODUTO")]
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal? Quantidade { get; set; }

        [DisplayName("Quantidade Recebida")]
        [Column("QUANTIDADERECEBIDA")]
        public decimal? QuantidadeRecebida { get; set; }

        [DisplayName("IPI")]
        [Column("IPI")]
        public decimal? Ipi { get; set; }
        
        [DisplayName("Preço Unitário")]
        [Column("PRECOUNITARIO")]
        public decimal? PrecoUnitario { get; set; }

        [DisplayName("Status")]
        [Column("STATUS")]
        public string Status { get; set; }

        [DisplayName("IdCFOP")]
        [Column("IDCFOP")]
        public int? IdCFOP { get; set; }

        [DisplayName("IdVariantesConfig")]
        [Column("IDVARIANTESCONFIG")]
        public int? IdVariantesConfig { get; set; }

        [DisplayName("IdVariantesEstilo")]
        [Column("IDVARIANTESESTILO")]
        public int? IdVariantesEstilo { get; set; }

        [DisplayName("IdVariantesCor")]
        [Column("IDVARIANTESCOR")]
        public int? IdVariantesCor { get; set; }

        [DisplayName("IdVariantesTamanho")]
        [Column("IDVARIANTESTAMANHO")]
        public int? IdVariantesTamanho { get; set; }

        [DisplayName("IdGrupoLotes")]
        [Column("IDGRUPOLOTES")]
        public int? IdGrupoLotes { get; set; }

        [DisplayName("IdGrupoSeries")]
        [Column("IDGRUPOSERIES")]
        public int? IdGrupoSeries { get; set; }

        [DisplayName("IdArmazem")]
        [Column("IDARMAZEM")]
        public int? IdArmazem { get; set; }

        [DisplayName("IdDeposito")]
        [Column("IDDEPOSITO")]
        public int? IdDeposito { get; set; }

        [DisplayName("IdLocalizacao")]
        [Column("IDLOCALIZACAO")]
        public int? IdLocalizacao { get; set; }

        //[DisplayName("CodigoExternoFornecedor")]
        //[Column("CODIGOEXTERNOFORNECEDOR")]
        //public string CodigoExternoFornecedor { get; set; }

        [DisplayName("AtivoFixo")]
        [Column("ATIVOFIXO")]
        public bool? AtivoFixo { get; set; }

        [DisplayName("IdGrupodeAtivo")]
        [Column("IDGRUPODEATIVO")]
        public int? IdGrupodeAtivo { get; set; }

        [DisplayName("IdAtivoFixo")]
        [Column("IDATIVOFIXO")]
        public int? IdAtivoFixo { get; set; }

        [DisplayName("IdGrupoImposto")]
        [Column("IDGRUPOIMPOSTO")]
        public int? IdGrupoImposto { get; set; }

        [DisplayName("IdGrupoImpostosItem")]
        [Column("IDGRUPOIMPOSTOSITEM")]
        public int? IdGrupoImpostosItem { get; set; }

        [DisplayName("IdNCM")]
        [Column("IDNCM")]
        public int? IdNCM { get; set; }

        [DisplayName("IdGrupoEncargos")]
        [Column("IDGRUPOENCARGOS")]
        public int? IdGrupoEncargos { get; set; }

        [DisplayName("IdGrupoDescontos")]
        [Column("IDGRUPODESCONTOS")]
        public int? IdGrupoDescontos { get; set; }

        [DisplayName("IdGrupoFrete")]
        [Column("IDGRUPOFRETE")]
        public int? IdGrupoFrete { get; set; }

        [DisplayName("IdRoyalties")]
        [Column("IDROYALTIES")]
        public int? IdRoyalties { get; set; }

        [DisplayName("QuantidadeAReceber")]
        [Column("QUANTIDADEARECEBER")]
        public decimal? QuantidadeAReceber { get; set; }

        [DisplayName("IdUnidade")]
        [Column("IDUNIDADE")]
        public int? IdUnidade { get; set; }

        [DisplayName("PrecoTabela")]
        [Column("PRECOTABELA")]
        public decimal? PrecoTabela { get; set; }

        [DisplayName("DescontoPercentual")]
        [Column("DESCONTOPERCENTUAL")]
        public decimal? DescontoPercentual { get; set; }

        [DisplayName("DescontoValor")]
        [Column("DESCONTOVALOR")]
        public decimal? DescontoValor { get; set; }

        [DisplayName("ValorEncargos")]
        [Column("VALORENCARGOS")]
        public decimal? ValorEncargos { get; set; }

        [DisplayName("ValorLiquido")]
        [Column("VALORLIQUIDO")]
        public decimal? ValorLiquido { get; set; }

        [DisplayName("IdCodigoServico")]
        [Column("IDCODIGOSERVICO")]
        public int? IdCodigoServico { get; set; }

        [DisplayName("IdTipoDocumentoFiscal")]
        [Column("IDTIPODOCUMENTOFISCAL")]
        public int? IdTipoDocumentoFiscal { get; set; }

        [DisplayName("MovimentaEstoque")]
        [Column("MOVIMENTAESTOQUE")]
        public bool? MovimentaEstoque { get; set; }

        [DisplayName("TipoOrdem")]
        [Column("TIPOORDEM")]
        public int? TipoOrdem { get; set; }

        [DisplayName("IdCodigoExternoFornecedor")]
        [Column("IDCODIGOEXTERNOFORNECEDOR")]
        public int? IdCodigoExternoFornecedor { get; set; }

        [DisplayName("IdMetodoPreciacao")]
        [Column("IDMETODOPRECIACAO")]
        public int? IdMetodoPreciacao { get; set; }

        [DisplayName("CreditoICMSAtivo")]
        [Column("CREDITOICMSATIVO")]
        public bool? CreditoICMSAtivo { get; set; }

        [DisplayName("CreditoPisCofins")]
        [Column("CREDITOPISCOFINS")]
        public bool? CreditoPisCofins { get; set; }

        [DisplayName("ParcelaICMS")]
        [Column("PARCELAICMS")]
        public int? ParcelaICMS { get; set; }

        [DisplayName("TipoTransacaoAtivo")]
        [Column("TIPOTRANSACAOATIVO")]
        public int? TipoTransacaoAtivo { get; set; }

        [DisplayName("IdGrupoImpostoRetido")]
        [Column("IDGRUPOIMPOSTORETIDO")]
        public int? IdGrupoImpostoRetido { get; set; }

        [DisplayName("IdGrupoImpostoItemRetido")]
        [Column("IDGRUPOIMPOSTOITEMRETIDO")]
        public int? IdGrupoImpostoItemRetido { get; set; }

        [DisplayName("PesoUnitario")]
        [Column("PESOUNITARIO")]
        public decimal? PesoUnitario { get; set; }

        [DisplayName("IdOrdemPlanejada")]
        [Column("IDORDEMPLANEJADA")]
        public int? IdOrdemPlanejada { get; set; }

        [DisplayName("IdPlanoMestre")]
        [Column("IDPLANOMESTRE")]
        public int? IdPlanoMestre { get; set; }

        [DisplayName("IdOrdemDevolvida")]
        [Column("IDORDEMDEVOLVIDA")]
        public int? IdOrdemDevolvida { get; set; }

        [DisplayName("StatusLinha")]
        [Column("STATUSLINHA")]
        public int? StatusLinha { get; set; }

        [DisplayName("Id Cest")]
        [Column("IDCEST")]
        public int? IdCest { get; set; }
        //public virtual GrupoProduto GrupoProduto { get; set; }
    }
}
