using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("DESCONTOVAREJISTA", Schema = "DBO")]
    public class DescontoVarejista
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDDESCONTOVAREJISTA")]
        public int IdDescontoVarejista { get; set; }

        [DisplayName("Id Pedido Venda")]
        [Column("IDPEDIDOVENDA")]
        public int IdPedidoVenda { get; set; }

        [DisplayName("Id Pedido Venda Item")]
        [Column("IDPEDIDOVENDAITEM")]
        public int IdPedidoVendaItem { get; set; }

        [DisplayName("Id Nota Fiscal")]
        [Column("IDNOTAFISCAL")]
        public int? IdNotaFiscal { get; set; }

        [DisplayName("Id Nota Fiscal Item")]
        [Column("IDNOTAFISCALITEM")]
        public int? IdNotaFiscalItem { get; set; }

        [DisplayName("Id Cliente")]
        [Column("IDCLIENTE")]
        public int IdCliente { get; set; }

        [DisplayName("Data Pedido")]
        [Column("DATAPEDIDO")]
        public DateTime DataPedido { get; set; }

        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal Valor { get; set; }
    }
}
