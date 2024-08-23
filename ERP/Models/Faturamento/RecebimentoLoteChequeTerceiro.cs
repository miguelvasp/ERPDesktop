
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("RECEBIMENTOLOTECHEQUETERCEIRO", Schema = "DBO")]
    public class RecebimentoLoteChequeTerceiro
    {
        [Key]
        [DisplayName("IdRecebimentoLoteChequeTerceiro")]
        [Column("IDRECEBIMENTOLOTECHEQUETERCEIRO")]
        public int? IdRecebimentoLoteChequeTerceiro { get; set; }
 
        [DisplayName("IdRecebimentoLote")]
        [Column("IDRECEBIMENTOLOTE")]
        public int? IdRecebimentoLote { get; set; }
 
        [DisplayName("IdChequeTerceiro")]
        [Column("IDCHEQUETERCEIRO")]
        public int? IdChequeTerceiro { get; set; }
 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }
 
    }
}
