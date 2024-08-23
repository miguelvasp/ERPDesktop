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
    public class FornecedorTelefoneDAL : IRepository<FornecedorTelefone>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public FornecedorTelefoneDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<FornecedorTelefone> Get()
        {
            var tb = db.FornecedorTelefone.ToList();
            return tb.ToList();
        }

        public FornecedorTelefone GetByID(int id)
        {
            return db.FornecedorTelefone.Find(id);
        }

        public void Insert(FornecedorTelefone entidade)
        {
            db.FornecedorTelefone.Add(entidade);
        }

        public void Delete(int id)
        {
            FornecedorTelefone tb = db.FornecedorTelefone.Find(id);
            db.FornecedorTelefone.Remove(tb);
        }

        public void Update(FornecedorTelefone entidade)
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
