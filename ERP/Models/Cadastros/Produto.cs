using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("PRODUTO", Schema = "DBO")]
    public class Produto
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDPRODUTO")]
        public int IdProduto { get; set; }

        [DisplayName("Id Empresa")]
        [Column("IDEMPRESA")]
        public int? IdEmpresa { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        public decimal? EstoqueMinimo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Nome Produto")]
        [Column("NOMEPRODUTO")]
        public string NomeProduto { get; set; }

        [DisplayName("Id Tipo Produto")]
        [Column("IDTIPOPRODUTO")]
        public int? IdTipoProduto { get; set; }

        [DisplayName("Id Grupo Produto")]
        [Column("IDGRUPOPRODUTO")]
        public int? IdGrupoProduto { get; set; }
        
        [DisplayName("IdVariantesGrupo")]
        [Column("IDVARIANTESGRUPO")]
        public int? IdVariantesGrupo { get; set; }

        [DisplayName("IdVariantesConfig")]
        [Column("IDVARIANTESCONFIG")]
        public int? IdVariantesConfig { get; set; }

        [DisplayName("IdVariantesTamanho")]
        [Column("IDVARIANTESTAMANHO")]
        public int? IdVariantesTamanho { get; set; }

        [DisplayName("IdVariantesCor")]
        [Column("IDVARIANTESCOR")]
        public int? IdVariantesCor { get; set; }

        [DisplayName("IdVariantesEstilo")]
        [Column("IDVARIANTESESTILO")]
        public int? IdVariantesEstilo { get; set; }

        [DisplayName("ComprasIdUnidade")]
        [Column("COMPRASIDUNIDADE")]
        public int? ComprasIdUnidade { get; set; }

        [DisplayName("ComprasEntregaExcedente")]
        [Column("COMPRASENTREGAEXCEDENTE")]
        public decimal? ComprasEntregaExcedente { get; set; }

        [DisplayName("ComprasEntregaInsuficiente")]
        [Column("COMPRASENTREGAINSUFICIENTE")]
        public decimal? ComprasEntregaInsuficiente { get; set; }

        [DisplayName("ComprasIdGrupoImposto")]
        [Column("COMPRASIDGRUPOIMPOSTO")]
        public int? ComprasIdGrupoImposto { get; set; }

        [DisplayName("ComprasRetencaoFonte")]
        [Column("COMPRASRETENCAOFONTE")]
        public bool ComprasRetencaoFonte { get; set; }

        [DisplayName("ComprasIdGrupoImpostoRetiro")]
        [Column("COMPRASIDGRUPOIMPOSTORETIRO")]
        public int? ComprasIdGrupoImpostoRetiro { get; set; }

        [DisplayName("ComprasIdGrupoEncargos")]
        [Column("COMPRASIDGRUPOENCARGOS")]
        public int? ComprasIdGrupoEncargos { get; set; }

        [DisplayName("ComprasEncargosSobrePreco")]
        [Column("COMPRASENCARGOSSOBREPRECO")]
        public decimal? ComprasEncargosSobrePreco { get; set; }

        [DisplayName("ComprasIncluiNoPrecoUnitario")]
        [Column("COMPRASINCLUINOPRECOUNITARIO")]
        public bool ComprasIncluiNoPrecoUnitario { get; set; }

        [DisplayName("ComprasIdGrupoDesconto")]
        [Column("COMPRASIDGRUPODESCONTO")]
        public int? ComprasIdGrupoDesconto { get; set; }

        [DisplayName("Compras Id Grupo Preço")]
        [Column("COMPRASIDGRUPOPRECO")]
        public int? ComprasIdGrupoPreco { get; set; }
        
        [DisplayName("ComprasIdGrupoItensSuplementares")]
        [Column("COMPRASIDGRUPOITENSSUPLEMENTARES")]
        public int? ComprasIdGrupoItensSuplementares { get; set; }

        [DisplayName("CompraProdDescontinuado")]
        [Column("COMPRAPRODDESCONTINUADO")]
        public bool CompraProdDescontinuado { get; set; }

        public int? ComprasIdFornecedor { get; set; }

        [DisplayName("VendaIdUnidade")]
        [Column("VENDAIDUNIDADE")]
        public int? VendaIdUnidade { get; set; }

        [DisplayName("VendaEntregaExcedente")]
        [Column("VENDAENTREGAEXCEDENTE")]
        public decimal? VendaEntregaExcedente { get; set; }

        [DisplayName("VendaEntregaInsuficiente")]
        [Column("VENDAENTREGAINSUFICIENTE")]
        public decimal? VendaEntregaInsuficiente { get; set; }

        [DisplayName("VendaIdGrupoImposto")]
        [Column("VENDAIDGRUPOIMPOSTO")]
        public int? VendaIdGrupoImposto { get; set; }

        [DisplayName("VendaRetencaoFonte")]
        [Column("VENDARETENCAOFONTE")]
        public bool VendaRetencaoFonte { get; set; }

        [DisplayName("VendaGrupoImpostoRetido")]
        [Column("VENDAGRUPOIMPOSTORETIDO")]
        public int? VendaGrupoImpostoRetido { get; set; }

        [DisplayName("VendaIdGrupoEncargos")]
        [Column("VENDAIDGRUPOENCARGOS")]
        public int? VendaIdGrupoEncargos { get; set; }

        [DisplayName("VendaEncargosSobrePreco")]
        [Column("VENDAENCARGOSSOBREPRECO")]
        public decimal? VendaEncargosSobrePreco { get; set; }

        [DisplayName("VendaIncluirNoPrecoUnitario")]
        [Column("VENDAINCLUIRNOPRECOUNITARIO")]
        public bool VendaIncluirNoPrecoUnitario { get; set; }

        [DisplayName("VendaIdGrupoDesconto")]
        [Column("VENDAIDGRUPODESCONTO")]
        public int? VendaIdGrupoDesconto { get; set; }

        [DisplayName("Venda Id Grupo Preço")]
        [Column("VENDAIDGRUPOPRECO")]
        public int? VendaIdGrupoPreco { get; set; }

        [DisplayName("VendaMarkup")]
        [Column("VENDAMARKUP")]
        public int? VendaMarkup { get; set; }

        [DisplayName("VendaIndiceContribuicao")]
        [Column("VENDAINDICECONTRIBUICAO")]
        public decimal? VendaIndiceContribuicao { get; set; }

        [DisplayName("VendaPercentualEncargos")]
        [Column("VENDAPERCENTUALENCARGOS")]
        public decimal? VendaPercentualEncargos { get; set; }

        [DisplayName("VendaUsarProdutoAlternativo")]
        [Column("VENDAUSARPRODUTOALTERNATIVO")]
        public int? VendaUsarProdutoAlternativo { get; set; }

        [DisplayName("VendaIdProdutoAlternativo")]
        [Column("VENDAIDPRODUTOALTERNATIVO")]
        public int? VendaIdProdutoAlternativo { get; set; }

        [DisplayName("VendaPreco")]
        [Column("VENDAPRECO")]
        public decimal? VendaPreco { get; set; }

        [DisplayName("VendaPrecoUnidade")]
        [Column("VENDAPRECOUNIDADE")]
        public decimal? VendaPrecoUnidade { get; set; }

        [DisplayName("VendaPrecoQuantidade")]
        [Column("VENDAPRECOQUANTIDADE")]
        public decimal? VendaPrecoQuantidade { get; set; }

        [DisplayName("VendaPrecoIdGrupoDesconto")]
        [Column("VENDAPRECOIDGRUPODESCONTO")]
        public int? VendaPrecoIdGrupoDesconto { get; set; }

        [DisplayName("VendaPrecoIdGrupoAlocacaoFrete")]
        [Column("VENDAPRECOIDGRUPOALOCACAOFRETE")]
        public int? VendaPrecoIdGrupoAlocacaoFrete { get; set; }

        [DisplayName("VendaAtualizaPrecoBase")]
        [Column("VENDAATUALIZAPRECOBASE")]
        public int? VendaAtualizaPrecoBase { get; set; }

        [DisplayName("VendaProdDescontinuado")]
        [Column("VENDAPRODDESCONTINUADO")]
        public bool VendaProdDescontinuado { get; set; }

        public decimal? VendaPrecoUnit { get; set; }

        public decimal? VendaMagemLucro { get; set; }

        [DisplayName("ComExtCodMercadoria")]
        [Column("COMEXTCODMERCADORIA")]
        public string ComExtCodMercadoria { get; set; }

        [DisplayName("ComExtPercentualEncargos")]
        [Column("COMEXTPERCENTUALENCARGOS")]
        public decimal? ComExtPercentualEncargos { get; set; }

        [DisplayName("ComExtIdPais")]
        [Column("COMEXTIDPAIS")]
        public int? ComExtIdPais { get; set; }

        [DisplayName("ComExtCidade")]
        [Column("COMEXTCIDADE")]
        public string ComExtCidade { get; set; }

        [DisplayName("EstoqueIdUnidade")]
        [Column("ESTOQUEIDUNIDADE")]
        public int? EstoqueIdUnidade { get; set; }

        [DisplayName("EstoquePeso")]
        [Column("ESTOQUEPESO")]
        public decimal? EstoquePeso { get; set; }

        [DisplayName("EstoqueTara")]
        [Column("ESTOQUETARA")]
        public decimal? EstoqueTara { get; set; }

        [DisplayName("EstqouePesoBruto")]
        [Column("ESTQOUEPESOBRUTO")]
        public decimal? EstqouePesoBruto { get; set; }

        [DisplayName("EstoqueProfundidade")]
        [Column("ESTOQUEPROFUNDIDADE")]
        public decimal? EstoqueProfundidade { get; set; }

        [DisplayName("EstoqueLargura")]
        [Column("ESTOQUELARGURA")]
        public decimal? EstoqueLargura { get; set; }

        [DisplayName("EstoqueAltura")]
        [Column("ESTOQUEALTURA")]
        public decimal? EstoqueAltura { get; set; }

        [DisplayName("EstoqueVolume")]
        [Column("ESTOQUEVOLUME")]
        public decimal? EstoqueVolume { get; set; }

        [DisplayName("EstoqueIdGrupoLotes")]
        [Column("ESTOQUEIDGRUPOLOTES")]
        public int? EstoqueIdGrupoLotes { get; set; }

        [DisplayName("EstoqueIdGrupoSeries")]
        [Column("ESTOQUEIDGRUPOSERIES")]
        public int? EstoqueIdGrupoSeries { get; set; }

        [DisplayName("EstoqueIdEmbalagem")]
        [Column("ESTOQUEIDEMBALAGEM")]
        public int? EstoqueIdEmbalagem { get; set; }

        [DisplayName("EstoqueQtdeEmbalagem")]
        [Column("ESTOQUEQTDEEMBALAGEM")]
        public decimal? EstoqueQtdeEmbalagem { get; set; }

        [DisplayName("EstoqueTempoManuseio")]
        [Column("ESTOQUETEMPOMANUSEIO")]
        public int? EstoqueTempoManuseio { get; set; }

        [DisplayName("EstoqueTempoPrateleira")]
        [Column("ESTOQUETEMPOPRATELEIRA")]
        public int? EstoqueTempoPrateleira { get; set; }

        [DisplayName("EstoqueValidadeDias")]
        [Column("ESTOQUEVALIDADEDIAS")]
        public int? EstoqueValidadeDias { get; set; }

        [DisplayName("ProducaoIdUnidade")]
        [Column("PRODUCAOIDUNIDADE")]
        public int? ProducaoIdUnidade { get; set; }

        [DisplayName("ProducaoProfundidade")]
        [Column("PRODUCAOPROFUNDIDADE")]
        public decimal? ProducaoProfundidade { get; set; }

        [DisplayName("ProducaoLargura")]
        [Column("PRODUCAOLARGURA")]
        public decimal? ProducaoLargura { get; set; }

        [DisplayName("ProducaoAltura")]
        [Column("PRODUCAOALTURA")]
        public decimal? ProducaoAltura { get; set; }

        [DisplayName("ProducaoDensidade")]
        [Column("PRODUCAODENSIDADE")]
        public decimal? ProducaoDensidade { get; set; }

        [DisplayName("ProducaoSucataConstante")]
        [Column("PRODUCAOSUCATACONSTANTE")]
        public decimal? ProducaoSucataConstante { get; set; }

        [DisplayName("ProducaoSucataVariavel")]
        [Column("PRODUCAOSUCATAVARIAVEL")]
        public decimal? ProducaoSucataVariavel { get; set; }

        [DisplayName("ProducaoIdPerfil")]
        [Column("PRODUCAOIDPERFIL")]
        public int? ProducaoIdPerfil { get; set; }

        [DisplayName("ProducaoIdGrupoProducao")]
        [Column("PRODUCAOIDGRUPOPRODUCAO")]
        public int? ProducaoIdGrupoProducao { get; set; }

        [DisplayName("ProducaoLiberacao")]
        [Column("PRODUCAOLIBERACAO")]
        public int? ProducaoLiberacao { get; set; }

        [DisplayName("ProducaoTipoProducao")]
        [Column("PRODUCAOTIPOPRODUCAO")]
        public int? ProducaoTipoProducao { get; set; }

        [DisplayName("ProducaoItemPlanejamento")]
        [Column("PRODUCAOITEMPLANEJAMENTO")]
        public int? ProducaoItemPlanejamento { get; set; }

        [DisplayName("ProducaoIdPlanoMestre")]
        [Column("PRODUCAOIDPLANOMESTRE")]
        public int? ProducaoIdPlanoMestre { get; set; }

        [DisplayName("CustoIdGrupoLancamento")]
        [Column("CUSTOIDGRUPOLANCAMENTO")]
        public int? CustoIdGrupoLancamento { get; set; }

        [DisplayName("CustoIdGrupoCusto")]
        [Column("CUSTOIDGRUPOCUSTO")]
        public int? CustoIdGrupoCusto { get; set; }

        [DisplayName("CustoCustoVariante")]
        [Column("CUSTOCUSTOVARIANTE")]
        public decimal? CustoCustoVariante { get; set; }

        [DisplayName("CustoAtualizarUltimoCusto")]
        [Column("CUSTOATUALIZARULTIMOCUSTO")]
        public bool CustoAtualizarUltimoCusto { get; set; }

        [DisplayName("CustoABCAliquota")]
        [Column("CUSTOABCALIQUOTA")]
        public int? CustoABCAliquota { get; set; }

        [DisplayName("CustoABCMargem")]
        [Column("CUSTOABCMARGEM")]
        public int? CustoABCMargem { get; set; }

        [DisplayName("CustoABCReceita")]
        [Column("CUSTOABCRECEITA")]
        public int? CustoABCReceita { get; set; }

        [DisplayName("CustoABCManutencao")]
        [Column("CUSTOABCMANUTENCAO")]
        public int? CustoABCManutencao { get; set; }

        [DisplayName("FiscalOrigem")]
        [Column("FISCALORIGEM")]
        public int? FiscalOrigem { get; set; }

        [DisplayName("FiscalIdNCM")]
        [Column("FISCALIDNCM")]
        public int? FiscalIdNCM { get; set; }

        [DisplayName("FiscalNCMExcecao")]
        [Column("FISCALNCMEXCECAO")]
        public int? FiscalNCMExcecao { get; set; }

        [DisplayName("FicalIdTipoItem")]
        [Column("FICALIDTIPOITEM")]
        public int? FicalIdTipoItem { get; set; }

        [DisplayName("FiscalIdCodigoServico")]
        [Column("FISCALIDCODIGOSERVICO")]
        public int? FiscalIdCodigoServico { get; set; }

        [DisplayName("FiscalICMSServico")]
        [Column("FISCALICMSSERVICO")]
        public bool FiscalICMSServico { get; set; }

        [DisplayName("FiscalPercentualAprox")]
        [Column("FISCALPERCENTUALAPROX")]
        public decimal? FiscalPercentualAprox { get; set; }

        [DisplayName("EstoqueProdDescontinuado")]
        [Column("ESTOQUEPRODDESCONTINUADO")]
        public bool EstoqueProdDescontinuado { get; set; }

        [DisplayName("ProducaoProdDescontinuado")]
        [Column("PRODUCAOPRODDESCONTINUADO")]
        public bool ProducaoProdDescontinuado { get; set; }

        [Column("IDGRUPOESTOQUE")]
        public int? IdGrupoEstoque { get; set; }

        [Column("IDGRUPORASTREAMENTO")]
	    public int? IdGrupoRastreamento { get; set; }

        [Column("IDGRUPOARMAZENAMENTO")]
        public int? IdGrupoArmazenamento { get; set; }

        [Column("PRODUTOACABADOMATERIAPRIMA")]
        public int? ProdutoAcabadoMateriaPrima { get; set; }

        [DisplayName("Id Cest")]
        [Column("IDCEST")]
        public int? IdCest { get; set; }

        public decimal? QtdeProducao { get; set; }

        public string DadosComplementares { get; set; }

        public int? IdMarca { get; set; }

        public string EAN { get; set; }
        public string DescricaoCorrigida { get; set; }

        public virtual GrupoProduto GrupoProduto { get; set; }


        //public virtual ICollection<AjusteEstoque> AjusteEstoque { get; set; }
        //public virtual ICollection<Estoque> Estoque { get; set; }
        //public virtual ICollection<MovimentoEstoque> MovimentoEstoque { get; set; }
        //public virtual ICollection<NotaFiscalItem> NotaFiscalItem { get; set; }
        //public virtual ICollection<PedidoCompraItem> PedidoCompraItem { get; set; }
    }
}
