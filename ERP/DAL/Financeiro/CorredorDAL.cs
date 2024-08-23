using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class CorredorDAL : Repository<Corredor>
    {
        public List<Corredor> getByParams(string prtCorredor, string prtNumero, string prtNome)
        {
            List<Corredor> dp = new List<Corredor>();
            dp = (from c in db.Corredor
                  where (prtCorredor == "" || c.CorredorLocal.Contains(prtCorredor)) &&
                  (prtNumero == "" || c.NumeroCorredor.Contains(prtNumero)) &&
                  (prtNome == "" || c.Nome.Contains(prtNome))
                  select c).OrderBy(o => o.Nome).ToList();

            return dp;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from ac in db.Corredor
                                     select new ComboItem
                                     {
                                         iValue = ac.IdCorredor,
                                         Text = ac.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<GenericReport> GetDataReport(List<Corredor> prtLst)
        {
            List<GenericReport> lista = (from r in prtLst
                                         select new GenericReport
                                         {
                                             Text1 = r.Deposito.Descricao,
                                             Text2 = r.CorredorLocal,
                                             Text3 = r.NumeroCorredor,
                                             Text4 = r.Nome
                                         }).OrderBy(o => o.Text2).ToList();

            return lista;
        }
    }
}