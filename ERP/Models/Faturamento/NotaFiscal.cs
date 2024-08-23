using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("NOTAFISCAL", Schema = "DBO")]
    public class NotaFiscal
    {
        [Key]
        [DisplayName("IdNotaFiscal")]
        [Column("IDNOTAFISCAL")]
        public int IdNotaFiscal { get; set; }

        public int? IdEmpresa { get; set; }

        [DisplayName("Numero")]
        [Column("NUMERO")]
        public string Numero { get; set; }

        public int? IdCondicaoPagamento { get; set; }

        [DisplayName("IdDocumento")]
        [Column("IDDOCUMENTO")]
        public int? IdDocumento { get; set; }

        [DisplayName("IdEmitente")]
        [Column("IDEMITENTE")]
        public int? IdEmitente { get; set; }

        [DisplayName("ClienteFornecedor")]
        [Column("CLIENTEFORNECEDOR")]
        public string ClienteFornecedor { get; set; }

        [DisplayName("IdDestinatario")]
        [Column("IDDESTINATARIO")]
        public int? IdDestinatario { get; set; }

        [DisplayName("RazaoSocial")]
        [Column("RAZAOSOCIAL")]
        public string RazaoSocial { get; set; }

        [DisplayName("NomeFantasia")]
        [Column("NOMEFANTASIA")]
        public string NomeFantasia { get; set; }

        [DisplayName("Endereco")]
        [Column("ENDERECO")]
        public string Endereco { get; set; }

        [DisplayName("Complemento")]
        [Column("COMPLEMENTO")]
        public string Complemento { get; set; }

        [DisplayName("Bairro")]
        [Column("BAIRRO")]
        public string Bairro { get; set; }

        [DisplayName("UF")]
        [Column("UF")]
        public string UF { get; set; }

        [DisplayName("CEP")]
        [Column("CEP")]
        public string CEP { get; set; }

        [DisplayName("CNPJ")]
        [Column("CNPJ")]
        public string CNPJ { get; set; }

        [DisplayName("IE")]
        [Column("IE")]
        public string IE { get; set; }

        [DisplayName("DirecaoCFOP")]
        [Column("DIRECAOCFOP")]
        public int? DirecaoCFOP { get; set; }

        [DisplayName("FormaEmissao")]
        [Column("FORMAEMISSAO")]
        public int? FormaEmissao { get; set; }

        [DisplayName("TipoAtendimento")]
        [Column("TIPOATENDIMENTO")]
        public int? TipoAtendimento { get; set; }

        [DisplayName("FinalidadeEmissao")]
        [Column("FINALIDADEEMISSAO")]
        public int? FinalidadeEmissao { get; set; }

        [DisplayName("NomeOperacao")]
        [Column("NOMEOPERACAO")]
        public string NomeOperacao { get; set; }

        [DisplayName("ValorDesconto")]
        [Column("VALORDESCONTO")]
        public decimal? ValorDesconto { get; set; }

        [DisplayName("ValorFrete")]
        [Column("VALORFRETE")]
        public decimal? ValorFrete { get; set; }

        [DisplayName("ValorSeguro")]
        [Column("VALORSEGURO")]
        public decimal? ValorSeguro { get; set; }

        [DisplayName("BaseIPI")]
        [Column("BASEIPI")]
        public decimal? BaseIPI { get; set; }

        [DisplayName("ValorIPI")]
        [Column("VALORIPI")]
        public decimal? ValorIPI { get; set; }

        [DisplayName("BaseICMS")]
        [Column("BASEICMS")]
        public decimal? BaseICMS { get; set; }

        [DisplayName("ValorICMS")]
        [Column("VALORICMS")]
        public decimal? ValorICMS { get; set; }

        [DisplayName("BaseICMSSubs")]
        [Column("BASEICMSSUBS")]
        public decimal? BaseICMSSubs { get; set; }

        [DisplayName("ValorICMSSubs")]
        [Column("VALORICMSSUBS")]
        public decimal? ValorICMSSubs { get; set; }

        [DisplayName("ValorMercadoria")]
        [Column("VALORMERCADORIA")]
        public decimal? ValorMercadoria { get; set; }

        [DisplayName("TotalNF")]
        [Column("TOTALNF")]
        public decimal? TotalNF { get; set; }

        [DisplayName("DataSaida")]
        [Column("DATASAIDA")]
        public DateTime? DataSaida { get; set; }

        [DisplayName("DataEntrada")]
        [Column("DATAENTRADA")]
        public DateTime? DataEntrada { get; set; }

        [DisplayName("IdTransportadora")]
        [Column("IDTRANSPORTADORA")]
        public int? IdTransportadora { get; set; }

        [DisplayName("TransPlaca")]
        [Column("TRANSPLACA")]
        public string TransPlaca { get; set; }

        [DisplayName("TransUF")]
        [Column("TRANSUF")]
        public string TransUF { get; set; }

        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal? Quantidade { get; set; }

        [DisplayName("Especie")]
        [Column("ESPECIE")]
        public string Especie { get; set; }

        [DisplayName("PesoLiquido")]
        [Column("PESOLIQUIDO")]
        public decimal? PesoLiquido { get; set; }

        [DisplayName("PesoBruto")]
        [Column("PESOBRUTO")]
        public decimal? PesoBruto { get; set; }

        [DisplayName("Volumes")]
        [Column("VOLUMES")]
        public decimal? Volumes { get; set; }

        [DisplayName("TipoFrete")]
        [Column("TIPOFRETE")]
        public int? TipoFrete { get; set; }

        [DisplayName("DataEmissao")]
        [Column("DATAEMISSAO")]
        public DateTime DataEmissao { get; set; }

        [DisplayName("IdCFOP")]
        [Column("IDCFOP")]
        public int? IdCFOP { get; set; }

        [DisplayName("IdCidade")]
        [Column("IDCIDADE")]
        public int? IdCidade { get; set; }

        [DisplayName("NotaStatus")]
        [Column("NOTASTATUS")]
        public int? NotaStatus { get; set; }

        [DisplayName("Serie")]
        [Column("SERIE")]
        public string Serie { get; set; }

        [DisplayName("ChaveNFe")]
        [Column("CHAVENFE")]
        public string ChaveNFe { get; set; }

        [DisplayName("IdPais")]
        [Column("IDPAIS")]
        public int? IdPais { get; set; }

        [DisplayName("EnderecoNumero")]
        [Column("ENDERECONUMERO")]
        public string EnderecoNumero { get; set; }

        [DisplayName("Protocolo")]
        [Column("PROTOCOLO")]
        public string Protocolo { get; set; }

        [DisplayName("DataAutorizacao")]
        [Column("DATAAUTORIZACAO")]
        public DateTime? DataAutorizacao { get; set; }

        [DisplayName("DataCancelamento")]
        [Column("DATACANCELAMENTO")]
        public DateTime? DataCancelamento { get; set; }

        [DisplayName("JustificativaCancelamento")]
        [Column("JUSTIFICATIVACANCELAMENTO")]
        public string JustificativaCancelamento { get; set; }

        [DisplayName("Telefone")]
        [Column("TELEFONE")]
        public string Telefone { get; set; }

        [DisplayName("DataEntrega")]
        [Column("DATAENTREGA")]
        public DateTime? DataEntrega { get; set; }

        [DisplayName("IdContasPagar")]
        [Column("IDCONTASPAGAR")]
        public int? IdContasPagar { get; set; }

        [DisplayName("NFConfirmada")]
        [Column("NFCONFIRMADA")]
        public bool NFConfirmada { get; set; }

        [DisplayName("IdContasReceber")]
        [Column("IDCONTASRECEBER")]
        public int? IdContasReceber { get; set; }

        [DisplayName("NFecNF")]
        [Column("NFECNF")]
        public int? NFecNF { get; set; }

        [DisplayName("NFecDV")]
        [Column("NFECDV")]
        public int? NFecDV { get; set; }

        [DisplayName("NFetpNF")]
        [Column("NFETPNF")]
        public int? NFetpNF { get; set; }

        [DisplayName("NFetpEmiss")]
        [Column("NFETPEMISS")]
        public int? NFetpEmiss { get; set; }

        [DisplayName("NFefinNFe")]
        [Column("NFEFINNFE")]
        public int? NFefinNFe { get; set; }

        [DisplayName("NFeIndFinal")]
        [Column("NFEINDFINAL")]
        public int? NFeIndFinal { get; set; }

        [DisplayName("NFeIndPres")]
        [Column("NFEINDPRES")]
        public int? NFeIndPres { get; set; }

        [DisplayName("NFeModelo")]
        [Column("NFEMODELO")]
        public int? NFeModelo { get; set; }

        [DisplayName("NFeIndPag")]
        [Column("NFEINDPAG")]
        public int? NFeIndPag { get; set; }

        [DisplayName("NFeRecibo")]
        [Column("NFERECIBO")]
        public string NFeRecibo { get; set; }

        [DisplayName("NFeResultado")]
        [Column("NFERESULTADO")]
        public string NFeResultado { get; set; }

        [Column("NFEPROTOCOLOCANCELAMENTO")]
        public string NFeProtocoloCancelamento { get; set; }

        public string NFeReferencia { get; set; }

        //public virtual UnidadeFederacao UnidadeFederacao { get; set; }
        public virtual Cidade Cidade { get; set; } 
        public virtual ICollection<NotaFiscalItem> Itens { get; set; }
         
    }
}
