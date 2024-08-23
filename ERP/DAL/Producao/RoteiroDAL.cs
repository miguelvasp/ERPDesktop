using ERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class RoteiroDAL : Repository<Roteiro>
    {
        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.Roteiro
                                     select new ComboItem()
                                     {
                                         Text = c.Descricao,
                                         iValue = c.IdRoteiro
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
