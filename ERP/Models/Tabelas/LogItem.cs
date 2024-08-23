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
    [Table("LOGITEMS", Schema = "DBO")]
    public class LogItem
    {
        [Key]
        [Column("ITEMID")]
        public int ItemId { get; set; }

        [Column("LOGID")]
        public int LogId { get; set; }
        public virtual Log Log { get; set; }

        [Display(Name = "Field")]
        [Column("LGIFIELD")]
        public string LgiField { get; set; }

        [Display(Name = "Old value")]
        [Column("LGIOLDVALUE")]
        [StringLength(int.MaxValue)]
        public string LgiOldValue { get; set; }

        [Display(Name = "New Value")]
        [Column("LGINEWVALUE")]
        [StringLength(int.MaxValue)]
        public string LgiNewValue { get; set; }
    }
}