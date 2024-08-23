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
    public class TargetFieldsDAL : IRepository<TargetFields>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public TargetFieldsDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<TargetFields> Get()
        {
            var tb = db.TargetFields.ToList();
            return tb.ToList();
        }

        public TargetFields GetByID(int id)
        {
            return db.TargetFields.Find(id);
        }

        public void Insert(TargetFields entidade)
        {
            db.TargetFields.Add(entidade);
        }

        public void Delete(int id)
        {
            TargetFields tb = db.TargetFields.Find(id);
            db.TargetFields.Remove(tb);
        }

        public void Update(TargetFields entidade)
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
