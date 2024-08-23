using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class GrupoItensSuplementaresDAL : Repository<GrupoItensSuplementares>
    {
        public override IEnumerable<GrupoItensSuplementares> Get()
        {
            var tb = db.GrupoItensSuplementares.OrderBy(x => x.Descricao).ToList();
            return tb.ToList();
        }

        public IEnumerable<ComboItem> getCombo()
        {
            List<ComboItem> lista = (from ge in db.GrupoItensSuplementares
                                     select new ComboItem
                                     {
                                         iValue = ge.IdGrupoItensSuplementares,
                                         Text = ge.Descricao
                                     }).OrderBy(x => x.Text).ToList();

            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from g in db.GrupoItensSuplementares
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
