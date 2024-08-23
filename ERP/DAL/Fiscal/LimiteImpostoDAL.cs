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
    public class LimiteImpostoDAL : IRepository<LimiteImposto>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public LimiteImpostoDAL()
        {

        }

        public IEnumerable<LimiteImposto> Get()
        {
            var li = db.LimiteImposto.ToList();
            return li.ToList();
        }

        public LimiteImposto GetByID(int id)
        {
            return db.LimiteImposto.Find(id);
        }

        public List<LimiteImposto> GetByCodigoImposto(int idCodigoImposto)
        {
            var lista = (from l in db.LimiteImposto
                         where l.IdCodigoImposto == idCodigoImposto
                         select l).ToList();
            return lista;
        }



        public List<LimiteImposto> getByParams(string prtDtDe, string prtDtAte)
        {
            List<LimiteImposto> li = new List<LimiteImposto>();
            if (string.IsNullOrEmpty(prtDtDe) && string.IsNullOrEmpty(prtDtAte))
            {
                li = (from m in db.LimiteImposto
                      select m).OrderBy(o => o.IdLimiteImposto).ToList();
            }
            else if (!string.IsNullOrEmpty(prtDtDe) && string.IsNullOrEmpty(prtDtAte))
            {
                DateTime dtDeIni = Convert.ToDateTime(prtDtDe + " 00:00:00");
                DateTime dtDeFim = Convert.ToDateTime(prtDtDe + " 23:59:00");

                li = (from m in db.LimiteImposto
                      where (m.De.Value >= dtDeIni &&
                            m.De.Value <= dtDeFim)
                      select m).OrderBy(o => o.IdLimiteImposto).ToList();
            }
            else if (string.IsNullOrEmpty(prtDtDe) && !string.IsNullOrEmpty(prtDtAte))
            {
                DateTime dtAteIni = Convert.ToDateTime(prtDtAte + " 00:00:00");
                DateTime dtAteFim = Convert.ToDateTime(prtDtAte + " 23:59:00");

                li = (from m in db.LimiteImposto
                      where (m.Ate.Value >= dtAteIni &&
                            m.Ate.Value <= dtAteFim)
                      select m).OrderBy(o => o.IdLimiteImposto).ToList();
            }
            else if (!string.IsNullOrEmpty(prtDtDe) && !string.IsNullOrEmpty(prtDtAte))
            {
                DateTime dtDeIni = Convert.ToDateTime(prtDtDe + " 00:00:00");
                DateTime dtDeFim = Convert.ToDateTime(prtDtDe + " 23:59:00");
                DateTime dtAteIni = Convert.ToDateTime(prtDtAte + " 00:00:00");
                DateTime dtAteFim = Convert.ToDateTime(prtDtAte + " 23:59:00");

                li = (from m in db.LimiteImposto
                      where (m.De.Value >= dtDeIni && m.De.Value <= dtDeFim) &&
                            (m.Ate.Value >= dtAteIni && m.Ate.Value <= dtAteFim)
                      select m).OrderBy(o => o.IdLimiteImposto).ToList();
            }

            return li;
        }

        public void Insert(LimiteImposto entidade)
        {
            db.LimiteImposto.Add(entidade);
        }

        public void Delete(int id)
        {
            LimiteImposto li = db.LimiteImposto.Find(id);
            db.LimiteImposto.Remove(li);
        }

        public void Update(LimiteImposto entidade)
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
