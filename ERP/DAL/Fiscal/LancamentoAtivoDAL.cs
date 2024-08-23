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
    public class LancamentoAtivoDAL : IRepository<LancamentoAtivo>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public LancamentoAtivoDAL()
        {
        }

        public IEnumerable<LancamentoAtivo> Get()
        {
            var l = db.LancamentoAtivo.ToList();
            return l.ToList();
        }

        public LancamentoAtivo GetByID(int id)
        {
            return db.LancamentoAtivo.Find(id);
        }

        public List<LancamentoAtivo> getByParams(string prtDescricao)
        {
            List<LancamentoAtivo> la = new List<LancamentoAtivo>();
            la = (from l in db.LancamentoAtivo
                   where (prtDescricao == "" || l.Descricao.Contains(prtDescricao))
                   select l).OrderBy(o => o.Descricao).ToList();

            return la;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from l in db.LancamentoAtivo
                                     select new ComboItem
                                     {
                                         iValue = l.IdLancamentoAtivo,
                                         Text = l.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(LancamentoAtivo entidade)
        {
            db.LancamentoAtivo.Add(entidade);
        }

        public void Delete(int id)
        {
            LancamentoAtivo l = db.LancamentoAtivo.Find(id);
            if (l != null)
            {
                db.LancamentoAtivo.Remove(l);
            }
        }

        public void Update(LancamentoAtivo entidade)
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