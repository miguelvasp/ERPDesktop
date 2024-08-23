using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("PLANOPAGAMENTO", Schema = "DBO")]
    public class PlanoPagamento
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDPLANOPAGAMENTO")]
        public int IdPlanoPagamento { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("TipoDistribuicao")]
        [Column("TIPODISTRIBUICAO")]
        public int? TipoDistribuicao { get; set; }

        [DisplayName("PagamentoPor")]
        [Column("PAGAMENTOPOR")]
        public int? PagamentoPor { get; set; }

        [DisplayName("Período")]
        [Column("PERIODO")]
        public int? Periodo { get; set; }

        [DisplayName("NumeroPagamentos")]
        [Column("NUMEROPAGAMENTOS")]
        public int? NumeroPagamentos { get; set; }

        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }

        [DisplayName("ValorMinimo")]
        [Column("VALORMINIMO")]
        public decimal? ValorMinimo { get; set; }

        [DisplayName("AlocacaoImpostos")]
        [Column("ALOCACAOIMPOSTOS")]
        public int? AlocacaoImpostos { get; set; }
    }
}
