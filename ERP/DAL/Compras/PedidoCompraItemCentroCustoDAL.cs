using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class PedidoCompraItemCentroCustoDAL : Repository<PedidoCompraItemCentroCusto>
    {
        public List<int?> GetValoresCadastrados(int idPedidoCompraItem)
        {
            List<int?> lista = (from p in db.PedidoCompraItemCentroCusto
                                where p.IdPedidoCompraItem == idPedidoCompraItem
                                select p.IdValoresCentroCusto).ToList();
            return lista;
        }

        public List<int> GetIdsPedidoCompraItemCentroCusto(int idPedidoCompraItem)
        {
            List<int> lista = (from p in db.PedidoCompraItemCentroCusto
                               where p.IdPedidoCompraItem == idPedidoCompraItem
                               select p.IdPedidoCompraItemCentroCusto).ToList();
            return lista;
        }

        public List<CentroCustoValoresModelView> GetByPedidoCompraItem(int Id)
        {
            List<CentroCustoValoresModelView> lista = (from c in db.CentroCusto
                                                       join v in db.ValoresCentroCusto on c.IdCentroCusto equals v.IdCentroCusto
                                                       join cf in db.PedidoCompraItemCentroCusto on v.IdValoresCentroCusto equals cf.IdValoresCentroCusto
                                                       where cf.IdPedidoCompraItem == Id
                                                       select new CentroCustoValoresModelView
                                                       {
                                                           Id = cf.IdPedidoCompraItemCentroCusto,
                                                           CentroCusto = c.Descricao,
                                                           Nome = v.Nome
                                                       }).OrderBy(x => x.CentroCusto).ToList();
            return lista;
        }
    }
}
