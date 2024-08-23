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
    public class FuncionarioEnderecoDAL : IRepository<FuncionarioEndereco>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public FuncionarioEnderecoDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<FuncionarioEndereco> Get()
        {
            var tb = db.FuncionarioEndereco.ToList();
            return tb.ToList();
        }

        public FuncionarioEndereco GetByID(int id)
        {
            return db.FuncionarioEndereco.Find(id);
        }

        public void Insert(FuncionarioEndereco entidade)
        {
            db.FuncionarioEndereco.Add(entidade);
        }

        public void Delete(int id)
        {
            FuncionarioEndereco tb = db.FuncionarioEndereco.Find(id);
            db.FuncionarioEndereco.Remove(tb);
        }

        public void Update(FuncionarioEndereco entidade)
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