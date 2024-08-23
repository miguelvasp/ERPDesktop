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
    public class PerfilFornecedorDAL : IRepository<PerfilFornecedor>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public PerfilFornecedorDAL()
        {
            
        }

        public IEnumerable<PerfilFornecedor> Get()
        {
            var tb = db.PerfilFornecedor.ToList();
            return tb.ToList();
        }

        public PerfilFornecedor GetByID(int id)
        {
            return db.PerfilFornecedor.Find(id);
        }

        public List<PerfilFornecedor> getByParams(string prtNome, string prtDescricao)
        {
            List<PerfilFornecedor> pf = new List<PerfilFornecedor>();
            pf = (from p in db.PerfilFornecedor
                   where (prtNome == "" || p.Nome.Contains(prtNome)) &&
                   (prtDescricao == "" || p.Descricao.Contains(prtDescricao))
                   select p).OrderBy(o => o.Nome).ToList();

            return pf;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.PerfilFornecedor
                                     select new ComboItem()
                                     {
                                         Text = c.Nome,
                                         iValue = c.IdPerfilFornecedor
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(PerfilFornecedor entidade)
        {
            db.PerfilFornecedor.Add(entidade);
        }

        public void Delete(int id)
        {
            PerfilFornecedor tb = db.PerfilFornecedor.Find(id);
            db.PerfilFornecedor.Remove(tb);
        }

        public void Update(PerfilFornecedor entidade)
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
