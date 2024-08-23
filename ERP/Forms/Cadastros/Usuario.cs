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
    [Table("USUARIO", Schema = "DBO")]
    public class Usuario
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }

        [DisplayName("Id Perfil")]
        [Column("IDPERFIL")]
        public int IdPerfil { get; set; }
        public virtual Perfil Perfil { get; set; }

        [DisplayName("Nome Completo")]
        [Column("NOMECOMPLETO")]
        public string NomeCompleto { get; set; }

        [DisplayName("Login")]
        [Column("LOGIN")]
        public string Login { get; set; }

        [DisplayName("Senha")]
        [Column("SENHA")]
        public string Senha { get; set; }

        [DisplayName("E-Mail")]
        [Column("EMAIL")]
        public string EMail { get; set; }

        [DisplayName("Ativo")]
        [Column("ATIVO")]
        public bool Ativo { get; set; }

        public virtual ICollection<AjusteEstoque> AjusteEstoque { get; set; }
        public virtual ICollection<Permissao> Permissao { get; set; }
        
    }
}
