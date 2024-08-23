using ERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class CentroCustoDAL : Repository<CentroCusto>
    {
        public List<CentroCusto> getByParams(string prtCodigo, string prtDescricao)
        {
            List<CentroCusto> cc = new List<CentroCusto>();
            cc = (from c in db.CentroCusto
                  where c.Codigo.Contains(prtCodigo) &&
                      (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                  select c).OrderBy(o => o.Codigo).ToList();

            return cc;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from cc in db.CentroCusto
                                     select new ComboItem
                                     {
                                         iValue = cc.IdCentroCusto,
                                         Text = cc.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
