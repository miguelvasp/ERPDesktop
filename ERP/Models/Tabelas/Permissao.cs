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
    [Table("PERMISSAO", Schema = "DBO")]
    public class Permissao
    {
        [Key]
        [DisplayName("Id Permissão")]
        [Column("IDPERMISSAO")]
        public int IdPermissao { get; set; }

        [DisplayName("Id Usuário")]
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        [DisplayName("Id Perfil")]
        [Column("IDPERFIL")]
        public int IdPerfil { get; set; }
        public virtual Perfil Perfil { get; set; }

        [DisplayName("Id Programa")]
        [Column("IDPROGRAMA")]
        public int IdPrograma { get; set; }
        public virtual Programa Programa { get; set; }

        [DisplayName("Visualizar")]
        [Column("VISUALIZAR")]
        public bool Visualizar { get; set; }

        [DisplayName("Incluir")]
        [Column("INCLUIR")]
        public bool Incluir { get; set; }

        [DisplayName("Excluir")]
        [Column("EXCLUIR")]
        public bool Excluir { get; set; }

        [DisplayName("Alterar")]
        [Column("ALTERAR")]
        public bool Alterar { get; set; }
    }
}
