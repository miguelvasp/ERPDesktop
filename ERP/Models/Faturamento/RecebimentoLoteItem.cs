
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("RECEBIMENTOLOTEITEM", Schema = "DBO")]
    public class RecebimentoLoteItem
    {
        [Key]
        [DisplayName("IdRecebimentoLoteItem")]
        [Column("IDRECEBIMENTOLOTEITEM")]
        public int IdRecebimentoLoteItem { get; set; }
 
        [DisplayName("IdRecebimentoLote")]
        [Column("IDRECEBIMENTOLOTE")]
        public int? IdRecebimentoLote { get; set; }
 
        [DisplayName("IdContasreceberAberto")]
        [Column("IDCONTASRECEBERRABERTO")]
        public int? IdContasReceberAberto { get; set; }
 
        [DisplayName("IdContasreceberBaixa")]
        [Column("IDCONTASRECEBERBAIXA")]
        public int? IdContasReceberBaixa { get; set; }
 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }
 
        [DisplayName("StatusBaixa")]
        [Column("STATUSBAIXA")]
        public int? StatusBaixa { get; set; }
 
    }
}
