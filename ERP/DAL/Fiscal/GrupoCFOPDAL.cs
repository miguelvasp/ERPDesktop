using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class GrupoCFOPDAL : Repository<GrupoCFOP>
    {
        public List<GrupoCFOP> getByParams(string prtDescricao)
        {
            List<GrupoCFOP> gc = new List<GrupoCFOP>();
            gc = (from g in db.GrupoCFOP
                  where (prtDescricao == "" || g.Descricao.Contains(prtDescricao))
                  select g).OrderBy(o => o.Descricao).ToList();

            return gc;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.GrupoCFOP
                                     select new ComboItem()
                                     {
                                         Text = c.Descricao,
                                         iValue = c.IdGrupoCFOP
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from g in db.GrupoCFOP
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
