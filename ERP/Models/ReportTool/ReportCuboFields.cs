
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("REPORTCUBOFIELDS", Schema = "DBO")]
    public class ReportCuboFields
    {
        [Key]
        [DisplayName("IdReportCuboFields")]
        [Column("IDREPORTCUBOFIELDS")]
        public int IdReportCuboFields { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
        [DisplayName("Titulo")]
        [Column("TITULO")]
        public string Titulo { get; set; }
 
        [DisplayName("TipoCampo")]
        [Column("TIPOCAMPO")]
        public string TipoCampo { get; set; }
 
        [DisplayName("TipoFiltro")]
        [Column("TIPOFILTRO")]
        public string TipoFiltro { get; set; }
 
        [DisplayName("IdReportCubo")]
        [Column("IDREPORTCUBO")]
        public int? IdReportCubo { get; set; }
 
    }
}
