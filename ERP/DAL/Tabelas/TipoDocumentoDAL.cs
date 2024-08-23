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
    public class TipoDocumentoDAL : IRepository<TipoDocumento>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public TipoDocumentoDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<TipoDocumento> Get()
        {
            var td = db.TipoDocumento.ToList();
            return td.ToList();
        }

        public TipoDocumento GetByID(int id)
        {
            return db.TipoDocumento.Find(id);
        }

        public void Insert(TipoDocumento entidade)
        {
            db.TipoDocumento.Add(entidade);
        }

        public void Delete(int id)
        {
            TipoDocumento td = db.TipoDocumento.Find(id);
            db.TipoDocumento.Remove(td);
        }

        public void Update(TipoDocumento entidade)
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
