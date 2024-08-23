using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("PEDIDOVENDACENTROCUSTO", Schema = "DBO")]
    public class PedidoVendaCentroCusto
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDPEDIDOVENDACENTROCUSTO")]
        public int IdPedidoVendaCentroCusto { get; set; }

        [DisplayName("IdPedidoVenda")]
        [Column("IDPEDIDOVENDA")]
        public int? IdPedidoVenda { get; set; }

        [DisplayName("IdValoresCentroCusto")]
        [Column("IDVALORESCENTROCUSTO")]
        public int? IdValoresCentroCusto { get; set; }
    }
}
