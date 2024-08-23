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
    public class ConfGrupoImpostosItemRetidoDAL : IRepository<ConfGrupoImpostosItemRetido>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ConfGrupoImpostosItemRetidoDAL()
        {
        }

        public IEnumerable<ConfGrupoImpostosItemRetido> Get()
        {
            var tb = db.ConfGrupoImpostosItemRetido.ToList();
            return tb.ToList();
        }

        public ConfGrupoImpostosItemRetido GetByID(int id)
        {
            return db.ConfGrupoImpostosItemRetido.Find(id);
        }

        public List<ConfImpostoRetidoModelView> GetByGrupoRetido(int pId)
        {
            List<ConfImpostoRetidoModelView> lista = (from c in db.ConfGrupoImpostosItemRetido
                                                      join ci in db.CodigoImpostoRetido on c.IdCodigoImpostoRetido equals ci.IdCodigoImpostoRetido
                                                      join v in db.ValoresImpostoRetido on ci.IdCodigoImpostoRetido equals v.IdCodigoImpostoRetido
                                                      where c.IdGrupoImpostoRetido == pId  
                                                      select new ConfImpostoRetidoModelView
                                                      {
                                                          IdConfGrupoImpostoRetido = c.IdConfGrupoImpostosItemRetido,
                                                          CodigoImposto = ci.Descricao,
                                                          Aliquota = v.Aliquota,
                                                          Exclusao = v.PercentualExclusao
                                                      }).Distinct().ToList();
            return lista;
        }



        public void Insert(ConfGrupoImpostosItemRetido entidade)
        {
            db.ConfGrupoImpostosItemRetido.Add(entidade);
        }

        public void Delete(int id)
        {
            ConfGrupoImpostosItemRetido tb = db.ConfGrupoImpostosItemRetido.Find(id);
            db.ConfGrupoImpostosItemRetido.Remove(tb);
        }

        public void Update(ConfGrupoImpostosItemRetido entidade)
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
