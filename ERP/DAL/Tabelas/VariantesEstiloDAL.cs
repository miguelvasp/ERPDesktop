using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class VariantesEstiloDAL : Repository<VariantesEstilo>
    {
        public override IEnumerable<VariantesEstilo> Get()
        {
            var tb = db.VariantesEstilo.OrderBy(x => x.Descricao).ToList();
            return tb.ToList();
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.VariantesEstilo
                                     select new ComboItem()
                                     {
                                         Text = c.Descricao,
                                         iValue = c.IdVariantesEstilo
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from v in db.VariantesEstilo
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
