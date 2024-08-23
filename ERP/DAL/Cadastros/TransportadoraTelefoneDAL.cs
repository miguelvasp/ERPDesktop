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
    public class TransportadoraTelefoneDAL : IRepository<TransportadoraTelefone>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public TransportadoraTelefoneDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<TransportadoraTelefone> Get()
        {
            var tb = db.TransportadoraTelefone.ToList();
            return tb.ToList();
        }

        public TransportadoraTelefone GetByID(int id)
        {
            return db.TransportadoraTelefone.Find(id);
        }

        public void Insert(TransportadoraTelefone entidade)
        {
            db.TransportadoraTelefone.Add(entidade);
        }

        public void Delete(int id)
        {
            TransportadoraTelefone tb = db.TransportadoraTelefone.Find(id);
            db.TransportadoraTelefone.Remove(tb);
        }

        public void Update(TransportadoraTelefone entidade)
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
