
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PEDIDOBALCAOPRODUTO", Schema = "DBO")]
    public class PedidoBalcaoProduto
    {
        [Key]
        [DisplayName("IdPedidoBalcaoProduto")]
        [Column("IDPEDIDOBALCAOPRODUTO")]
        public int IdPedidoBalcaoProduto { get; set; }

        [DisplayName("IdPedidoBalcao")]
        [Column("IDPEDIDOBALCAO")]
        public int? IdPedidoBalcao { get; set; }

        [DisplayName("IdProduto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }

        [DisplayName("Qtde")]
        [Column("QTDE")]
        public decimal? Qtde { get; set; }

        [DisplayName("ValorUnitario")]
        [Column("VALORUNITARIO")]
        public decimal? ValorUnitario { get; set; }

        [DisplayName("ValorTotal")]
        [Column("VALORTOTAL")]
        public decimal? ValorTotal { get; set; }
        public decimal? Desconto { get; set; }

        public virtual Produto Produto { get; set; }
 
    }
}
