using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ERP.DAL
{
    public class ContatoTelefoneDAL : IRepository<ContatoTelefone>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ContatoTelefoneDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<ContatoTelefone> Get()
        {
            var tb = db.ContatoTelefone.ToList();
            return tb.ToList();
        }

        public ContatoTelefone GetByID(int id)
        {
            return db.ContatoTelefone.Find(id);
        }

        public void Insert(ContatoTelefone entidade)
        {
            db.ContatoTelefone.Add(entidade);
        }

        public void Delete(int id)
        {
            ContatoTelefone tb = db.ContatoTelefone.Find(id);
            db.ContatoTelefone.Remove(tb);
        }

        public void Update(ContatoTelefone entidade)
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
