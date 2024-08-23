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
    public class CondicaoFreteDAL : IRepository<CondicaoFrete>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public CondicaoFreteDAL()
        {
        }

        public IEnumerable<CondicaoFrete> Get()
        {
            var cf = db.CondicaoFrete.ToList();
            return cf.ToList();
        }

        public CondicaoFrete GetByID(int id)
        {
            return db.CondicaoFrete.Find(id);
        }

        public List<CondicaoFrete> getByParams(string prtNome, string prtDescricao)
        {
            List<CondicaoFrete> cf = new List<CondicaoFrete>();
            cf = (from c in db.CondicaoFrete
                  where (prtNome == "" || c.Nome.Contains(prtNome)) &&
                  (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                  select c).OrderBy(o => o.Nome).ToList();

            return cf;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.CondicaoFrete
                                     select new ComboItem
                                     {
                                         iValue = c.IdCondicaoFrete,
                                         Text = c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(CondicaoFrete entidade)
        {
            db.CondicaoFrete.Add(entidade);
        }

        public void Delete(int id)
        {
            CondicaoFrete cf = db.CondicaoFrete.Find(id);
            db.CondicaoFrete.Remove(cf);
        }

        public void Update(CondicaoFrete entidade)
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