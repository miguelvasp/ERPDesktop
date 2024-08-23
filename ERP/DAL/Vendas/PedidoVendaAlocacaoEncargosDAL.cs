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
    public class PedidoVendaAlocacaoEncargosDAL : Repository<PedidoVendaAlocacaoEncargos>
    {
        public PedidoVendaAlocacaoEncargos GetByPedidoVenda(int pIdPedidoVenda)
        {
            PedidoVendaAlocacaoEncargos p = (from a in db.PedidoVendaAlocacaoEncargos
                                             where a.IdPedidoVenda == pIdPedidoVenda
                                             select a).FirstOrDefault();
            return p;
        }
    }
}
