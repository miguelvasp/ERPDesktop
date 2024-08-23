using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class ImpostoRetidoDAL : Repository<ImpostoRetido>
    {
        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.ImpostoRetido
                                     select new ComboItem()
                                     {
                                         Text = c.Descricao,
                                         iValue = c.IdImpostoRetido
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from i in db.ImpostoRetido
                                         select new GenericReport
                                         {
                                             Text1 = i.Descricao,
                                             Text2 = "",
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}
