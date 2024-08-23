
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PEDIDOCOMPRAENCARGOS", Schema = "DBO")]
    public class PedidoCompraEncargos
    {
        [Key]
        [DisplayName("IdPedidoCompraEncargos")]
        [Column("IDPEDIDOCOMPRAENCARGOS")]
        public int? IdPedidoCompraEncargos { get; set; }
 
        [DisplayName("IdPedidoCompra")]
        [Column("IDPEDIDOCOMPRA")]
        public int? IdPedidoCompra { get; set; }
 
        [DisplayName("TipoEncargo")]
        [Column("TIPOENCARGO")]
        public int? TipoEncargo { get; set; }
 
        [DisplayName("Descricao")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }
 
    }
}
