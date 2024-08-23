
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("VWPEDIDOVENDASEPARACAO", Schema = "DBO")]
    public class vwPedidoVendaSeparacao
    {
        [Key]
        [DisplayName("LineId")]
        [Column("LINEID")]
        public long LineId { get; set; }
 
        [DisplayName("IdPedidoVenda")]
        [Column("IDPEDIDOVENDA")]
        public int? IdPedidoVenda { get; set; }
 
        [DisplayName("IdPedidoVendaItem")]
        [Column("IDPEDIDOVENDAITEM")]
        public int? IdPedidoVendaItem { get; set; }
 
        [DisplayName("PedidoNumero")]
        [Column("PEDIDONUMERO")]
        public int? PedidoNumero { get; set; }
 
        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime? Data { get; set; }
 
        [DisplayName("DataEntrega")]
        [Column("DATAENTREGA")]
        public DateTime? DataEntrega { get; set; }

        [Column("IDCLIENTE")]
        public int IdCliente { get; set; }

        [DisplayName("NomeFantasia")]
        [Column("NOMEFANTASIA")]
        public string NomeFantasia { get; set; }
 
        [DisplayName("RazaoSocial")]
        [Column("RAZAOSOCIAL")]
        public string RazaoSocial { get; set; }
 
        [DisplayName("Logradouro")]
        [Column("LOGRADOURO")]
        public string Logradouro { get; set; }
 
        [DisplayName("Numero")]
        [Column("NUMERO")]
        public string Numero { get; set; }
 
        [DisplayName("Complemento")]
        [Column("COMPLEMENTO")]
        public string Complemento { get; set; }
 
        [DisplayName("Bairro")]
        [Column("BAIRRO")]
        public string Bairro { get; set; }
 
        [DisplayName("CEP")]
        [Column("CEP")]
        public string CEP { get; set; }
 
        [DisplayName("Cidade")]
        [Column("CIDADE")]
        public string Cidade { get; set; }
 
        [DisplayName("UF")]
        [Column("UF")]
        public string UF { get; set; }
 
        [DisplayName("Codigo")]
        [Column("CODIGO")]
        public string Codigo { get; set; }
 
        [DisplayName("NomeProduto")]
        [Column("NOMEPRODUTO")]
        public string NomeProduto { get; set; }
 
        [DisplayName("Config")]
        [Column("CONFIG")]
        public string Config { get; set; }
 
        [DisplayName("Cor")]
        [Column("COR")]
        public string Cor { get; set; }
 
        [DisplayName("Estilo")]
        [Column("ESTILO")]
        public string Estilo { get; set; }
 
        [DisplayName("Tamanho")]
        [Column("TAMANHO")]
        public string Tamanho { get; set; }
 
        [DisplayName("QuantidadeSeparacao")]
        [Column("QUANTIDADESEPARACAO")]
        public decimal? QuantidadeSeparacao { get; set; }

        [DisplayName("QuantidadePorFaturar")]
        [Column("QUANTIDADEPORFATURAR")]
        public decimal? QuantidadePorFaturar { get; set; }
 
    }
}
