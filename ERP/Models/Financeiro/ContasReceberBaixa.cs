
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CONTASRECEBERBAIXA", Schema = "DBO")]
    public class ContasReceberBaixa
    {
        [Key]
        [DisplayName("IdContasReceberBaixa")]
        [Column("IDCONTASRECEBERBAIXA")]
        public int IdContasReceberBaixa { get; set; }
 
        [DisplayName("IdContasReceberAberto")]
        [Column("IDCONTASRECEBERABERTO")]
        public int? IdContasReceberAberto { get; set; }
 
        [DisplayName("TipoTransacao")]
        [Column("TIPOTRANSACAO")]
        public int? TipoTransacao { get; set; }
 
        [DisplayName("DataPagamento")]
        [Column("DATAPAGAMENTO")]
        public DateTime? DataPagamento { get; set; }
 
        [DisplayName("Documento")]
        [Column("DOCUMENTO")]
        public string Documento { get; set; }
 
        [DisplayName("Observacao")]
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

        [DisplayName("IdFornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }

        [DisplayName("IdCliente")]
        [Column("IDCLIENTE")]
        public int? IdCliente { get; set; }

        [DisplayName("IdContaContabil")]
        [Column("IDCONTACONTABIL")]
        public int? IdContaContabil { get; set; }

        [DisplayName("Cheque")]
        [Column("CHEQUE")]
        public int? Cheque { get; set; }

        [DisplayName("IdCheque")]
        [Column("IDCHEQUE")]
        public int? IdCheque { get; set; }

    }
}
