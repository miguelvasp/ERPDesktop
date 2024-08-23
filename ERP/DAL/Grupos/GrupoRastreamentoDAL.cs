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
    public class GrupoRastreamentoDAL : IRepository<GrupoRastreamento>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public GrupoRastreamentoDAL()
        {
            
        }

        public IEnumerable<GrupoRastreamento> Get()
        {
            var tb = db.GrupoRastreamento.ToList();
            return tb.ToList();
        }

        public GrupoRastreamento GetByID(int id)
        {
            return db.GrupoRastreamento.Find(id);
        }

        public List<GrupoRastreamento> getByParams(string prtNome, string prtDescricao)
        {
            List<GrupoRastreamento> gr = new List<GrupoRastreamento>();
            gr = (from g in db.GrupoRastreamento
                  where (prtNome == "" || g.Nome.Contains(prtNome)) &&
                  (prtDescricao == "" || g.Descricao.Contains(prtDescricao))
                  select g).OrderBy(o => o.Nome).ToList();

            return gr;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from g in db.GrupoRastreamento
                                     select new ComboItem
                                     {
                                         iValue = g.IdGrupoRastreamento,
                                         Text = g.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(GrupoRastreamento entidade)
        {
            db.GrupoRastreamento.Add(entidade);
        }

        public void Delete(int id)
        {
            GrupoRastreamento tb = db.GrupoRastreamento.Find(id);
            if (tb != null)
            {
                db.GrupoRastreamento.Remove(tb);
            }  
        }

        public void Update(GrupoRastreamento entidade)
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
