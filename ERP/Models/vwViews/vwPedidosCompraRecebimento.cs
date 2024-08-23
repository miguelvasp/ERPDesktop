
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("VWPEDIDOSCOMPRARECEBIMENTO", Schema = "DBO")]
    public class vwPedidosCompraRecebimento
    {
        [Key]
        [DisplayName("IdFornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }
 
        [DisplayName("StatusAprovacao")]
        [Column("STATUSAPROVACAO")]
        public int? StatusAprovacao { get; set; }
 
        [DisplayName("IdPedidoCompra")]
        [Column("IDPEDIDOCOMPRA")]
        public int? IdPedidoCompra { get; set; }
 
        [DisplayName("IdPedidoCompraItem")]
        [Column("IDPEDIDOCOMPRAITEM")]
        public int? IdPedidoCompraItem { get; set; }
 
        [DisplayName("PedidoNumero")]
        [Column("PEDIDONUMERO")]
        public int? PedidoNumero { get; set; }
 
        [DisplayName("Codigo")]
        [Column("CODIGO")]
        public string Codigo { get; set; }
 
        [DisplayName("NomeProduto")]
        [Column("NOMEPRODUTO")]
        public string NomeProduto { get; set; }
 
        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal? Quantidade { get; set; }
 
        [DisplayName("Ipi")]
        [Column("IPI")]
        public decimal? Ipi { get; set; }
 
        [DisplayName("PrecoUnitario")]
        [Column("PRECOUNITARIO")]
        public decimal? PrecoUnitario { get; set; }
 
        [DisplayName("DescontoPercentual")]
        [Column("DESCONTOPERCENTUAL")]
        public decimal? DescontoPercentual { get; set; }
 
        [DisplayName("DescontoValor")]
        [Column("DESCONTOVALOR")]
        public decimal? DescontoValor { get; set; }
 
        [DisplayName("ValorLiquido")]
        [Column("VALORLIQUIDO")]
        public decimal? ValorLiquido { get; set; }
 
        [DisplayName("QTDE_RECEBIDA")]
        [Column("QTDE_RECEBIDA")]
        public decimal? QTDE_RECEBIDA { get; set; }
 
        [DisplayName("QTDE_A_RECEBER")]
        [Column("QTDE_A_RECEBER")]
        public decimal? QTDE_A_RECEBER { get; set; }
 
    }
}
