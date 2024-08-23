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
    public class FornecedorContaBancariaDAL : IRepository<FornecedorContaBancaria>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public FornecedorContaBancariaDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<FornecedorContaBancaria> Get()
        {
            var tb = db.FornecedorContaBancaria.ToList();
            return tb.ToList();
        }

        public FornecedorContaBancaria GetByID(int id)
        {
            return db.FornecedorContaBancaria.Find(id);
        }

        public void Insert(FornecedorContaBancaria entidade)
        {
            db.FornecedorContaBancaria.Add(entidade);
        }

        public void Delete(int id)
        {
            FornecedorContaBancaria tb = db.FornecedorContaBancaria.Find(id);
            db.FornecedorContaBancaria.Remove(tb);
        }

        public void Update(FornecedorContaBancaria entidade)
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
