using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ERP.DAL
{
    public class DocumentoFiscalDAL : IRepository<DocumentoFiscal>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public DocumentoFiscalDAL()
        {
        }

        public IEnumerable<DocumentoFiscal> Get()
        {
            var d = db.DocumentoFiscal.ToList();
            return d.ToList();
        }

        public DocumentoFiscal GetByID(int id)
        {
            return db.DocumentoFiscal.Find(id);
        }

        public List<DocumentoFiscal> getByParams(string prtCodigo,string prtDescricao)
        {
            List<DocumentoFiscal> d = new List<DocumentoFiscal>();
            d = (from a in db.DocumentoFiscal
                 where (prtCodigo == "" || a.Codigo.Contains(prtCodigo)) &&
                       (prtDescricao == "" || a.Descricao.Contains(prtDescricao))
                 select a).OrderBy(o => o.Codigo).ToList();

            return d;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.DocumentoFiscal
                                     select new ComboItem
                                     {
                                         iValue = c.IdDocumentoFiscal,
                                         Text = c.Codigo
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(DocumentoFiscal entidade)
        {
            db.DocumentoFiscal.Add(entidade);
        }

        public void Delete(int id)
        {
            DocumentoFiscal d = db.DocumentoFiscal.Find(id);
            db.DocumentoFiscal.Remove(d);
        }

        public void Update(DocumentoFiscal entidade)
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

