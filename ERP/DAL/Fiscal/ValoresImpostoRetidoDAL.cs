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
    public class ValoresImpostoRetidoDAL : IRepository<ValoresImpostoRetido>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ValoresImpostoRetidoDAL()
        {

        }

        public IEnumerable<ValoresImpostoRetido> Get()
        {
            var vi = db.ValoresImpostoRetido.ToList();
            return vi.ToList();
        }
        public List<ValoresImpostoRetido> GetByCodigoImposto(int id)
        {
            var lista = (from v in db.ValoresImpostoRetido
                         where v.IdCodigoImpostoRetido == id &
                         v.De <= DateTime.Now &
                         v.Ate >= DateTime.Now
                         select v).ToList();
            return lista;
        }

        public ValoresImpostoRetido GetByID(int id)
        {
            return db.ValoresImpostoRetido.Find(id);
        }

        public List<ValoresImpostoRetido> getByParams(string prtDtDe, string prtDtAte)
        {
            List<ValoresImpostoRetido> vi = new List<ValoresImpostoRetido>();
            if (string.IsNullOrEmpty(prtDtDe) && string.IsNullOrEmpty(prtDtAte))
            {
                vi = (from m in db.ValoresImpostoRetido
                      select m).OrderBy(o => o.IdValoresImpostoRetido).ToList();
            }
            else if (!string.IsNullOrEmpty(prtDtDe) && string.IsNullOrEmpty(prtDtAte))
            {
                DateTime dtDeIni = Convert.ToDateTime(prtDtDe + " 00:00:00");
                DateTime dtDeFim = Convert.ToDateTime(prtDtDe + " 23:59:00");

                vi = (from m in db.ValoresImpostoRetido
                      where (m.De.Value  >= dtDeIni &&
                            m.De.Value <= dtDeFim)
                      select m).OrderBy(o => o.IdValoresImpostoRetido).ToList();
            }
            else if (string.IsNullOrEmpty(prtDtDe) && !string.IsNullOrEmpty(prtDtAte))
            {
                DateTime dtAteIni = Convert.ToDateTime(prtDtAte + " 00:00:00");
                DateTime dtAteFim = Convert.ToDateTime(prtDtAte + " 23:59:00");

                vi = (from m in db.ValoresImpostoRetido
                      where (m.Ate.Value >= dtAteIni &&
                            m.Ate.Value <= dtAteFim)
                      select m).OrderBy(o => o.IdValoresImpostoRetido).ToList();
            }
            else if (!string.IsNullOrEmpty(prtDtDe) && !string.IsNullOrEmpty(prtDtAte))
            {
                DateTime dtDeIni = Convert.ToDateTime(prtDtDe + " 00:00:00");
                DateTime dtDeFim = Convert.ToDateTime(prtDtDe + " 23:59:00");
                DateTime dtAteIni = Convert.ToDateTime(prtDtAte + " 00:00:00");
                DateTime dtAteFim = Convert.ToDateTime(prtDtAte + " 23:59:00");

                vi = (from m in db.ValoresImpostoRetido
                      where (m.De.Value >= dtDeIni && m.De.Value <= dtDeFim) &&
                            (m.Ate.Value >= dtAteIni && m.Ate.Value <= dtAteFim)
                      select m).OrderBy(o => o.IdValoresImpostoRetido).ToList();
            }

            return vi;
        }

        public bool VerificaDatas(DateTime DataInicial, DateTime DataFinal, int pIdCodigoImpostoRetido)
        {
            bool ok = true;
            //verifica a primeira data
            var Ini = (from di in db.ValoresImpostoRetido
                       where (di.De <= DataInicial && di.Ate >= DataInicial)
                       & di.IdCodigoImpostoRetido == pIdCodigoImpostoRetido
                       select di).ToList();

            if (Ini != null && Ini.Count > 0)
            {
                ok = false;
            }
            else
            {
                var fim = (from di in db.ValoresImpostoRetido
                           where (di.De <= DataFinal && di.Ate >= DataFinal)
                           & di.IdCodigoImpostoRetido == pIdCodigoImpostoRetido
                           select di).ToList();
                if (fim != null && fim.Count > 0)
                {
                    ok = false;
                }
            }
            return ok;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.ValoresImpostoRetido
                                     select new ComboItem
                                     {
                                         iValue = c.IdValoresImpostoRetido,
                                         Text = SqlFunctions.StringConvert(c.Aliquota)
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }


        public void Insert(ValoresImpostoRetido entidade)
        {
            db.ValoresImpostoRetido.Add(entidade);
        }

        public void Delete(int id)
        {
            ValoresImpostoRetido vi = db.ValoresImpostoRetido.Find(id);
            db.ValoresImpostoRetido.Remove(vi);
        }

        public void Update(ValoresImpostoRetido entidade)
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