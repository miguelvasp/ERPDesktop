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
    [Table("PERFILMODULO", Schema = "DBO")]
    public class PerfilModulo
    {
        [Key]
        [DisplayName("Id Perfil Módulo")]
        [Column("IDPERFILMODULO")]
        public int IdPerfilModulo { get; set; }

        [DisplayName("Id Perfil")]
        [Column("IDPERFIL")]
        public int IdPerfil { get; set; }
        public virtual Perfil Perfil { get; set; }

        [DisplayName("Id Módulo")]
        [Column("IDMODULO")]
        public int IdModulo { get; set; }
        public virtual Modulo Modulo { get; set; }
    }
}
