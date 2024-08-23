
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("TEXTOTRANSACAO", Schema = "DBO")]
    public class TextoTransacao
    {
        [Key]
        [DisplayName("IdTextoTransacao")]
        [Column("IDTEXTOTRANSACAO")]
        public int IdTextoTransacao { get; set; }
 
        [DisplayName("IdOrigemLancamento")]
        [Column("IDORIGEMLANCAMENTO")]
        public int? IdOrigemLancamento { get; set; }
        
        [DisplayName("Texto")]
        [Column("TEXTO")]
        public string Texto { get; set; }

        public virtual OrigemLancamento OrigemLancamento { get; set; }
 
    }
}
