using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class GrupoSeriesDAL : Repository<GrupoSeries>
    {
        public override IEnumerable<GrupoSeries> Get()
        {
            var tb = db.GrupoSeries.OrderBy(x => x.Descricao).ToList();
            return tb.ToList();
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.GrupoSeries
                                     select new ComboItem()
                                     {
                                         Text = c.Descricao,
                                         iValue = c.IdGrupoSeries
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
        
        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from g in db.GrupoSeries
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
