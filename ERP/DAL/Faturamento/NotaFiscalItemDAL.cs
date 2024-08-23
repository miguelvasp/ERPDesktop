using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using ERP.ModelView;

namespace ERP.DAL
{
    public class NotaFiscalItemDAL : Repository<NotaFiscalItem>
    {
        public List<NotaFiscalItem> GetByNF(int pIdNotaFiscal)
        {
            var lista = (from i in db.NotaFiscalItem
                         where i.IdNotaFiscal == pIdNotaFiscal
                         select i).OrderBy(x => x.Item).ToList();
            return lista;
        }

        public List<NotaFiscalItem> getItens(int pIdNotaFiscal)
        {
            return (from i in db.NotaFiscalItem
                    where i.IdNotaFiscal == pIdNotaFiscal
                    select i).ToList();
        }

        public List<NotaFiscalItemModelView> GetByNFGrid(int pIdNotaFiscal)
        {
            List<NotaFiscalItemModelView> lista = (from i in db.NotaFiscalItem

                                                   from u in db.Unidade
                                                   .Where(x => x.IdUnidade == i.IdUnidade)
                                                   .DefaultIfEmpty()

                                                   from n in db.ClassificacaoFiscal
                                                   .Where(x => x.IdNCM == i.IdNCM)
                                                   .DefaultIfEmpty()

                                                   from p in db.PedidoVenda
                                                   .Where(x => x.IdPedidoVenda == i.IdPedidoVenda)
                                                   .DefaultIfEmpty()

                                                   where i.IdNotaFiscal == pIdNotaFiscal

                                                   select new NotaFiscalItemModelView
                                                   {
                                                       Id = i.IdNotaFiscalItem,
                                                       Codigo = i.Codigo,
                                                       Descricao = i.Descricao,
                                                       NCM = n.NCM,
                                                       Qtde = i.Quantidade,
                                                       Unidade = u.UnidadeMedida,
                                                       ValorUnit = i.ValorUnitario,
                                                       ValorDesc = i.Desconto,
                                                       Total = i.ValorTotal,
                                                       BaseIcms = i.BaseICMS,
                                                       ValorICMS = i.ValorICMS,
                                                       ValorIPI = i.ValorIPI,
                                                       AliquotaICMS = i.AliquotaICMS,
                                                       AliquotaIPI = i.AliquotaIPI,
                                                       Pedido = p.PedidoNumero
                                                   }).ToList();
            return lista;
        }
    }
}
