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
    public class MatrizCFOPDAL : IRepository< MatrizCFOP>, IDisposable
    { private DB_ERPContext db = new DB_ERPContext();

    public MatrizCFOPDAL()
        {

        }

    public IEnumerable<MatrizCFOP> Get()
        {
            var mc = db.MatrizCFOP.ToList();
            return mc.ToList();
        }

        public  MatrizCFOP GetByID(int id)
        {
            return db.MatrizCFOP.Find(id);
        }

        public List<MatrizCFOP> getByParams(string prtDescricao)
        {
            List<MatrizCFOP> mc = new List<MatrizCFOP>();
            mc = (from m in db.MatrizCFOP
                  where (prtDescricao == "" || m.Descricao.Contains(prtDescricao))
                  select m).OrderBy(o => o.Descricao).ToList();

            return mc;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.MatrizCFOP
                                     select new ComboItem()
                                     {
                                         Text = c.Descricao,
                                         iValue = c.IdMatrizCFOP
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(MatrizCFOP entidade)
        {
            db.MatrizCFOP.Add(entidade);
        }

        public void Delete(int id)
        {
            MatrizCFOP mc = db.MatrizCFOP.Find(id);
            db.MatrizCFOP.Remove(mc);
        }

        public void Update(MatrizCFOP entidade)
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