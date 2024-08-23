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
    [Table("MODULO", Schema = "DBO")]
    public class Modulo
    {
        [Key]
        [DisplayName("Id Módulo")]
        [Column("IDMODULO")]
        public int IdModulo { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        public virtual ICollection<PerfilModulo> PerfilModelo { get; set; }
        public virtual ICollection<ModuloPrograma> ModuloPrograma { get; set; }
    }
}
