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
    public class PedidoBalcaoProdutoDAL : Repository<PedidoBalcaoProduto>
    {
        public List<PedidoBalcaoProduto> getByPedidoId(int Id)
        {
            return (from i in db.PedidoBalcaoProduto
                    where i.IdPedidoBalcao == Id
                    select i).ToList();
        }


        public void RateiaDesconto(int IdPedidoBalcao, decimal Desconto)
        {
            try
            {
                List<PedidoBalcaoProduto> lista = this.getByPedidoId(IdPedidoBalcao);

                decimal total = Convert.ToDecimal(lista.Sum(x => x.Qtde * x.ValorUnitario));

                decimal percentual = (Desconto * 100.00M) / total;

                foreach (PedidoBalcaoProduto p in lista)
                {
                    p.Desconto = (percentual * (p.ValorUnitario * p.Qtde)) / 100M;
                    p.ValorTotal = (p.ValorUnitario * p.Qtde) - p.Desconto;
                    this.Update(p);
                    this.Save();
                }
            }
            catch 
            { 
            }
            
        }


    }
}
