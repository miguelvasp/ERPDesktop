using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class LocalProducaoDAL : Repository<LocalProducao>
    {
        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.LocalProducao
                                     select new ComboItem
                                     {
                                         iValue = c.IdLocalProducao,
                                         Text = c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }


}
