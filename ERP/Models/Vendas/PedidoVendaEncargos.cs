
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PEDIDOVENDAENCARGOS", Schema = "DBO")]
    public class PedidoVendaEncargos
    {
        [Key]
        [DisplayName("IdPedidoVendaEncargos")]
        [Column("IDPEDIDOVENDAENCARGOS")]
        public int IdPedidoVendaEncargos { get; set; }
 
        [DisplayName("IdPedidoVenda")]
        [Column("IDPEDIDOVENDA")]
        public int? IdPedidoVenda { get; set; }
 
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
