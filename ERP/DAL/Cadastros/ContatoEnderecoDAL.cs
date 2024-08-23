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
    public class ContatoEnderecoDAL : IRepository<ContatoEndereco>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ContatoEnderecoDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<ContatoEndereco> Get()
        {
            var tb = db.ContatoEndereco.ToList();
            return tb.ToList();
        }

        public ContatoEndereco GetByID(int id)
        {
            return db.ContatoEndereco.Find(id);
        }

        public void Insert(ContatoEndereco entidade)
        {
            db.ContatoEndereco.Add(entidade);
        }

        public void Delete(int id)
        {
            ContatoEndereco tb = db.ContatoEndereco.Find(id);
            db.ContatoEndereco.Remove(tb);
        }

        public void Update(ContatoEndereco entidade)
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
