using ERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class FeriadoDAL : Repository<Feriado>
    {
        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from i in db.Feriado
                                     select new ComboItem
                                     {
                                         iValue = i.IdFeriado,
                                         Text = i.Descricao
                                     }).ToList();
            return lista;
        }
    }
}
