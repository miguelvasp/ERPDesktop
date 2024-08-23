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
    public class ConversaoUnidadeDAL: IRepository<ConversaoUnidade>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ConversaoUnidadeDAL()
        {
        }

        public IEnumerable<ConversaoUnidade> Get()
        {
            var c = db.ConversaoUnidade.ToList();
            return c.ToList();
        }

        public ConversaoUnidade GetByID(int id)
        {
            return db.ConversaoUnidade.Find(id);
        }

        public void Insert(ConversaoUnidade entidade)
        {
            db.ConversaoUnidade.Add(entidade);
        }

        public void Delete(int id)
        {
            ConversaoUnidade c = db.ConversaoUnidade.Find(id);
            if (c != null)
            {
                db.ConversaoUnidade.Remove(c);
            }
        }

        public void Update(ConversaoUnidade entidade)
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