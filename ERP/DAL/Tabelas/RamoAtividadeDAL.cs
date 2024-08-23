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
    public class RamoAtividadeDAL: IRepository<RamoAtividade>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public RamoAtividadeDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<RamoAtividade> Get()
        {
            var f = db.RamoAtividade.ToList();
            return f.ToList();
        }

        public RamoAtividade GetByID(int id)
        {
            return db.RamoAtividade.Find(id);
        }

        public void Insert(RamoAtividade entidade)
        {
            db.RamoAtividade.Add(entidade);
        }

        public void Delete(int id)
        {
            RamoAtividade f = db.RamoAtividade.Find(id);
            db.RamoAtividade.Remove(f);
        }

        public void Update(RamoAtividade entidade)
        {
            db.Entry(entidade).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Save(string IdUsuarioCorrente)
        {
            db.SaveChanges(IdUsuarioCorrente);
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
