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
    public class MetodoPagamentoDAL : IRepository<MetodoPagamento>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public MetodoPagamentoDAL()
        {
        }

        public IEnumerable<MetodoPagamento> Get()
        {
            var mp = db.MetodoPagamento.ToList();
            return mp.ToList();
        }

        public MetodoPagamento GetByID(int id)
        {
            return db.MetodoPagamento.Find(id);
        }

        public void Insert(MetodoPagamento entidade)
        {
            db.MetodoPagamento.Add(entidade);
        }

        public void Delete(int id)
        {
            MetodoPagamento mp = db.MetodoPagamento.Find(id);
            db.MetodoPagamento.Remove(mp);
        }

        public void Update(MetodoPagamento entidade)
        {
            db.Entry(entidade).State = EntityState.Modified;
        }

        public List<MetodoPagamento> getByParams(string prtNome)
        {
            List<MetodoPagamento> mp = new List<MetodoPagamento>();
            mp = (from p in db.MetodoPagamento
                    where p.Nome.Contains(prtNome) 
                    select p).OrderBy(o => o.Nome).ToList();

            return mp;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from f in db.MetodoPagamento
                                     select new ComboItem
                                     {
                                         iValue = f.IdMetodoPagamento,
                                         Text = f.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
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
