using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class AprovacaoDocumentoDAL : IRepository<AprovacaoDocumento>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public AprovacaoDocumentoDAL()
        {
        }

        public IEnumerable<AprovacaoDocumento> Get()
        {
            var tb = db.AprovacaoDocumento.ToList();
            return tb.ToList();
        }

        public AprovacaoDocumento GetByID(int id)
        {
            return db.AprovacaoDocumento.Find(id);
        }

        public AprovacaoNivel GetFirtsByNivel(string sigla)
        {
            var n = (from ad in db.AprovacaoDocumento
                     join an in db.AprovacaoNivel on ad.IdAprovacaoDocumento equals an.IdAprovacaoDocumento
                     where ad.Sigla == sigla
                     select an).OrderBy(x => x.Sequencia).FirstOrDefault();
            return n;
        }

        public AprovacaoNivel GetLastByNivel(string sigla)
        {
            var n = (from ad in db.AprovacaoDocumento
                     join an in db.AprovacaoNivel on ad.IdAprovacaoDocumento equals an.IdAprovacaoDocumento
                     select an).OrderByDescending(x => x.Sequencia).FirstOrDefault();
            return n;
        }

        public void Insert(AprovacaoDocumento entidade)
        {
            db.AprovacaoDocumento.Add(entidade);
        }

        public void Delete(int id)
        {
            AprovacaoDocumento tb = db.AprovacaoDocumento.Find(id);
            db.AprovacaoDocumento.Remove(tb);
        }

        public void Update(AprovacaoDocumento entidade)
        {
            db.Entry(entidade).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
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
