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
    public class GrupoImpostoCodigosDAL : IRepository<GrupoImpostoCodigos>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public GrupoImpostoCodigosDAL( )
        {
             
        }

        public IEnumerable<GrupoImpostoCodigos> Get()
        {
            var tb = db.GrupoImpostoCodigos.ToList();
            return tb.ToList();
        }

        public GrupoImpostoCodigos GetByID(int id)
        {
            return db.GrupoImpostoCodigos.Find(id);
        }

        public List<GrupoImpostoCodigos> GetCodigosByGrupoImposto(int Id)
        {
            var lista = (from g in db.GrupoImpostoCodigos
                         join c in db.CodigoImposto on g.IdCodigoImposto equals c.IdCodigoImposto
                         where g.IdGrupoImposto == Id
                         select g).ToList();
            return lista;
        }

        public void Insert(GrupoImpostoCodigos entidade)
        {
            db.GrupoImpostoCodigos.Add(entidade);
        }

        public void Delete(int id)
        {
            GrupoImpostoCodigos tb = db.GrupoImpostoCodigos.Find(id);
            db.GrupoImpostoCodigos.Remove(tb);
        }

        public void Update(GrupoImpostoCodigos entidade)
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
