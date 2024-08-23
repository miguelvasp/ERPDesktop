using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class GrupoCustoDAL : Repository<GrupoCusto>
    {
        public override IEnumerable<GrupoCusto> Get()
        {
            var tb = db.GrupoCusto.OrderBy(x => x.Descricao).ToList();
            return tb.ToList();
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from g in db.GrupoCusto
                                         select new GenericReport
                                         {
                                             Text1 = g.Descricao,
                                             Text2 = "",
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}
