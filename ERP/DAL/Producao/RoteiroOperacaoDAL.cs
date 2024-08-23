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
    public class RoteiroOperacaoDAL : Repository<RoteiroOperacao>
    {
        public List<RoteiroOperacao> GetByRoteiroId(int id)
        {
            List<RoteiroOperacao> lista = (from r in db.RoteiroOperacao
                                           where r.IdRoteiro == id
                                           select r).ToList();
            return lista;
        }
    }
}
