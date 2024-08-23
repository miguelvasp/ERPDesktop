
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PEDIDOBALCAOCREDIARIO", Schema = "DBO")]
    public class PedidoBalcaoCrediario
    {
        [Key]
        [DisplayName("IdPedidoBalcaoCrediario")]
        [Column("IDPEDIDOBALCAOCREDIARIO")]
        public int IdPedidoBalcaoCrediario { get; set; }
 
        [DisplayName("IdPedidoBalcao")]
        [Column("IDPEDIDOBALCAO")]
        public int? IdPedidoBalcao { get; set; }
 
        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime? Data { get; set; }
 
        [DisplayName("Contador")]
        [Column("CONTADOR")]
        public int? Contador { get; set; }
 
        [DisplayName("Vencimento")]
        [Column("VENCIMENTO")]
        public DateTime? Vencimento { get; set; }
 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }
 
        [DisplayName("ValorExtenso")]
        [Column("VALOREXTENSO")]
        public string ValorExtenso { get; set; }
 
        [DisplayName("IdCliente")]
        [Column("IDCLIENTE")]
        public int? IdCliente { get; set; }
 
    }
}
