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
    public class AtivoImobilizadoDAL : IRepository<AtivoImobilizado>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public AtivoImobilizadoDAL()
        {
            
        }
        
        public IEnumerable<AtivoImobilizado> Get()
        {
            var tb = db.AtivoImobilizado.ToList();
            return tb.ToList();
        }

        public AtivoImobilizado GetByID(int id)
        {
            return db.AtivoImobilizado.Find(id);
        }

        public List<AtivoImobilizado> getByParams(string prtNome, string prtDescricao)
        {
            List<AtivoImobilizado> aut = new List<AtivoImobilizado>();
            aut = (from a in db.AtivoImobilizado
                   where (prtNome == "" || a.Nome.Contains(prtNome)) &&
                   (prtDescricao == "" || a.Descricao.Contains(prtDescricao))
                   select a).OrderBy(o => o.Nome).ToList();

            return aut;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.AtivoImobilizado
                                     select new ComboItem()
                                     {
                                         Text = c.Nome,
                                         iValue = c.IdAtivoImobilizado
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(AtivoImobilizado entidade)
        {
            db.AtivoImobilizado.Add(entidade);
        }

        public void Delete(int id)
        {
            AtivoImobilizado tb = db.AtivoImobilizado.Find(id);
            if (tb != null)
            {
                db.AtivoImobilizado.Remove(tb);
            }
        }

        public void Update(AtivoImobilizado entidade)
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
