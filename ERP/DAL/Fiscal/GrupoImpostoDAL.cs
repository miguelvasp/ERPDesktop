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
    public class GrupoImpostoDAL : IRepository<GrupoImposto>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public GrupoImpostoDAL()
        {
            
        }

        public IEnumerable<GrupoImposto> Get()
        {
            var tb = db.GrupoImposto.OrderBy(x => x.Descricao).ToList();
            return tb.ToList();
        }

        public GrupoImposto GetByID(int id)
        {
            return db.GrupoImposto.Find(id);
        }

        public string GetCodigoSituacaoTributaria(int IdGrupoImposto, int TipoImposto)
        {
            return (from g in db.GrupoImposto
                    join c in db.ConfGrupoImposto on g.IdGrupoImposto equals c.IdGrupoImposto
                    join t in db.CodigoTributacao on c.IdCodigoTributacao equals t.IdCodigoTributacao
                    join i in db.CodigoImposto on c.IdCodigoImposto equals i.IdCodigoImposto
                    where g.IdGrupoImposto == IdGrupoImposto
                    && i.TipoImposto == TipoImposto
                    select t.Codigo).FirstOrDefault();
        }

        public List<GrupoImposto> getByParams(string prtCodigo, string prtDescricao)
        {
            List<GrupoImposto> GrupoImposto = new List<GrupoImposto>();
            GrupoImposto = (from gi in db.GrupoImposto
                            where gi.CodigoGrupoImposto.Contains(prtCodigo) &&
                      (prtDescricao == "" || gi.Descricao.Contains(prtDescricao))
                           select gi).OrderBy(o => o.CodigoGrupoImposto).ToList();

            return GrupoImposto;
        }

        public IEnumerable<ComboItem> getCombo()
        {
            List<ComboItem> lista = (from gi in db.GrupoImposto
                                     select new ComboItem
                                     {
                                         iValue = gi.IdGrupoImposto,
                                         Text = gi.Descricao
                                     }).OrderBy(x => x.Text).ToList();

            return lista;
        }

        public void Insert(GrupoImposto entidade)
        {
            db.GrupoImposto.Add(entidade);
        }

        public void Delete(int id)
        {
            GrupoImposto tb = db.GrupoImposto.Find(id);
            db.GrupoImposto.Remove(tb);
        }

        public void Update(GrupoImposto entidade)
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
