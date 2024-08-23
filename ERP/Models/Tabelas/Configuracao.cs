
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CONFIGURACAO", Schema = "DBO")]
    public class Configuracao
    {
        [Key]
        [DisplayName("IdConfiguracao")]
        [Column("IDCONFIGURACAO")]
        public int IdConfiguracao { get; set; }

        [DisplayName("IdEmpresa")]
        [Column("IDEMPRESA")]
        public int? IdEmpresa { get; set; }

        [DisplayName("EMailUserName")]
        [Column("EMAILUSERNAME")]
        public string EMailUserName { get; set; }

        [DisplayName("EMailPassword")]
        [Column("EMAILPASSWORD")]
        public string EMailPassword { get; set; }

        [DisplayName("EMailSMTP")]
        [Column("EMAILSMTP")]
        public string EMailSMTP { get; set; }

        [DisplayName("EMailPort")]
        [Column("EMAILPORT")]
        public string EMailPort { get; set; }

        [DisplayName("EMailSSL")]
        [Column("EMAILSSL")]
        public bool EMailSSL { get; set; }

        [DisplayName("VersaoSistema")]
        [Column("VERSAOSISTEMA")]
        public decimal? VersaoSistema { get; set; }

        [DisplayName("PrazoEntrega")]
        [Column("PRAZOENTREGA")]
        public int? PrazoEntrega { get; set; }

        [DisplayName("IdModoEntregaVendas")]
        [Column("IDMODOENTREGAVENDAS")]
        public int? IdModoEntregaVendas { get; set; }

        [DisplayName("IdGrupoArmazenamentoProduto")]
        [Column("IDGRUPOARMAZENAMENTOPRODUTO")]
        public int? IdGrupoArmazenamentoProduto { get; set; }

        [DisplayName("IdGrupoRastreabilidadeProduto")]
        [Column("IDGRUPORASTREABILIDADEPRODUTO")]
        public int? IdGrupoRastreabilidadeProduto { get; set; }

        [DisplayName("IdGrupoEstoqueProduto")]
        [Column("IDGRUPOESTOQUEPRODUTO")]
        public int? IdGrupoEstoqueProduto { get; set; }

        [DisplayName("IdModoEntregaCompras")]
        [Column("IDMODOENTREGACOMPRAS")]
        public int? IdModoEntregaCompras { get; set; }

        [DisplayName("IdGrupoRastreabilidadeServico")]
        [Column("IDGRUPORASTREABILIDADESERVICO")]
        public int? IdGrupoRastreabilidadeServico { get; set; }

        [DisplayName("IdGrupoArmazemServico")]
        [Column("IDGRUPOARMAZEMSERVICO")]
        public int? IdGrupoArmazemServico { get; set; }

        [DisplayName("IdGrupoEstoqueServico")]
        [Column("IDGRUPOESTOQUESERVICO")]
        public int? IdGrupoEstoqueServico { get; set; }

        [DisplayName("UsarPadraoEstoque")]
        [Column("USARPADRAOESTOQUE")]
        public bool? UsarPadraoEstoque { get; set; }

        [DisplayName("UsarPadraoCompras")]
        [Column("USARPADRAOCOMPRAS")]
        public bool? UsarPadraoCompras { get; set; }

        [DisplayName("UsarPadraoVendas")]
        [Column("USARPADRAOVENDAS")]
        public bool? UsarPadraoVendas { get; set; }

        [Column("CASASDECIMAIS")]
        public int? CasasDecimais { get; set; }

        [Column("IDDEPOSITOVENDAS")]
        public int? IdDepositoVendas { get; set; }

        [Column("IDARMAZEMVENDAS")]
        public int? IdArmazemVendas { get; set; }

        [Column("IDDEPOSITOCOMPRAS")]
        public int? IdDepositoCompras { get; set; }

        [Column("IDARMAZEMCOMPRAS")]
        public int? IdArmazemCompras { get; set; }

        [DisplayName("VendasRelValorTotal")]
        [Column("VENDASRELVALORTOTAL")]
        public bool? VendasRelValorTotal { get; set; }

        [DisplayName("VendasRelDescontoVarejista")]
        [Column("VENDASRELDESCONTOVAREJISTA")]
        public bool? VendasRelDescontoVarejista { get; set; }

        [DisplayName("VendasRelTotalProdutos")]
        [Column("VENDASRELTOTALPRODUTOS")]
        public bool? VendasRelTotalProdutos { get; set; }

        [DisplayName("VendasRelPeso")]
        [Column("VENDASRELPESO")]
        public bool? VendasRelPeso { get; set; }

        [DisplayName("VendasRelVendedor")]
        [Column("VENDASRELVENDEDOR")]
        public bool? VendasRelVendedor { get; set; }

        [DisplayName("VendasRelTelevendas")]
        [Column("VENDASRELTELEVENDAS")]
        public bool? VendasRelTelevendas { get; set; }

        [DisplayName("Ambiente NFe")]
        [Column("AMBIENTENFE")]
        public int? AmbienteNFe { get; set; }

        [DisplayName("NFeSiglaWS")]
        [Column("NFESIGLAWS")]
        public string NFeSiglaWS { get; set; }

        [DisplayName("NFe Licença")]
        [Column("NFELICENCA")]
        public string NFeLicenca { get; set; }

    }
}
