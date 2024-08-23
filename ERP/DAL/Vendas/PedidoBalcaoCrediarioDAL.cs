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
    public class PedidoBalcaoCrediarioDAL : Repository<PedidoBalcaoCrediario>
    {

        public List<PedidoBalcaoCrediario> getByIdPedidoBalcao(int IdPedidoBalcao)
        {
            return (from i in db.PedidoBalcaoCrediario
                    where i.IdPedidoBalcao == IdPedidoBalcao
                    select i).ToList();
        }
    }
}
