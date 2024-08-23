using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("PEDIDOCOMPRAITEMCENTROCUSTO", Schema = "DBO")]
    public class PedidoCompraItemCentroCusto
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDPEDIDOCOMPRAITEMCENTROCUSTO")]
        public int IdPedidoCompraItemCentroCusto { get; set; }

        [DisplayName("IdPedidoCompraItem")]
        [Column("IDPEDIDOCOMPRAITEM")]
        public int? IdPedidoCompraItem { get; set; }

        [DisplayName("IdValoresCentroCusto")]
        [Column("IDVALORESCENTROCUSTO")]
        public int? IdValoresCentroCusto { get; set; }
    }
}
