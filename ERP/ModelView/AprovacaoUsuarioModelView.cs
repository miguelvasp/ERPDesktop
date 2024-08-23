using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class AprovacaoUsuarioModelView
    {
        //x.IdAprovacaoUsuario, x.Usuario.Perfil.Nome, x.Usuario.NomeCompleto
        public int? IdAprovacaoUsuario { get; set; }
        public string Nome { get; set; }
        public string NomeCompleto { get; set; }
    }
}
