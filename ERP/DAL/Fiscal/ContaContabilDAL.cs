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
    public class ContaContabilDAL : IRepository<ContaContabil>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ContaContabilDAL()
        {
        }

        public ContaContabilDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<ContaContabil> Get()
        {
            var cc = db.ContaContabil.ToList();
            return cc.ToList();
        }

        public ContaContabil GetByID(int id)
        {
            return db.ContaContabil.Find(id);
        }

        public List<ContaContabil> getByParams(string prtCodigo, string prtDescricao)
        {
            List<ContaContabil> cc = new List<ContaContabil>();
            cc = (from c in db.ContaContabil
                  where c.Codigo.Contains(prtCodigo) &&
                      (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                  select c).OrderBy(o => o.Codigo).ToList();

            return cc;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from b in db.ContaContabil
                                     select new ComboItem
                                     {
                                         iValue = b.IdContaContabil,
                                         Text = b.Codigo + " - " + b.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<ComboItem> GetComboByTipo(int prtTipoConta)
        {
            List<ComboItem> lista = (from cc in db.ContaContabil
                                     where cc.IdTipoConta == prtTipoConta
                                     select new ComboItem
                                     {
                                         iValue = cc.IdContaContabil,
                                         Text = cc.Codigo + " - " + cc.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }


        public void Insert(ContaContabil entidade)
        {
            db.ContaContabil.Add(entidade);
        }

        public void Delete(int id)
        {
            ContaContabil cc = db.ContaContabil.Find(id);
            db.ContaContabil.Remove(cc);
        }

        public void Update(ContaContabil entidade)
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
