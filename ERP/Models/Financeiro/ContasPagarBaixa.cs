using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("CONTASPAGARBAIXA", Schema = "DBO")]
    public class ContasPagarBaixa
    {
        [Key]
        [DisplayName("IdContasPagarBaixa")]
        [Column("IDCONTASPAGARBAIXA")]
        public int IdContasPagarBaixa { get; set; }
 
        [DisplayName("IdContasPagarAberto")]
        [Column("IDCONTASPAGARABERTO")]
        public int? IdContasPagarAberto { get; set; }
 
        //[DisplayName("TipoTransacao")]
        //[Column("TIPOTRANSACAO")]
        //public int? TipoTransacao { get; set; }
 
        [DisplayName("DataPagamento")]
        [Column("DATAPAGAMENTO")]
        public DateTime? DataPagamento { get; set; }
 
        [DisplayName("Documento")]
        [Column("DOCUMENTO")]
        public string Documento { get; set; }

        [DisplayName("Observação")]
        [Column("OBSERVACAO")]
        public string Observacao { get; set; }

 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }
 
        [DisplayName("NumeroCheque")]
        [Column("NUMEROCHEQUE")]
        public string NumeroCheque { get; set; }
 
        [DisplayName("IdContaBancaria")]
        [Column("IDCONTABANCARIA")]
        public int? IdContaBancaria { get; set; }
 
        [DisplayName("Liquidada")]
        [Column("LIQUIDADA")]
        public bool Liquidada { get; set; }

        [DisplayName("IdMetodoPagamento")]
        [Column("IDMETODOPAGAMENTO")]
        public int? IdMetodoPagamento { get; set; }

        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }

        [Column("IDCLIENTE")]
        public int? IdCliente { get; set; }

        [Column("IDCONTACONTABIL")]
        public int? IdContaContabil { get; set; }

        [Column("IDCHEQUE")]
        public int? IdCheque { get; set; }

        [Column("CHEQUE")]
        public int? Cheque { get; set; }
    }
}
