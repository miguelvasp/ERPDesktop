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
    public class RepresentanteVendasDAL : IRepository<RepresentanteVendas>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public RepresentanteVendasDAL()
        {
        }

        public IEnumerable<RepresentanteVendas> Get()
        {
            var rv = db.RepresentanteVendas.ToList();
            return rv.ToList();
        }

        public RepresentanteVendas GetByID(int id)
        {
            return db.RepresentanteVendas.Find(id);
        }

        public List<RepresentanteVendas> getByParams(string prtDescricao)
        {
            List<RepresentanteVendas> rv = new List<RepresentanteVendas>();
            rv = (from r in db.RepresentanteVendas
                   where (prtDescricao == "" || r.Descricao.Contains(prtDescricao))
                   select r).OrderBy(o => o.Descricao).ToList();

            return rv;
        }

        public void Insert(RepresentanteVendas entidade)
        {
            db.RepresentanteVendas.Add(entidade);
        }

        public void Delete(int id)
        {
            RepresentanteVendas rv = db.RepresentanteVendas.Find(id);
            db.RepresentanteVendas.Remove(rv);
        }

        public void Update(RepresentanteVendas entidade)
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
