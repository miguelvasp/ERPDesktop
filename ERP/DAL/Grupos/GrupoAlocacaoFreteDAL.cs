using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class GrupoAlocacaoFreteDAL : Repository<GrupoAlocacaoFrete>
    {
        public override IEnumerable<GrupoAlocacaoFrete> Get()
        {
            var tb = db.GrupoAlocacaoFrete.OrderBy(x => x.Descricao).ToList();
            return tb.ToList();
        }

        public IEnumerable<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from ge in db.GrupoAlocacaoFrete
                                     select new ComboItem
                                     {
                                         iValue = ge.IdGrupoAlocacaoFrete,
                                         Text = ge.Descricao
                                     }).OrderBy(x => x.Text).ToList();

            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from g in db.GrupoAlocacaoFrete
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
