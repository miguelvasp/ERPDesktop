using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("DIARIOBOM", Schema = "DBO")]
    public class DiarioBOM
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDDIARIOBOM")]
        public int IdDiarioBom { get; set; }

        [DisplayName("Tipo Diário")]
        [Column("TIPODIARIO")]
        public int? TipoDiario { get; set; }

        [DisplayName("Nome Diário")]
        [Column("NOMEDIARIO")]
        public string NomeDiario { get; set; }

        [DisplayName("Id Ordem Produção")]
        [Column("IDORDEMPRODUCAO")]
        public int? IdOrdemProducao { get; set; }

        [DisplayName("AceitaErro")]
        [Column("ACEITAERRO")]
        public bool AceitaErro { get; set; }

        [DisplayName("AguardandoCriacao")]
        [Column("AGUARDANDOCRIACAO")]
        public bool AguardandoCriacao { get; set; }

        [DisplayName("ConsumoAutomaticoBOM")]
        [Column("CONSUMOAUTOMATICOBOM")]
        public bool ConsumoAutomaticoBOM { get; set; }

        [DisplayName("Lancado")]
        [Column("LANCADO")]
        public bool Lancado { get; set; }

        [DisplayName("Data Lançamento")]
        [Column("DATALANCAMENTO")]
        public DateTime? DataLancamento { get; set; }

        [DisplayName("IdSequenciaComprovante")]
        [Column("IDSEQUENCIACOMPROVANTE")]
        public int? IdSequenciaComprovante { get; set; }

        [DisplayName("IdSequenciaDiario")]
        [Column("IDSEQUENCIADIARIO")]
        public int? IdSequenciaDiario { get; set; }
    }
}
