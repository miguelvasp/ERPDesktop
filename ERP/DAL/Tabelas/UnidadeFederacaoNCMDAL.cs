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
    public class UnidadeFederacaoNCMDAL: IRepository<UnidadeFederacaoNCM>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public UnidadeFederacaoNCMDAL()
        {

        }

        public IEnumerable<UnidadeFederacaoNCM> Get()
        {
            var uf = db.UnidadeFederacaoNCM.ToList();
            return uf.ToList();
        }

        public UnidadeFederacaoNCM GetByID(int id)
        {
            return db.UnidadeFederacaoNCM.Find(id);
        }

        public List<UnidadeFederacaoNCM> getByParams(string prtUF, string prtCodigo)
        {
            List<UnidadeFederacaoNCM> uf = new List<UnidadeFederacaoNCM>();
            uf = (from u in db.UnidadeFederacaoNCM
                      where u.UnidadeFederacao.UF.Contains(prtUF) &&
                      (prtCodigo == "" || u.ClassificacaoFiscal.NCM.Contains(prtCodigo))
                      select u).OrderBy(o => o.ClassificacaoFiscal.NCM).ToList();

            return uf;
        }

        public void Insert(UnidadeFederacaoNCM entidade)
        {
            db.UnidadeFederacaoNCM.Add(entidade);
        }

        public void Delete(int id)
        {
            UnidadeFederacaoNCM uf = db.UnidadeFederacaoNCM.Find(id);
            db.UnidadeFederacaoNCM.Remove(uf);
        }

        public void Update(UnidadeFederacaoNCM entidade)
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
