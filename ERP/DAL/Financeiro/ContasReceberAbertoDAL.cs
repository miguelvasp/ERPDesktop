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
    public class ContasReceberAbertoDAL : Repository<ContasReceberAberto>
    {
        public ContasReceberAberto getProximoVencimento(int IdContasReceber)
        {
            var conta = (from c in db.ContasReceberAberto
                         where c.IdContasReceber == IdContasReceber
                         select c).OrderBy(x => x.Vencimento).FirstOrDefault();
            return conta;
        }

        public List<ContasReceberAberto> getByIdConta(int Id)
        {
            return (from c in db.ContasReceberAberto
                    where c.IdContasReceber == Id
                    select c).ToList();
        }
    }
}
