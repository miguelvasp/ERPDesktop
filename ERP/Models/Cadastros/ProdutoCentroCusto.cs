using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("PRODUTOCENTROCUSTO", Schema = "DBO")]
    public class ProdutoCentroCusto
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDPRODUTOCENTROCUSTO")]
        public int IdProdutoCentroCusto { get; set; }

        [DisplayName("IdProduto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }

        [DisplayName("IdValoresCentroCusto")]
        [Column("IDVALORESCENTROCUSTO")]
        public int? IdValoresCentroCusto { get; set; }
    }
}
