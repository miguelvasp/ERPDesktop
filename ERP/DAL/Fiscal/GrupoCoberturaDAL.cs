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
    public class GrupoCoberturaDAL: IRepository<GrupoCobertura>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public GrupoCoberturaDAL()
        {

        }

        public IEnumerable<GrupoCobertura> Get()
        {
            var gc = db.GrupoCobertura.OrderBy(x => x.Descricao).ToList();
            return gc.ToList();
        }

        public GrupoCobertura GetByID(int id)
        {
            return db.GrupoCobertura.Find(id);
        }

        public List<GrupoCobertura> getByParams(string prtCodigo, string prtDescricao)
        {
            List<GrupoCobertura> cc = new List<GrupoCobertura>();
            cc = (from c in db.GrupoCobertura
                   where (prtCodigo == "" || c.Codigo.Contains(prtCodigo)) &&
                   (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                   select c).OrderBy(o => o.Codigo).ToList();

            return cc;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.GrupoCobertura
                                     select new ComboItem
                                     {
                                         iValue = c.IdGrupoCobertura,
                                         Text = c.Codigo
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(GrupoCobertura entidade)
        {
            db.GrupoCobertura.Add(entidade);
        }

        public void Delete(int id)
        {
            GrupoCobertura gc = db.GrupoCobertura.Find(id);
            db.GrupoCobertura.Remove(gc);
        }

        public void Update(GrupoCobertura entidade)
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