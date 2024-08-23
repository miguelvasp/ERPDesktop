using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class TipoItemDAL : Repository<TipoItem>
    {
        public override IEnumerable<TipoItem> Get()
        {
            var tb = db.TipoItem.OrderBy(x => x.Descricao).ToList();
            return tb.ToList();
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from t in db.TipoItem
                                         select new GenericReport
                                         {
                                             Text1 = t.Descricao,
                                             Text2 = "",
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}
