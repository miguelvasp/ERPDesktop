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
    public class CodigoTributacaoDAL : IRepository<CodigoTributacao>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public CodigoTributacaoDAL()
        {

        }

        public IEnumerable<CodigoTributacao> Get()
        {
            var ct = db.CodigoTributacao.ToList();
            return ct.ToList();
        }

        public CodigoTributacao GetByID(int id)
        {
            return db.CodigoTributacao.Find(id);
        }

        public List<CodigoTributacao> getByParams(string prtCodigo, string prtDescricao)
        {
            List<CodigoTributacao> ct = new List<CodigoTributacao>();
            ct = (from c in db.CodigoTributacao
                   where (prtCodigo == "" || c.Codigo.Contains(prtCodigo)) &&
                   (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                   select c).OrderBy(o => o.Codigo).ToList();

            return ct;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = new List<ComboItem>();
            var aux = (from c in db.CodigoTributacao
                                     select new
                                     {
                                         c.IdCodigoTributacao,
                                         c.Codigo,
                                         c.Descricao
                                     }).OrderBy(x => x.Codigo).ToList();

            foreach(var i in aux)
            {
                ComboItem ci = new ComboItem();
                ci.iValue = i.IdCodigoTributacao;
                ci.Text = i.Codigo + "-" + i.Descricao;
                lista.Add(ci);
            }

            return lista;
        }

        public List<ComboItem> GetComboTipoImposto(int pTipoImposto)
        {
            List<ComboItem> lista = new List<ComboItem>();
            var aux = (from c in db.CodigoTributacao
                       where c.TipoImposto == pTipoImposto
                       select new
                       {
                           c.IdCodigoTributacao,
                           c.Codigo,
                           c.Descricao
                       }).OrderBy(x => x.Codigo).ToList();

            foreach (var i in aux)
            {
                ComboItem ci = new ComboItem();
                ci.iValue = i.IdCodigoTributacao;
                ci.Text = i.Codigo + "-" + i.Descricao;
                lista.Add(ci);
            }

            return lista;
        }

        public void Insert(CodigoTributacao entidade)
        {
            db.CodigoTributacao.Add(entidade);
        }

        public void Delete(int id)
        {
            CodigoTributacao ct = db.CodigoTributacao.Find(id);
            if (ct != null)
            {
                db.CodigoTributacao.Remove(ct);
            }
        }

        public void Update(CodigoTributacao entidade)
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
