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
   public class GrupoComprasDAL: IRepository< GrupoCompras>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public  GrupoComprasDAL()
        {
        }

        public GrupoComprasDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<GrupoCompras> Get()
        {
            var cc = db.GrupoCompras.ToList();
            return cc.ToList();
        }

        public GrupoCompras GetByID(int id)
        {
            return db.GrupoCompras.Find(id);
        }

        public List<GrupoCompras> getByParams(string prtNome, string prtDescricao)
        {
            List<GrupoCompras> cc = new List<GrupoCompras>();
            cc = (from c in db.GrupoCompras
                  where (prtNome == "" || c.Nome.Contains(prtNome)) &&
                      (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                  select c).OrderBy(o => o.Nome).ToList();

            return cc;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from b in db.GrupoCompras
                                     select new ComboItem
                                     {
                                         iValue = b.IdGrupoCompras,
                                         Text = b.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(GrupoCompras entidade)
        {
            db.GrupoCompras.Add(entidade);
        }

        public void Delete(int id)
        {
            GrupoCompras cc = db.GrupoCompras.Find(id);
            db.GrupoCompras.Remove(cc);
        }

        public void Update(GrupoCompras entidade)
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
