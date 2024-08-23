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
    public class ContadorEnderecoDAL : IRepository<ContadorEndereco>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ContadorEnderecoDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<ContadorEndereco> Get()
        {
            var tb = db.ContadorEndereco.ToList();
            return tb.ToList();
        }

        public ContadorEndereco GetByID(int id)
        {
            return db.ContadorEndereco.Find(id);
        }

        public void Insert(ContadorEndereco entidade)
        {
            db.ContadorEndereco.Add(entidade);
        }

        public void Delete(int id)
        {
            ContadorEndereco tb = db.ContadorEndereco.Find(id);
            db.ContadorEndereco.Remove(tb);
        }

        public void Update(ContadorEndereco entidade)
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
