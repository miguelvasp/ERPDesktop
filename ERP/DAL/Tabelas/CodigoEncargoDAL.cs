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
    public class CodigoEncargoDAL : IRepository<CodigoEncargo>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public CodigoEncargoDAL()
        {
            
        }

        public IEnumerable<CodigoEncargo> Get()
        {
            var ce = db.CodigoEncargo.ToList();
            return ce.ToList();
        }

        public CodigoEncargo GetByID(int id)
        {
            return db.CodigoEncargo.Find(id);
        }

        public List<CodigoEncargo> getByParams()
        {
            List<CodigoEncargo> cm = new List<CodigoEncargo>();
            cm = (from p in db.CodigoEncargo 
                  select p).OrderBy(o => o.Nome).ToList();

            return cm;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from cm in db.CodigoEncargo
                                     select new ComboItem
                                     {
                                         iValue = cm.IdCodigoEncargo,
                                         Text = cm.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(CodigoEncargo entidade)
        {
            db.CodigoEncargo.Add(entidade);
        }

        public void Delete(int id)
        {
            CodigoEncargo ce = db.CodigoEncargo.Find(id);
            db.CodigoEncargo.Remove(ce);
        }

        public void Update(CodigoEncargo entidade)
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
