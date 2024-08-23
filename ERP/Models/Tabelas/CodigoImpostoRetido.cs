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
    [Table("CODIGOIMPOSTORETIDO", Schema = "DBO")]
    public class CodigoImpostoRetido
    {
        [Key]
        [DisplayName("Id Código Imposto Retido")]
        [Column("IDCODIGOIMPOSTORETIDO")]
        public int IdCodigoImpostoRetido { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Tipo Imposto")]
        [Column("TIPOIMPOSTO")]
        public int? TipoImposto { get; set; }

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

      

        [DisplayName("Id Conta Contábil")]
        [Column("IDCONTACONTABIL")]
        public int? IdContaContabil { get; set; }

        [DisplayName("Id Conta Contábil Retido a Receber")]
        [Column("IDCONTACONTABILRETIDOARECEBER")]
        public int? IdContaContabilRetidoAReceber { get; set; }

        [DisplayName("Id Conta Contábil Liquidação")]
        [Column("IDCONTACONTABILLIQUIDACAO")]
        public int? IdContaContabilLiquidacao { get; set; }

     

        [DisplayName("Base")]
        [Column("BASE")]
        public int? Base { get; set; }

        [DisplayName("Deduzir INSS")]
        [Column("DEDUZIRINSS")]
        public bool DeduzirINSS { get; set; }

        [DisplayName("Arredondamento")]
        [Column("ARREDONDAMENTO")]
        public decimal? Arredondamento { get; set; }

        [DisplayName("Forma de Arredondamento")]
        [Column("FORMAARREDONDAMENTO")]
        public int? FormaArredondamento { get; set; }

        [DisplayName("Método Cálculo")]
        [Column("METODOCALCULO")]
        public int? MetodoCalculo { get; set; }

        [DisplayName("Código Receita")]
        [Column("CODIGORECEITA")]
        public string CodigoReceita { get; set; }
    }
}
