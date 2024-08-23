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
    public class CalendarioDataDAL : Repository<CalendarioData>
    {
        public List<CalendarioData> getByCalendarioID(int id)
        {
            List<CalendarioData> lista = (from c in db.CalendarioData
                                          where c.IdCalendario == id
                                          select c).ToList();
            return lista;
        }
    }
}
