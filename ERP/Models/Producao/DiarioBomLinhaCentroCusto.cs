using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("DIARIOBOMLINHACENTROCUSTO", Schema = "DBO")]
    public class DiarioBomLinhaCentroCusto
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDDIARIOBOMLINHACENTROCUSTO")]
        public int? IdDiarioBomLinhaCentroCusto { get; set; }

        [DisplayName("Id Diário Bom Linha")]
        [Column("IDDIARIOBOMLINHA")]
        public int? IdDiarioBomLinha { get; set; }

        [DisplayName("Id Valores Centro Custo")]
        [Column("IDVALORESCENTROCUSTO")]
        public int? IdValoresCentroCusto { get; set; }
    }
}
