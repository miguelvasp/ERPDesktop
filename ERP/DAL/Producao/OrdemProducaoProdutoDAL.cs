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
    public class OrdemProducaoProdutoDAL : Repository<OrdemProducaoProduto>
    {
        public List<OrdemProducaoProduto> getListByOP(int IdOrdemProducao)
        {
            return (from p in db.OrdemProducaoProduto
                    where p.IdOrdemProducao == IdOrdemProducao
                    select p).ToList();
        }
    }
}
