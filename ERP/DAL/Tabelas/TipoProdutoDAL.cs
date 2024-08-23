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
    public class TipoProdutoDAL : IRepository<TipoProduto>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public TipoProdutoDAL()
        {
        }

        public IEnumerable<TipoProduto> Get()
        {
            var tp = db.TipoProduto.OrderBy(x => x.Descricao).ToList();
            return tp.ToList();
        }

        public TipoProduto GetByID(int id)
        {
            return db.TipoProduto.Find(id);
        }

        public void Insert(TipoProduto entidade)
        {
            db.TipoProduto.Add(entidade);
        }

        public void Delete(int id)
        {
            TipoProduto tp = db.TipoProduto.Find(id);
            db.TipoProduto.Remove(tp);
        }

        public void Update(TipoProduto entidade)
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
