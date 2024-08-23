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
    public class MetodoDepreciacaoDAL: IRepository<MetodoDepreciacao>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public MetodoDepreciacaoDAL()
        {
        }

        public IEnumerable<MetodoDepreciacao> Get()
        {
            var md = db.MetodoDepreciacao.ToList();
            return md.ToList();
        }

        public MetodoDepreciacao GetByID(int id)
        {
            return db.MetodoDepreciacao.Find(id);
        }

        public List<MetodoDepreciacao> getByParams(string prtDescricao)
        {
            List<MetodoDepreciacao> md = new List<MetodoDepreciacao>();
            md = (from m in db.MetodoDepreciacao
                   where  (prtDescricao == "" || m.Descricao.Contains(prtDescricao))
                   select m).OrderBy(o => o.Descricao).ToList();

            return md;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.MetodoDepreciacao
                                     select new ComboItem
                                     {
                                         iValue = c.IdMetodoDepreciacao,
                                         Text = c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(MetodoDepreciacao entidade)
        {
            db.MetodoDepreciacao.Add(entidade);
        }

        public void Delete(int id)
        {
            MetodoDepreciacao md = db.MetodoDepreciacao.Find(id);
            db.MetodoDepreciacao.Remove(md);
        }

        public void Update(MetodoDepreciacao entidade)
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