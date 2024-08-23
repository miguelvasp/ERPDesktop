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
    public class VendedorMetasDAL : IRepository<VendedorMetas>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public VendedorMetasDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<VendedorMetas> Get()
        {
            var tb = db.VendedorMetas.ToList();
            return tb.ToList();
        }

        public VendedorMetas GetByID(int id)
        {
            return db.VendedorMetas.Find(id);
        }

        public void Insert(VendedorMetas entidade)
        {
            db.VendedorMetas.Add(entidade);
        }

        public void Delete(int id)
        {
            VendedorMetas tb = db.VendedorMetas.Find(id);
            db.VendedorMetas.Remove(tb);
        }

        public void Update(VendedorMetas entidade)
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
