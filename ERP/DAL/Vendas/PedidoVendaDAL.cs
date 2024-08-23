using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class PedidoVendaDAL : IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();
        private DB_ERPViewContext dbv = new DB_ERPViewContext();
        private GenericRepository<PedidoVenda> pvRepository;
        private GenericRepository<PedidoVendaItem> pviRepository;

        private class ValoresPedido
        {
            public decimal Valor { get; set; }
            public decimal Desconto { get; set; }
            public decimal Total { get; set; }
        }

        public void ApagarItemDependencias(int IdPedidoVendaItem)
        {
            PedidoVendaItemCentroCustoDAL cDal = new PedidoVendaItemCentroCustoDAL();
            var Centros = cDal.GetCentros(IdPedidoVendaItem);

            foreach (var c in Centros)
            {
                cDal.Delete(c.IdPedidoVendaItemCentroCusto);
                cDal.Save();
            }

            PedidoVendaItemApuracaoImpostoDAL aDal = new PedidoVendaItemApuracaoImpostoDAL();
            var impostos = aDal.GetByPedidoItem(IdPedidoVendaItem);
            foreach(var i in impostos)
            {
                aDal.Delete(i.IdPedidoVendaItemApuracaoImposto);
                aDal.Save();
            }

            PedidoVendaItemEncargoDAL eDal = new PedidoVendaItemEncargoDAL();
            var Encargos = eDal.GetByItem(IdPedidoVendaItem);
            foreach(var e in Encargos)
            {
                eDal.Delete(e.IdPedidoVendaItemEncargo);
                eDal.Save();
            }
        }

        public GenericRepository<PedidoVenda> PVRepository
        {
            get
            {
                if (this.pvRepository == null)
                {
                    this.pvRepository = new GenericRepository<PedidoVenda>(db);
                }
                return pvRepository;
            }
        }

        public GenericRepository<PedidoVendaItem> PVIRepository
        {
            get
            {
                if (this.pviRepository == null)
                {
                    this.pviRepository = new GenericRepository<PedidoVendaItem>(db);
                }
                return pviRepository;
            }
        }

        public int ConsultaPedidoReferencia(int pNumeroPedido, int IdCliente)
        {
            var pedido = (from p in db.PedidoVenda
                          where p.TipoOrdem == 1 && p.IdCliente == IdCliente && p.PedidoNumero == pNumeroPedido
                          select p).Count();
            return pedido;
        }

        public List<vwPedidoVendasRel> GetvwPedidoVendaImpressao(int idPedidoVenda, bool SoFaturar = false)
        {
            Configuracao confEmpresa = new ConfiguracaoDAL().GetByEmpresa(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
            DB_ERPViewContext dbv = new DB_ERPViewContext();
            var lista = (from v in dbv.vwPedidoVendasRel
                         where v.Pedido == idPedidoVenda
                         select v).Distinct().ToList();

           
            foreach(var s in lista)
            {
                if (Convert.ToBoolean(confEmpresa.VendasRelValorTotal))
                { 
                        s.PrecoUnitario = s.PrecoUnitario + s.DescontoVarejista;  
                } 

                if (SoFaturar)
                {
                    s.Quantidade = s.QuantidadePorFaturar;
                    s.TOTAL = s.QuantidadePorFaturar * s.PrecoUnitario;
                }
                    
            }
            

             

            return lista;
        }

        public List<PedidoVendasItemModelView> GetItens(int pPedidoVendas)
        {
            db.Configuration.LazyLoadingEnabled = false;
            List<PedidoVendasItemModelView> lista = (from pi in db.PedidoVendaItem
                                                     join pd in db.PedidoVenda on pi.IdPedidoVenda equals pd.IdPedidoVenda
                                                     join p in db.Produto on pi.IdProduto equals p.IdProduto

                                                     from cf in db.VariantesConfig.Where(x => x.IdVariantesConfig == pi.IdVariantesConfig).DefaultIfEmpty()
                                                     from t in db.VariantesTamanho.Where(x => x.IdVariantesTamanho == pi.IdVariantesTamanho).DefaultIfEmpty()
                                                     from co in db.VariantesCor.Where(x => x.IdVariantesCor == pi.IdVariantesCor).DefaultIfEmpty()
                                                     from e in db.VariantesEstilo.Where(x => x.IdVariantesEstilo == pi.IdVariantesEstilo).DefaultIfEmpty()


                                                     where pi.IdPedidoVenda == pPedidoVendas
                                                     select new PedidoVendasItemModelView
                                                      { 
                                                          IdPedidoVendaItem = pi.IdPedidoVendaItem,
                                                          Pedidonumero = pd.PedidoNumero,
                                                          Codigo = p.Codigo,
                                                          NomeProduto = p.NomeProduto,
                                                          Quantidade = pi.Quantidade,
                                                          Ipi = pi.Ipi,
                                                          PrecoUnitario = pi.PrecoUnitario,
                                                          DescontoPercentual = pi.DescontoPercentual,
                                                          DescontoValor = pi.DescontoPercentual,
                                                          Total = pi.ValorLiquido,
                                                          Config = cf.Descricao,
                                                          Tamanho = t.Descricao,
                                                          Estilo = e.Descricao,
                                                          Cor = co.Descricao
                                                      }).ToList();
             
            return lista;
        }

        public PedidoVenda GetPedidoByNF(int pIdNotaFiscal)
        {
            PedidoVenda pv = (from p in db.PedidoVenda
                              join i in db.PedidoVendaItem on p.IdPedidoVenda equals i.IdPedidoVenda
                              join nf in db.NotaFiscalItem on i.IdPedidoVenda equals nf.IdPedidoVenda
                              where nf.IdNotaFiscal == pIdNotaFiscal
                              select p).FirstOrDefault();
            return pv;
        }

        public List<PedidoVendaItem> GetListaItensPedidoVendas(List<int> iList)
        {
            var lista = (from i in db.PedidoVendaItem
                         where iList.Contains(i.IdPedidoVendaItem)
                         select i).ToList();
            return lista;
        }

        public List<PedidoVendasModelView> GetPedidos(string DataIni, string DataFim, string DataEntregaIni, string DataEntregaFim, string NumeroPedido,
            string IdEmpresa, string IdCliente, string IdGrupoCliente, string IdArmazem, string IdDeposito, string IdLocalizacao,
            string IdTipoOrdem, string IdTelevendas, string IdVendedor,
            string IdProduto, string IdConfig, string IdEstilo, string IdCor, string IdTamanho,
            string pStatus, string pStatusAprovacao, string pCNPJ)
        {
            int empresa = IdEmpresa == "" ? 0 : Convert.ToInt32(IdEmpresa);
            int numeroPedido = NumeroPedido == "" ? -1 : Convert.ToInt32(NumeroPedido);
            int cliente = IdCliente == "" ? 0 : Convert.ToInt32(IdCliente);
            int grupoCliente = IdGrupoCliente == "" ? 0 : Convert.ToInt32(IdGrupoCliente);
            int armazem = IdArmazem == "" ? 0 : Convert.ToInt32(IdArmazem);
            int deposito = IdDeposito == "" ? 0 : Convert.ToInt32(IdDeposito);
            int localizacao = IdLocalizacao == "" ? 0 : Convert.ToInt32(IdLocalizacao);
            int tipoOrdem = IdTipoOrdem == "" ? 0 : Convert.ToInt32(IdTipoOrdem);
            int teleVendas = IdTelevendas == "" ? 0 : Convert.ToInt32(IdTelevendas);
            int vendedor = IdVendedor == "" ? 0 : Convert.ToInt32(IdVendedor);
            int produto = IdProduto == "" ? 0 : Convert.ToInt32(IdProduto);
            int config = IdConfig == "" ? 0 : Convert.ToInt32(IdConfig);
            int estilo = IdEstilo == "" ? 0 : Convert.ToInt32(IdEstilo);
            int cor = IdCor == "" ? 0 : Convert.ToInt32(IdCor);
            int tamanho = IdTamanho == "" ? 0 : Convert.ToInt32(IdTamanho);
            int status = pStatus == "" ? 0 : Convert.ToInt32(pStatus);
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

            List<PedidoVendasModelView> lista = (from p in db.PedidoVenda
                                                 join e in db.Empresa on p.IdEmpresa equals e.IdEmpresa into _e
                                                 from e in _e.DefaultIfEmpty()

                                                 join c in db.Cliente on p.IdCliente equals c.IdCliente into _c
                                                 from c in _c.DefaultIfEmpty()

                                                 join pi in db.PedidoVendaItem on p.IdPedidoVenda equals pi.IdPedidoVenda into _pi
                                                 from pi in _pi.DefaultIfEmpty()

                                                 join pd in db.Produto on pi.IdProduto equals pd.IdProduto into _pd
                                                 from pd in _pd.DefaultIfEmpty()

                                                 join an in db.AprovacaoNivel on p.StatusAprovacao equals an.IdAprovacaoNivel into _an
                                                 from an in _an.DefaultIfEmpty()

                                                 where (p.Data >= DI & p.Data <= DF)
                                                 & (p.DataEntrega >= DEI & p.DataEntrega <= DEF)
                                                 & (empresa == 0 || p.IdEmpresa == empresa)
                                                 & (numeroPedido == -1 || p.PedidoNumero == numeroPedido) 
                                                 & (cliente == 0 || p.IdCliente == cliente)
                                                 & (grupoCliente == 0 || p.IdGrupoCliente == grupoCliente)
                                                 & (tipoOrdem == 0 || p.TipoOrdem == tipoOrdem)
                                                 & (teleVendas == 0 || p.IdTeleVendas == teleVendas)
                                                 & (vendedor == 0 || p.IdVendedor == vendedor)
                                                 & (status == 0 || p.Status == status)
                                                 & (statusAprovacao == -1 || p.StatusAprovacao == statusAprovacao)
                                                 & (armazem == 0 || pi.IdArmazem == armazem)
                                                 & (deposito == 0 || pi.IdDeposito == deposito)
                                                 & (localizacao == 0 || pi.IdLocalizacao == localizacao)
                                                 & (produto == 0 || pi.IdProduto == produto)
                                                 & (config == 0 || pi.IdVariantesConfig == config)
                                                 & (estilo == 0 || pd.IdVariantesEstilo == estilo)
                                                 & (cor == 0 || pd.IdVariantesCor == cor)
                                                 & (tamanho == 0 || pd.IdVariantesTamanho == tamanho)
                                                 & (pCNPJ == "" || c.CNPJ == pCNPJ)

                                                 select new PedidoVendasModelView
                                                  {
                                                      IdPedidoVendas = p.IdPedidoVenda,
                                                      PedidoNumero = p.PedidoNumero,
                                                      Data = p.Data,
                                                      NomeFantasia = c.RazaoSocial,
                                                      DataEntrega = p.DataEntrega,
                                                      Status = p.Status == 1 ? "Em Aberto" :
                                                              p.Status == 2 ? "Separação" :
                                                              p.Status == 3 ? "A Faturar" :
                                                              p.Status == 4 ? "Faturado" :
                                                              p.Status == 5 ? "Faturado Parcialmente" :
                                                              p.Status == 6 ? "Cancelado" :
                                                              p.Status == 7 ? "Saldo Cancelado" : "",
                                                      StatusAprovacao = an.Nome
                                                      //LogoEmpresa = e.Logo
                                                  }
                ).Distinct().OrderByDescending(x => x.PedidoNumero).ToList();

            foreach (PedidoVendasModelView item in lista)
            {
                var valores = (from p in db.PedidoVendaItem
                               where p.IdPedidoVenda == item.IdPedidoVendas
                               group p by new { p.IdPedidoVenda } into g
                               select new ValoresPedido()
                               {
                                   Valor = (g.Sum(s => s.Quantidade * s.PrecoUnitario)),
                                   Desconto = (g.Sum(s => (s.Quantidade * s.PrecoUnitario * (s.DescontoPercentual / 100)) + s.DescontoValor)),
                                   Total = (g.Sum(s => s.ValorLiquido))
                               }).FirstOrDefault();
                if (valores != null)
                {
                    item.Valor = valores.Valor;
                    item.Desconto = valores.Desconto;
                    item.Total = valores.Total;
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

        public List<PedidoVendasModelView> GetPedidosSeparacao(string DataIni, string DataFim, string IdEmpresa, string IdCliente)
        {
            int empresa = IdEmpresa == "" ? 0 : Convert.ToInt32(IdEmpresa);
            int cliente = IdCliente == "" ? 0 : Convert.ToInt32(IdCliente);
            db.Configuration.LazyLoadingEnabled = false;
            DateTime DI = Convert.ToDateTime(DataIni + " 00:00:00");
            DateTime DF = Convert.ToDateTime(DataFim + " 23:59:00");

            List<PedidoVendasModelView> lista = (from p in db.PedidoVenda
                                                 join c in db.Cliente on p.IdCliente equals c.IdCliente
                                                 where (p.Data >= DI & p.Data <= DF)
                                                 & (empresa == 0 || p.IdEmpresa == empresa)
                                                 & (cliente == 0 || p.IdCliente == cliente)
                                                 & (p.Status == 2 || p.Status == 3 || p.Status == 5) // pedidos liberados, a faturar ou faturados parcialmente

                                                 from pi in db.PedidoVendaItem
                                                 .Where(v => v.IdPedidoVenda == p.IdPedidoVenda)
                                                 .DefaultIfEmpty()

                                                 from an in db.AprovacaoNivel
                                                 .Where(x => x.IdAprovacaoNivel == p.StatusAprovacao)
                                                 .DefaultIfEmpty()

                                                 select new PedidoVendasModelView
                                                 {
                                                     IdPedidoVendas = p.IdPedidoVenda,
                                                     PedidoNumero = p.PedidoNumero,
                                                     Data = p.Data,
                                                     NomeFantasia = c.RazaoSocial,
                                                     DataEntrega = p.DataEntrega,
                                                     Status = p.Status == 1 ? "Em Aberto" :
                                                              p.Status == 2 ? "Separação" :
                                                              p.Status == 3 ? "A Faturar" :
                                                              p.Status == 4 ? "Faturado" :
                                                              p.Status == 5 ? "Faturado Parcialmente" :
                                                              p.Status == 6 ? "Cancelado" :
                                                              p.Status == 7 ? "Saldo Cancelado" : "",
                                                     StatusAprovacao = an.Nome
                                                 }
                ).Distinct().OrderByDescending(x => x.PedidoNumero).ToList();

            return lista;
        }

        public List<PedidoVendaItem> GetItensByPedido(int pIdPedidoVendas)
        {
            return (from pi in db.PedidoVendaItem
                    where pi.IdPedidoVenda == pIdPedidoVendas
                    select pi).ToList();
        }

        public PedidosTotaisModelView getTotaisPedido(int pIdPedidoVenda, bool SoFaturar = false)
        {
            PedidosTotaisModelView p = new PedidosTotaisModelView();
            p.TotalProdutos = 0;
            p.TotalImpostosNaoInclusos = 0;
            p.TotalImpostos = 0;
            p.TotalEncargos = 0;
            p.TotalPedido = 0;
            p.TotalDesconto = 0;
            p.TotalDescontoVarejista = 0;
            p.TotalValorReal = 0;
            p.IPI = 0;
            p.PIS = 0;
            p.ICMS = 0;
            p.COFINS = 0;
            p.ISS = 0;
            p.IRRF = 0;
            p.INSS = 0;
            p.ImpostoImportacao = 0;
            p.OutrosImpostos = 0;
            p.CSLL = 0;
            p.ICMSST = 0;
            p.ICMSDiff = 0;

            //Pega os valores dos produtos e descontos
            var itensPedido = (from i in db.PedidoVendaItem
                               where i.IdPedidoVenda == pIdPedidoVenda
                               select new
                               {
                                   i.PrecoUnitario,
                                   Quantidade = SoFaturar ? i.QuantidadePorFaturar : i.Quantidade,
                                   i.DescontoPercentual,
                                   i.DescontoValor,
                                   i.DescontoVarejista,
                                   i.ValorOriginal
                               }).ToList();

            foreach(var i in itensPedido)
            {
                p.TotalProdutos += (Convert.ToDecimal(i.PrecoUnitario) + Convert.ToDecimal(i.DescontoVarejista))* Convert.ToDecimal(i.Quantidade);
                p.TotalDesconto += Convert.ToDecimal(i.DescontoValor);
                p.TotalValorReal += (Convert.ToDecimal(i.PrecoUnitario) + Convert.ToDecimal(i.DescontoVarejista)) * Convert.ToDecimal(i.Quantidade);

                //Calcula o desconto em percentual
                decimal Percentual = i.DescontoPercentual;
                if(Percentual > 0)
                {
                    decimal DescontoPercentual = (p.TotalProdutos * Percentual) /100M;
                    p.TotalDesconto += DescontoPercentual;
                } 
                p.TotalDescontoVarejista += Convert.ToDecimal(i.DescontoVarejista * i.Quantidade); //O valor original traz o valor sem desconto algum
            }

            

            //total dos encargos
            var encargos = (from i in db.PedidoVendaItem 
                            where i.IdPedidoVenda == pIdPedidoVenda
                            select i.ValorEncargos).ToList();
            foreach(decimal? e in encargos)
            {
                p.TotalEncargos += Convert.ToDecimal(e);
            }

            //pega os impostos
            var impostos = (from pi in db.PedidoVendaItem
                            join i in db.PedidoVendaItemApuracaoImposto on pi.IdPedidoVendaItem equals i.IdPedidoVendaItem
                            join c in db.CodigoImposto on i.IdCodigoImposto equals c.IdCodigoImposto
                            where pi.IdPedidoVenda == pIdPedidoVenda
                            select new
                            {
                                i.ValorImposto,
                                c.TipoImposto,
                                c.ImpostoIncluso
                            }).ToList();

            foreach(var i in impostos)
            {
                if (i.TipoImposto == 1) p.IPI += Convert.ToDecimal(i.ValorImposto);
                if (i.TipoImposto == 2) p.PIS += Convert.ToDecimal(i.ValorImposto);
                if (i.TipoImposto == 3) p.ICMS += Convert.ToDecimal(i.ValorImposto);
                if (i.TipoImposto == 4) p.COFINS += Convert.ToDecimal(i.ValorImposto);
                if (i.TipoImposto == 5) p.ISS += Convert.ToDecimal(i.ValorImposto);
                if (i.TipoImposto == 6) p.IRRF += Convert.ToDecimal(i.ValorImposto);
                if (i.TipoImposto == 7) p.INSS += Convert.ToDecimal(i.ValorImposto);
                if (i.TipoImposto == 8) p.ImpostoImportacao += Convert.ToDecimal(i.ValorImposto);
                if (i.TipoImposto == 9) p.OutrosImpostos += Convert.ToDecimal(i.ValorImposto);
                if (i.TipoImposto == 10) p.CSLL += Convert.ToDecimal(i.ValorImposto);
                if (i.TipoImposto == 11) p.ICMSST += Convert.ToDecimal(i.ValorImposto);
                if (i.TipoImposto == 12) p.ICMSDiff += Convert.ToDecimal(i.ValorImposto);

                if(!i.ImpostoIncluso)
                {
                    p.TotalImpostosNaoInclusos += Convert.ToDecimal(i.ValorImposto);
                }

                p.TotalImpostos += Convert.ToDecimal(i.ValorImposto);
            }

            return p;
        }

        public decimal GetValorImpostoByTipo(int pIdPedidoVendaItem, int TipoImposto)
        {
            decimal? imposto = (from i in db.PedidoVendaItemApuracaoImposto
                                where i.IdPedidoVendaItem == pIdPedidoVendaItem
                                && i.TipoImposto == TipoImposto
                                select i.ValorImposto).FirstOrDefault();
            if(imposto == null)
            {
                return 0;
            }
            else
            {
                return (decimal)imposto;
            }
        }

        public decimal getImpostosNaoInclusosPorItem(int pIdPedidoVendaItem)
        {
            decimal TotalImpostosNaoInclusos = 0;
            //pega os impostos
            var impostos = (from pi in db.PedidoVendaItem
                            join i in db.PedidoVendaItemApuracaoImposto on pi.IdPedidoVendaItem equals i.IdPedidoVendaItem
                            join c in db.CodigoImposto on i.IdCodigoImposto equals c.IdCodigoImposto
                            where pi.IdPedidoVendaItem == pIdPedidoVendaItem
                            select new
                            {
                                i.ValorImposto,
                                c.TipoImposto,
                                c.ImpostoIncluso
                            }).ToList();

            foreach (var i in impostos)
            {
                if(i.TipoImposto != 11)//ICMSST
                {
                    if (!i.ImpostoIncluso)
                    {
                        TotalImpostosNaoInclusos += Convert.ToDecimal(i.ValorImposto);
                    }
                }
                
            }

            return TotalImpostosNaoInclusos;
        }
        

        public void AtualizaStatusPedidoAposFaturamento(int idPedidoVenda)
        {
            bool PedidoFaturado = false;
            bool PedidoParcialmenteFaturado = false;
            var itens = (from i in db.PedidoVendaItem
                         where i.IdPedidoVenda == idPedidoVenda
                         select new
                         {
                             i.Quantidade,
                             i.QuantidadeFaturada
                         }).ToList();

            foreach(var i in itens)
            {
                if(Convert.ToDecimal(i.QuantidadeFaturada) > 0)
                {
                    PedidoFaturado = true;
                    if (Convert.ToDecimal(i.Quantidade) > Convert.ToDecimal(i.QuantidadeFaturada))
                    {
                        PedidoParcialmenteFaturado = true;
                    }
                }
                
            }

            if(PedidoFaturado)
            {
                PedidoVenda pv = this.PVRepository.GetByID(idPedidoVenda);
                if(PedidoParcialmenteFaturado)
                {
                    pv.Status = 5;
                }
                else
                {
                    pv.Status = 4;//pedido faturado completo
                }
                this.PVRepository.Update(pv);
                this.Save();
            }



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
