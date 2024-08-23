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
    public class PeriodoLiquidacaoImpostoVencDAL : IRepository<PeriodoLiquidacaoImpostoVenc>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public PeriodoLiquidacaoImpostoVencDAL()
        {

        }

        public IEnumerable<PeriodoLiquidacaoImpostoVenc> Get()
        {
            var pli = db.PeriodoLiquidacaoImpostoVenc.ToList();
            return pli.ToList();
        }

        public PeriodoLiquidacaoImpostoVenc GetByID(int id)
        {
            return db.PeriodoLiquidacaoImpostoVenc.Find(id);
        }

        public List<PeriodoLiquidacaoImpostoVenc> getByParams(string prtDtDe, string prtDtAte)
        {
            List<PeriodoLiquidacaoImpostoVenc> pli = new List<PeriodoLiquidacaoImpostoVenc>();
            if (string.IsNullOrEmpty(prtDtDe) && string.IsNullOrEmpty(prtDtAte))
            {
                pli = (from m in db.PeriodoLiquidacaoImpostoVenc
                      select m).OrderBy(o => o.IdPeriodoLiquidacaoImpostoVenc).ToList();
            }
            else if (!string.IsNullOrEmpty(prtDtDe) && string.IsNullOrEmpty(prtDtAte))
            {
                DateTime dtDeIni = Convert.ToDateTime(prtDtDe + " 00:00:00");
                DateTime dtDeFim = Convert.ToDateTime(prtDtDe + " 23:59:00");

                pli = (from m in db.PeriodoLiquidacaoImpostoVenc
                      where (m.De.Value >= dtDeIni &&
                            m.De.Value <= dtDeFim)
                      select m).OrderBy(o => o.IdPeriodoLiquidacaoImpostoVenc).ToList();
            }
            else if (string.IsNullOrEmpty(prtDtDe) && !string.IsNullOrEmpty(prtDtAte))
            {
                DateTime dtAteIni = Convert.ToDateTime(prtDtAte + " 00:00:00");
                DateTime dtAteFim = Convert.ToDateTime(prtDtAte + " 23:59:00");

                pli = (from m in db.PeriodoLiquidacaoImpostoVenc
                      where (m.Ate.Value >= dtAteIni &&
                            m.Ate.Value <= dtAteFim)
                      select m).OrderBy(o => o.IdPeriodoLiquidacaoImpostoVenc).ToList();
            }
            else if (!string.IsNullOrEmpty(prtDtDe) && !string.IsNullOrEmpty(prtDtAte))
            {
                DateTime dtDeIni = Convert.ToDateTime(prtDtDe + " 00:00:00");
                DateTime dtDeFim = Convert.ToDateTime(prtDtDe + " 23:59:00");
                DateTime dtAteIni = Convert.ToDateTime(prtDtAte + " 00:00:00");
                DateTime dtAteFim = Convert.ToDateTime(prtDtAte + " 23:59:00");

                pli = (from m in db.PeriodoLiquidacaoImpostoVenc
                      where (m.De.Value >= dtDeIni && m.De.Value <= dtDeFim) &&
                            (m.Ate.Value >= dtAteIni && m.Ate.Value <= dtAteFim)
                      select m).OrderBy(o => o.IdPeriodoLiquidacaoImpostoVenc).ToList();
            }

            return pli;
        }

        public List<PeriodoLiquidacaoImpostoVenc> GetVencimentoByPeriodoId(int pId)
        {
            List<PeriodoLiquidacaoImpostoVenc> lista = (from p in db.PeriodoLiquidacaoImpostoVenc
                                                        where p.IdPeriodoLiquidacaoImposto == pId
                                                        select p).ToList();
            return lista;
        }


        public void Insert(PeriodoLiquidacaoImpostoVenc entidade)
        {
            db.PeriodoLiquidacaoImpostoVenc.Add(entidade);
        }

        public void Delete(int id)
        {
            PeriodoLiquidacaoImpostoVenc pli = db.PeriodoLiquidacaoImpostoVenc.Find(id);
            db.PeriodoLiquidacaoImpostoVenc.Remove(pli);
        }

        public void Update(PeriodoLiquidacaoImpostoVenc entidade)
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
