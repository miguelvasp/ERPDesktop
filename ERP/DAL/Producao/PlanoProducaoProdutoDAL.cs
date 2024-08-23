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
    public class PlanoProducaoProdutoDAL : Repository<PlanoProducaoProduto>
    {
        public List<PlanoProducaoProduto> getByPlanoId(int IdPlanoProducao)
        {
            return (from p in db.PlanoProducaoProduto
                    where p.IdPlanoProducao == IdPlanoProducao
                    select p).ToList();
        }
    }
}
