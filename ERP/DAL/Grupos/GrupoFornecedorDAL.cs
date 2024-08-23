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
    public class GrupoFornecedorDAL : IRepository<GrupoFornecedor>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public GrupoFornecedorDAL()
        {

        }

        public IEnumerable<GrupoFornecedor> Get()
        {
            var gf = db.GrupoFornecedor.ToList();
            return gf.ToList();
        }

        public GrupoFornecedor GetByID(int id)
        {
            return db.GrupoFornecedor.Find(id);
        }

        public List<GrupoFornecedor> getByParams(string prtDescricao)
        {
            List<GrupoFornecedor> gf = new List<GrupoFornecedor>();
            gf = (from gFor in db.GrupoFornecedor
                  where (prtDescricao == "" || gFor.Descricao.Contains(prtDescricao))
                  select gFor).OrderBy(o => o.Descricao).ToList();

            return gf;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from f in db.GrupoFornecedor
                                     select new ComboItem
                                     {
                                         iValue = f.IdGrupoFornecedor,
                                         Text = f.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(GrupoFornecedor entidade)
        {
            db.GrupoFornecedor.Add(entidade);
        }

        public void Delete(int id)
        {
            GrupoFornecedor gf = db.GrupoFornecedor.Find(id);
            db.GrupoFornecedor.Remove(gf);
        }

        public void Update(GrupoFornecedor entidade)
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
