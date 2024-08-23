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
    public class GrupoAtivoDAL : IRepository<GrupoAtivo>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public GrupoAtivoDAL()
        {

        }

        public IEnumerable<GrupoAtivo> Get()
        {
            var tb = db.GrupoAtivo.ToList();
            return tb.ToList();
        }

        public GrupoAtivo GetByID(int id)
        {
            return db.GrupoAtivo.Find(id);
        }

        public List<GrupoAtivo> getByParams(string prtCodigo, string prtDescricao)
        {
            List<GrupoAtivo> ga = new List<GrupoAtivo>();
            ga = (from g in db.GrupoAtivo
                  where (prtCodigo == "" || g.Codigo.Contains(prtCodigo)) &&
                        (prtDescricao == "" || g.Descricao.Contains(prtDescricao))
                  select g).OrderBy(o => o.Descricao).ToList();

            return ga;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.GrupoAtivo
                                     select new ComboItem()
                                     {
                                         Text = c.Descricao,
                                         iValue = c.IdGrupoAtivo
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(GrupoAtivo entidade)
        {
            db.GrupoAtivo.Add(entidade);
        }

        public void Delete(int id)
        {
            GrupoAtivo tb = db.GrupoAtivo.Find(id);
            db.GrupoAtivo.Remove(tb);
        }

        public void Update(GrupoAtivo entidade)
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
