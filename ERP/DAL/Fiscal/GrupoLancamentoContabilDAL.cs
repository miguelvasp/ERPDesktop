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
    public class GrupoLancamentoContabilDAL : IRepository<GrupoLancamentoContabil>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public GrupoLancamentoContabilDAL()
        {
        }

        public IEnumerable<GrupoLancamentoContabil> Get()
        {
            var glc = db.GrupoLancamentoContabil.ToList();
            return glc.ToList();
        }

        public GrupoLancamentoContabil GetByID(int id)
        {
            return db.GrupoLancamentoContabil.Find(id);
        }

        public List<GrupoLancamentoContabil> getByParams(string prtDescricao)
        {
            List<GrupoLancamentoContabil> glc = new List<GrupoLancamentoContabil>();
            glc = (from a in db.GrupoLancamentoContabil
                   where (prtDescricao == "" || a.Descricao.Contains(prtDescricao))
                   select a).OrderBy(o => o.Descricao).ToList();

            return glc;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.GrupoLancamentoContabil
                                     select new ComboItem
                                     {
                                         iValue = c.IdGrupoLancamentoContabil,
                                         Text = c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(GrupoLancamentoContabil entidade)
        {
            db.GrupoLancamentoContabil.Add(entidade);
        }

        public void Delete(int id)
        {
            GrupoLancamentoContabil glc = db.GrupoLancamentoContabil.Find(id);
            db.GrupoLancamentoContabil.Remove(glc);
        }

        public void Update(GrupoLancamentoContabil entidade)
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
