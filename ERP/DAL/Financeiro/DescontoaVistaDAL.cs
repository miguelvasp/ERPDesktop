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
    public class DescontoaVistaDAL: IRepository<DescontoaVista>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public DescontoaVistaDAL()
        {
        }

        public IEnumerable<DescontoaVista> Get()
        {
            var d = db.DescontoaVista.ToList();
            return d.ToList();
        }

        public DescontoaVista GetByID(int id)
        {
            return db.DescontoaVista.Find(id);
        }

        public List<DescontoaVista> getByParams(string prtDescricao)
        {
            List<DescontoaVista> d = new List<DescontoaVista>();
            d = (from a in db.DescontoaVista
                   where (prtDescricao == "" || a.Descricao.Contains(prtDescricao))
                   select a).OrderBy(o => o.Descricao).ToList();

            return d;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.DescontoaVista
                                     select new ComboItem
                                     {
                                         iValue = c.IdDescontoaVista,
                                         Text = c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(DescontoaVista entidade)
        {
            db.DescontoaVista.Add(entidade);
        }

        public void Delete(int id)
        {
            DescontoaVista d = db.DescontoaVista.Find(id);
            db.DescontoaVista.Remove(d);
        }

        public void Update(DescontoaVista entidade)
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
