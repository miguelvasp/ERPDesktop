using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class PedidoVendaCentroCustoDAL : Repository<PedidoVendaCentroCusto>
    {
        public List<int?> GetValoresCadastrados(int idPedidoVenda)
        {
            List<int?> lista = (from p in db.PedidoVendaCentroCusto
                                where p.IdPedidoVenda == idPedidoVenda
                                select p.IdValoresCentroCusto).ToList();
            return lista;
        }

        public List<int> GetIdsPedidoVendasCentroCusto(int idPedidoVenda)
        {
            List<int> lista = (from p in db.PedidoVendaCentroCusto
                                where p.IdPedidoVenda == idPedidoVenda
                                select p.IdPedidoVendaCentroCusto).ToList();
            return lista;
        }

        

        public List<CentroCustoValoresModelView> GetByPedidoVenda(int Id)
        {
            List<CentroCustoValoresModelView> lista = (from c in db.CentroCusto
                                                       join v in db.ValoresCentroCusto on c.IdCentroCusto equals v.IdCentroCusto
                                                       join cf in db.PedidoVendaCentroCusto on v.IdValoresCentroCusto equals cf.IdValoresCentroCusto
                                                       where cf.IdPedidoVenda == Id
                                                       select new CentroCustoValoresModelView
                                                       {
                                                           Id = cf.IdPedidoVendaCentroCusto,
                                                           CentroCusto = c.Descricao,
                                                           Nome = v.Nome
                                                       }).OrderBy(x => x.CentroCusto).ToList();
            return lista;
        }
        
    }
}
