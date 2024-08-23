using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("RECEBIMENTOITEMLOTE", Schema = "DBO")]
    public class RecebimentoItemLote
    {
        [Key]
        [DisplayName("IdLote")]
        [Column("IDLOTE")]
        public int? IdLote { get; set; }

        [DisplayName("IdRecebimentoItem")]
        [Column("IDRECEBIMENTOITEM")]
        public int? IdRecebimentoItem { get; set; }

        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal? Quantidade { get; set; }

        [DisplayName("DataVencimento")]
        [Column("DATAVENCIMENTO")]
        public DateTime? DataVencimento { get; set; }

        [DisplayName("DataFabricacao")]
        [Column("DATAFABRICACAO")]
        public DateTime? DataFabricacao { get; set; }

        [DisplayName("DataAvisoPrateleira")]
        [Column("DATAAVISOPRATELEIRA")]
        public DateTime? DataAvisoPrateleira { get; set; }

        [DisplayName("DataValidade")]
        [Column("DATAVALIDADE")]
        public DateTime? DataValidade { get; set; }

        [DisplayName("LoteFornecedor")]
        [Column("LOTEFORNECEDOR")]
        public string LoteFornecedor { get; set; }

        [DisplayName("LoteInterno")]
        [Column("LOTEINTERNO")]
        public string LoteInterno { get; set; }

    }
}
