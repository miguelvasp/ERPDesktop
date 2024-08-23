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
    public class ModeloDocumentoDAL: IRepository<ModeloDocumento>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ModeloDocumentoDAL()
        {
        }

        public IEnumerable<ModeloDocumento> Get()
        {
            var md = db.ModeloDocumento.ToList();
            return md.ToList();
        }

        public ModeloDocumento GetByID(int id)
        {
            return db.ModeloDocumento.Find(id);
        }

        public List<ModeloDocumento> getByParams(string prtCodigo, string prtDescricao)
        {
            List<ModeloDocumento> md = new List<ModeloDocumento>();
            md = (from a in db.ModeloDocumento
                 where (prtCodigo == "" || a.Codigo.Contains(prtCodigo)) &&
                       (prtDescricao == "" || a.Descricao.Contains(prtDescricao))
                 select a).OrderBy(o => o.Codigo).ToList();

            return md;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.ModeloDocumento
                                     select new ComboItem
                                     {
                                         iValue = c.IdModeloDocumento,
                                         Text = c.Codigo
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(ModeloDocumento entidade)
        {
            db.ModeloDocumento.Add(entidade);
        }

        public void Delete(int id)
        {
            ModeloDocumento md = db.ModeloDocumento.Find(id);
            db.ModeloDocumento.Remove(md);
        }

        public void Update(ModeloDocumento entidade)
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

