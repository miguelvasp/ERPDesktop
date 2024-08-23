using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class GrupoRecursosDAL : IRepository<GrupoRecursos>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public GrupoRecursosDAL()
        {
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.GrupoRecursos
                                     select new ComboItem
                                     {
                                         iValue = c.IdGrupoRecursos,
                                         Text = c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public IEnumerable<GrupoRecursos> Get()
        {
            var tb = db.GrupoRecursos.ToList();
            return tb.ToList();
        }

        public GrupoRecursos GetByID(int id)
        {
            return db.GrupoRecursos.Find(id);
        }

        public void Insert(GrupoRecursos entidade)
        {
            db.GrupoRecursos.Add(entidade);
        }

        public void Delete(int id)
        {
            GrupoRecursos tb = db.GrupoRecursos.Find(id);
            db.GrupoRecursos.Remove(tb);
        }

        public void Update(GrupoRecursos entidade)
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
