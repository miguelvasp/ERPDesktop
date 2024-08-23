
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("REPORTCUBO", Schema = "DBO")]
    public class ReportCubo
    {
        [Key]
        [DisplayName("IdReportCubo")]
        [Column("IDREPORTCUBO")]
        public int IdReportCubo { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
        [DisplayName("NomeView")]
        [Column("NOMEVIEW")]
        public string NomeView { get; set; }

        public virtual ICollection<ReportCuboFields> Campos { get; set; }
 
    }
}
