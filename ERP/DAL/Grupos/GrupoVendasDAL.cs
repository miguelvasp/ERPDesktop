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
    public class GrupoVendasDAL : IRepository<GrupoVendas>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public GrupoVendasDAL()
        {

        }

        public IEnumerable<GrupoVendas> Get()
        {
            var seg = db.GrupoVendas.ToList();
            return seg.ToList();
        }

        public GrupoVendas GetByID(int id)
        {
            return db.GrupoVendas.Find(id);
        }

        public List<GrupoVendas> getByParams(string prtCodigo, string prtDescricao)
        {
            List<GrupoVendas> gv = new List<GrupoVendas>();
            gv = (from t in db.GrupoVendas
                   where (prtCodigo == "" || t.Codigo.Contains(prtCodigo)) &&
                   (prtDescricao == "" || t.Descricao.Contains(prtDescricao))
                   select t).OrderBy(o => o.Codigo).ToList();

            return gv;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.GrupoVendas
                                     select new ComboItem
                                     {
                                         iValue = c.IdGrupoVendas,
                                         Text = c.Codigo
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(GrupoVendas entidade)
        {
            db.GrupoVendas.Add(entidade);
        }

        public void Delete(int id)
        {
            GrupoVendas seg = db.GrupoVendas.Find(id);
            db.GrupoVendas.Remove(seg);
        }

        public void Update(GrupoVendas entidade)
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