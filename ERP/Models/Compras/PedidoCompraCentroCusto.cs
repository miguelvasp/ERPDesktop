using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("PEDIDOCOMPRACENTROCUSTO", Schema = "DBO")]
    public class PedidoCompraCentroCusto
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDPEDIDOCOMPRACENTROCUSTO")]
        public int IdPedidoCompraCentroCusto { get; set; }

        [DisplayName("IdPedidoCompra")]
        [Column("IDPEDIDOCOMPRA")]
        public int? IdPedidoCompra { get; set; }

        [DisplayName("IdValoresCentroCusto")]
        [Column("IDVALORESCENTROCUSTO")]
        public int? IdValoresCentroCusto { get; set; }
    }
}
