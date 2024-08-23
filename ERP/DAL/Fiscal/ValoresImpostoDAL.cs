using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
//using System.Data.Objects.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class ValoresImpostoDAL : IRepository<ValoresImposto>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ValoresImpostoDAL()
        {

        }

        public IEnumerable<ValoresImposto> Get()
        {
            var vi = db.ValoresImposto.ToList();
            return vi.ToList();
        }

        public ValoresImposto GetByID(int id)
        {
            return db.ValoresImposto.Find(id);
        }

        public List<ValoresImposto> GetByCodigoImposto(int id)
        {
            var lista = (from v in db.ValoresImposto
                         where v.IdCodigoImposto == id
                         select v).ToList();
            return lista;
        }

        public bool VerificaDatas(DateTime DataInicial, DateTime DataFinal, int pIdCodigoImposto)
        {
            bool ok = true;
            //verifica a primeira data
            var Ini = (from di in db.ValoresImposto
                       where (di.De <= DataInicial && di.Ate >= DataInicial)
                       & di.IdCodigoImposto == pIdCodigoImposto
                       select di).ToList();

            if(Ini != null && Ini.Count > 0)
            {
                ok = false;
            }
            else
            {
                var fim = (from di in db.ValoresImposto
                           where (di.De <= DataFinal && di.Ate >= DataFinal)
                           & di.IdCodigoImposto == pIdCodigoImposto
                           select di).ToList();
                if(fim != null && fim.Count > 0)
                {
                    ok = false;
                }
            }
            return ok;
        }

        public List<ValoresImposto> getByParams(string prtDtDe, string prtDtAte)
        {
            List<ValoresImposto> vi = new List<ValoresImposto>();
            if (string.IsNullOrEmpty(prtDtDe) && string.IsNullOrEmpty(prtDtAte))
            {
                vi = (from m in db.ValoresImposto
                      select m).OrderBy(o => o.IdValoresImposto).ToList();
            }
            else if (!string.IsNullOrEmpty(prtDtDe) && string.IsNullOrEmpty(prtDtAte))
            {
                DateTime dtDeIni = Convert.ToDateTime(prtDtDe + " 00:00:00");
                DateTime dtDeFim = Convert.ToDateTime(prtDtDe + " 23:59:00");

                vi = (from m in db.ValoresImposto
                      where (m.De.Value  >= dtDeIni &&
                            m.De.Value <= dtDeFim)
                      select m).OrderBy(o => o.IdValoresImposto).ToList();
            }
            else if (string.IsNullOrEmpty(prtDtDe) && !string.IsNullOrEmpty(prtDtAte))
            {
                DateTime dtAteIni = Convert.ToDateTime(prtDtAte + " 00:00:00");
                DateTime dtAteFim = Convert.ToDateTime(prtDtAte + " 23:59:00");

                vi = (from m in db.ValoresImposto
                      where (m.Ate.Value >= dtAteIni &&
                            m.Ate.Value <= dtAteFim)
                      select m).OrderBy(o => o.IdValoresImposto).ToList();
            }
            else if (!string.IsNullOrEmpty(prtDtDe) && !string.IsNullOrEmpty(prtDtAte))
            {
                DateTime dtDeIni = Convert.ToDateTime(prtDtDe + " 00:00:00");
                DateTime dtDeFim = Convert.ToDateTime(prtDtDe + " 23:59:00");
                DateTime dtAteIni = Convert.ToDateTime(prtDtAte + " 00:00:00");
                DateTime dtAteFim = Convert.ToDateTime(prtDtAte + " 23:59:00");

                vi = (from m in db.ValoresImposto
                      where (m.De.Value >= dtDeIni && m.De.Value <= dtDeFim) &&
                            (m.Ate.Value >= dtAteIni && m.Ate.Value <= dtAteFim)
                      select m).OrderBy(o => o.IdValoresImposto).ToList();
            }

            return vi;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.ValoresImposto
                                     select new ComboItem
                                     {
                                         iValue = c.IdValoresImposto,
                                         Text = SqlFunctions.StringConvert(c.Aliquota)
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }


        public void Insert(ValoresImposto entidade)
        {
            db.ValoresImposto.Add(entidade);
        }

        public void Delete(int id)
        {
            ValoresImposto vi = db.ValoresImposto.Find(id);
            db.ValoresImposto.Remove(vi);
        }

        public void Update(ValoresImposto entidade)
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