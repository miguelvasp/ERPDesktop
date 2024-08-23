using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class PedidoCompraCentroCustoDAL : Repository<PedidoCompraCentroCusto>
    {
        public List<int?> GetValoresCadastrados(int idPedidoCompra)
        {
            List<int?> lista = (from p in db.PedidoCompraCentroCusto
                                where p.IdPedidoCompra == idPedidoCompra
                                select p.IdValoresCentroCusto).ToList();
            return lista;
        }

        public List<int> GetIdsPedidoCompraCentroCusto(int idPedidoCompra)
        {
            List<int> lista = (from p in db.PedidoCompraCentroCusto
                               where p.IdPedidoCompra== idPedidoCompra
                               select p.IdPedidoCompraCentroCusto).ToList();
            return lista;
        }

        public List<CentroCustoValoresModelView> GetByPedidoCompra(int Id)
        {
            List<CentroCustoValoresModelView> lista = (from c in db.CentroCusto
                                                       join v in db.ValoresCentroCusto on c.IdCentroCusto equals v.IdCentroCusto
                                                       join cf in db.PedidoCompraCentroCusto on v.IdValoresCentroCusto equals cf.IdValoresCentroCusto
                                                       where cf.IdPedidoCompra == Id
                                                       select new CentroCustoValoresModelView
                                                       {
                                                           Id = cf.IdPedidoCompraCentroCusto,
                                                           CentroCusto = c.Descricao,
                                                           Nome = v.Nome
                                                       }).OrderBy(x => x.CentroCusto).ToList();
            return lista;
        }
    }
}
