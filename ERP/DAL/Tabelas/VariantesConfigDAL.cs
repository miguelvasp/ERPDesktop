using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class VariantesConfigDAL : Repository<VariantesConfig>
    {
        public override IEnumerable<VariantesConfig> Get()
        {
            var tb = db.VariantesConfig.OrderBy(x => x.Descricao).ToList();
            return tb.ToList();
        }

        public IEnumerable<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from ge in db.VariantesConfig
                                     select new ComboItem
                                     {
                                         iValue = ge.IdVariantesConfig,
                                         Text = ge.Descricao
                                     }).OrderBy(x => x.Text).ToList();

            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from v in db.VariantesConfig
                                         select new GenericReport
                                         {
                                             Text1 = v.Codigo,
                                             Text2 = v.Descricao,
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}
