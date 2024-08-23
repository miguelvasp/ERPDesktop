using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class EmbalagemDAL : Repository<Embalagem>
    {
        public override IEnumerable<Embalagem> Get()
        {
            var tb = db.Embalagem.OrderBy(x => x.Descricao).ToList();
            return tb.ToList();
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from e in db.Embalagem
                                         select new GenericReport
                                         {
                                             Text1 = e.Descricao,
                                             Text2 = "",
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}
