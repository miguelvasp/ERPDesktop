using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class ValoresCentroCustoDAL : IRepository<ValoresCentroCusto>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ValoresCentroCustoDAL()
        {
        }

        public IEnumerable<ValoresCentroCusto> Get()
        {
            var v = db.ValoresCentroCusto.ToList();
            return v.ToList();
        }

        public ValoresCentroCusto GetByID(int id)
        {
            return db.ValoresCentroCusto.Find(id);
        }

        public List<ValoresCentroCusto> GetByCentroCusto(int id)
        {
            var lista = (from v in db.ValoresCentroCusto
                         where v.IdCentroCusto == id
                         select v).OrderBy(x => x.Nome).ToList();
            return lista;
        }

        public List<ValoresCentroCusto> getByParams(string prtNome, string prtDescricao)
        {
            List<ValoresCentroCusto> vcc = new List<ValoresCentroCusto>();
            vcc = (from v in db.ValoresCentroCusto
                   where (prtNome == "" || v.Nome.Contains(prtNome)) &&
                   (prtDescricao == "" || v.Descricao.Contains(prtDescricao))
                   select v).OrderBy(o => o.Nome).ToList();

            return vcc;
        }

        public List<CentroCustoValoresModelView> GetListagem()
        {
            List<CentroCustoValoresModelView> lista = (from c in db.CentroCusto
                                                       join v in db.ValoresCentroCusto on c.IdCentroCusto equals v.IdCentroCusto
                                                       select new CentroCustoValoresModelView
                                                       {
                                                           Id = v.IdValoresCentroCusto,
                                                           CentroCusto = c.Descricao,
                                                           Nome = v.Nome
                                                       }).OrderBy(x => x.CentroCusto).ThenBy(x => x.Nome).ToList();
            return lista;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from v in db.ValoresCentroCusto 
                                     select new ComboItem
                                     {
                                         iValue = v.IdValoresCentroCusto,
                                         Text = v.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(ValoresCentroCusto entidade)
        {
            db.ValoresCentroCusto.Add(entidade);
        }

        public void Delete(int id)
        {
            ValoresCentroCusto v = db.ValoresCentroCusto.Find(id);
            if (v != null)
            {
                db.ValoresCentroCusto.Remove(v);
            }
        }

        public void Update(ValoresCentroCusto entidade)
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