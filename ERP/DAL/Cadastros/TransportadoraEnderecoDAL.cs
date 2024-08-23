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
    public class TransportadoraEnderecoDAL : IRepository<TransportadoraEndereco>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public TransportadoraEnderecoDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<TransportadoraEndereco> Get()
        {
            var tb = db.TransportadoraEndereco.ToList();
            return tb.ToList();
        }

        public TransportadoraEndereco GetByID(int id)
        {
            return db.TransportadoraEndereco.Find(id);
        }

        public void Insert(TransportadoraEndereco entidade)
        {
            db.TransportadoraEndereco.Add(entidade);
        }

        public void Delete(int id)
        {
            TransportadoraEndereco tb = db.TransportadoraEndereco.Find(id);
            db.TransportadoraEndereco.Remove(tb);
        }

        public void Update(TransportadoraEndereco entidade)
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
