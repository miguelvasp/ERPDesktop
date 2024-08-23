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
    public class DepreciacaoEspecialDAL: IRepository<DepreciacaoEspecial>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public DepreciacaoEspecialDAL()
        {
        }

        public IEnumerable<DepreciacaoEspecial> Get()
        {
            var de = db.DepreciacaoEspecial.ToList();
            return de.ToList();
        }

        public DepreciacaoEspecial GetByID(int id)
        {
            return db.DepreciacaoEspecial.Find(id);
        }

        public List<DepreciacaoEspecial> getByParams(string prtCodigo, string prtDescricao)
        {
            List<DepreciacaoEspecial> de = new List<DepreciacaoEspecial>();
            de = (from a in db.DepreciacaoEspecial
                   where (prtCodigo == "" || a.Codigo.Contains(prtCodigo)) &&
                   (prtDescricao == "" || a.Descricao.Contains(prtDescricao))
                   select a).OrderBy(o => o.Codigo).ToList();

            return de;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.DepreciacaoEspecial
                                     select new ComboItem
                                     {
                                         iValue = c.IdDepreciacaoEspecial,
                                         Text = c.Codigo
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(DepreciacaoEspecial entidade)
        {
            db.DepreciacaoEspecial.Add(entidade);
        }

        public void Delete(int id)
        {
            DepreciacaoEspecial de = db.DepreciacaoEspecial.Find(id);
            db.DepreciacaoEspecial.Remove(de);
        }

        public void Update(DepreciacaoEspecial entidade)
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
