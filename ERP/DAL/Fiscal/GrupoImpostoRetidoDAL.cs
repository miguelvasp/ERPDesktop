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
    public class GrupoImpostoRetidoDAL: IRepository<GrupoImpostoRetido>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public GrupoImpostoRetidoDAL()
        {
        }

        public IEnumerable<GrupoImpostoRetido> Get()
        {
            var g = db.GrupoImpostoRetido.ToList();
            return g.ToList();
        }

        public GrupoImpostoRetido GetByID(int id)
        {
            return db.GrupoImpostoRetido.Find(id);
        }


        

        public List<GrupoImpostoRetido> getByParams(string prtCodigo, string prtDescricao)
        {
            List<GrupoImpostoRetido> gir = new List<GrupoImpostoRetido>();
            gir = (from g in db.GrupoImpostoRetido
                   where (prtCodigo == "" || g.Codigo.Contains(prtCodigo)) &&
                   (prtDescricao == "" || g.Descricao.Contains(prtDescricao))
                   select g).OrderBy(o => o.Codigo).ToList();

            return gir;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from g in db.GrupoImpostoRetido
                                     select new ComboItem
                                     {
                                         iValue = g.IdGrupoImpostoRetido,
                                         Text = g.Codigo + " - " + g.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(GrupoImpostoRetido entidade)
        {
            db.GrupoImpostoRetido.Add(entidade);
        }

        public void Delete(int id)
        {
            GrupoImpostoRetido g = db.GrupoImpostoRetido.Find(id);
            if (g != null)
            {
                db.GrupoImpostoRetido.Remove(g);
            }
        }

        public void Update(GrupoImpostoRetido entidade)
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

