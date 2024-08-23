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
    public class NotaFiscalObsDAL : Repository<NotaFiscalObs>
    {
        public List<NotaFiscalObs> getByNotaId(int id)
        {
            return (from o in db.NotaFiscalObs
                    where o.IdNotaFiscal == id
                    select o).ToList();
        }
    }
}
