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
    public class PedidoCompraAlocacaoEncargosDAL : Repository<PedidoCompraAlocacaoEncargos>
    {
        public PedidoCompraAlocacaoEncargos GetByPedidoCompra(int pIdPedidoCompra)
        {
            PedidoCompraAlocacaoEncargos p = (from a in db.PedidoCompraAlocacaoEncargos
                                             where a.IdPedidoCompra == pIdPedidoCompra
                                             select a).FirstOrDefault();
            return p;
        }
    }
}
