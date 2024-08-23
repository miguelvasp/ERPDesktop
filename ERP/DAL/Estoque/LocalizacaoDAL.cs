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
    public class LocalizacaoDAL : IRepository<Localizacao>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public LocalizacaoDAL()
        {
            
        }

        public IEnumerable<Localizacao> Get()
        {
            var tb = db.Localizacao.ToList();
            return tb.ToList();
        }

        public Localizacao GetByID(int id)
        {
            return db.Localizacao.Find(id);
        }

        public List<Localizacao> getByParams(string prtNome)
        {
            List<Localizacao> local = new List<Localizacao>();
            local = (from l in db.Localizacao
                   where (prtNome == "" || l.Nome.Contains(prtNome))
                   select l).OrderBy(o => o.Nome).ToList();

            return local;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.Localizacao
                                     select new ComboItem()
                                     {
                                         Text = c.Nome,
                                         iValue = c.IdLocalizacao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(Localizacao entidade)
        {
            db.Localizacao.Add(entidade);
        }

        public void Delete(int id)
        {
            Localizacao tb = db.Localizacao.Find(id);
            db.Localizacao.Remove(tb);
        }

        public void Update(Localizacao entidade)
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
