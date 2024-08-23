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
    public class ContadorTelefoneDAL : IRepository<ContadorTelefone>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ContadorTelefoneDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<ContadorTelefone> Get()
        {
            var tb = db.ContadorTelefone.ToList();
            return tb.ToList();
        }

        public ContadorTelefone GetByID(int id)
        {
            return db.ContadorTelefone.Find(id);
        }

        public void Insert(ContadorTelefone entidade)
        {
            db.ContadorTelefone.Add(entidade);
        }

        public void Delete(int id)
        {
            ContadorTelefone tb = db.ContadorTelefone.Find(id);
            db.ContadorTelefone.Remove(tb);
        }

        public void Update(ContadorTelefone entidade)
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

