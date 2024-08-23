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
    public class ModuloDAL: IRepository<Modulo>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ModuloDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<Modulo> Get()
        {
            var mod = db.Modulo.OrderBy(c => c.Nome).ToList();
            return mod;
        }

        public Modulo GetByID(int id)
        {
            return db.Modulo.Find(id);
        }

        public List<DropList> GetList()
        {
            var aux = (from c in db.Modulo
                       select new
                       {
                           Value = c.IdModulo,
                           Text = c.Descricao
                       }).OrderBy(x => x.Text).ToList();
            List<DropList> lista = new List<DropList>();
            foreach (var i in aux)
            {
                DropList d = new DropList();
                d.Text = i.Text;
                d.Value = i.Value.ToString();
                lista.Add(d);
            }
            return lista;
        }

        public List<Modulo> getByParams(string prtNome, string prtDescricao)
        {
            List<Modulo> modulo = new List<Modulo>();
            modulo = (from m in db.Modulo
                      where m.Nome.Contains(prtNome) &&
                      (prtDescricao == "" || m.Descricao.Contains(prtDescricao)) 
                      select m).OrderBy(o => o.Nome).ToList();

            return modulo;
        }

        public void Insert(Modulo entidade)
        {
            db.Modulo.Add(entidade);
        }

        public void Delete(int id)
        {
            Modulo mod = db.Modulo.Find(id);
            db.Modulo.Remove(mod);
        }

        public void Update(Modulo entidade)
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