using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("ATIVOIMOBILIZADO", Schema = "DBO")]
    public class AtivoImobilizado
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDATIVOIMOBILIZADO")]
        public int IdAtivoImobilizado { get; set; }

        [DisplayName("Id Grupo Ativo")]
        [Column("IDGRUPOATIVO")]
        public int? IdGrupoAtivo { get; set; }
        public virtual GrupoAtivo GrupoAtivo { get; set; }

        [DisplayName("Número Físico")]
        [Column("NUMEROFISICO")]
        public string NumeroFisico { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Tipo")]
        [Column("TIPO")]
        public int? Tipo { get; set; }

        [DisplayName("TipoPropriedade")]
        [Column("TIPOPROPRIEDADE")]
        public int? TipoPropriedade { get; set; }

        [DisplayName("Marca")]
        [Column("MARCA")]
        public string Marca { get; set; }

        [DisplayName("Modelo")]
        [Column("MODELO")]
        public string Modelo { get; set; }

        [DisplayName("Ano")]
        [Column("ANO")]
        public int? Ano { get; set; }

        [DisplayName("NumeroSerie")]
        [Column("NUMEROSERIE")]
        public string NumeroSerie { get; set; }

        [DisplayName("DataGarantia")]
        [Column("DATAGARANTIA")]
        public DateTime? DataGarantia { get; set; }

        [DisplayName("Apolice")]
        [Column("APOLICE")]
        public string Apolice { get; set; }

        [DisplayName("DataApolice")]
        [Column("DATAAPOLICE")]
        public DateTime? DataApolice { get; set; }

        [DisplayName("ValorSegurado")]
        [Column("VALORSEGURADO")]
        public decimal? ValorSegurado { get; set; }

        [DisplayName("IdLocalizacao")]
        [Column("IDLOCALIZACAO")]
        public int? IdLocalizacao { get; set; }

        [DisplayName("Id Funcionário")]
        [Column("IDFUNCIONARIO")]
        public int? IdFuncionario { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        [DisplayName("Código Barras")]
        [Column("CODIGOBARRAS")]
        public string CodigoBarras { get; set; }

        [DisplayName("AtivoNaoLocalizado")]
        [Column("ATIVONAOLOCALIZADO")]
        public bool AtivoNaoLocalizado { get; set; }

        [DisplayName("IdAtivoEstrutura")]
        [Column("IDATIVOESTRUTURA")]
        public int? IdAtivoEstrutura { get; set; }

        [DisplayName("CreditoICMS")]
        [Column("CREDITOICMS")]
        public bool? CreditoICMS { get; set; }

        [DisplayName("CreditoPisCofins")]
        [Column("CREDITOPISCOFINS")]
        public bool? CreditoPisCofins { get; set; }

        [DisplayName("ParcelasCredito")]
        [Column("PARCELASCREDITO")]
        public int? ParcelasCredito { get; set; }
    }
}
