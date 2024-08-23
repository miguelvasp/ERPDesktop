using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using ERP.ModelView;

namespace ERP.DAL
{
    public class ConfGrupoImpostoRetidoDAL : IRepository<ConfGrupoImpostoRetido>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ConfGrupoImpostoRetidoDAL()
        {
        }

        public IEnumerable<ConfGrupoImpostoRetido> Get()
        {
            var tb = db.ConfGrupoImpostoRetido.ToList();
            return tb.ToList();
        }

        public ConfGrupoImpostoRetido GetByID(int id)
        {
            return db.ConfGrupoImpostoRetido.Find(id);
        }

        public List<ConfImpostoRetidoModelView> GetByGrupoRetido(int pId)
        {
            List<ConfImpostoRetidoModelView> lista = (from c in db.ConfGrupoImpostoRetido
                                                      join ci in db.CodigoImpostoRetido on c.IdCodigoImpostoRetido equals ci.IdCodigoImpostoRetido
                                                      join v in db.ValoresImpostoRetido on ci.IdCodigoImpostoRetido equals v.IdCodigoImpostoRetido
                                                      where c.IdGrupoImpostoRetido == pId 
                                                      select new ConfImpostoRetidoModelView
                                                      {
                                                          IdConfGrupoImpostoRetido = c.IdConfGrupoImpostoRetido,
                                                          CodigoImposto = ci.Descricao,
                                                          Aliquota = v.Aliquota,
                                                          Exclusao = v.PercentualExclusao
                                                      }).Distinct().ToList();
            return lista;
        }

        public void Insert(ConfGrupoImpostoRetido entidade)
        {
            db.ConfGrupoImpostoRetido.Add(entidade);
        }

        public void Delete(int id)
        {
            ConfGrupoImpostoRetido tb = db.ConfGrupoImpostoRetido.Find(id);
            db.ConfGrupoImpostoRetido.Remove(tb);
        }

        public void Update(ConfGrupoImpostoRetido entidade)
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
