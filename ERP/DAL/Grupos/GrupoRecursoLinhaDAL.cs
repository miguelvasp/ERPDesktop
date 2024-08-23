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
    public class GrupoRecursoLinhaDAL : IRepository<GrupoRecursoLinha>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public GrupoRecursoLinhaDAL()
        {
        }

        public List<GrupoRecursoLinhaModelView> GetByGrupoId(int id)
        {
            List<GrupoRecursoLinhaModelView> lista = (from g in db.GrupoRecursoLinha
                                                      join r in db.Recursos on g.IdRecurso equals r.IdRecurso
                                                      where g.IdGrupoRecurso == id
                                                      select new GrupoRecursoLinhaModelView
                                                      {
                                                          Id = g.IdGrupoRecursoLinha,
                                                          Recurso = r.Descricao,
                                                          Descricao = g.Descricao
                                                      }).ToList();
            return lista;
        }

        public IEnumerable<GrupoRecursoLinha> Get()
        {
            var tb = db.GrupoRecursoLinha.ToList();
            return tb.ToList();
        }

        public GrupoRecursoLinha GetByID(int id)
        {
            return db.GrupoRecursoLinha.Find(id);
        }

        public void Insert(GrupoRecursoLinha entidade)
        {
            db.GrupoRecursoLinha.Add(entidade);
        }

        public void Delete(int id)
        {
            GrupoRecursoLinha tb = db.GrupoRecursoLinha.Find(id);
            db.GrupoRecursoLinha.Remove(tb);
        }

        public void Update(GrupoRecursoLinha entidade)
        {
            db.Entry(entidade).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
