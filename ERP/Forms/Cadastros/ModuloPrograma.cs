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
    [Table("MODULOPROGRAMA", Schema = "DBO")]
    public class ModuloPrograma
    {
        [Key]
        [DisplayName("Id Módulo Programa")]
        [Column("IDMODULOPROGRAMA")]
        public int IdModuloPrograma { get; set; }

        [DisplayName("Id Módulo")]
        [Column("IDMODULO")]
        public int IdModulo { get; set; }
        public virtual Modulo Modulo { get; set; }

        [DisplayName("Id Programa")]
        [Column("IDPROGRAMA")]
        public int IdPrograma { get; set; }
        public virtual Programa Programa { get; set; }
    }
}
