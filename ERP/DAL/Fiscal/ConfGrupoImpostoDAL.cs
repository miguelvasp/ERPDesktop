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
    public class ConfGrupoImpostoDAL : IRepository<ConfGrupoImposto>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ConfGrupoImpostoDAL()
        {
            
        }

        public IEnumerable<ConfGrupoImposto> Get()
        {
            var cgi = db.ConfGrupoImposto.ToList();
            return cgi.ToList();
        }

        public ConfGrupoImposto GetByID(int id)
        {
            return db.ConfGrupoImposto.Find(id);
        }

        public List<ConfGrupoImposto> getByParams(string prtCodigo)
        {
            List<ConfGrupoImposto> cgi = new List<ConfGrupoImposto>();
            //cgi = (from a in db.ConfGrupoImposto
            //       where (prtCodigo == "" || a.Codigo.Contains(prtCodigo))
            //       select a).OrderBy(o => o.Codigo).ToList();

            return cgi;
        }

        public List<ConfGrupoImpostoModalView> getByGrupoImposto(int IdGrupoImposto)
        {
            CodigoImpostoDAL dal = new CodigoImpostoDAL();
            List<ConfGrupoImpostoModalView> lista = (from c in db.ConfGrupoImposto
                                                     where c.IdGrupoImposto == IdGrupoImposto

                                                     from ci in db.CodigoImposto
                                                     .Where(x => x.IdCodigoImposto == c.IdCodigoImposto)
                                                     .DefaultIfEmpty()

                                                     from cis in db.CodigoIsencao
                                                     .Where(x => x.IdCodigoIsencao == c.IdCodigoIsencao)
                                                     .DefaultIfEmpty()

                                                     from ct in db.CodigoTributacao
                                                     .Where(x => x.IdCodigoTributacao == c.IdCodigoTributacao)
                                                     .DefaultIfEmpty()
                                                     select new ConfGrupoImpostoModalView
                                                     {
                                                         IdConfGrupoImposto = c.IdConfGrupoImposto,
                                                         CodigoImposto = ci.Descricao,
                                                         CodigoIsencao = cis.Descricao,
                                                         CodigoTributqacao =  ct.Descricao,
                                                         idCodigoImposto = ci.IdCodigoImposto,
                                                         ImpostoSobreUso = c.ImpostoSobreUso == null ? "" : c.ImpostoSobreUso == true ? "Sim" : "Não",
                                                         Isento = c.Isento == true ? "Sim" : "Não"
                                                     }).ToList();

            foreach(ConfGrupoImpostoModalView i in lista)
            {
                if(dal.ConsultaPercentualPorData(i.idCodigoImposto) != null)
                {
                    i.Percentual = dal.ConsultaPercentualPorData(i.idCodigoImposto).Aliquota;
                }
                
            }


            return lista; 
        }

        //public List<ComboItem> GetCombo()
        //{
        //    List<ComboItem> lista = (from c in db.ConfGrupoImposto
        //                             select new ComboItem
        //                             {
        //                                 iValue = c.IdConfGrupoImposto,
        //                                 Text = c.Codigo
        //                             }).OrderBy(x => x.Text).ToList();
        //    return lista;
        //}

        public void Insert(ConfGrupoImposto entidade)
        {
            db.ConfGrupoImposto.Add(entidade);
        }

        public void Delete(int id)
        {
            ConfGrupoImposto cgi = db.ConfGrupoImposto.Find(id);
            db.ConfGrupoImposto.Remove(cgi);
        }

        public void Update(ConfGrupoImposto entidade)
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
