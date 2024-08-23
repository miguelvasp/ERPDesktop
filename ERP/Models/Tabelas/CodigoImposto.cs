using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("CODIGOIMPOSTO", Schema = "DBO")]
    public class CodigoImposto
    {
        [Key]
        [DisplayName("Id Código Imposto")]
        [Column("IDCODIGOIMPOSTO")]
        public int IdCodigoImposto { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Id Juridição Imposto")]
        [Column("IDJURIDICAOIMPOSTO")]
        public int? IdJuridicaoImposto { get; set; }

        [DisplayName("Percentual Valor")]
        [Column("PERCENTUALVALOR")]
        public decimal? PercentualValor { get; set; }

        [DisplayName("Id Moeda")]
        [Column("IDMOEDA")]
        public int IdMoeda { get; set; }
        public virtual Moeda Moeda { get; set; }

        [DisplayName("Id Período Liquidação Imposto")]
        [Column("IDPERIODOLIQUIDACAOIMPOSTO")]
        public int IdPeriodoLiquidacaoImposto { get; set; }
        public virtual PeriodoLiquidacaoImposto PeriodoLiquidacaoImposto { get; set; }

        [DisplayName("Id Grupo Lançamento Contábil")]
        [Column("IDGRUPOLANCAMENTOCONTABIL")]
        public int IdGrupoLancamentoContabil { get; set; }
        public virtual GrupoLancamentoContabil GrupoLancamentoContabil { get; set; }

        [DisplayName("Porcentagem Negativa Imposto")]
        [Column("PORCENTAGEMNEGATIVAIMPOSTO")]
        public bool PorcentagemNegativaImposto { get; set; }

        [DisplayName("Parâmetros Cálculos")]
        [Column("PARAMETROSCALCULOS")]
        public int? ParametrosCalculos { get; set; }

        [DisplayName("Base Marginal")]
        [Column("BASEMARGINAL")]
        public int? BaseMarginal { get; set; }

        [DisplayName("Método Cálculo")]
        [Column("METODOCALCULO")]
        public int? MetodoCalculo { get; set; }

        [DisplayName("Id Código Imposto Imposto")]
        [Column("IDCODIGOIMPOSTOIMPOSTO")]
        public int IdCodigoImpostoImposto { get; set; }

        [DisplayName("Id Unidade Operacional")]
        [Column("IDUNIDADE")]
        public int? IdUnidade { get; set; }
        public virtual Unidade Unidade { get; set; }

        [DisplayName("Data do Cálculo")]
        [Column("DATACALCULO")]
        public int? DataCalculo { get; set; }

        [DisplayName("Tipo do Imposto")]
        [Column("TIPOIMPOSTO")]
        public int? TipoImposto { get; set; }

        [DisplayName("Id Código Tributação")]
        [Column("IDCODIGOTRIBUTACAO")]
        public int IdCodigoTributacao { get; set; }
        public virtual CodigoTributacao CodigoTributacao { get; set; }

        [DisplayName("Imposto Retido Recuperável")]
        [Column("IMPOSTORETIDORECUPERAVEL")]
        public bool ImpostoRetidoRecuperavel { get; set; }

        [DisplayName("Imposto Incluso")]
        [Column("IMPOSTOINCLUSO")]
        public bool ImpostoIncluso { get; set; }

        [DisplayName("Método Substituição Tributária")]
        [Column("METODOSUBSTITUICAOTRIBUTARIA")]
        public int? MetodoSubstituicaoTributaria { get; set; }

        [DisplayName("Código Receita")]
        [Column("CODIGORECEITA")]
        public string CodigoReceita { get; set; }
    }
}
