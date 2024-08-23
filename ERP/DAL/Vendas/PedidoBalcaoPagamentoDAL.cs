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
    public class PedidoBalcaoPagamentoDAL : Repository<PedidoBalcaoPagamento>
    {
        public List<PedidoBalcaoPagamento> getByPedidoId(int IdPedidoBalcao)
        {
            return (from l in db.PedidoBalcaoPagamento
                    where l.IdPedidoBalcao == IdPedidoBalcao
                    select l).ToList();
        }
    }
}
