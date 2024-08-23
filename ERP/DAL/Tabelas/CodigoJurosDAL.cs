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
    public class CodigoJurosDAL : IRepository<CodigoJuros>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public CodigoJurosDAL()
        {
        }

        public IEnumerable<CodigoJuros> Get()
        {
            var cj = db.CodigoJuros.ToList();
            return cj.ToList();
        }

        public CodigoJuros GetByID(int id)
        {
            return db.CodigoJuros.Find(id);
        }

        public List<CodigoJuros> getByParams(string prtNome, string prtDescricao)
        {
            List<CodigoJuros> cj = new List<CodigoJuros>();
            cj = (from p in db.CodigoJuros
                  where (prtNome == "" || p.Nome.Contains(prtNome)) &&
                    (prtDescricao == "" || p.Descricao.Contains(prtDescricao))
                  select p).OrderBy(o => o.Nome).ToList();

            return cj;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from cj in db.CodigoJuros
                                     select new ComboItem
                                     {
                                         iValue = cj.IdCodigoJuros,
                                         Text = cj.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(CodigoJuros entidade)
        {
            db.CodigoJuros.Add(entidade);
        }

        public void Delete(int id)
        {
            CodigoJuros cj = db.CodigoJuros.Find(id);
            db.CodigoJuros.Remove(cj);
        }

        public void Update(CodigoJuros entidade)
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