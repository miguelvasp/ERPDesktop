using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class ProgramaDAL : Repository<Programa>
    {
        public List<Programa> getByParams(string prtNome, string prtDescricao, string prtFormulario)
        {
            List<Programa> prg = new List<Programa>();
            prg = (from p in db.Programa
                   where p.Nome.Contains(prtNome) &&
                   (prtDescricao == "" || p.Descricao.Contains(prtDescricao)) &&
                   (prtFormulario == "" || p.Formulario.Contains(prtFormulario))
                   select p).OrderBy(o => o.Nome).ToList();

            return prg;
        }

        public List<Programa> GetByUserIdFavorito(int IdUsuario, List<string> lista)
        {
            var l = (from p in db.Programa
                     join pe in db.Permissao on p.IdPrograma equals pe.IdPrograma
                     where pe.IdUsuario == IdUsuario && (p.TipoPrograma == 1 || p.TipoPrograma == 3)
                     && !lista.Contains(p.Formulario)
                     select p).OrderBy(x => x.Nome).ToList();
            return l;
        }

        public List<Programa> GetByUserId(int IdUsuario)
        {
            var l = (from p in db.Programa
                     join pe in db.Permissao on p.IdPrograma equals pe.IdPrograma
                     where pe.IdUsuario == IdUsuario && (p.TipoPrograma == 1 || p.TipoPrograma == 3)
                     select p).OrderBy(x => x.Nome).ToList();
            return l;
        }
    }
}