using ERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class ChaveReducaoDAL : Repository<ChaveReducao>
    {
        public List<ChaveReducao> getByParams(string prtCodigo, string prtDescricao)
        {
            List<ChaveReducao> c = new List<ChaveReducao>();
            c = (from a in db.ChaveReducao
                 where (prtCodigo == "" || a.Codigo.Contains(prtCodigo)) &&
                 (prtDescricao == "" || a.Descricao.Contains(prtDescricao))
                 select a).OrderBy(o => o.Codigo).ToList();

            return c;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.ChaveReducao
                                     select new ComboItem
                                     {
                                         iValue = c.IdChaveReducao,
                                         Text = c.Codigo
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
