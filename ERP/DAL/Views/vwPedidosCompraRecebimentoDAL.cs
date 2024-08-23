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
    public class vwPedidosCompraRecebimentoDAL 
    {
        DB_ERPViewContext dbv = new DB_ERPViewContext();
        public List<PedidoComprasItemModelView> GetItensByFornecedor(int pIdFornecedor)
        {
            DB_ERPContext db = new DB_ERPContext();
            //Procura o Id de Status Liberado para Pedido de Compras
            string Sigla = "PC";
            string StatusLiberado = "Liberado";
            AprovacaoNivel nivel = (from a in db.AprovacaoDocumento
                                    join n in db.AprovacaoNivel on a.IdAprovacaoDocumento equals n.IdAprovacaoDocumento
                                    where a.Sigla == Sigla
                                    && n.Nome == StatusLiberado
                                    select n).FirstOrDefault();

            //Procura os produtos para o fornecedor de pedidos de compras que tenham sido liberados e que esteja em aberto ou tenham sido atendidos parcialmente.
            db.Configuration.LazyLoadingEnabled = false;
            List<PedidoComprasItemModelView> lista = (from p in dbv.vwPedidosCompraRecebimento 
                                                      where p.IdFornecedor == pIdFornecedor
                                                      && p.StatusAprovacao == nivel.IdAprovacaoNivel 
                                                      select new PedidoComprasItemModelView
                                                      {
                                                          IdPedidoCompra = p.IdPedidoCompra,
                                                          IdPedidoCompraItem = p.IdPedidoCompraItem,
                                                          Pedidonumero = p.PedidoNumero,
                                                          Codigo = p.Codigo,
                                                          NomeProduto = p.NomeProduto,
                                                          Quantidade = p.Quantidade,
                                                          QuantidadeAReceber = p.QTDE_A_RECEBER,
                                                          QuantidadeRecebida = p.QTDE_RECEBIDA,
                                                          Saldo = p.Quantidade - p.QTDE_RECEBIDA,
                                                          Ipi = p.Ipi,
                                                          PrecoUnitario = p.PrecoUnitario,
                                                          DescontoPercentual = p.DescontoPercentual,
                                                          DescontoValor = p.DescontoPercentual,
                                                          Total = p.ValorLiquido
                                                      }).ToList();
            return lista;
        }
    }
}
