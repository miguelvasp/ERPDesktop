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
    public class TipoEnderecoDAL : IRepository<TipoEndereco>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public TipoEnderecoDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<TipoEndereco> Get()
        {
            var te = db.TipoEndereco.ToList();
            return te.ToList();
        }

        public TipoEndereco GetByID(int id)
        {
            return db.TipoEndereco.Find(id);
        }

        public void Insert(TipoEndereco entidade)
        {
            db.TipoEndereco.Add(entidade);
        }

        public void Delete(int id)
        {
            TipoEndereco te = db.TipoEndereco.Find(id);
            db.TipoEndereco.Remove(te);
        }

        public void Update(TipoEndereco entidade)
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
