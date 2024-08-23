using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("PLANOPREVISAO", Schema = "DBO")]
    public class PlanoPrevisao
    {
        [Key]
        [DisplayName("Id Plano Previsão")]
        [Column("IDPLANOPREVISAO")]
        public int IdPlanoPrevisao { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Incluir Previsão de Fornecimento")]
        [Column("INCLUIRPREVISAOFORNECIMENTO")]
        public bool IncluirPrevisaoFornecimento { get; set; }

        [DisplayName("Incluir Previsão de Demanda")]
        [Column("INCLUIRPREVISAODEMANDA")]
        public bool IncluirPrevisaoDemanda { get; set; }

        [DisplayName("Limite de Tempo Cobertura")]
        [Column("LIMITETEMPOCOBERTURA")]
        public int LimiteTempoCobertura { get; set; }

        [DisplayName("Limite de Tempo Detalhamento")]
        [Column("LIMITETEMPODETALHAMENTO")]
        public int LimiteTempoDetalhamento { get; set; }

        [DisplayName("Limite de Tempo Capacidade")]
        [Column("LIMITETEMPOCAPACIDADE")]
        public int LimiteTempoCapacidade { get; set; }

        [DisplayName("Sequência de Ordem Planejadas")]
        [Column("SEQUENCIAORDEMPLANEJADAS")]
        public string SequenciaOrdemPlanejadas { get; set; }

        [DisplayName("Redução")]
        [Column("REDUCAO")]
        public int? Reducao { get; set; }
    }
}
