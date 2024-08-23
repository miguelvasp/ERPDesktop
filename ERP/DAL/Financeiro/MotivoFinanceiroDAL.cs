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
    public class MotivoFinanceiroDAL : IRepository<MotivoFinanceiro>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public MotivoFinanceiroDAL()
        {

        }

        public IEnumerable<MotivoFinanceiro> Get()
        {
            var dp = db.MotivoFinanceiro.OrderBy(x => x.Nome).ToList();
            return dp.ToList();
        }

        public MotivoFinanceiro GetByID(int id)
        {
            return db.MotivoFinanceiro.Find(id);
        }

        public List<MotivoFinanceiro> getByParams(string prtNome, string prtDescricao)
        {
            List<MotivoFinanceiro> dp = new List<MotivoFinanceiro>();
            dp = (from mf in db.MotivoFinanceiro
                  where (prtNome == "" || mf.Nome.Contains(prtNome)) &&
                  (prtDescricao == "" || mf.Descricao.Contains(prtDescricao))
                  select mf).OrderBy(o => o.Nome).ToList();

            return dp;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from ac in db.MotivoFinanceiro
                                     select new ComboItem
                                     {
                                         iValue = ac.IdMotivoFinanceiro,
                                         Text = ac.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<ComboItem> GetComboFornecedor()
        {
            List<ComboItem> lista = (from ac in db.MotivoFinanceiro
                                     where ac.Fornecedor == true
                                     select new ComboItem
                                     {
                                         iValue = ac.IdMotivoFinanceiro,
                                         Text = ac.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(MotivoFinanceiro entidade)
        {
            db.MotivoFinanceiro.Add(entidade);
        }

        public void Delete(int id)
        {
            MotivoFinanceiro dp = db.MotivoFinanceiro.Find(id);
            db.MotivoFinanceiro.Remove(dp);
        }

        public void Update(MotivoFinanceiro entidade)
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