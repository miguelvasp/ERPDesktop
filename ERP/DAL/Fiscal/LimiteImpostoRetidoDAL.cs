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
    public class LimiteImpostoRetidoDAL : Repository<LimiteImpostoRetido>
    {
        public List<LimiteImpostoRetido> GetByCodigoImpostoRetido(int idCodigoImposto)
        {
            var lista = (from l in db.LimiteImpostoRetido
                         where l.IdCodigoImpostoretido == idCodigoImposto
                         select l).ToList();
            return lista;
        }
    }
}
