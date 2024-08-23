using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class GrupoEncargosDAL : Repository<GrupoEncargos>
    {
        public override IEnumerable<GrupoEncargos> Get()
        {
            var tb = db.GrupoEncargos.OrderBy(x => x.Descricao).ToList();
            return tb.ToList();
        }

        public IEnumerable<ComboItem> getCombo()
        {
            List<ComboItem> lista = (from ge in db.GrupoEncargos
                                     select new ComboItem
                                     {
                                         iValue = ge.IdGrupoEncargos,
                                         Text = ge.Descricao
                                     }).OrderBy(x => x.Text).ToList();

            return lista;
        }

        

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from g in db.GrupoEncargos
                                         select new GenericReport
                                         {
                                             Text1 = g.Nome,
                                             Text2 = g.Descricao,
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}
