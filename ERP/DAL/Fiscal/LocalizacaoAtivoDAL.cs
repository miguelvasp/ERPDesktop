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
    public class LocalizacaoAtivoDAL : IRepository<LocalizacaoAtivo>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public LocalizacaoAtivoDAL()
        {
        }

        public IEnumerable<LocalizacaoAtivo> Get()
        {
            var l = db.LocalizacaoAtivo.ToList();
            return l.ToList();
        }

        public LocalizacaoAtivo GetByID(int id)
        {
            return db.LocalizacaoAtivo.Find(id);
        }

        public List<LocalizacaoAtivo> getByParams(string prtDescricao)
        {
            List<LocalizacaoAtivo> la = new List<LocalizacaoAtivo>();
            la = (from l in db.LocalizacaoAtivo
                  where (prtDescricao == "" || l.Descricao.Contains(prtDescricao))
                  select l).OrderBy(o => o.Descricao).ToList();

            return la;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.LocalizacaoAtivo
                                     select new ComboItem
                                     {
                                         iValue = c.IdLocalizacaoAtivo,
                                         Text = c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(LocalizacaoAtivo entidade)
        {
            db.LocalizacaoAtivo.Add(entidade);
        }

        public void Delete(int id)
        {
            LocalizacaoAtivo l = db.LocalizacaoAtivo.Find(id);
            if (l != null)
            {
                db.LocalizacaoAtivo.Remove(l);
            }
        }

        public void Update(LocalizacaoAtivo entidade)
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