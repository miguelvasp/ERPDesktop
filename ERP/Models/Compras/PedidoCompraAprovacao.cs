using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("PEDIDOCOMPRAAPROVACAO", Schema = "DBO")]
    public class PedidoCompraAprovacao
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDPEDIDOCOMPRAAPROVACAO")]
        public int IdPedidoCompraAprovacao { get; set; }
 
        [DisplayName("IdPedidoCompra")]
        [Column("IDPEDIDOCOMPRA")]
        public int IdPedidoCompra { get; set; }
 
        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime Data { get; set; }
 
        [DisplayName("NovoStatus")]
        [Column("NOVOSTATUS")]
        public string NovoStatus { get; set; }
 
        [DisplayName("Usuario")]
        [Column("USUARIO")]
        public string Usuario { get; set; } 
    }
}
