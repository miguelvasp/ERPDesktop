using ERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class ChaveMinemaxDAL : Repository<ChaveMinemax>
    {
        public List<ChaveMinemax> getByParams(string prtCodigo, string prtDescricao)
        {
            List<ChaveMinemax> c = new List<ChaveMinemax>();
            c = (from a in db.ChaveMinemax
                 where (prtCodigo == "" || a.Codigo.Contains(prtCodigo)) &&
                 (prtDescricao == "" || a.Descricao.Contains(prtDescricao))
                 select a).OrderBy(o => o.Codigo).ToList();

            return c;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.ChaveMinemax
                                     select new ComboItem
                                     {
                                         iValue = c.IdChaveMinemax,
                                         Text = c.Codigo
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
