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
    public class UnidadeFederacaoDAL: IRepository<UnidadeFederacao>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public UnidadeFederacaoDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<UnidadeFederacao> Get()
        {
            var uf = db.UnidadeFederacao.OrderBy(o => o.UF).ToList();
            return uf.ToList();
        }

        public UnidadeFederacao GetByID(int id)
        {
            return db.UnidadeFederacao.Find(id);
        }

        public void Insert(UnidadeFederacao entidade)
        {
            db.UnidadeFederacao.Add(entidade);
        }

        public void Delete(int id)
        {
            UnidadeFederacao uf = db.UnidadeFederacao.Find(id);
            db.UnidadeFederacao.Remove(uf);
        }

        public void Update(UnidadeFederacao entidade)
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
