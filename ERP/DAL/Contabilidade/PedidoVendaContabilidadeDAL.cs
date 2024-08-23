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
    public class PedidoVendaContabilidadeDAL : Repository<PedidoVendaContabilidade>
    {
        public PedidoVendaContabilidade GetByPedidoItem(int IdPedidoItem, string TipoMovimento)
        {
            return (from c in db.PedidoVendaContabilidade
                    where c.IdPedidoVendaItem == IdPedidoItem
                    && c.TipoMovimento == TipoMovimento
                    && c.Historico == false
                    select c).FirstOrDefault();
        }

        public List<PedidoVendaContabilidade> GetByPedidoItem(int IdPedidoItem)
        {
            db.Configuration.LazyLoadingEnabled = true;
            return (from c in db.PedidoVendaContabilidade
                    where c.IdPedidoVendaItem == IdPedidoItem
                    select c).ToList();
        }
    }
}
