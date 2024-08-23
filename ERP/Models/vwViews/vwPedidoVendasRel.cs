
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("VWPEDIDOVENDASREL", Schema = "DBO")]
    public class vwPedidoVendasRel
    {
        [Key]
        [DisplayName("LineId")]
        [Column("LINEID")]
        public long LineId { get; set; }
 
        [DisplayName("PedidoNumero")]
        [Column("PEDIDONUMERO")]
        public int? PedidoNumero { get; set; }
 
        [DisplayName("Pedido")]
        [Column("PEDIDO")]
        public int? Pedido { get; set; }
 
        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime? Data { get; set; }
 
        [DisplayName("Moeda")]
        [Column("MOEDA")]
        public string Moeda { get; set; }
 
        [DisplayName("CondicaoPgto")]
        [Column("CONDICAOPGTO")]
        public string CondicaoPgto { get; set; }
 
        [DisplayName("DataEntrega")]
        [Column("DATAENTREGA")]
        public DateTime? DataEntrega { get; set; }
 
        [DisplayName("PrazoEntrega")]
        [Column("PRAZOENTREGA")]
        public int? PrazoEntrega { get; set; }
 
        [DisplayName("Observacao")]
        [Column("OBSERVACAO")]
        public string Observacao { get; set; }
 
        [DisplayName("Emissao")]
        [Column("EMISSAO")]
        public DateTime? Emissao { get; set; }
 
        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal? Quantidade { get; set; }
 
        [DisplayName("Ipi")]
        [Column("IPI")]
        public decimal? Ipi { get; set; }
 
        [DisplayName("PrecoUnitario")]
        [Column("PRECOUNITARIO")]
        public decimal? PrecoUnitario { get; set; }
 
        [DisplayName("TOTAL")]
        [Column("TOTAL")]
        public decimal? TOTAL { get; set; }
 
        [DisplayName("EmpresaRazaoSocial")]
        [Column("EMPRESARAZAOSOCIAL")]
        public string EmpresaRazaoSocial { get; set; }
 
        [DisplayName("EmpresaEndereco")]
        [Column("EMPRESAENDERECO")]
        public string EmpresaEndereco { get; set; }
 
        [DisplayName("EmpresaNumero")]
        [Column("EMPRESANUMERO")]
        public string EmpresaNumero { get; set; }
 
        [DisplayName("EmpresaCEP")]
        [Column("EMPRESACEP")]
        public string EmpresaCEP { get; set; }
 
        [DisplayName("EmpresaCNPJ")]
        [Column("EMPRESACNPJ")]
        public string EmpresaCNPJ { get; set; }
 
        [DisplayName("EmpresaCidade")]
        [Column("EMPRESACIDADE")]
        public string EmpresaCidade { get; set; }
 
        [DisplayName("EmpresaUF")]
        [Column("EMPRESAUF")]
        public string EmpresaUF { get; set; }
 
        [DisplayName("EmpresaEmail")]
        [Column("EMPRESAEMAIL")]
        public string EmpresaEmail { get; set; }
 
        [DisplayName("EmpresaBairro")]
        [Column("EMPRESABAIRRO")]
        public string EmpresaBairro { get; set; }
 
        //[DisplayName("EmpresaLogo")]
        //[Column("EMPRESALOGO")]
        //public byte EmpresaLogo { get; set; }
 
        [DisplayName("ClienteRazaoSocial")]
        [Column("CLIENTERAZAOSOCIAL")]
        public string ClienteRazaoSocial { get; set; }
 
        [DisplayName("ClienteEndereco")]
        [Column("CLIENTEENDERECO")]
        public string ClienteEndereco { get; set; }
 
        [DisplayName("ClienteNumero")]
        [Column("CLIENTENUMERO")]
        public string ClienteNumero { get; set; }
 
        [DisplayName("ClienteCEP")]
        [Column("CLIENTECEP")]
        public string ClienteCEP { get; set; }
 
        [DisplayName("ClienteCidade")]
        [Column("CLIENTECIDADE")]
        public string ClienteCidade { get; set; }
 
        [DisplayName("ClienteTelefone")]
        [Column("CLIENTETELEFONE")]
        public string ClienteTelefone { get; set; }
 
        [DisplayName("ClienteUF")]
        [Column("CLIENTEUF")]
        public string ClienteUF { get; set; }
 
        [DisplayName("CODIGO")]
        [Column("CODIGO")]
        public string CODIGO { get; set; }
 
        [DisplayName("NomeProduto")]
        [Column("NOMEPRODUTO")]
        public string NomeProduto { get; set; }
 
        [DisplayName("UnidadeMedida")]
        [Column("UNIDADEMEDIDA")]
        public string UnidadeMedida { get; set; }
 
        [DisplayName("totalPedido")]
        [Column("TOTALPEDIDO")]
        public decimal? totalPedido { get; set; }
 
        [DisplayName("PesoUnitario")]
        [Column("PESOUNITARIO")]
        public decimal? PesoUnitario { get; set; }
 
        [DisplayName("Cor")]
        [Column("COR")]
        public string Cor { get; set; }
 
        [DisplayName("DescontoVarejista")]
        [Column("DESCONTOVAREJISTA")]
        public decimal? DescontoVarejista { get; set; }
 
        [DisplayName("Vendedor")]
        [Column("VENDEDOR")]
        public string Vendedor { get; set; }
 
        [DisplayName("TeleVendas")]
        [Column("TELEVENDAS")]
        public string TeleVendas { get; set; }

        [Column("QUANTIDADEPORFATURAR")]
        public decimal? QuantidadePorFaturar { get; set; }

    }
}
