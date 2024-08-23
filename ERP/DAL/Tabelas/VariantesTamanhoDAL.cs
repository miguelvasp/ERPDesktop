using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class VariantesTamanhoDAL : Repository<VariantesTamanho>
    {
        public override IEnumerable<VariantesTamanho> Get()
        {
            var tb = db.VariantesTamanho.OrderBy(x => x.Descricao).ToList();
            return tb.ToList();
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.VariantesTamanho
                                     select new ComboItem()
                                     {
                                         Text = c.Descricao,
                                         iValue = c.IdVariantesTamanho
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from v in db.VariantesTamanho
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
