using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("EMPRESA", Schema = "DBO")]
    public class Empresa
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDEMPRESA")]
        public int IdEmpresa { get; set; }

        [DisplayName("Razão Social")]
        [Column("RAZAOSOCIAL")]
        public string RazaoSocial { get; set; }

        [DisplayName("Fantasia")]
        [Column("FANTASIA")]
        public string Fantasia { get; set; }

        [DisplayName("CNPJ")]
        [Column("CNPJ")]
        public string CNPJ { get; set; }

        [DisplayName("IE")]
        [Column("IE")]
        public string IE { get; set; }

        [DisplayName("Endereço")]
        [Column("ENDERECO")]
        public string Endereco { get; set; }

        [DisplayName("Número")]
        [Column("NUMERO")]
        public string Numero { get; set; }

        [DisplayName("Complemento")]
        [Column("COMPLEMENTO")]
        public string Complemento { get; set; }

        [DisplayName("Bairro")]
        [Column("BAIRRO")]
        public string Bairro { get; set; }

        [DisplayName("Id Cidade")]
        [Column("IDCIDADE")]
        public int? IdCidade { get; set; }
        public virtual Cidade Cidade { get; set; }

        [DisplayName("Id UF")]
        [Column("IDUF")]
        public int? IdUF { get; set; }

        [DisplayName("CEP")]
        [Column("CEP")]
        public string CEP { get; set; }

        [DisplayName("Telefone")]
        [Column("TELEFONE")]
        public string Telefone { get; set; }

        [DisplayName("Telefone2")]
        [Column("TELEFONE2")]
        public string Telefone2 { get; set; }

        [DisplayName("Fax")]
        [Column("FAX")]
        public string Fax { get; set; }

        [DisplayName("Email")]
        [Column("EMAIL")]
        public string Email { get; set; }

        [DisplayName("Última Fatura")]
        [Column("ULTIMAFATURA")]
        public int? UltimaFatura { get; set; }

        [DisplayName("Última Nota Fiscal")]
        [Column("ULTIMANOTAFISCAL")]
        public int? UltimaNotaFiscal { get; set; }

        [DisplayName("Último Conhecimento")]
        [Column("ULTIMOCONHECIMENTO")]
        public int? UltimoConhecimento { get; set; }

        [DisplayName("Logo")]
        [Column("LOGO")]
        public byte[] Logo { get; set; }

        [DisplayName("Última Nota Serviço")]
        [Column("ULTIMANOTASERVICO")]
        public int? UltimaNotaServico { get; set; }

        [DisplayName("Id Contador")]
        [Column("IDCONTADOR")]
        public int? IdContador { get; set; }

        [DisplayName("Último Pedido Compras")]
        [Column("ULTIMOPEDIDOCOMPRAS")]
        public int? UltimoPedidoCompras { get; set; }

        [DisplayName("Última Nota Fiscal Provisória")]
        [Column("ULTIMANOTAFISCALPROVISORIA")]
        public int? UltimaNotaFiscalProvisoria { get; set; }

        [DisplayName("Último Pedido Vendas")]
        [Column("ULTIMOPEDIDOVENDAS")]
        public int? UltimoPedidoVendas { get; set; }

        [DisplayName("Último Recebimento")]
        [Column("ULTIMORECEBIMENTO")]
        public int? UltimoRecebimento { get; set; }

        [DisplayName("Último Contrato Comercial")]
        [Column("ULTIMOCONTRATOCOMERCIAL")]
        public int? UltimoContratoComercial { get; set; }

        [DisplayName("Última Ordem Produção")]
        [Column("ULTIMAORDEMPRODUCAO")]
        public int? UltimaOrdemProducao { get; set; }

      

   

        [DisplayName("CRT")]
        [Column("CRT")]
        public int? CRT { get; set; }

       

        [Column("ULTIMACOMISSAO")]
        public int? UltimaComissao { get; set; }

        [Column("IDMOEDA")]
        public int? IdMoeda { get; set; }
    }
}
