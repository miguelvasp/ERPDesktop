using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("COMISSAOCONTACORRENTE", Schema = "DBO")]
    public class ComissaoContaCorrente
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCOMISSAOCONTACORRENTE")]
        public int IdComissaoContaCorrente { get; set; }

        [DisplayName("Id Vendedor")]
        [Column("IDVENDEDOR")]
        public int IdVendedor { get; set; }

        [DisplayName("Id Nota Fiscal")]
        [Column("IDNOTAFISCAL")]
        public int? IdNotaFiscal { get; set; }

        [DisplayName("Data Nota Fiscal")]
        [Column("DATANOTAFISCAL")]
        public DateTime? DataNotaFiscal { get; set; }

        [DisplayName("Comissão Percentual")]
        [Column("COMISSAOPERCENTUAL")]
        public decimal ComissaoPercentual { get; set; }

        [DisplayName("Comissão")]
        [Column("COMISSAO")]
        public decimal Comissao { get; set; }

        [DisplayName("Valor a Pagar")]
        [Column("VALORAPAGAR")]
        public decimal ValorAPagar { get; set; }

        [DisplayName("Acréscimo")]
        [Column("ACRESCIMO")]
        public decimal? Acrescimo { get; set; }

        [DisplayName("Valor Pago")]
        [Column("VALORPAGO")]
        public decimal? ValorPago { get; set; }

        [DisplayName("Tipo Comissão")]
        [Column("TIPOCOMISSAO")]
        public int TipoComissao { get; set; }

        [DisplayName("Observação")]
        [Column("OBSERVACAO")]
        public string Observacao { get; set; }

        [Column("TIPOLANCAMENTO")]
        public int? TipoLancamento { get; set; }

        [Column("IDTELEVENDAS")]
        public int? IdTeleVendas { get; set; }

        [Column("IDCONTASPAGAR")]
        public int? IdContasPagar { get; set; }
    }
}
