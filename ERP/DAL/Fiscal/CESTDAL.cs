using ERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL.Fiscal
{
    public class CESTDAL : Repository<CEST>
    {
        public List<CEST> getByParams(string prtCodigo, string prtDescricao)
        {
            List<CEST> lista = new List<CEST>();
            lista = (from c in db.CEST
                    where (prtCodigo == "" || c.NCM.Contains(prtCodigo)) &&
                    (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                    select c).OrderBy(o => o.NCM).ToList();

            return lista;
        }

        public CEST getByCod(string Cest)
        {
            return (from c in db.CEST
                    where c.Cest.Replace(".", string.Empty) == Cest
                    select c).FirstOrDefault();
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.CEST
                                     select new ComboItem()
                                     {
                                         Text = c.Cest,
                                         iValue = c.IdCest
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }        
    }
}
