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
    public class TempoDepreciacaoDAL: IRepository<TempoDepreciacao>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public TempoDepreciacaoDAL()
        {
        }

        public IEnumerable<TempoDepreciacao> Get()
        {
            var t = db.TempoDepreciacao.ToList();
            return t.ToList();
        }

        public TempoDepreciacao GetByID(int id)
        {
            return db.TempoDepreciacao.Find(id);
        }

        public List<TempoDepreciacao> getByParams(string prtGrupoAtivo)
        {
            List<TempoDepreciacao> td = new List<TempoDepreciacao>();
            td = (from t in db.TempoDepreciacao
                  where (prtGrupoAtivo == "" || t.GrupoAtivo.Descricao.Contains(prtGrupoAtivo))
                   select t).OrderBy(o => o.GrupoAtivo.Descricao).ToList();

            return td;
        }

        public void Insert(TempoDepreciacao entidade)
        {
            db.TempoDepreciacao.Add(entidade);
        }

        public void Delete(int id)
        {
            TempoDepreciacao t = db.TempoDepreciacao.Find(id);
            if (t != null)
            {
                db.TempoDepreciacao.Remove(t);
            }
        }

        public void Update(TempoDepreciacao entidade)
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