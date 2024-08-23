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
    public class PlanoMestreDAL : IRepository<PlanoMestre>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public PlanoMestreDAL()
        {

        }

        public IEnumerable<PlanoMestre> Get()
        {
            var tb = db.PlanoMestre.OrderBy(x => x.Descricao).ToList();
            return tb.ToList();
        }

        public PlanoMestre GetByID(int id)
        {
            return db.PlanoMestre.Find(id);
        }

        public List<PlanoMestre> getByParams(string prtCodigo, string prtDescricao)
        {
            List<PlanoMestre> pp = new List<PlanoMestre>();
            pp = (from a in db.PlanoMestre
                  where (prtCodigo == "" || a.Codigo.Contains(prtCodigo)) &&
                  (prtDescricao == "" || a.Descricao.Contains(prtDescricao))
                  select a).OrderBy(o => o.Codigo).ToList();

            return pp;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.PlanoMestre
                                     select new ComboItem
                                     {
                                         iValue = c.IdPlanoMestre,
                                         Text = c.Codigo
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(PlanoMestre entidade)
        {
            db.PlanoMestre.Add(entidade);
        }

        public void Delete(int id)
        {
            PlanoMestre tb = db.PlanoMestre.Find(id);
            db.PlanoMestre.Remove(tb);
        }

        public void Update(PlanoMestre entidade)
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
