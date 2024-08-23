using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class GrupoComissaoDAL : Repository<GrupoComissao>
    {
        public override IEnumerable<GrupoComissao> Get()
        {
            var gc = db.GrupoComissao.OrderBy(x => x.Descricao).ToList();
            return gc.ToList();
        }

        public List<GrupoComissao> getByParams(string prtDescricao)
        {
            List<GrupoComissao> cc = new List<GrupoComissao>();
            cc = (from c in db.GrupoComissao
                  where (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                  select c).OrderBy(o => o.Descricao).ToList();

            return cc;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.GrupoComissao
                                     select new ComboItem
                                     {
                                         iValue = c.IdGrupoComissao,
                                         Text = c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from g in db.GrupoComissao
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
