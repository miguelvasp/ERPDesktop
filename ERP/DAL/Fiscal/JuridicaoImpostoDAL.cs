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
    public class JuridicaoImpostoDAL : IRepository<JuridicaoImposto>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public JuridicaoImpostoDAL()
        {

        }

        public IEnumerable<JuridicaoImposto> Get()
        {
            var ji = db.JuridicaoImposto.ToList();
            return ji.ToList();
        }

        public JuridicaoImposto GetByID(int id)
        {
            return db.JuridicaoImposto.Find(id);
        }

        public List<JuridicaoImposto> getByParams(string prtCodigo, string prtDescricao)
        {
            List<JuridicaoImposto> ji = new List<JuridicaoImposto>();
            ji = (from a in db.JuridicaoImposto
                   where (prtCodigo == "" || a.Codigo.Contains(prtCodigo)) &&
                   (prtDescricao == "" || a.Descricao.Contains(prtDescricao))
                   select a).OrderBy(o => o.Codigo).ToList();

            return ji;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.JuridicaoImposto
                                     select new ComboItem
                                     {
                                         iValue = c.IdJuridicaoImposto,
                                         Text = c.Codigo
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }


        public void Insert(JuridicaoImposto entidade)
        {
            db.JuridicaoImposto.Add(entidade);
        }

        public void Delete(int id)
        {
            JuridicaoImposto ji = db.JuridicaoImposto.Find(id);
            db.JuridicaoImposto.Remove(ji);
        }

        public void Update(JuridicaoImposto entidade)
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
