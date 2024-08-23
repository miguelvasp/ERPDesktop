using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("LOGS", Schema = "DBO")]
    public class Log
    {
        [Key]
        [Column("LOGID")]
        public int LogId { get; set; }

        [Display(Name = "Date")]
        [Column("LOGDATE")]
        public DateTime LogDate { get; set; }

        [Column("LOGFORM")]
        public string LogForm { get; set; }

        [Display(Name = "User name")]
        [Column("SAMID")]
        public string SamId { get; set; }

        [Display(Name = "Type")]
        [Column("TYPE")]
        public string Type { get; set; }

        [Display(Name = "Key value")]
        [Column("KEYVALUE")]
        public string KeyValue { get; set; }

        [Display(Name = "MasterKey")]
        [Column("MASTERKEY")]
        public string MasterKey { get; set; }

        public virtual ICollection<LogItem> Logitens { get; set; }
    }
}