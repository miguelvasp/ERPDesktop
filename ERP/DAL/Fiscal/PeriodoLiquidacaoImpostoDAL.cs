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
    public class PeriodoLiquidacaoImpostoDAL : IRepository<PeriodoLiquidacaoImposto>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public PeriodoLiquidacaoImpostoDAL()
        {
        }

        public IEnumerable<PeriodoLiquidacaoImposto> Get()
        {
            var pli = db.PeriodoLiquidacaoImposto.ToList();
            return pli.ToList();
        }

        public PeriodoLiquidacaoImposto GetByID(int id)
        {
            return db.PeriodoLiquidacaoImposto.Find(id);
        }

        public List<PeriodoLiquidacaoImposto> getByParams(string prtCodigo, string prtDescricao)
        {
            List<PeriodoLiquidacaoImposto> cm = new List<PeriodoLiquidacaoImposto>();
            cm = (from p in db.PeriodoLiquidacaoImposto
                  where (prtCodigo == "" || p.Codigo.Contains(prtCodigo)) &&
                    (prtDescricao == "" || p.Descricao.Contains(prtDescricao))
                  select p).OrderBy(o => o.Codigo).ToList();

            return cm;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from pli in db.PeriodoLiquidacaoImposto
                                     select new ComboItem
                                     {
                                         iValue = pli.IdPeriodoLiquidacaoImposto,
                                         Text = pli.Codigo
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(PeriodoLiquidacaoImposto entidade)
        {
            db.PeriodoLiquidacaoImposto.Add(entidade);
        }

        public void Delete(int id)
        {
            PeriodoLiquidacaoImposto pli = db.PeriodoLiquidacaoImposto.Find(id);
            db.PeriodoLiquidacaoImposto.Remove(pli);
        }

        public void Update(PeriodoLiquidacaoImposto entidade)
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
