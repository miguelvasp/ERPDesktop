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
    public class CalendarioDataLinhasDAL : Repository<CalendarioDataLinhas>
    {
        public List<CalendarioDataLinhas> GetByDataId(int id)
        {
            return (from l in db.CalendarioDataLinhas
                    where l.IdCalendarioData == id
                    select l).ToList();
        }
    }
}
