using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("PEDIDOVENDAITEMCENTROCUSTO", Schema = "DBO")]
    public class PedidoVendaItemCentroCusto
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDPEDIDOVENDAITEMCENTROCUSTO")]
        public int IdPedidoVendaItemCentroCusto { get; set; }

        [DisplayName("IdPedidoVendaItem")]
        [Column("IDPEDIDOVENDAITEM")]
        public int? IdPedidoVendaItem { get; set; }

        [DisplayName("IdValoresCentroCusto")]
        [Column("IDVALORESCENTROCUSTO")]
        public int? IdValoresCentroCusto { get; set; }
    }
}
