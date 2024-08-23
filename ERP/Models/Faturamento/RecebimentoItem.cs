using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("RECEBIMENTOITEM", Schema = "DBO")]
    public class RecebimentoItem
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDRECEBIMENTOITEM")]
        public int IdRecebimentoItem { get; set; }

        [DisplayName("IdRecebimento")]
        [Column("IDRECEBIMENTO")]
        public int IdRecebimento { get; set; }

        [DisplayName("IdLoteRecebimento")]
        [Column("IDLOTERECEBIMENTO")]
        public int IdLoteRecebimento { get; set; }

        [DisplayName("Id Pedido Compra")]
        [Column("IDPEDIDOCOMPRA")]
        public int IdPedidoCompra { get; set; }

        [DisplayName("Id Pedido Compra Item")]
        [Column("IDPEDIDOCOMPRAITEM")]
        public int? IdPedidoCompraItem { get; set; }

        [DisplayName("Id Produto")]
        [Column("IDPRODUTO")]
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        [DisplayName("Nome Produto")]
        [Column("NOMEPRODUTO")]
        public string NomeProduto { get; set; }

        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal Quantidade { get; set; }

        [DisplayName("Quantidade Recebida")]
        [Column("QUANTIDADERECEBIDA")]
        public decimal QuantidadeRecebida { get; set; }

        [DisplayName("Id Unidade")]
        [Column("IDUNIDADE")]
        public int IdUnidade { get; set; }
        public virtual Unidade Unidade { get; set; }

        [DisplayName("Valor Unitário")]
        [Column("VALORUNITARIO")]
        public decimal ValorUnitario { get; set; }

        [DisplayName("Valor Total")]
        [Column("VALORTOTAL")]
        public decimal ValorTotal { get; set; }

        [DisplayName("Desconto")]
        [Column("DESCONTO")]
        public decimal Desconto { get; set; }

        [DisplayName("Seguro")]
        [Column("SEGURO")]
        public decimal Seguro { get; set; }

        [DisplayName("Frete")]
        [Column("FRETE")]
        public decimal Frete { get; set; }

        [DisplayName("Despesas Acessorias")]
        [Column("DESPESASACESSORIAS")]
        public decimal DespesasAcessorias { get; set; }

        [DisplayName("Royalties")]
        [Column("ROYALTIES")]
        public decimal Royalties { get; set; }

        [DisplayName("Valor Líquido")]
        [Column("VALORLIQUIDO")]
        public decimal ValorLiquido { get; set; }

        [DisplayName("IdVariantesEstilo")]
        [Column("IDVARIANTESESTILO")]
        public int? IdVariantesEstilo { get; set; }

        [DisplayName("IdVariantesConfig")]
        [Column("IDVARIANTESCONFIG")]
        public int? IdVariantesConfig { get; set; }

        [DisplayName("IdVariantesCor")]
        [Column("IDVARIANTESCOR")]
        public int? IdVariantesCor { get; set; }

        [DisplayName("IdVariantesTamanho")]
        [Column("IDVARIANTESTAMANHO")]
        public int? IdVariantesTamanho { get; set; }

        [DisplayName("Id Grupo Lotes")]
        [Column("IDGRUPOLOTEs")]
        public int? IdGrupoLotes { get; set; }

        [DisplayName("Id Grupo Séries")]
        [Column("IDGRUPOSERIES")]
        public int? IdGrupoSeries { get; set; }

        [DisplayName("Id Armazém")]
        [Column("IDARMAZEM")]
        public int? IdArmazem { get; set; }

        [DisplayName("Id Depósito")]
        [Column("IDDEPOSITO")]
        public int? IdDeposito { get; set; }

        [DisplayName("Id Localização")]
        [Column("IDLOCALIZACAO")]
        public int? IdLocalizacao { get; set; }

        [DisplayName("Id Grupo Ativo")]
        [Column("IDGRUPOATIVO")]
        public int? IdGrupoAtivo { get; set; }

        [DisplayName("Id Método Depreciação")]
        [Column("IDMETODODEPRECIACAO")]
        public int? IdMetodoDepreciacao { get; set; }

        [DisplayName("Id Ativo Fixo")]
        [Column("IDATIVOFIXO")]
        public int? IdAtivoFixo { get; set; }

        [Column("IDNOTAFISCAL")]
        public int? IdNotaFiscal { get; set; }
    }
}
