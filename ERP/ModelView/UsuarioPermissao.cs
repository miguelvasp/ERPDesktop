using ERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class UsuarioPermissao
    {
        [Key]
        [DisplayName("Id Permissao")]
        public int IdPermissao { get; set; }

        [DisplayName("Id Usuário")]
        public int IdUsuario { get; set; }

        [DisplayName("Usuário")]
        public string NomeUsuario { get; set; }

        [DisplayName("Id Perfil")]
        public int IdPerfil { get; set; }

        [DisplayName("Perfil")]
        public string DescricaoPerfil { get; set; }

        [DisplayName("Id Programa")]
        public int IdPrograma { get; set; }

        [DisplayName("Programa")]
        public string DescricaoPrograma { get; set; }

        [DisplayName("Permite Manutenção")]
        public bool PermiteManutencao { get; set; }
        
        [DisplayName("Visualizar")]
        public bool Visual { get; set; }

        [DisplayName("Incluir")]
        public bool Incluir { get; set; }

        [DisplayName("Excluir")]
        public bool Excluir { get; set; }

        [DisplayName("Alterar")]
        public bool Alterar { get; set; }
    }
}
