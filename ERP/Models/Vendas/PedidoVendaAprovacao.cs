using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("PEDIDOVENDAAPROVACAO", Schema = "DBO")]
    public class PedidoVendaAprovacao
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDPEDIDOVENDAAPROVACAO")]
        public int IdPedidoVendaAprovacao { get; set; }

        [DisplayName("Id Pedido Venda")]
        [Column("IDPEDIDOVENDA")]
        public int IdPedidoVenda { get; set; }

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
