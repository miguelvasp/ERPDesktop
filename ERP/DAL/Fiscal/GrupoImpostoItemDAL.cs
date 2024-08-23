using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class GrupoImpostoItemDAL : Repository<GrupoImpostoItem>
    {
        public List<GrupoImpostoItem> getByParams(string prtCodigo, string prtDescricao)
        {
            List<GrupoImpostoItem> gir = new List<GrupoImpostoItem>();
            gir = (from g in db.GrupoImpostoItem
                   where (prtCodigo == "" || g.Codigo.Contains(prtCodigo)) &&
                   (prtDescricao == "" || g.Descricao.Contains(prtDescricao))
                   select g).OrderBy(o => o.Codigo).ToList();

            return gir;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.GrupoImpostoItem
                                     select new ComboItem()
                                     {
                                         Text = c.Descricao,
                                         iValue = c.IdGrupoImpostoItem
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from g in db.GrupoImpostoItem
                                         select new GenericReport
                                         {
                                             Text1 = g.Codigo,
                                             Text2 = g.Descricao,
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}
