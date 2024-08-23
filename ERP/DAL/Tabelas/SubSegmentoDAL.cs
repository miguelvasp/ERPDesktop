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
    public class SubSegmentoDAL : IRepository<SubSegmento>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public SubSegmentoDAL()
        {

        }

        public IEnumerable<SubSegmento> Get()
        {
            var seg = db.SubSegmento.ToList();
            return seg.ToList();
        }

        

        public SubSegmento GetByID(int id)
        {
            return db.SubSegmento.Find(id);
        }

        public IEnumerable<SubSegmento> GetByIDSegmento(int idSegmento)
        {
            return db.SubSegmento.Where(w => w.IdSegmento == idSegmento).ToList();
        }

        public List<SubSegmento> getByParams(string prtSegmento, string prtNome)
        {
            List<SubSegmento> subSegmento = new List<SubSegmento>();
            subSegmento = (from ss in db.SubSegmento
                           where ss.Segmento.Nome.Contains(prtSegmento) &&
                      (prtNome == "" || ss.Nome.Contains(prtNome))
                           select ss).OrderBy(o => o.Nome).ToList();

            return subSegmento;
        }

        public void Insert(SubSegmento entidade)
        {
            db.SubSegmento.Add(entidade);
        }

        public void Delete(int id)
        {
            SubSegmento seg = db.SubSegmento.Find(id);
            db.SubSegmento.Remove(seg);
        }

        public void Update(SubSegmento entidade)
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
