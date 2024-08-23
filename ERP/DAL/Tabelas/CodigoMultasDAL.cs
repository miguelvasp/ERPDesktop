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
    public class CodigoMultasDAL : IRepository<CodigoMultas>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public CodigoMultasDAL()
        {
        }

        public IEnumerable<CodigoMultas> Get()
        {
            var cm = db.CodigoMultas.ToList();
            return cm.ToList();
        }

        public CodigoMultas GetByID(int id)
        {
            return db.CodigoMultas.Find(id);
        }

        public List<CodigoMultas> getByParams(string prtNome, string prtDescricao)
        {
            List<CodigoMultas> cm = new List<CodigoMultas>();
            cm = (from p in db.CodigoMultas
                  where (prtNome == "" || p.Nome.Contains(prtNome)) &&
                    (prtDescricao == "" || p.Descricao.Contains(prtDescricao))
                  select p).OrderBy(o => o.Nome).ToList();

            return cm;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from cm in db.CodigoMultas
                                     select new ComboItem
                                     {
                                         iValue = cm.IdCodigoMultas,
                                         Text = cm.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(CodigoMultas entidade)
        {
            db.CodigoMultas.Add(entidade);
        }

        public void Delete(int id)
        {
            CodigoMultas cm = db.CodigoMultas.Find(id);
            db.CodigoMultas.Remove(cm);
        }

        public void Update(CodigoMultas entidade)
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