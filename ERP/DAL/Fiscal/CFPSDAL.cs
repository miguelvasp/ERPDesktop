using ERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class CFPSDAL : Repository<CFPS>
    {
        public List<CFPS> getByParams(string prtCodigo, string prtDescricao)
        {
            List<CFPS> cfps = new List<CFPS>();
            cfps = (from c in db.CFPS
                    where (prtCodigo == "" || c.CFPSCod.Contains(prtCodigo)) &&
                    (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                    select c).OrderBy(o => o.CFPSCod).ToList();

            return cfps;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.CFPS
                                     select new ComboItem()
                                     {
                                         Text = c.Descricao,
                                         iValue = c.IdCFPS
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
