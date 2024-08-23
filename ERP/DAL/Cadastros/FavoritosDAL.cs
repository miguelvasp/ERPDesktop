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
    public class FavoritosDAL : IRepository<Favoritos>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public FavoritosDAL()
        {
           
        }

        public IEnumerable<Favoritos> Get()
        {
            var tb = db.Favoritos.ToList();
            return tb.ToList();
        }

        public Favoritos GetByID(int id)
        {
            return db.Favoritos.Find(id);
        }

        public List<Favoritos> getByUsuario(int IdUsuario)
        {
            var lista = (from f in db.Favoritos
                         where f.IdUsuario == IdUsuario
                         select f).OrderBy(x => x.Grupo).ToList();
            return lista;
        }

        public void Insert(int IdUsuario, string Form, string Nome, string Grupo)
        {
            Favoritos f = new Favoritos();
            f.IdUsuario = IdUsuario;
            f.Form = Form;
            f.Nome = Nome;
            f.Grupo = Grupo;
            db.Favoritos.Add(f);
            db.SaveChanges();
        }

        public void Insert(Favoritos entidade)
        {
            db.Favoritos.Add(entidade);
        }

        public void Delete(int id)
        {
            Favoritos tb = db.Favoritos.Find(id);
            db.Favoritos.Remove(tb);
        }

        public void Delete(string frm, int IdUsuario)
        {
            Favoritos f = db.Favoritos.Where(x => x.Form == frm & x.IdUsuario == IdUsuario).FirstOrDefault();
            if(f != null)
            {
                db.Favoritos.Remove(f);
                db.SaveChanges();
            }
        }

        public void Update(Favoritos entidade)
        {
            db.Entry(entidade).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
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
