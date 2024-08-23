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
    public class PlanoPrevisaoDAL : IRepository<PlanoPrevisao>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public PlanoPrevisaoDAL()
        {

        }

        public IEnumerable<PlanoPrevisao> Get()
        {
            var tb = db.PlanoPrevisao.OrderBy(x => x.Descricao).ToList();
            return tb.ToList();
        }

        public PlanoPrevisao GetByID(int id)
        {
            return db.PlanoPrevisao.Find(id);
        }

        public List<PlanoPrevisao> getByParams(string prtCodigo, string prtDescricao)
        {
            List<PlanoPrevisao> pp = new List<PlanoPrevisao>();
            pp = (from a in db.PlanoPrevisao
                   where (prtCodigo == "" || a.Codigo.Contains(prtCodigo)) &&
                   (prtDescricao == "" || a.Descricao.Contains(prtDescricao))
                   select a).OrderBy(o => o.Codigo).ToList();

            return pp;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.PlanoPrevisao
                                     select new ComboItem
                                     {
                                         iValue = c.IdPlanoPrevisao,
                                         Text = c.Codigo
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
        
        public void Insert(PlanoPrevisao entidade)
        {
            db.PlanoPrevisao.Add(entidade);
        }

        public void Delete(int id)
        {
            PlanoPrevisao tb = db.PlanoPrevisao.Find(id);
            db.PlanoPrevisao.Remove(tb);
        }

        public void Update(PlanoPrevisao entidade)
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
