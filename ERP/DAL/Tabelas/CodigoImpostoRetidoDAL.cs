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
    public class CodigoImpostoRetidoDAL : IRepository<CodigoImpostoRetido>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public CodigoImpostoRetidoDAL()
        {
           
        }

        public IEnumerable<CodigoImpostoRetido> Get()
        {
            var ci = db.CodigoImpostoRetido.ToList();
            return ci.ToList();
        }

        public CodigoImpostoRetido GetByID(int id)
        {
            return db.CodigoImpostoRetido.Find(id);
        }


        public List<CodigoImpostoRetido> getByParams(string prtCodigo, string prtDescricao)
        {
            List<CodigoImpostoRetido> cir = new List<CodigoImpostoRetido>();
            cir = (from c in db.CodigoImpostoRetido
                   where (prtCodigo == "" || c.Codigo.Contains(prtCodigo)) &&
                  (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                  select c).OrderBy(o => o.Descricao).ToList();

            return cir;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.CodigoImpostoRetido
                                     select new ComboItem
                                     {
                                         iValue = c.IdCodigoImpostoRetido,
                                         Text = c.Codigo
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(CodigoImpostoRetido entidade)
        {
            db.CodigoImpostoRetido.Add(entidade);
        }

        public void Delete(int id)
        {
            CodigoImpostoRetido ci = db.CodigoImpostoRetido.Find(id);
            db.CodigoImpostoRetido.Remove(ci);
        }

        public void Update(CodigoImpostoRetido entidade)
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

