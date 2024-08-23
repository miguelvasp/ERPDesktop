using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class TotalDimensoesDAL : IRepository<TotalDimensoes>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public TotalDimensoesDAL()
        {
        }

        public IEnumerable<TotalDimensoes> Get()
        {
            var t = db.TotalDimensoes.ToList();
            return t.ToList();
        }

        public TotalDimensoes GetByID(int id)
        {
            return db.TotalDimensoes.Find(id);
        }

               
        public List<TotalDimensoesModelView> getItensTotalDimensao(int IdValoresCentroCusto)
        {
            List<TotalDimensoesModelView> lista = (from t in db.TotalDimensoes
                                            join d in db.CentroCusto on t.IdCentroCustoDe equals d.IdCentroCusto into d1
                                                from d2 in d1.DefaultIfEmpty()
                                            join a in db.CentroCusto on t.IdCentroCustoAte equals a.IdCentroCusto into a1
                                                from a2 in a1.DefaultIfEmpty()
                                            where t.IdValoresCentroCusto == IdValoresCentroCusto
                                                   select new TotalDimensoesModelView
                                            {
                                                IdTotalDimensoes = t.IdTotalDimensoes,
                                                IdValoresCentroCusto= t.IdValoresCentroCusto,
                                                DimensaoDe = d2.Codigo + " - " + d2.Descricao,
                                                DimensaoAte = a2.Codigo + " - " + a2.Descricao
                                            }).OrderBy(o => o.IdTotalDimensoes).ToList();

            return lista;
        }

        public void Insert(TotalDimensoes entidade)
        {
            db.TotalDimensoes.Add(entidade);
        }

        public void Delete(int id)
        {
            TotalDimensoes t = db.TotalDimensoes.Find(id);
            if (t != null)
            {
                db.TotalDimensoes.Remove(t);
            }
        }

        public void Update(TotalDimensoes entidade)
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