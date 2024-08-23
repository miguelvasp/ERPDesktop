
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("REPORTHEADER", Schema = "DBO")]
    public class ReportHeader
    {
        [Key]
        [DisplayName("IdReportHeader")]
        [Column("IDREPORTHEADER")]
        public int IdReportHeader { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
        [DisplayName("IdRepCubo")]
        [Column("IDREPCUBO")]
        public int? IdRepCubo { get; set; }
 
        [DisplayName("Usuarios")]
        [Column("USUARIOS")]
        public string Usuarios { get; set; }
 
    }
}
