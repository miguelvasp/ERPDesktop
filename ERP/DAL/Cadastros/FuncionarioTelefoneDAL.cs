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
    public class FuncionarioTelefoneDAL: IRepository<FuncionarioTelefone>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public FuncionarioTelefoneDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<FuncionarioTelefone> Get()
        {
            var tb = db.FuncionarioTelefone.ToList();
            return tb.ToList();
        }

        public FuncionarioTelefone GetByID(int id)
        {
            return db.FuncionarioTelefone.Find(id);
        }

        public void Insert(FuncionarioTelefone entidade)
        {
            db.FuncionarioTelefone.Add(entidade);
        }

        public void Delete(int id)
        {
            FuncionarioTelefone tb = db.FuncionarioTelefone.Find(id);
            db.FuncionarioTelefone.Remove(tb);
        }

        public void Update(FuncionarioTelefone entidade)
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