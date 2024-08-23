
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("REPORTFIELDS", Schema = "DBO")]
    public class ReportFields
    {
        [Key]
        [DisplayName("IdReportFields")]
        [Column("IDREPORTFIELDS")]
        public int IdReportFields { get; set; }
 
        [DisplayName("IdReportCuboFields")]
        [Column("IDREPORTCUBOFIELDS")]
        public int? IdReportCuboFields { get; set; }
 
        [DisplayName("IdReportHeader")]
        [Column("IDREPORTHEADER")]
        public int? IdReportHeader { get; set; }
 
        [DisplayName("Agrupamento")]
        [Column("AGRUPAMENTO")]
        public bool Agrupamento { get; set; }
 
        [DisplayName("AgrupamentoOrdem")]
        [Column("AGRUPAMENTOORDEM")]
        public int? AgrupamentoOrdem { get; set; }
 
        [DisplayName("Filtro")]
        [Column("FILTRO")]
        public string Filtro { get; set; }
 
    }
}
