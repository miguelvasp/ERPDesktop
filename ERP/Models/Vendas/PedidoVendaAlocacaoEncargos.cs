
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PEDIDOVENDAALOCACAOENCARGOS", Schema = "DBO")]
    public class PedidoVendaAlocacaoEncargos
    {
        [Key]
        [DisplayName("IdPedidoVenda")]
        [Column("IDPEDIDOVENDAALOCAENCARGOS")]
        public int IdPedidoVendaAlocaEncargos { get; set; } 

        [DisplayName("IdPedidoVenda")]
        [Column("IDPEDIDOVENDA")]
        public int IdPedidoVenda { get; set; }
 
        [DisplayName("DistribuirPor")]
        [Column("DISTRIBUIRPOR")]
        public int? DistribuirPor { get; set; }
 
        [DisplayName("Linhas")]
        [Column("LINHAS")]
        public int? Linhas { get; set; }
 
        [DisplayName("DistribuirTudo")]
        [Column("DISTRIBUIRTUDO")]
        public bool? DistribuirTudo { get; set; }
 
        [DisplayName("Recebido_Separado")]
        [Column("RECEBIDO_SEPARADO")]
        public bool? Recebido_Separado { get; set; }
 
    }
}
