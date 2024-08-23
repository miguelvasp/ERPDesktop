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
    [Table("TARGETFIELDS", Schema = "DBO")]
    public class TargetFields
    {

        [Key]
        [Column("IDTARGET")]
        public int IdTarget { get; set; }

        [DisplayName("Table Name")]
        [Column("TABLENAME")]
        public string TableName { get; set; }

        [DisplayName("Field Name")]
        [Column("FIELDNAME")]
        public string FieldName { get; set; }
    }
}
