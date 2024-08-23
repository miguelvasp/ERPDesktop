using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class TipoTransacaoBancariaDAL : Repository<TipoTransacaoBancaria>
    {
        public List<TipoTransacaoBancaria> getByParams(string prtCodigo, string prtDescricao)
        {
            List<TipoTransacaoBancaria> ttb = new List<TipoTransacaoBancaria>();
            ttb = (from t in db.TipoTransacaoBancaria
                   where (prtCodigo == "" || t.Codigo.Contains(prtCodigo)) &&
                         (prtDescricao == "" || t.Descricao.Contains(prtDescricao))
                   select t).OrderBy(o => o.Codigo).ToList();

            return ttb;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from ttb in db.TipoTransacaoBancaria
                                     select new ComboItem
                                     {
                                         iValue = ttb.IdTipoTransacaoBancaria,
                                         Text = ttb.Codigo
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from t in db.TipoTransacaoBancaria
                                         select new GenericReport
                                         {
                                             Text1 = t.Codigo,
                                             Text2 = t.Descricao,
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}