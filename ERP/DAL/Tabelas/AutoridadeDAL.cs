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
    public class AutoridadeDAL : IRepository<Autoridade>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public AutoridadeDAL()
        {
        }

        public IEnumerable<Autoridade> Get()
        {
            var a = db.Autoridade.ToList();
            return a.ToList();
        }

        public Autoridade GetByID(int id)
        {
            return db.Autoridade.Find(id);
        }

        public List<Autoridade> getByParams(string prtNomeAutoridade, string prtDescricao)
        {
            List<Autoridade> aut = new List<Autoridade>();
            aut = (from a in db.Autoridade
                   where (prtNomeAutoridade == "" || a.NomeAutoridade.Contains(prtNomeAutoridade)) &&
                   (prtDescricao == "" || a.Descricao.Contains(prtDescricao))
                   select a).OrderBy(o => o.NomeAutoridade).ToList();

            return aut;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.Autoridade
                                     select new ComboItem
                                     {
                                         iValue = c.IdAutoridade,
                                         Text = c.NomeAutoridade
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(Autoridade entidade)
        {
            db.Autoridade.Add(entidade);
        }

        public void Delete(int id)
        {
            Autoridade a = db.Autoridade.Find(id);
            if (a != null)
            {
                db.Autoridade.Remove(a);
            }
        }

        public void Update(Autoridade entidade)
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
