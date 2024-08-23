using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("ROTEIROOPERACAOLINHAS", Schema = "DBO")]
    public class RoteiroOperacaoLinhas
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDROTEIROOPERACAOLINHAS")]
        public int IdRoteiroOperacaoLinhas { get; set; }

        [DisplayName("IdRoteiroOperacao")]
        [Column("IDROTEIROOPERACAO")]
        public int? IdRoteiroOperacao { get; set; }

        [DisplayName("Código Item")]
        [Column("CODIGOITEM")]
        public int? CodigoItem { get; set; }

        [DisplayName("IdProduto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }

        [DisplayName("IdGrupoLancamento")]
        [Column("IDGRUPOLANCAMENTO")]
        public int? IdGrupoLancamento { get; set; }

        [DisplayName("IdGrupoRoteiros")]
        [Column("IDGRUPOROTEIROS")]
        public int? IdGrupoRoteiros { get; set; }

        [DisplayName("Id Armazém")]
        [Column("IDARMAZEM")]
        public int? IdArmazem { get; set; }

        [DisplayName("Carregar")]
        [Column("CARREGAR")]
        public int? Carregar { get; set; }

        [DisplayName("QtdeRecursos")]
        [Column("QTDERECURSOS")]
        public int? QtdeRecursos { get; set; }

        [DisplayName("ValorCustoOperacao")]
        [Column("VALORCUSTOOPERACAO")]
        public decimal? ValorCustoOperacao { get; set; }

        [DisplayName("VAlorCustoQuantidade")]
        [Column("VALORCUSTOQUANTIDADE")]
        public decimal? VAlorCustoQuantidade { get; set; }

        [DisplayName("Fator")]
        [Column("FATOR")]
        public decimal? Fator { get; set; }

        [DisplayName("Fórmula")]
        [Column("FORMULA")]
        public decimal? Formula { get; set; }
    }
}
