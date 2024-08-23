
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("NOTAFISCALITEM", Schema = "DBO")]
    public class NotaFiscalItem
    {
        [Key]
        [DisplayName("IdNotaFiscalItem")]
        [Column("IDNOTAFISCALITEM")]
        public int IdNotaFiscalItem { get; set; }

        [DisplayName("IdNotaFiscal")]
        [Column("IDNOTAFISCAL")]
        public int? IdNotaFiscal { get; set; }

        [DisplayName("Item")]
        [Column("ITEM")]
        public int? Item { get; set; }

        [DisplayName("IdProduto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }

        [DisplayName("Codigo")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descricao")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal? Quantidade { get; set; }

        [DisplayName("ValorUnitario")]
        [Column("VALORUNITARIO")]
        public decimal? ValorUnitario { get; set; }

        [DisplayName("Desconto")]
        [Column("DESCONTO")]
        public decimal? Desconto { get; set; }

        [DisplayName("Seguro")]
        [Column("SEGURO")]
        public decimal? Seguro { get; set; }

        [DisplayName("Frete")]
        [Column("FRETE")]
        public decimal? Frete { get; set; }

        [DisplayName("DespesasAcessorias")]
        [Column("DESPESASACESSORIAS")]
        public decimal? DespesasAcessorias { get; set; }

        [DisplayName("CodigoCliente")]
        [Column("CODIGOCLIENTE")]
        public string CodigoCliente { get; set; }

        [DisplayName("CodigoFornecedor")]
        [Column("CODIGOFORNECEDOR")]
        public string CodigoFornecedor { get; set; }

        [DisplayName("SituacaoTribIPI")]
        [Column("SITUACAOTRIBIPI")]
        public string SituacaoTribIPI { get; set; }

        [DisplayName("AliquotaIPI")]
        [Column("ALIQUOTAIPI")]
        public decimal? AliquotaIPI { get; set; }

        [DisplayName("ValorIPI")]
        [Column("VALORIPI")]
        public decimal? ValorIPI { get; set; }

        [DisplayName("EnquadramentoIPI")]
        [Column("ENQUADRAMENTOIPI")]
        public int? EnquadramentoIPI { get; set; }

        [DisplayName("SituacaoTribICMS")]
        [Column("SITUACAOTRIBICMS")]
        public string SituacaoTribICMS { get; set; }

        [DisplayName("BaseICMS")]
        [Column("BASEICMS")]
        public decimal? BaseICMS { get; set; }

        [DisplayName("AliquotaICMS")]
        [Column("ALIQUOTAICMS")]
        public decimal? AliquotaICMS { get; set; }

        [DisplayName("ValorICMS")]
        [Column("VALORICMS")]
        public decimal? ValorICMS { get; set; }

        [DisplayName("ValorTotal")]
        [Column("VALORTOTAL")]
        public decimal? ValorTotal { get; set; }

        [DisplayName("PesoLiquido")]
        [Column("PESOLIQUIDO")]
        public decimal? PesoLiquido { get; set; }

        [DisplayName("PesoBruto")]
        [Column("PESOBRUTO")]
        public decimal? PesoBruto { get; set; }

        [DisplayName("Volumes")]
        [Column("VOLUMES")]
        public decimal? Volumes { get; set; }

        [DisplayName("IdUnidade")]
        [Column("IDUNIDADE")]
        public int? IdUnidade { get; set; }

        [DisplayName("IdNCM")]
        [Column("IDNCM")]
        public int? IdNCM { get; set; }

        [DisplayName("Observacao")]
        [Column("OBSERVACAO")]
        public string Observacao { get; set; }

        [DisplayName("IdPedidoVenda")]
        [Column("IDPEDIDOVENDA")]
        public int? IdPedidoVenda { get; set; }

        [DisplayName("IdCFOP")]
        [Column("IDCFOP")]
        public int? IdCFOP { get; set; }

        [DisplayName("IdCor")]
        [Column("IDCOR")]
        public int? IdCor { get; set; }

        [DisplayName("IdEstilo")]
        [Column("IDESTILO")]
        public int? IdEstilo { get; set; }

        [DisplayName("IdConfiguracao")]
        [Column("IDCONFIGURACAO")]
        public int? IdConfiguracao { get; set; }

        [DisplayName("IdTamanho")]
        [Column("IDTAMANHO")]
        public int? IdTamanho { get; set; }

        [DisplayName("IdPedidoVendaItem")]
        [Column("IDPEDIDOVENDAITEM")]
        public int? IdPedidoVendaItem { get; set; }

        [DisplayName("PrecoTabelaPedidoVenda")]
        [Column("PRECOTABELAPEDIDOVENDA")]
        public decimal? PrecoTabelaPedidoVenda { get; set; }

        [DisplayName("SituacaoTribPIS")]
        [Column("SITUACAOTRIBPIS")]
        public string SituacaoTribPIS { get; set; }

        [DisplayName("BasePIS")]
        [Column("BASEPIS")]
        public decimal? BasePIS { get; set; }

        [DisplayName("AliquotaPIS")]
        [Column("ALIQUOTAPIS")]
        public decimal? AliquotaPIS { get; set; }

        [DisplayName("ValorPIS")]
        [Column("VALORPIS")]
        public decimal? ValorPIS { get; set; }

        [DisplayName("SituacaoTribCOFINS")]
        [Column("SITUACAOTRIBCOFINS")]
        public string SituacaoTribCOFINS { get; set; }

        [DisplayName("BaseCOFINS")]
        [Column("BASECOFINS")]
        public decimal? BaseCOFINS { get; set; }

        [DisplayName("AliquotaCOFINS")]
        [Column("ALIQUOTACOFINS")]
        public decimal? AliquotaCOFINS { get; set; }

        [DisplayName("ValorCOFINS")]
        [Column("VALORCOFINS")]
        public decimal? ValorCOFINS { get; set; }

        [DisplayName("EAN")]
        [Column("EAN")]
        public string EAN { get; set; }

        [DisplayName("indTot")]
        [Column("INDTOT")]
        public int? indTot { get; set; }

        [DisplayName("Origem")]
        [Column("ORIGEM")]
        public int? Origem { get; set; }

        [DisplayName("BaseICMSST")]
        [Column("BASEICMSST")]
        public decimal? BaseICMSST { get; set; }

        [DisplayName("SituacaoTriICMSST")]
        [Column("SITUACAOTRIICMSST")]
        public string SituacaoTriICMSST { get; set; }

        [DisplayName("AliquotaICMSST")]
        [Column("ALIQUOTAICMSST")]
        public decimal? AliquotaICMSST { get; set; }

        [DisplayName("ValorICMSST")]
        [Column("VALORICMSST")]
        public decimal? ValorICMSST { get; set; }

        public int? IdCest { get; set; }

        public int? IdVendedor { get; set; }
        public int? IdVendedorTelevendas { get; set; }
        public decimal? PercentualVendedor { get; set; }
        public decimal? PercentualTelevendas { get; set; }
        public decimal? ComissaoVendedor { get; set; }
        public decimal? ComissaoVendedorExtra { get; set; }
        public decimal? ComissaoTelevendas { get; set; }
        public decimal? ComissaoTelevendasExtra { get; set; }
        public decimal? ComissaoNegativa { get; set; }
        public int? Conversao { get; set; }

        public virtual CEST Cest { get; set; }
        public virtual Produto Produto { get; set; }

    }
}
