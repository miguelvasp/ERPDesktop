using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class GrupoRoteiroDAL : IRepository<GrupoRoteiro>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public GrupoRoteiroDAL()
        {
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.GrupoRoteiro
                                     select new ComboItem
                                     {
                                         iValue = c.IdGrupoRoteiro,
                                         Text = c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public IEnumerable<GrupoRoteiro> Get()
        {
            var tb = db.GrupoRoteiro.ToList();
            return tb.ToList();
        }

        public GrupoRoteiro GetByID(int id)
        {
            return db.GrupoRoteiro.Find(id);
        }

        public void Insert(GrupoRoteiro entidade)
        {
            db.GrupoRoteiro.Add(entidade);
        }

        public void Delete(int id)
        {
            GrupoRoteiro tb = db.GrupoRoteiro.Find(id);
            db.GrupoRoteiro.Remove(tb);
        }

        public void Update(GrupoRoteiro entidade)
        {
            db.Entry(entidade).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
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
