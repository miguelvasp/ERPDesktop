using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class vwTableRelations
    {
        [Key]
        public string TABLE_NAME { get; set; }
        public string FK_COLUMN_NAME { get; set; }
        public string REFERENCED_TABLE_NAME { get; set; }
        public string REFERENCED_COLUMN_NAME { get; set; }
    }
}