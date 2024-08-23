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
    [Table("RAMOATIVIDADE", Schema = "DBO")]
    public class RamoAtividade
    {
        [Key]
        [DisplayName("IdRamoAtividade")]
        [Column("IDRAMOATIVIDADE")]
        public int IdRamoAtividade { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
    }
}
