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
    public class ClienteTelefoneDAL : IRepository<ClienteTelefone>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ClienteTelefoneDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<ClienteTelefone> Get()
        {
            var tb = db.ClienteTelefone.ToList();
            return tb.ToList();
        }

        public ClienteTelefone GetByID(int id)
        {
            return db.ClienteTelefone.Find(id);
        }

        public void Insert(ClienteTelefone entidade)
        {
            db.ClienteTelefone.Add(entidade);
        }

        public void Delete(int id)
        {
            ClienteTelefone tb = db.ClienteTelefone.Find(id);
            db.ClienteTelefone.Remove(tb);
        }

        public void Update(ClienteTelefone entidade)
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
