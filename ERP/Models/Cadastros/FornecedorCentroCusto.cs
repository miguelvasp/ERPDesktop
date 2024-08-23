using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("FORNECEDORCENTROCUSTO", Schema = "DBO")]
    public class FornecedorCentroCusto
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDFORNECEDORCENTROCUSTO")]
        public int IdFornecedorCentroCusto { get; set; }
 
        [DisplayName("IdFornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }
 
        [DisplayName("IdValoresCentroCusto")]
        [Column("IDVALORESCENTROCUSTO")]
        public int? IdValoresCentroCusto { get; set; }
    }
}
