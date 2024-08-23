using ERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class PedidoVendaAprovacaoDAL : Repository<PedidoVendaAprovacao>
    {
        public List<PedidoVendaAprovacao> GetByIdPedido(int IdPedido)
        {
            var lista = (from p in db.PedidoVendaAprovacao
                         where p.IdPedidoVenda == IdPedido
                         select p).OrderBy(x => x.Data).ToList();
            return lista;
        }
    }
}
