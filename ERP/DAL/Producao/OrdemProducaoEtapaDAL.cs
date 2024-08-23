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
    public class OrdemProducaoEtapaDAL : Repository<OrdemProducaoEtapa>
    {
        public List<OrdemProducaoEtapa> getListByOP(int IdOrdemProducao)
        {
            return (from e in db.OrdemProducaoEtapa
                    where e.IdOrdemProducao == IdOrdemProducao
                    select e).ToList();
        }
    }
}
