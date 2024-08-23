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
    public class CodigoImpostoDAL : IRepository<CodigoImposto>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public CodigoImpostoDAL()
        {
           
        }

        public IEnumerable<CodigoImposto> Get()
        {
            var ci = db.CodigoImposto.ToList();
            return ci.ToList();
        }

        public CodigoImposto GetByID(int id)
        {
            return db.CodigoImposto.Find(id);
        }

        

        public List<CodigoImposto> getByParams(string prtDescricao)
        {
            List<CodigoImposto> ci = new List<CodigoImposto>();
            ci = (from c in db.CodigoImposto
                   where (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                   select c).OrderBy(o => o.Descricao).ToList();

            return ci;
        }

        public List<CodImpMV> getByParamsMV(string prtDescricao)
        {
            List<CodImpMV> ci = new List<CodImpMV>();
            ci = (from c in db.CodigoImposto
                  where (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                  select new CodImpMV
                  {
                      IdCodigoImposto = c.IdCodigoImposto,
                      Descricao = c.Descricao,
                      TipoImposto = c.TipoImposto == 1 ? "IPI" :
                                         c.TipoImposto == 2 ? "PIS" :
                                         c.TipoImposto == 3 ? "ICMS" :
                                         c.TipoImposto == 4 ? "COFINS" :
                                         c.TipoImposto == 5 ? "ISS" :
                                         c.TipoImposto == 6 ? "IRRF" :
                                         c.TipoImposto == 7 ? "INSS" :
                                         c.TipoImposto == 8 ? "Imposto de Importação" :
                                         c.TipoImposto == 9 ? "Outros Impostos" :
                                         c.TipoImposto == 10 ? "CSLL" :
                                         c.TipoImposto == 11 ? "ICMSST" :
                                         c.TipoImposto == 12 ? "ICMSDiff" : "-"
                  }).OrderBy(o => o.Descricao).ToList();

            return ci;
        }

        public ValoresImposto ConsultaPercentualPorData(int pIdCodigoImposto)
        {
            var percentual = (from v in db.ValoresImposto
                              where v.IdCodigoImposto == pIdCodigoImposto
                              & DbFunctions.TruncateTime(DateTime.Now) >= DbFunctions.TruncateTime(v.De)
                              & DbFunctions.TruncateTime(DateTime.Now) <= DbFunctions.TruncateTime(v.Ate) 
                              select v).FirstOrDefault();
            return percentual;
        }

        public List<CodigoImposto> GetCodigosDisponiveis(List<int> CodigosUsados)
        {
            var lista = (from c in db.CodigoImposto
                         where !CodigosUsados.Contains(c.IdCodigoImposto)
                         select c).OrderBy(x => x.Descricao).ToList();
            return lista;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.CodigoImposto
                                     select new ComboItem
                                     {
                                         iValue = c.IdCodigoImposto,
                                         Text = c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(CodigoImposto entidade)
        {
            db.CodigoImposto.Add(entidade);
        }

        public void Delete(int id)
        {
            CodigoImposto ci = db.CodigoImposto.Find(id);
            if (ci != null)
            {
                db.CodigoImposto.Remove(ci);
            }
        }

        public void Update(CodigoImposto entidade)
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
