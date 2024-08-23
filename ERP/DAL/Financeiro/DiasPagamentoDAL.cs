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
    public class DiasPagamentoDAL : IRepository<DiasPagamento>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public DiasPagamentoDAL()
        {
        }

        public IEnumerable<DiasPagamento> Get()
        {
            var dp = db.DiasPagamento.ToList();
            return dp.ToList();
        }

        public DiasPagamento GetByID(int id)
        {
            return db.DiasPagamento.Find(id);
        }

        public List<DiasPagamento> getByParams(string prtNome)
        {
            List<DiasPagamento> dp = new List<DiasPagamento>();
            dp = (from p in db.DiasPagamento
                    where (prtNome == "" || p.Nome.Contains(prtNome))
                    select p).OrderBy(o => o.Nome).ToList();

            return dp;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from dp in db.DiasPagamento
                                     select new ComboItem
                                     {
                                         iValue = dp.IdDiasPagamento,
                                         Text = dp.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(DiasPagamento entidade)
        {
            db.DiasPagamento.Add(entidade);
        }

        public void Delete(int id)
        {
            DiasPagamento dp = db.DiasPagamento.Find(id);
            db.DiasPagamento.Remove(dp);
        }

        public void Update(DiasPagamento entidade)
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