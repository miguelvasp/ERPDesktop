using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ERP.ModelView;

namespace ERP.DAL
{
    public class ConfGrupoImpostoItemDAL : IRepository<ConfGrupoImpostoItem>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ConfGrupoImpostoItemDAL()
        {

        }

        public IEnumerable<ConfGrupoImpostoItem> Get()
        {
            var cgii = db.ConfGrupoImpostoItem.ToList();
            return cgii.ToList();
        }

        public ConfGrupoImpostoItem GetByID(int id)
        {
            return db.ConfGrupoImpostoItem.Find(id);
        }

        public List<ConfGrupoImpostoItemModelView> GetByGrupoImpostoItem(int pId)
        {
            List<ConfGrupoImpostoItemModelView> lista = (from c in db.ConfGrupoImpostoItem
                                                      join ci in db.CodigoImposto on c.IdCodigoImposto equals ci.IdCodigoImposto
                                                      
                                                      from  v in db.ValoresImposto
                                                      .Where(x => x.IdCodigoImposto == ci.IdCodigoImposto)
                                                      .DefaultIfEmpty()

                                                      from ct in db.CodigoTributacao
                                                      .Where(x => x.IdCodigoTributacao == c.IdCodigoTributacao)
                                                      .DefaultIfEmpty()

                                                      where c.IdGrupoImpostoItem == pId
                                                         select new ConfGrupoImpostoItemModelView
                                                      {
                                                          IdConfGrupoImpostoItem = c.IdConfGrupoImpostoItem,
                                                          CodigoImposto = ci.Descricao,
                                                          CodigoTributacao = ct.Descricao,
                                                          Isento = c.Isento == true ? "Sim" : "Não",
                                                          SemCredito = c.SemCreditoImposto == true ? "Sim" : "Não"
                                                      }).Distinct().ToList();
            return lista;
        }

        public List<ConfGrupoImpostoItem> getByParams(string prtCodigo)
        {
            List<ConfGrupoImpostoItem> cgi = new List<ConfGrupoImpostoItem>();
            cgi = (from a in db.ConfGrupoImpostoItem 
                   select a).ToList();

            return cgi;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.ConfGrupoImpostoItem
                                     join ci in db.CodigoImposto on c.IdCodigoImposto equals ci.IdCodigoImposto
                                     select new ComboItem
                                     {
                                         iValue = c.IdConfGrupoImpostoItem,
                                         Text = ci.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(ConfGrupoImpostoItem entidade)
        {
            db.ConfGrupoImpostoItem.Add(entidade);
        }

        public void Delete(int id)
        {
            ConfGrupoImpostoItem cgii = db.ConfGrupoImpostoItem.Find(id);
            db.ConfGrupoImpostoItem.Remove(cgii);
        }

        public void Update(ConfGrupoImpostoItem entidade)
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
