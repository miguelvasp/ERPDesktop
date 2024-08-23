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
    public class MovimentoEstoqueDAL : IRepository<MovimentoEstoque>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public MovimentoEstoqueDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<MovimentoEstoque> Get()
        {
            var tb = db.MovimentoEstoque.ToList();
            return tb.ToList();
        }

        public MovimentoEstoque GetByID(int id)
        {
            return db.MovimentoEstoque.Find(id);
        }

        public void Insert(MovimentoEstoque entidade)
        {
            db.MovimentoEstoque.Add(entidade);
        }

        public void Delete(int id)
        {
            MovimentoEstoque tb = db.MovimentoEstoque.Find(id);
            db.MovimentoEstoque.Remove(tb);
        }

        public void Update(MovimentoEstoque entidade)
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
