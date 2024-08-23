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
    public class PerfilProducaoDAL : IRepository<PerfilProducao>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public PerfilProducaoDAL()
        {

        }

        public IEnumerable<PerfilProducao> Get()
        {
            var tb = db.PerfilProducao.ToList();
            return tb.ToList();
        }

        public PerfilProducao GetByID(int id)
        {
            return db.PerfilProducao.Find(id);
        }

        public List<PerfilProducao> getByParams(string prtNome)
        {
            List<PerfilProducao> pp = new List<PerfilProducao>();
            pp = (from p in db.PerfilProducao
                  where (prtNome == "" || p.Nome.Contains(prtNome))
                  select p).OrderBy(o => o.Nome).ToList();

            return pp;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.PerfilProducao
                                     select new ComboItem()
                                     {
                                         Text = c.Nome,
                                         iValue = c.IdPerfilProducao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(PerfilProducao entidade)
        {
            db.PerfilProducao.Add(entidade);
        }

        public void Delete(int id)
        {
            PerfilProducao tb = db.PerfilProducao.Find(id);
            db.PerfilProducao.Remove(tb);
        }

        public void Update(PerfilProducao entidade)
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
