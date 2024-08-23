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
    public class TransportadoraContatoDAL : IRepository<TransportadoraContato>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public TransportadoraContatoDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<TransportadoraContato> Get()
        {
            var tb = db.TransportadoraContato.ToList();
            return tb.ToList();
        }

        public TransportadoraContato GetByID(int id)
        {
            return db.TransportadoraContato.Find(id);
        }

        public void Insert(TransportadoraContato entidade)
        {
            db.TransportadoraContato.Add(entidade);
        }

        public void Delete(int id)
        {
            TransportadoraContato tb = db.TransportadoraContato.Find(id);
            db.TransportadoraContato.Remove(tb);
        }

        public void Update(TransportadoraContato entidade)
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
