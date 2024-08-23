
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PEDIDOCOMPRAITEMENCARGO", Schema = "DBO")]
    public class PedidoCompraItemEncargo
    {
        [Key]
        [DisplayName("IdPedidoCompraItemEncargo")]
        [Column("IDPEDIDOCOMPRAITEMENCARGO")]
        public int? IdPedidoCompraItemEncargo { get; set; }
 
        [DisplayName("IdPedidoCompraItem")]
        [Column("IDPEDIDOCOMPRAITEM")]
        public int? IdPedidoCompraItem { get; set; }
 
        [DisplayName("IdTransacao")]
        [Column("IDTRANSACAO")]
        public int? IdTransacao { get; set; }
 
        [DisplayName("IdCodigoEncargo")]
        [Column("IDCODIGOENCARGO")]
        public int? IdCodigoEncargo { get; set; }
 
        [DisplayName("IdMoeda")]
        [Column("IDMOEDA")]
        public int? IdMoeda { get; set; }
 
        [DisplayName("ValorEncargo")]
        [Column("VALORENCARGO")]
        public decimal? ValorEncargo { get; set; }
 
        [DisplayName("TipoEncargo")]
        [Column("TIPOENCARGO")]
        public int? TipoEncargo { get; set; }
 
        [DisplayName("IdGrupoImposto")]
        [Column("IDGRUPOIMPOSTO")]
        public int? IdGrupoImposto { get; set; }
 
        [DisplayName("IdGrupoImpostoItem")]
        [Column("IDGRUPOIMPOSTOITEM")]
        public int? IdGrupoImpostoItem { get; set; }
 
        [DisplayName("IncluiNotaFiscal")]
        [Column("INCLUINOTAFISCAL")]
        public bool IncluiNotaFiscal { get; set; }
 
        [DisplayName("IncluiImposto")]
        [Column("INCLUIIMPOSTO")]
        public bool IncluiImposto { get; set; }
 
    }
}
