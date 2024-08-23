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
    public class ClienteEnderecoDAL : IRepository<ClienteEndereco>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ClienteEnderecoDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<ClienteEndereco> Get()
        {
            var tb = db.ClienteEndereco.ToList();
            return tb.ToList();
        }

        public ClienteEndereco GetByID(int id)
        {
            return db.ClienteEndereco.Find(id);
        }

        public void Insert(ClienteEndereco entidade)
        {
            db.ClienteEndereco.Add(entidade);
        }

        public void Delete(int id)
        {
            ClienteEndereco tb = db.ClienteEndereco.Find(id);
            db.ClienteEndereco.Remove(tb);
        }

        public void Update(ClienteEndereco entidade)
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
