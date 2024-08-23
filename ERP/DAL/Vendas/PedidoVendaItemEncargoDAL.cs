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
    public class PedidoVendaItemEncargoDAL : Repository<PedidoVendaItemEncargo>
    {
        public List<PedidoVendaItemEncargo> GetByItem(int idPedidoVendaItem)
        {
            return (from p in db.PedidoVendaItemEncargo
                    where p.IdPedidoVendaItem == idPedidoVendaItem
                    select p).ToList();
        }
    }
}
