using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class VariantesGrupoDAL : Repository<VariantesGrupo>
    {
        public override IEnumerable<VariantesGrupo> Get()
        {
            var tb = db.VariantesGrupo.OrderBy(x => x.Descricao).ToList();
            return tb.ToList();
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from v in db.VariantesGrupo
                                         select new GenericReport
                                         {
                                             Text1 = v.Descricao,
                                             Text2 = "",
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}
