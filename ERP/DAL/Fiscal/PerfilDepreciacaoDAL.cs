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
   public class PerfilDepreciacaoDAL : IRepository<PerfilDepreciacao>, IDisposable
    {
       private DB_ERPContext db = new DB_ERPContext();

       public PerfilDepreciacaoDAL()
        {
        }

       public IEnumerable<PerfilDepreciacao> Get()
        {
            var pd = db.PerfilDepreciacao.ToList();
            return pd.ToList();
        }

       public PerfilDepreciacao GetByID(int id)
        {
            return db.PerfilDepreciacao.Find(id);
        }

       public List<PerfilDepreciacao> getByParams(string prtDescricao)
        {
            List<PerfilDepreciacao> pd = new List<PerfilDepreciacao>();
            pd = (from tb in db.PerfilDepreciacao
                   where (prtDescricao == "" || tb.Descricao.Contains(prtDescricao))
                   select tb).OrderBy(o => o.Descricao).ToList();

            return pd;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from tb in db.PerfilDepreciacao
                                     select new ComboItem
                                     {
                                         iValue = tb.IdPerfilDepreciacao,
                                         Text = tb.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(PerfilDepreciacao entidade)
        {
            db.PerfilDepreciacao.Add(entidade);
        }

        public void Delete(int id)
        {
            PerfilDepreciacao pd = db.PerfilDepreciacao.Find(id);
            db.PerfilDepreciacao.Remove(pd);
        }

        public void Update(PerfilDepreciacao entidade)
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