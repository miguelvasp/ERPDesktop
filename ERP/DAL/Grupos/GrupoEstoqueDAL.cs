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
    public class GrupoEstoqueDAL : IRepository<GrupoEstoque>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public GrupoEstoqueDAL()
        {
          
        }

        public IEnumerable<GrupoEstoque> Get()
        {
            var tb = db.GrupoEstoque.ToList();
            return tb.ToList();
        }

        public GrupoEstoque GetByID(int id)
        {
            return db.GrupoEstoque.Find(id);
        }

        public List<GrupoEstoque> getByParams(string prtNome, string prtDescricao)
        {
            List<GrupoEstoque> ge = new List<GrupoEstoque>();
            ge = (from g in db.GrupoEstoque
                  where (prtNome == "" || g.Nome.Contains(prtNome)) &&
                  (prtDescricao == "" || g.Descricao.Contains(prtDescricao))
                  select g).OrderBy(o => o.Nome).ToList();

            return ge;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from g in db.GrupoEstoque
                                     select new ComboItem
                                     {
                                         iValue = g.IdGrupoEstoque,
                                         Text = g.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(GrupoEstoque entidade)
        {
            db.GrupoEstoque.Add(entidade);
        }

        public void Delete(int id)
        {
            GrupoEstoque tb = db.GrupoEstoque.Find(id);
            if (tb != null)
            {
                db.GrupoEstoque.Remove(tb);
            } 
        }

        public void Update(GrupoEstoque entidade)
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
