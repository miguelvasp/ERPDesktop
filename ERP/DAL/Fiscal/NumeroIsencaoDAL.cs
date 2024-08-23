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
    public class NumeroIsencaoDAL: IRepository<NumeroIsencao>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public NumeroIsencaoDAL()
        {
        }

        public IEnumerable<NumeroIsencao> Get()
        {
            var ni = db.NumeroIsencao.ToList();
            return ni.ToList();
        }

        public NumeroIsencao GetByID(int id)
        {
            return db.NumeroIsencao.Find(id);
        }

        public List<NumeroIsencao> getByParams(string prtNome)
        {
            List<NumeroIsencao> ni = new List<NumeroIsencao>();
            ni = (from n in db.NumeroIsencao
                   where (prtNome == "" || n.Nome.Contains(prtNome)) 
                   select n).OrderBy(o => o.Nome).ToList();

            return ni;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from ac in db.NumeroIsencao
                                     select new ComboItem
                                     {
                                         iValue = ac.IdNumeroIsencao,
                                         Text = ac.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(NumeroIsencao entidade)
        {
            db.NumeroIsencao.Add(entidade);
        }

        public void Delete(int id)
        {
            NumeroIsencao ni = db.NumeroIsencao.Find(id);
            db.NumeroIsencao.Remove(ni);
        }

        public void Update(NumeroIsencao entidade)
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