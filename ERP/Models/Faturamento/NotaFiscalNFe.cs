
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("NOTAFISCALNFE", Schema = "DBO")]
    public class NotaFiscalNFe
    {
        [Key]
        [DisplayName("IdNotaFiscal")]
        [Column("IDNOTAFISCALNFe")]
        public int IdNotaFiscalNFe { get; set; }
 
        [DisplayName("NFeXML")]
        [Column("NFEXML")]
        public string NFeXML { get; set; }

        [DisplayName("IdNotaFiscal")]
        [Column("IDNOTAFISCAL")]
        public int IdNotaFiscal { get; set; }

    }
}
