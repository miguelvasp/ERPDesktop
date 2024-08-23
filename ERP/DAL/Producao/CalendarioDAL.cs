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
    public class CalendarioDAL : Repository<Calendario>
    {
        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from ac in db.Calendario
                                     select new ComboItem
                                     {
                                         iValue = ac.IdCalendario,
                                         Text = ac.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
