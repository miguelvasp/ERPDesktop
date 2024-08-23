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
    public class UnidadeDAL: IRepository<Unidade>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public UnidadeDAL()
        {
        }

        public IEnumerable<Unidade> Get()
        {
            var u = db.Unidade.OrderBy(x => x.Descricao).ToList();
            return u.ToList();
        }
        
        public Unidade GetByID(int id)
        {
            return db.Unidade.Find(id);
        }

        public Unidade GetByUnidade(string unidade)
        {
            return db.Unidade.Where(x => x.UnidadeMedida == unidade).FirstOrDefault();
        }


        public List<Unidade> getByParams(string prtDescricao)
        {
            List<Unidade> uni = new List<Unidade>();
            uni = (from u in db.Unidade
                   where (prtDescricao == "" || u.Descricao.Contains(prtDescricao))
                   select u).OrderBy(o => o.Descricao).ToList();

            return uni;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.Unidade
                                     select new ComboItem
                                     {
                                         iValue = c.IdUnidade,
                                         Text = c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(Unidade entidade)
        {
            db.Unidade.Add(entidade);
        }

        public void Delete(int id)
        {
            Unidade u = db.Unidade.Find(id);
            db.Unidade.Remove(u);
        }

        public void Update(Unidade entidade)
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
