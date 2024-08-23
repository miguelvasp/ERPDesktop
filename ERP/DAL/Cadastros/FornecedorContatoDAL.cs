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
    public class FornecedorContatoDAL : IRepository<FornecedorContato>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public FornecedorContatoDAL()
        {
         

        }

        public IEnumerable<FornecedorContato> Get()
        {
            var tb = db.FornecedorContato.ToList();
            return tb.ToList();
        }

        public FornecedorContato GetByID(int id)
        {
            return db.FornecedorContato.Find(id);
        }

        public void Insert(FornecedorContato entidade)
        {
            db.FornecedorContato.Add(entidade);
        }

        public void Delete(int id)
        {
            FornecedorContato tb = db.FornecedorContato.Find(id);
            db.FornecedorContato.Remove(tb);
        }

        public void Update(FornecedorContato entidade)
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
