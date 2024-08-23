using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("CONTABANCARIA", Schema = "DBO")]
    public class ContaBancaria
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCONTABANCARIA")]
        public int IdContaBancaria { get; set; }

        [DisplayName("Id Banco")]
        [Column("IDBANCO")]
        public int IdBanco { get; set; }
        public virtual Banco Banco { get; set; }

        [DisplayName("IdEmpresa")]
        [Column("IDEMPRESA")]
        public int? IdEmpresa { get; set; }

        [DisplayName("Nome da Conta")]
        [Column("NOMECONTA")]
        public string NomeConta { get; set; }

        [DisplayName("Ag�ncia")]
        [Column("AGENCIA")]
        public string Agencia { get; set; }

        [DisplayName("Digito Ag�ncia")]
        [Column("DIGITOAGENCIA")]
        public string DigitoAgencia { get; set; }

        [DisplayName("Conta")]
        [Column("CONTA")]
        public string Conta { get; set; }

        [DisplayName("Digito Conta")]
        [Column("DIGITOCONTA")]
        public string DigitoConta { get; set; }

        [DisplayName("Data In�cio")]
        [Column("DATAINICIO")]
        public DateTime DataInicio { get; set; }

        [DisplayName("SaldoInicial")]
        [Column("SALDOINICIAL")]
        public decimal SaldoInicial { get; set; }

        [DisplayName("�ltimo Cheque")]
        [Column("ULTIMOCHEQUE")]
        public int UltimoCheque { get; set; }

        [DisplayName("Data Concilia��o")]
        [Column("DATACONCILIACAO")]
        public DateTime DataConciliacao { get; set; }

        [DisplayName("C�digo Swift")]
        [Column("CODIGOSWIFT")]
        public string CodigoSwift { get; set; }

        [DisplayName("IBAN")]
        [Column("IBAN")]
        public string IBAN { get; set; }

        [DisplayName("Id Moeda")]
        [Column("IDMOEDA")]
        public int? IdMoeda { get; set; }
        public virtual Moeda Moeda { get; set; }

        [DisplayName("Id Pa�s")]
        [Column("IDPAIS")]
        public int? IdPais { get; set; }

        [DisplayName("Nosso N�mero")]
        [Column("NOSSONUMERO")]
        public string NossoNumero { get; set; }

        [DisplayName("Carteira")]
        [Column("CARTEIRA")]
        public string Carteira { get; set; }

        [DisplayName("ConciliacaoAutomatica")]
        [Column("CONCILIACAOAUTOMATICA")]
        public int? ConciliacaoAutomatica { get; set; }

        [DisplayName("IdContaContabil")]
        [Column("IDCONTACONTABIL")]
        public int? IdContaContabil { get; set; }

        public bool? EmiteBoleto { get; set; }
        public string BoletoCarteira { get; set; }
        public string BoletoModalidade { get; set; }
        public string BoletoCodCedente { get; set; }
        public string BoletoUsoBanco { get; set; }
        public string BoletoCIP { get; set; } 
        public string BoletoConvenio { get; set; }

         
    }
}
