using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.ModelView;
using System.Data.Entity;

namespace ERP.DAL
{
    public class PedidoCompraItemDAL : Repository<PedidoCompraItem>
    {
        public PedidoCompraItem GetItem(int pPedidoCompra, int pProduto)
        {
            PedidoCompraItem p = (from pi in db.PedidoCompraItem
                                  where pi.IdPedidoCompra == pPedidoCompra
                                  && pi.IdProduto == pProduto
                                  select pi).FirstOrDefault();
            return p;
        }
    }

    

}
