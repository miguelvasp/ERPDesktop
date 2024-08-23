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
    public class TipoOperacaoBancariaDAL : IRepository<TipoOperacaoBancaria>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public TipoOperacaoBancariaDAL()
        {
        }

        public IEnumerable<TipoOperacaoBancaria> Get()
        {
            var tob = db.TipoOperacaoBancaria.ToList();
            return tob.ToList();
        }

        public TipoOperacaoBancaria GetByID(int id)
        {
            return db.TipoOperacaoBancaria.Find(id);
        }

        public List<TipoOperacaoBancaria> getByParams(string prtCodigo, string prtDescricao)
        {
            List<TipoOperacaoBancaria> tob = new List<TipoOperacaoBancaria>();
            tob = (from tb in db.TipoOperacaoBancaria
                   where (prtCodigo == "" || tb.Codigo.Contains(prtCodigo)) &&
                   (prtDescricao == "" || tb.Descricao.Contains(prtDescricao))
                   select tb).OrderBy(o => o.Codigo).ToList();

            return tob;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.TipoOperacaoBancaria
                                     select new ComboItem
                                     {
                                         iValue = c.IdTipoOperacaoBancaria,
                                         Text = c.Codigo + " - " + c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(TipoOperacaoBancaria entidade)
        {
            db.TipoOperacaoBancaria.Add(entidade);
        }

        public void Delete(int id)
        {
            TipoOperacaoBancaria tob = db.TipoOperacaoBancaria.Find(id);
            db.TipoOperacaoBancaria.Remove(tob);
        }

        public void Update(TipoOperacaoBancaria entidade)
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