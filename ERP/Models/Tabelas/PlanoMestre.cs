using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("PLANOMESTRE", Schema = "DBO")]
    public class PlanoMestre
    {
        [Key]
        [DisplayName("IdPlanoMestre")]
        [Column("IDPLANOMESTRE")]
        public int IdPlanoMestre { get; set; }

        [DisplayName("C�digo")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descri��o")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Incluir Estoque Dispon�vel")]
        [Column("INCLUIRESTOQUEDISPONIVEL")]
        public bool IncluirEstoqueDisponivel { get; set; }

        [DisplayName("Incluir Transa��es Estoque")]
        [Column("INCLUIRTRANSACOESESTOQUE")]
        public bool IncluirTransacoesEstoque { get; set; }

        [DisplayName("Incluir Cota��o Venda")]
        [Column("INCLUIRCOTACAOVENDA")]
        public bool IncluirCotacaoVenda { get; set; }

        [DisplayName("Incluir Cota��o Compra")]
        [Column("INCLUIRCOTACAOCOMPRA")]
        public bool IncluirCotacaoCompra { get; set; }

        [DisplayName("Incluir Requisi��es")]
        [Column("INCLUIRREQUISICOES")]
        public bool IncluirRequisicoes { get; set; }

        [DisplayName("Incluir Previs�o Demanda")]
        [Column("INCLUIRPREVISAODEMANDA")]
        public bool IncluirPrevisaoDemanda { get; set; }

        [DisplayName("Incluir Previs�o Fornecimento")]
        [Column("INCLUIRPREVISAOFORNECIMENTO")]
        public bool IncluirPrevisaoFornecimento { get; set; }

        [DisplayName("Limite de Tempo Cobertura")]
        [Column("LIMITETEMPOCOBERTURA")]
        public int? LimiteTempoCobertura { get; set; }

        [DisplayName("Limite de Tempo Capacidade")]
        [Column("LIMITETEMPOCAPACIDADE")]
        public int? LimiteTempoCapacidade { get; set; }
    }
}
