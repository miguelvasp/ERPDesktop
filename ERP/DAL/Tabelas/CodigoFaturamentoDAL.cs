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
    public class CodigoFaturamentoDAL : IRepository<CodigoFaturamento>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public CodigoFaturamentoDAL()
        {

        }

        public IEnumerable<CodigoFaturamento> Get()
        {
            var cf = db.CodigoFaturamento.ToList();
            return cf.ToList();
        }

        public CodigoFaturamento GetByID(int id)
        {
            return db.CodigoFaturamento.Find(id);
        }

        public List<CodigoFaturamento> getByParams(string prtCFOP, string prtDescricao)
        {
            List<CodigoFaturamento> cf = new List<CodigoFaturamento>();
            cf = (from p in db.CodigoFaturamento
                  where p.CFOP.Contains(prtCFOP) &&
                    (prtDescricao == "" || p.Descricao.Contains(prtDescricao))
                    select p).OrderBy(o => o.CFOP).ToList();

            return cf;
        }

        public void Insert(CodigoFaturamento entidade)
        {
            db.CodigoFaturamento.Add(entidade);
        }

        public void Delete(int id)
        {
            CodigoFaturamento cf = db.CodigoFaturamento.Find(id);
            db.CodigoFaturamento.Remove(cf);
        }

        public void Update(CodigoFaturamento entidade)
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

