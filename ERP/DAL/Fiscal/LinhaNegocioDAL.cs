using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class LinhaNegocioDAL : Repository<LinhaNegocio>
    {
        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from l in db.LinhaNegocio
                                         select new GenericReport
                                         {
                                             Text1 = l.Nome,
                                             Text2 = l.Descricao,
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}
