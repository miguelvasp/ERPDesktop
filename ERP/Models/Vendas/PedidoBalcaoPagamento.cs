
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PEDIDOBALCAOPAGAMENTO", Schema = "DBO")]
    public class PedidoBalcaoPagamento
    {
        [Key]
        [DisplayName("IdPedidoBalcaoPagamento")]
        [Column("IDPEDIDOBALCAOPAGAMENTO")]
        public int IdPedidoBalcaoPagamento { get; set; }
 
        [DisplayName("IdPedidoBalcao")]
        [Column("IDPEDIDOBALCAO")]
        public int? IdPedidoBalcao { get; set; }
 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }
 
         
        public string FormaPagamento { get; set; }
  
        public string Observacoes { get; set; }
 
    }
}
