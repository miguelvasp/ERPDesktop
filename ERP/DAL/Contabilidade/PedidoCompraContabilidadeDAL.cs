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
    public class PedidoCompraContabilidadeDAL : Repository<PedidoCompraContabilidade>
    {
        public PedidoCompraContabilidade GetByPedidoItem(int IdPedidoItem, string TipoMovimento)
        {
            return (from c in db.PedidoCompraContabilidade
                    where c.IdPedidoCompraItem == IdPedidoItem
                    && c.TipoMovimento == TipoMovimento
                    && c.Historico == false
                    select c).FirstOrDefault();
        }

        public List<PedidoCompraContabilidade> GetByPedidoItem(int IdPedidoItem)
        {
            db.Configuration.LazyLoadingEnabled = true;
            return (from c in db.PedidoCompraContabilidade
                    where c.IdPedidoCompraItem == IdPedidoItem 
                    select c).ToList();
        }
    }
}
