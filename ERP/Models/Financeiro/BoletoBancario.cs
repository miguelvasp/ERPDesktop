
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("BOLETOBANCARIO", Schema = "DBO")]
    public class BoletoBancario
    {
        [Key]
        [DisplayName("IdBoleto")]
        [Column("IDBOLETO")]
        public int IdBoleto { get; set; }

        [DisplayName("CedenteNome")]
        [Column("CEDENTENOME")]
        public string CedenteNome { get; set; }

        [DisplayName("CedenteEndereco")]
        [Column("CEDENTEENDERECO")]
        public string CedenteEndereco { get; set; }

        [DisplayName("CedenteCNPJ")]
        [Column("CEDENTECNPJ")]
        public string CedenteCNPJ { get; set; }

        [DisplayName("CedenteBanco")]
        [Column("CEDENTEBANCO")]
        public string CedenteBanco { get; set; }

        [DisplayName("CedenteAgencia")]
        [Column("CEDENTEAGENCIA")]
        public string CedenteAgencia { get; set; }

        [DisplayName("CedenteConta")]
        [Column("CEDENTECONTA")]
        public string CedenteConta { get; set; }

        [DisplayName("CedenteCarteira")]
        [Column("CEDENTECARTEIRA")]
        public string CedenteCarteira { get; set; }

        [DisplayName("CedenteModalidade")]
        [Column("CEDENTEMODALIDADE")]
        public string CedenteModalidade { get; set; }

        [DisplayName("CedenteConvenio")]
        [Column("CEDENTECONVENIO")]
        public string CedenteConvenio { get; set; }

        [DisplayName("CedenteCodCedente")]
        [Column("CEDENTECODCEDENTE")]
        public string CedenteCodCedente { get; set; }

        [DisplayName("CedenteUsoBanco")]
        [Column("CEDENTEUSOBANCO")]
        public string CedenteUsoBanco { get; set; }

        [DisplayName("CedenteCIP")]
        [Column("CEDENTECIP")]
        public string CedenteCIP { get; set; }

        [DisplayName("SacadoNome")]
        [Column("SACADONOME")]
        public string SacadoNome { get; set; }

        [DisplayName("SacadoDocumento")]
        [Column("SACADODOCUMENTO")]
        public string SacadoDocumento { get; set; }

        [DisplayName("SacadoEndereco")]
        [Column("SACADOENDERECO")]
        public string SacadoEndereco { get; set; }

        [DisplayName("SacadoCidade")]
        [Column("SACADOCIDADE")]
        public string SacadoCidade { get; set; }

        [DisplayName("SacadoBairro")]
        [Column("SACADOBAIRRO")]
        public string SacadoBairro { get; set; }

        [DisplayName("SacadoCEP")]
        [Column("SACADOCEP")]
        public string SacadoCEP { get; set; }

        [DisplayName("SacadoUF")]
        [Column("SACADOUF")]
        public string SacadoUF { get; set; }

        [DisplayName("SacadoAvalista")]
        [Column("SACADOAVALISTA")]
        public string SacadoAvalista { get; set; }

        [DisplayName("BoletoNossoNumero")]
        [Column("BOLETONOSSONUMERO")]
        public string BoletoNossoNumero { get; set; }

        [DisplayName("BoletoNossoDocumento")]
        [Column("BOLETONOSSODOCUMENTO")]
        public string BoletoNossoDocumento { get; set; }

        [DisplayName("BoletoParcelaNumero")]
        [Column("BOLETOPARCELANUMERO")]
        public int? BoletoParcelaNumero { get; set; }

        [DisplayName("BoletoParcelaTotal")]
        [Column("BOLETOPARCELATOTAL")]
        public int? BoletoParcelaTotal { get; set; }

        [DisplayName("BoletoQuantidade")]
        [Column("BOLETOQUANTIDADE")]
        public decimal? BoletoQuantidade { get; set; }

        [DisplayName("BoletoValorUnitario")]
        [Column("BOLETOVALORUNITARIO")]
        public decimal? BoletoValorUnitario { get; set; }

        [DisplayName("BoletoValorDocumento")]
        [Column("BOLETOVALORDOCUMENTO")]
        public decimal? BoletoValorDocumento { get; set; }

        [DisplayName("BoletoDataDocumento")]
        [Column("BOLETODATADOCUMENTO")]
        public DateTime? BoletoDataDocumento { get; set; }

        [DisplayName("BoletoDataVencimento")]
        [Column("BOLETODATAVENCIMENTO")]
        public DateTime? BoletoDataVencimento { get; set; }

        [DisplayName("BoletoEspecie")]
        [Column("BOLETOESPECIE")]
        public string BoletoEspecie { get; set; }

        [DisplayName("BoletoDataProcessamento")]
        [Column("BOLETODATAPROCESSAMENTO")]
        public DateTime? BoletoDataProcessamento { get; set; }

        [DisplayName("BoletoValorMora")]
        [Column("BOLETOVALORMORA")]
        public decimal? BoletoValorMora { get; set; }

        [DisplayName("BoletoPercentualMulta")]
        [Column("BOLETOPERCENTUALMULTA")]
        public decimal? BoletoPercentualMulta { get; set; }

        [DisplayName("BoletoPercentualMora")]
        [Column("BOLETOPERCENTUALMORA")]
        public decimal? BoletoPercentualMora { get; set; }

        [DisplayName("BoletoDataPagamento")]
        [Column("BOLETODATAPAGAMENTO")]
        public DateTime? BoletoDataPagamento { get; set; }

        [DisplayName("BoletoCalculaMultaMora")]
        [Column("BOLETOCALCULAMULTAMORA")]
        public bool BoletoCalculaMultaMora { get; set; }

        [DisplayName("BoletoValorDesconto")]
        [Column("BOLETOVALORDESCONTO")]
        public decimal? BoletoValorDesconto { get; set; }

        [DisplayName("BoletoDataDesconto")]
        [Column("BOLETODATADESCONTO")]
        public DateTime? BoletoDataDesconto { get; set; }

        [DisplayName("BoletoValorAcrescimo")]
        [Column("BOLETOVALORACRESCIMO")]
        public decimal? BoletoValorAcrescimo { get; set; }

        [DisplayName("BoletoValorOutros")]
        [Column("BOLETOVALOROUTROS")]
        public decimal? BoletoValorOutros { get; set; }

        [DisplayName("BoletoInstrucoes")]
        [Column("BOLETOINSTRUCOES")]
        public string BoletoInstrucoes { get; set; }

        [DisplayName("BoletoStatus")]
        [Column("BOLETOSTATUS")]
        public string BoletoStatus { get; set; }
        public int? IdContasReceber { get; set; }
        public int? IdContasReceberAberto { get; set; }
        public int? IdContasReceberBaixa { get; set; }
        public int? IdContaBancaria { get; set; }
    }
}
