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
    public class PlanoPagamentoDAL : IRepository<PlanoPagamento>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public PlanoPagamentoDAL()
        {
        }

        public IEnumerable<PlanoPagamento> Get()
        {
            var pp = db.PlanoPagamento.ToList();
            return pp.ToList();
        }

        public PlanoPagamento GetByID(int id)
        {
            return db.PlanoPagamento.Find(id);
        }

        public List<PlanoPagamento> getByParams(string prtNome, string prtDescricao)
        {
            List<PlanoPagamento> pp = new List<PlanoPagamento>();
            pp = (from p in db.PlanoPagamento
                    where p.Nome.Contains(prtNome) &&
                    (prtDescricao == "" || p.Descricao.Contains(prtDescricao))
                    select p).OrderBy(o => o.Nome).ToList();

            return pp;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from pp in db.PlanoPagamento
                                     select new ComboItem
                                     {
                                         iValue = pp.IdPlanoPagamento,
                                         Text = pp.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(PlanoPagamento entidade)
        {
            db.PlanoPagamento.Add(entidade);
        }

        public void Delete(int id)
        {
            PlanoPagamento pp = db.PlanoPagamento.Find(id);
            db.PlanoPagamento.Remove(pp);
        }

        public void Update(PlanoPagamento entidade)
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
