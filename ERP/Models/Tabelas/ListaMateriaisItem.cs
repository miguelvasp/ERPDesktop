using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("LISTAMATERIAISITEM", Schema = "DBO")]
    public class ListaMateriaisItem
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDLISTAMATERIAISITEM")]
        public int IdListaMateriaisItem { get; set; }

        [DisplayName("IdListaMateriais")]
        [Column("IDLISTAMATERIAIS")]
        public int? IdListaMateriais { get; set; }

        [DisplayName("IdProduto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("IdConfiguracao")]
        [Column("IDCONFIGURACAO")]
        public int? IdConfiguracao { get; set; }

        [DisplayName("IdEstilo")]
        [Column("IDESTILO")]
        public int? IdEstilo { get; set; }

        [DisplayName("IdCor")]
        [Column("IDCOR")]
        public int? IdCor { get; set; }

        [DisplayName("Id Tamanho")]
        [Column("IDTAMANHO")]
        public int? IdTamanho { get; set; }

        [DisplayName("Id Armazém")]
        [Column("IDARMAZEM")]
        public int? IdArmazem { get; set; }

        [DisplayName("De")]
        [Column("DE")]
        public DateTime? De { get; set; }

        [DisplayName("Até")]
        [Column("ATE")]
        public DateTime? Ate { get; set; }

        [DisplayName("Quantidade Origem")]
        [Column("QUANTIDADEORIGEM")]
        public int? QuantidadeOrigem { get; set; }

        [DisplayName("Id Unidade Bom")]
        [Column("IDUNIDADEBOM")]
        public int? IdUnidadeBom { get; set; }

        [DisplayName("Ativo")]
        [Column("ATIVO")]
        public bool Ativo { get; set; }

        [DisplayName("Alocação Custo Total")]
        [Column("ALOCACAOCUSTOTOTAL")]
        public int? AlocacaoCustoTotal { get; set; }

        [DisplayName("Construção")]
        [Column("CONSTRUCAO")]
        public bool Construcao { get; set; }

        [DisplayName("DataFormula")]
        [Column("DATAFORMULA")]
        public DateTime? DataFormula { get; set; }

        [DisplayName("MultiploFormula")]
        [Column("MULTIPLOFORMULA")]
        public int? MultiploFormula { get; set; }

        [DisplayName("Prioridade")]
        [Column("PRIORIDADE")]
        public int? Prioridade { get; set; }

        [DisplayName("QuantidadeProducao")]
        [Column("QUANTIDADEPRODUCAO")]
        public decimal? QuantidadeProducao { get; set; }

        [DisplayName("TamanhoFormula")]
        [Column("TAMANHOFORMULA")]
        public decimal? TamanhoFormula { get; set; }

        [DisplayName("UsarParaCalculo")]
        [Column("USARPARACALCULO")]
        public bool UsarParaCalculo { get; set; }

        [DisplayName("VariacoesCoProdutos")]
        [Column("VARIACOESCOPRODUTOS")]
        public bool VariacoesCoProdutos { get; set; }
    }
}
