using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class PedidoCompraDAL : IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();
        private GenericRepository<PedidoCompra> pcRepository;
        private GenericRepository<PedidoCompraItem> pciRepository;
        
        private class ValoresPedido
        {
            public decimal Valor { get; set; }
            public decimal Desconto { get; set; }
            public decimal Total { get; set; }
        }

        public GenericRepository<PedidoCompra> PCRepository
        {
            get
            {
                if (this.pcRepository == null)
                {
                    this.pcRepository = new GenericRepository<PedidoCompra>(db);
                }
                return pcRepository;
            }
        }

        public GenericRepository<PedidoCompraItem> PCIRepository
        {
            get
            {
                if (this.pciRepository == null)
                {
                    this.pciRepository = new GenericRepository<PedidoCompraItem>(db);
                }
                return pciRepository;
            }
        }

        public List<PedidoComprasModelView> GetPedidos(string DataIni, string DataFim, string DataEntregaIni, string DataEntregaFim, string NumeroPedido,
            string IdEmpresa, string IdFornecedor, string IdGrupoFornecedor, string IdArmazem, string IdDeposito, string IdLocalizacao,
            string IdTipoOrdem,
            string IdProduto, string IdConfig, string IdEstilo, string IdCor, string IdTamanho,
            string pStatus, string pStatusAprovacao)
        {
            int empresa = IdEmpresa == "" ? 0 : Convert.ToInt32(IdEmpresa);
            int numeroPedido = NumeroPedido == "" ? -1 : Convert.ToInt32(NumeroPedido);
            int fornecedor = IdFornecedor == "" ? 0 : Convert.ToInt32(IdFornecedor);
            int grupoFornecedor = IdGrupoFornecedor == "" ? 0 : Convert.ToInt32(IdGrupoFornecedor);
            int armazem = IdArmazem == "" ? 0 : Convert.ToInt32(IdArmazem);
            int deposito = IdDeposito == "" ? 0 : Convert.ToInt32(IdDeposito);
            int localizacao = IdLocalizacao == "" ? 0 : Convert.ToInt32(IdLocalizacao);
            int tipoOrdem = IdTipoOrdem == "" ? 0 : Convert.ToInt32(IdTipoOrdem);
            int produto = IdProduto == "" ? 0 : Convert.ToInt32(IdProduto);
            int config = IdConfig == "" ? 0 : Convert.ToInt32(IdConfig);
            int estilo = IdEstilo == "" ? 0 : Convert.ToInt32(IdEstilo);
            int cor = IdCor == "" ? 0 : Convert.ToInt32(IdCor);
            int tamanho = IdTamanho == "" ? 0 : Convert.ToInt32(IdTamanho);
            string status = pStatus;
            int statusAprovacao = pStatusAprovacao == "" ? -1 : Convert.ToInt32(pStatusAprovacao);

            db.Configuration.LazyLoadingEnabled = false;
            DateTime DI = Convert.ToDateTime(DataIni + " 00:00:00");
            DateTime DF = Convert.ToDateTime(DataFim + " 23:59:00");
            DateTime DEI = DateTime.Now;
            DateTime DEF = DateTime.Now;

            if (Util.Validacao.IsDateTime(DataEntregaIni) == null)
            {
                DEI = Convert.ToDateTime("01/01/2000 00:00:00");
            }
            else
            {
                DEI = Convert.ToDateTime(DataEntregaIni + " 00:00:00");
            }

            if (Util.Validacao.IsDateTime(DataEntregaIni) == null)
            {
                DEF = DateTime.Now.AddYears(1);
            }
            else
            {
                DEF = Convert.ToDateTime(DataEntregaFim + " 23:59:00");
            }


            List<PedidoComprasModelView> lista = (from p in db.PedidoCompra
                                                  join e in db.Empresa on p.IdEmpresa equals e.IdEmpresa into _e
                                                  from e in _e.DefaultIfEmpty()

                                                  join f in db.Fornecedor on p.IdFornecedor equals f.IdFornecedor into _f
                                                  from f in _f.DefaultIfEmpty()

                                                  join pi in db.PedidoCompraItem on p.IdPedidoCompra equals pi.IdPedidoCompra into _pi
                                                  from pi in _pi.DefaultIfEmpty()

                                                  join pd in db.Produto on pi.IdProduto equals pd.IdProduto into _pd
                                                  from pd in _pd.DefaultIfEmpty()

                                                  join an in db.AprovacaoNivel on p.StatusAprovacao equals an.IdAprovacaoNivel into _an
                                                  from an in _an.DefaultIfEmpty()

                                                  where (p.Data >= DI & p.Data <= DF)
                                                        & (p.DataEntrega >= DEI & p.DataEntrega <= DEF)
                                                        & (empresa == 0 || p.IdEmpresa == empresa)
                                                        & (numeroPedido == -1 || p.PedidoNumero == numeroPedido)
                                                        & (fornecedor == 0 || p.IdFornecedor == fornecedor)
                                                        & (grupoFornecedor == 0 || p.IdGrupoFornecedor == grupoFornecedor)
                                                        & (tipoOrdem == 0 || p.TipoOrdem == tipoOrdem)
                                                        & (status == "" || p.Status == status)
                                                        & (statusAprovacao == -1 || p.StatusAprovacao == statusAprovacao)
                                                        & (armazem == 0 || pi.IdArmazem == armazem)
                                                        & (deposito == 0 || pi.IdDeposito == deposito)
                                                        & (localizacao == 0 || pi.IdLocalizacao == localizacao)
                                                        & (produto == 0 || pi.IdProduto == produto)
                                                        & (config == 0 || pi.IdVariantesConfig == config)
                                                        & (estilo == 0 || pd.IdVariantesEstilo == estilo)
                                                        & (cor == 0 || pd.IdVariantesCor == cor)
                                                        & (tamanho == 0 || pd.IdVariantesTamanho == tamanho)

                                                  select new PedidoComprasModelView
                                                  {
                                                      IdPedidoCompras = p.IdPedidoCompra,
                                                      PedidoNumero = p.PedidoNumero,
                                                      Data = p.Data,
                                                      NomeFantasia = f.NomeFantasia,
                                                      DataEntrega = p.DataEntrega,
                                                      Status = p.Status,
                                                      StatusAprovacao = an.Nome
                                                     // LogoEmpresa = e.Logo
                                                  }
                ).Distinct().OrderByDescending(x => x.PedidoNumero).ToList();

            foreach (PedidoComprasModelView item in lista)
            {
                var valores = (from p in db.PedidoCompraItem
                               where p.IdPedidoCompra == item.IdPedidoCompras
                               group p by new { p.IdPedidoCompra } into g
                               select new ValoresPedido()
                               {
                                   Valor = (g.Sum(s => s.Quantidade.Value * s.PrecoUnitario.Value)),
                                   Desconto = (g.Sum(s => (s.Quantidade.Value * s.PrecoUnitario.Value * (s.DescontoPercentual.Value / 100)) + s.DescontoValor.Value)),
                                   Total = (g.Sum(s => s.ValorLiquido.Value))
                               }).FirstOrDefault();

                if (valores != null)
                {
                    item.Valor = valores.Valor == null ? 0 : valores.Valor;
                    item.Desconto = valores.Desconto == null ? 0 : valores.Desconto;
                    item.Total = valores.Total == null ? 0 : valores.Total;
                }
                else
                {
                    item.Valor = 0;
                    item.Desconto = 0;
                    item.Total = 0;
                }
            }

            return lista;
        }

        public List<PedidoCompraItem> GetItensByPedido(int pIdPedidoCompras)
        {
            return (from pi in db.PedidoCompraItem
                    where pi.IdPedidoCompra == pIdPedidoCompras
                    select pi).ToList();
        }

        public int ConsultaPedidoReferencia(int pNumeroPedido, int IdFornecedor)
        {
            var pedido = (from p in db.PedidoCompra
                          where p.TipoOrdem == 1 && p.IdFornecedor == IdFornecedor && p.PedidoNumero == pNumeroPedido
                          select p).Count();
            return pedido;
        }

        public List<PedidoComprasItemModelView> GetItens(int pPedidoCompras)
        {
            db.Configuration.LazyLoadingEnabled = false;
            List<PedidoComprasItemModelView> lista = (from pi in db.PedidoCompraItem
                                                      join pd in db.PedidoCompra on pi.IdPedidoCompra equals pd.IdPedidoCompra
                                                      join p in db.Produto on pi.IdProduto equals p.IdProduto
                                                      where pi.IdPedidoCompra == pPedidoCompras
                                                      select new PedidoComprasItemModelView
                                                      {
                                                          IdPedidoCompra = pd.IdPedidoCompra,
                                                          IdPedidoCompraItem = pi.IdPedidoCompraItem,
                                                          Pedidonumero = pd.PedidoNumero,
                                                          Codigo = p.Codigo,
                                                          NomeProduto = p.NomeProduto,
                                                          Quantidade = pi.Quantidade,
                                                          QuantidadeAReceber = pi.QuantidadeAReceber,
                                                          QuantidadeRecebida = pi.QuantidadeRecebida,
                                                          Ipi = pi.Ipi,
                                                          PrecoUnitario = pi.PrecoUnitario,
                                                          DescontoPercentual = pi.DescontoPercentual,
                                                          DescontoValor = pi.DescontoPercentual,
                                                          Total = pi.ValorLiquido
                                                      }).ToList();
            return lista;
        }

        public List<PedidoCompraItem> GetPedidoCompraItens(int pPedidoCompras)
        {
            db.Configuration.LazyLoadingEnabled = false;
            List<PedidoCompraItem> lista = (from pi in db.PedidoCompraItem
                                            join pd in db.PedidoCompra on pi.IdPedidoCompra equals pd.IdPedidoCompra
                                            where pi.IdPedidoCompra == pPedidoCompras
                                            select pi).ToList();
            return lista;
        }


        public List<PedidoComprasItemModelView> GetItensByFornecedor(int pIdFornecedor, int IdRecebimento)
        {
            db = new DB_ERPContext();
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
            List<PedidoComprasItemModelView> lista = (from pi in db.PedidoCompraItem
                                                      join pd in db.PedidoCompra on pi.IdPedidoCompra equals pd.IdPedidoCompra
                                                      join p in db.Produto on pi.IdProduto equals p.IdProduto
                                                      where pd.IdFornecedor == pIdFornecedor
                                                      && pd.StatusAprovacao == nivel.IdAprovacaoNivel
                                                      && (pi.Status != "T")
                                                      select new PedidoComprasItemModelView
                                                     { 
                                                         IdPedidoCompra = pd.IdPedidoCompra,
                                                         IdPedidoCompraItem = pi.IdPedidoCompraItem,
                                                         Pedidonumero = pd.PedidoNumero,
                                                         Codigo = p.Codigo,
                                                         NomeProduto = p.NomeProduto,
                                                         Quantidade = pi.Quantidade,
                                                         QuantidadeAReceber = pi.QuantidadeAReceber,
                                                         QuantidadeRecebida = 0,
                                                         Saldo = pi.QuantidadeAReceber,
                                                         Ipi = pi.Ipi,
                                                         PrecoUnitario = pi.PrecoUnitario,
                                                         DescontoPercentual = pi.DescontoPercentual,
                                                         DescontoValor = pi.DescontoPercentual,
                                                         Total = pi.ValorLiquido
                                                     }).ToList();
            return lista;
        }

        public void Save(string IdUsuarioCorrente)
        {
            db.SaveChanges(IdUsuarioCorrente);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
