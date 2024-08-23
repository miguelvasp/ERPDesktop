
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("TEXTOTRANSACAOSUBS", Schema = "DBO")]
    public class TextoTransacaoSubs
    {
        [Key]
        [DisplayName("IdTextoTransacaoSubs")]
        [Column("IDTEXTOTRANSACAOSUBS")]
        public int? IdTextoTransacaoSubs { get; set; }
 
        [DisplayName("Simbolo")]
        [Column("SIMBOLO")]
        public string Simbolo { get; set; }
 
        [DisplayName("Texto")]
        [Column("TEXTO")]
        public string Texto { get; set; }
 
    }
}
