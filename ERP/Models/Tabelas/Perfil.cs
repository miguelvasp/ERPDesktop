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
    [Table("PERFIL", Schema = "DBO")]
    public class Perfil
    {
        [Key]
        [DisplayName("Id Perfil")]
        [Column("IDPERFIL")]
        public int IdPerfil { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Ativo")]
        [Column("ATIVO")]
        public bool Ativo { get; set; }

        public virtual ICollection<PerfilModulo> PerfilModulo { get; set; }
        public virtual ICollection<Permissao> Permissao { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
