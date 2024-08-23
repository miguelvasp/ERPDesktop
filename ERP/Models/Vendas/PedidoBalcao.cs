
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PEDIDOBALCAO", Schema = "DBO")]
    public class PedidoBalcao
    {
        [Key]
        [DisplayName("IdPedidoBalcao")]
        [Column("IDPEDIDOBALCAO")]
        public int IdPedidoBalcao { get; set; } 
        public DateTime? Data { get; set; } 
        public int? IdCliente { get; set; } 
        public string Status { get; set; }
        public string NomeBalcao { get; set; }
        public int? IdCondicaoPagamento { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdUsuarioPagamento { get; set; }
        public decimal? Dinheiro { get; set; }
        public decimal? Troco { get; set; }
        public decimal? Total { get; set; }
        public decimal? Credito { get; set; }
        public decimal? Debito { get; set; }
        public int? IdContasReceber { get; set; }
        public decimal? PercentualDesconto { get; set; }
        public int? IdNotaFiscal { get; set; }
        public decimal? DescontoTotal { get; set; }
        public decimal? Crediario { get; set; }
        public string Observacao { get; set; }

        public virtual CondicaoPagamento CondicaoPagamento { get; set; }
        public virtual ICollection<PedidoBalcaoProduto> Produtos { get; set; }
        public virtual ICollection<PedidoBalcaoPagamento> Pagamentos { get; set; }


    }
}
