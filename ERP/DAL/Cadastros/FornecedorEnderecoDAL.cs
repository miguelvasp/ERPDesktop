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
    public class FornecedorEnderecoDAL : IRepository<FornecedorEndereco>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public FornecedorEnderecoDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<FornecedorEndereco> Get()
        {
            var tb = db.FornecedorEndereco.ToList();
            return tb.ToList();
        }

        public FornecedorEndereco GetByID(int id)
        {
            return db.FornecedorEndereco.Find(id);
        }

        public void Insert(FornecedorEndereco entidade)
        {
            db.FornecedorEndereco.Add(entidade);
        }

        public void Delete(int id)
        {
            FornecedorEndereco tb = db.FornecedorEndereco.Find(id);
            db.FornecedorEndereco.Remove(tb);
        }

        public void Update(FornecedorEndereco entidade)
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
