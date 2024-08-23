using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using ERP.ModelView;

namespace ERP.DAL
{
    public class RoteiroOperacaoRecursosDAL : Repository<RoteiroOperacaoRecursos>
    {
        public List<RoteiroOperacaoRecursoModelView> GetByLinhaId(int id)
        {
            List<RoteiroOperacaoRecursoModelView> lista = (from rr in db.RoteiroOperacaoRecursos
                                                           where rr.IdRoteiroOperacaoLinha == id

                                                           from r in db.Recursos
                                                           .Where(x => x.IdRecurso == rr.IdRecurso)
                                                           .DefaultIfEmpty()

                                                           from c in db.CapacidadeRecursos
                                                           .Where(x => x.IdCapacidadeRecursos == rr.IdCapacidadeRecurso)
                                                           .DefaultIfEmpty()

                                                           from g in db.GrupoRecursos
                                                           .Where(x => x.IdGrupoRecursos == rr.IdGrupoRecurso)
                                                           .DefaultIfEmpty()

                                                           select new RoteiroOperacaoRecursoModelView
                                                           {
                                                               Id = rr.IdRoteiroOperacaoRecurso,
                                                               Tipo = rr.Tipo == null ? "" :
                                                                      rr.Tipo == 1 ? "Recurso" :
                                                                      rr.Tipo == 2 ? "Capacidade" :
                                                                      rr.Tipo == 3 ? "Grupo Recursos" :
                                                                      rr.Tipo == 4 ? "Recurso" : "",
                                                               Recurso = r.Descricao,
                                                               CapacidadeRecurso = c.Descricao,
                                                               GrupoRecurso = g.Descricao
                                                           }).ToList();
            return lista;
        }
    }
}
