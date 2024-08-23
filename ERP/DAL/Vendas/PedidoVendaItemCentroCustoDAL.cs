using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class PedidoVendaItemCentroCustoDAL : Repository<PedidoVendaItemCentroCusto>
    {
        public List<int?> GetValoresCadastrados(int idPedidoVendaItem)
        {
            List<int?> lista = (from p in db.PedidoVendaItemCentroCusto
                                where p.IdPedidoVendaItem == idPedidoVendaItem
                                select p.IdValoresCentroCusto).ToList();
            return lista;
        }

        public List<int> GetIdsPedidoVendasItemCentroCusto(int idPedidoVendaItem)
        {
            List<int> lista = (from p in db.PedidoVendaItemCentroCusto
                               where p.IdPedidoVendaItem == idPedidoVendaItem
                               select p.IdPedidoVendaItemCentroCusto).ToList();
            return lista;
        }

        public List<PedidoVendaItemCentroCusto> GetCentros(int IdPedidoVendaItem)
        {
            return (from c in db.PedidoVendaItemCentroCusto
                    where c.IdPedidoVendaItem == IdPedidoVendaItem
                    select c).ToList();
        }


        public List<CentroCustoValoresModelView> GetByPedidoVendaItem(int Id)
        {
            List<CentroCustoValoresModelView> lista = (from c in db.CentroCusto
                                                       join v in db.ValoresCentroCusto on c.IdCentroCusto equals v.IdCentroCusto
                                                       join cf in db.PedidoVendaItemCentroCusto on v.IdValoresCentroCusto equals cf.IdValoresCentroCusto
                                                       where cf.IdPedidoVendaItem == Id
                                                       select new CentroCustoValoresModelView
                                                       {
                                                           Id = cf.IdPedidoVendaItemCentroCusto,
                                                           CentroCusto = c.Descricao,
                                                           Nome = v.Nome
                                                       }).OrderBy(x => x.CentroCusto).ToList();
            return lista;
        }
    }
}
