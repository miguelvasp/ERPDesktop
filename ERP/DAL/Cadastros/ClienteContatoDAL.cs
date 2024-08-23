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
    public class ClienteContatoDAL : IRepository<ClienteContato>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ClienteContatoDAL()
        {
            
        }

        public IEnumerable<ClienteContato> Get()
        {
            var tb = db.ClienteContato.ToList();
            return tb.ToList();
        }

        public ClienteContato GetByID(int id)
        {
            return db.ClienteContato.Find(id);
        }

        public void Insert(ClienteContato entidade)
        {
            db.ClienteContato.Add(entidade);
        }

        public void Delete(int id)
        {
            ClienteContato tb = db.ClienteContato.Find(id);
            db.ClienteContato.Remove(tb);
        }

        public void Update(ClienteContato entidade)
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
