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
    public class MoedaCotacaoDAL : IRepository<MoedaCotacao>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public MoedaCotacaoDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<MoedaCotacao> Get()
        {
            var tb = db.MoedaCotacao.ToList();
            return tb.ToList();
        }

        public MoedaCotacao GetByID(int id)
        {
            return db.MoedaCotacao.Find(id);
        }

        public void Insert(MoedaCotacao entidade)
        {
            db.MoedaCotacao.Add(entidade);
        }

        public void Delete(int id)
        {
            MoedaCotacao tb = db.MoedaCotacao.Find(id);
            db.MoedaCotacao.Remove(tb);
        }

        public void Update(MoedaCotacao entidade)
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
