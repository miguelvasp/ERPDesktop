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
    public class GrupoArmazenamentoDAL : IRepository<GrupoArmazenamento>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public GrupoArmazenamentoDAL()
        {
            
        }

        public IEnumerable<GrupoArmazenamento> Get()
        {
            var tb = db.GrupoArmazenamento.ToList();
            return tb.ToList();
        }

        public GrupoArmazenamento GetByID(int id)
        {
            return db.GrupoArmazenamento.Find(id);
        }

        public List<GrupoArmazenamento> getByParams(string prtNome, string prtDescricao)
        {
            List<GrupoArmazenamento> ga = new List<GrupoArmazenamento>();
            ga = (from g in db.GrupoArmazenamento
                   where (prtNome == "" || g.Nome.Contains(prtNome)) &&
                   (prtDescricao == "" || g.Descricao.Contains(prtDescricao))
                   select g).OrderBy(o => o.Nome).ToList();

            return ga;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from g in db.GrupoArmazenamento
                                     select new ComboItem
                                     {
                                         iValue = g.IdGrupoArmazenamento,
                                         Text = g.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(GrupoArmazenamento entidade)
        {
            db.GrupoArmazenamento.Add(entidade);
        }

        public void Delete(int id)
        {
            GrupoArmazenamento tb = db.GrupoArmazenamento.Find(id);
            if (tb != null)
            {
                db.GrupoArmazenamento.Remove(tb);
            }            
        }

        public void Update(GrupoArmazenamento entidade)
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
