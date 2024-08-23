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
    public class PedidoBalcaoDAL : Repository<PedidoBalcao>
    {
        public void apagaPagamentos(int id)
        {
            //PedidoBalcaoPagamentoDAL pdal = new PedidoBalcaoPagamentoDAL(); 
            //var pagamentos = (from p in db.PedidoBalcaoPagamento
            //                  where p.IdPedidoBalcao == id
            //                  select p).ToList();
            //foreach(var pg in pagamentos)
            //{
            //    pdal.Delete(pg.IdPedidoBalcaoPagamento);
            //    pdal.Save();
            //} 
        }

        public void apagaProdutos(int id)
        { 
            //PedidoBalcaoProdutoDAL mdal = new PedidoBalcaoProdutoDAL(); 
            //var produtos = (from pr in db.PedidoBalcaoProduto
            //                where pr.IdPedidoBalcao == id
            //                select pr).ToList();
            //foreach (var pr in produtos)
            //{
            //    mdal.Delete(pr.IdPedidoBalcaoProduto);
            //    mdal.Save();
            //}
        }


        public List<PedidoBalcaoView> getByParams(DateTime de, DateTime ate, int Pedido, string Nome, string Status)
        {
            return (from p in db.PedidoBalcao
                    join pr in db.PedidoBalcaoProduto on p.IdPedidoBalcao equals pr.IdPedidoBalcao

                    from c in db.CondicaoPagamento.Where(x => x.IdCondicaoPagamento == p.IdCondicaoPagamento).DefaultIfEmpty()
                    from v in db.Usuario.Where(x => x.IdUsuario == p.IdUsuario).DefaultIfEmpty()
                    from cx in db.Usuario.Where(x => x.IdUsuario == p.IdUsuarioPagamento).DefaultIfEmpty() 
                    orderby p.IdPedidoBalcao
                    where p.Data >= de
                    && p.Data <= ate
                    && (Pedido == 0 || p.IdPedidoBalcao == Pedido)
                    && (string.IsNullOrEmpty(Nome) || p.NomeBalcao.Contains(Nome))
                    && (Status == "Todos" || p.Status == Status)

                    select new PedidoBalcaoView
                    {
                        IdPedidoBalcao = p.IdPedidoBalcao,
                        Data = p.Data,
                        Status = p.Status,
                        NomeBalcao = p.NomeBalcao,
                        Condicao = c.Nome,
                        Vendedor = v.NomeCompleto,
                        Caixa = cx.NomeCompleto,
                        Dinheiro = p.Dinheiro,
                        Troco = p.Troco,
                        Total = p.Total,
                        Credito = p.Credito,
                        Debito = p.Debito
                    }).Distinct().ToList();
        }

        public List<PedidoBalcaoProduto> getItensById(int IdPedidoBalcao)
        {
            return (from i in db.PedidoBalcaoProduto
                    where i.IdPedidoBalcao == IdPedidoBalcao
                    select i).ToList();
        }



    }

    public class PedidoBalcaoView
    {
        public int IdPedidoBalcao { get; set; }
        public DateTime? Data { get; set; } 
        public string Status { get; set; }
        public string NomeBalcao { get; set; }
        public string Condicao { get; set; }
        public string  Vendedor { get; set; }
        public string Caixa { get; set; }
        public decimal? Dinheiro { get; set; }
        public decimal? Troco { get; set; }
        public decimal? Total { get; set; }
        public decimal? Credito { get; set; }
        public decimal? Debito { get; set; }
    }

    
}
