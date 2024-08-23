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
    public class TipoTelefoneDAL : IRepository<TipoTelefone>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public TipoTelefoneDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<TipoTelefone> Get()
        {
            var tt = db.TipoTelefone.ToList();
            return tt.ToList();
        }

        public TipoTelefone GetByID(int id)
        {
            return db.TipoTelefone.Find(id);
        }

        public void Insert(TipoTelefone entidade)
        {
            db.TipoTelefone.Add(entidade);
        }

        public void Delete(int id)
        {
            TipoTelefone tt = db.TipoTelefone.Find(id);
            db.TipoTelefone.Remove(tt);
        }

        public void Update(TipoTelefone entidade)
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
