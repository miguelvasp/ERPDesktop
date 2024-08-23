using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class RecebimentoDAL : IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();
        private GenericRepository<Recebimento> rRepository;
        private GenericRepository<RecebimentoItem> riRepository;
        private GenericRepository<PedidoCompra> pcRepository;
        private GenericRepository<PedidoCompraItem> pciRepository;

        public GenericRepository<Recebimento> RRepository
        {
            get
            {
                if (this.rRepository == null)
                {
                    this.rRepository = new GenericRepository<Recebimento>(db);
                }
                return rRepository;
            }
        }

        public GenericRepository<RecebimentoItem> RIRepository
        {
            get
            {
                if (this.riRepository == null)
                {
                    this.riRepository = new GenericRepository<RecebimentoItem>(db);
                }
                return riRepository;
            }
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

        public void ApagarItemRecebimento(int IdRecebimentoItem)
        {
            PedidoCompraItemDAL pdal = new PedidoCompraItemDAL();
            var r = this.riRepository.GetByID(IdRecebimentoItem);
            var p = pdal.GetByID(Convert.ToInt32(r.IdPedidoCompraItem));
            p.QuantidadeRecebida = p.QuantidadeRecebida - r.QuantidadeRecebida;
            p.QuantidadeAReceber = p.QuantidadeAReceber + r.QuantidadeRecebida;
            if(p.QuantidadeRecebida > 0 )
            {
                p.Status = "P";
            }
            else
            {
                p.Status = "A";
            }
            pdal.Update(p);
            pdal.Save();

            this.riRepository.Delete(r.IdRecebimentoItem);
            this.Save();

        }

        public bool VerificaItemRecebimento(int pItem)
        {
            bool ok = true; 

            RecebimentoItem ri = (from i in db.RecebimentoItem where i.IdRecebimentoItem == pItem select i).FirstOrDefault();
            if(ri != null)
            {
                //Verifica se o produto é obrigado a registrar os lotes na entrada
                GrupoRastreamento gr = (from p in db.Produto 
                                       join g in db.GrupoRastreamento on p.IdGrupoRastreamento equals g.IdGrupoRastreamento
                                       where p.IdProduto == ri.IdProduto
                                       select g).FirstOrDefault();
                List<RecebimentoItemLote> Lotes = (from lt in db.RecebimentoItemLote
                                                   where lt.IdRecebimentoItem == ri.IdRecebimentoItem
                                                   select lt).ToList();                
                
                if(gr != null && Convert.ToBoolean(gr.NumeroLoteEntrada))
                { 
                    if(Lotes == null || Lotes.Count == 0)
                    {
                        return false;
                    }
                }

                //Verifica se a quantidade dos lotes é igual a quantidade recebida
                if (Lotes != null || Lotes.Count > 0)
                {
                    decimal? Soma = Lotes.Sum(x => x.Quantidade);
                    if(Convert.ToDecimal(Soma) != Convert.ToDecimal(ri.QuantidadeRecebida))
                    {
                        return false;
                    }
                } 
            } 
            return ok;
        }

        public void EntradaEstoque(int pIdRecebimento)
        {
            BLL.BLInventario blInv = new BLL.BLInventario();
            Recebimento rec = (from r in db.Recebimento where r.IdRecebimento == pIdRecebimento select r).FirstOrDefault();
            List<RecebimentoItem> Itens = (from ri in db.RecebimentoItem where ri.IdRecebimento == pIdRecebimento select ri).ToList();

            //da entrada dos itens
            foreach(RecebimentoItem it in Itens)
            {
                //Procura os lotes caso existam 
                List<RecebimentoItemLote> Lotes = (from rl in db.RecebimentoItemLote where rl.IdRecebimentoItem == it.IdRecebimentoItem select rl).ToList();
                if(Lotes != null && Lotes.Count > 0)
                {
                    foreach(RecebimentoItemLote l in Lotes)
                    {
                        blInv.EntradaNoEstoqueFisico(it.IdProduto
                                                , it.IdDeposito
                                                , it.IdArmazem
                                                , it.IdLocalizacao
                                                , it.IdVariantesConfig
                                                , it.IdVariantesTamanho
                                                , it.IdVariantesCor
                                                , it.IdVariantesEstilo
                                                , it.IdUnidade
                                                , it.IdRecebimentoItem
                                                , null
                                                , l.Quantidade
                                                , null
                                                , rec.DataFisica
                                                , l.IdLote);
                    }
                }
                else //Quando o item nao precisa de lotes
                {
                    blInv.EntradaNoEstoqueFisico(it.IdProduto
                                                , it.IdDeposito
                                                , it.IdArmazem
                                                , it.IdLocalizacao
                                                , it.IdVariantesConfig
                                                , it.IdVariantesTamanho
                                                , it.IdVariantesCor
                                                , it.IdVariantesEstilo
                                                , it.IdUnidade
                                                , it.IdRecebimentoItem
                                                , null
                                                , it.QuantidadeRecebida
                                                , null
                                                , rec.DataFisica
                                                , null);
                }

                //if(it.IdPedidoCompraItem != null)
                //blInv.BaixaEstoqueReserva(Convert.ToInt32(it.IdPedidoCompraItem), Convert.ToDecimal(it.QuantidadeRecebida));
            }
        }




        public List<RecebimentoSelecionaModelView> GetRecebimentosByFornecedor(int Fornecedor)
        {
            var lista = (from re in db.Recebimento
                         join r in db.RecebimentoItem on re.IdRecebimento equals r.IdRecebimento
                         join p in db.PedidoCompra on r.IdPedidoCompra equals p.IdPedidoCompra
                         join pr in db.Produto on r.IdProduto equals pr.IdProduto

                         from vc in db.VariantesCor
                         .Where(x => x.IdVariantesCor == r.IdVariantesCor)
                         .DefaultIfEmpty()

                         from ve in db.VariantesEstilo
                         .Where(x => x.IdVariantesEstilo == r.IdVariantesEstilo)
                         .DefaultIfEmpty()

                         from vt in db.VariantesTamanho
                         .Where(x => x.IdVariantesTamanho == r.IdVariantesTamanho)
                         .DefaultIfEmpty()

                         from cp in db.CondicaoPagamento
                         .Where(x => x.IdCondicaoPagamento == p.IdCondicaoPagamento)
                         .DefaultIfEmpty()

                         from un in db.Unidade
                         .Where(x => x.IdUnidade == r.IdUnidade)
                         .DefaultIfEmpty()

                         where re.IdFornecedor == Fornecedor
                         && re.Confirmado == true
                         && r.IdNotaFiscal == null

                         select new RecebimentoSelecionaModelView
                         {
                             Id = r.IdRecebimentoItem,
                             Pedido = p.PedidoNumero,
                             Codigo = pr.Codigo,
                             Produto = pr.Descricao,
                             Cor = vc.Descricao,
                             Estilo = ve.Descricao,
                             Tamanho = vt.Descricao,
                             Qtde = r.QuantidadeRecebida,
                             Valor = r.ValorTotal,
                             Condicao = cp.Descricao,
                             Unidade = un.Descricao
                         }).OrderBy(x => x.Pedido).ThenBy(x => x.Produto).ToList();

            return lista;
        }

        public List<RecebimentoItem> GetListaItensRecebidos(List<int> iList)
        {
            var lista = (from i in db.RecebimentoItem
                         where iList.Contains(i.IdRecebimentoItem)
                         && i.IdNotaFiscal == null
                         select i).ToList();
            return lista;
        }

        public List<RecebimentoComprasModelView> GetRecebimentos(string DataIni, string DataFim, string IdEmpresa, string IdFornecedor)
        {

            int empresa = IdEmpresa == "" ? 0 : Convert.ToInt32(IdEmpresa);
            int fornecedor = IdFornecedor == "" ? 0 : Convert.ToInt32(IdFornecedor);

            db.Configuration.LazyLoadingEnabled = false;
            DateTime DI = Convert.ToDateTime(DataIni + " 00:00:00");
            DateTime DF = Convert.ToDateTime(DataFim + " 23:59:00");

            List<RecebimentoComprasModelView> lista = (from r in db.Recebimento
                                                       join f in db.Fornecedor on r.IdFornecedor equals f.IdFornecedor
                                                       where (r.DataFisica >= DI & r.DataFisica <= DF)
                                                       & (empresa == 0 || r.IdEmpresa == empresa)
                                                       & (fornecedor == 0 || r.IdFornecedor == fornecedor)

                                                       select new RecebimentoComprasModelView
                                                       {
                                                           IdRecebimento = r.IdRecebimento,
                                                           DataFisica = r.DataFisica,
                                                           RecebimentoNumero = r.RecebimentoNumero,
                                                           NomeFantasia = f.NomeFantasia,
                                                           Status = r.Confirmado == true ? "Recebimento Confirmado" : "Em Digitação"
                                                       }
                ).Distinct().OrderByDescending(x => x.IdRecebimento).ToList();

            return lista;
        }

        public List<RecebimentoItemModelView> GetItens(int pRecebimento)
        {
            db.Configuration.LazyLoadingEnabled = false;
            List<RecebimentoItemModelView> lista = (from ri in db.RecebimentoItem
                                                    join p in db.Produto on ri.IdProduto equals p.IdProduto
                                                    where ri.IdRecebimento == pRecebimento
                                                    select new RecebimentoItemModelView
                                                    {
                                                          IdPedidoCompraItem = ri.IdPedidoCompraItem,
                                                          IdRecebimentoItem = ri.IdRecebimentoItem,
                                                          Codigo = p.Codigo,
                                                          NomeProduto = p.NomeProduto,
                                                          Quantidade = ri.Quantidade,
                                                          QuantidadeRecebida = ri.QuantidadeRecebida,
                                                          PrecoUnitario = ri.ValorUnitario,
                                                          Total = ri.QuantidadeRecebida * ri.ValorUnitario,
                                                          IdPedidoCompra = ri.IdPedidoCompra
                                                      }).ToList();
            return lista;
        }

        public decimal GetSumQuantidadeAReceber(int pIdPedidoCompras)
        {
            var qtdeAReceber = (from pi in db.PedidoCompraItem
                                where pi.IdPedidoCompra == pIdPedidoCompras
                                select new { pi.QuantidadeAReceber }
                  ).ToList();

            var sum = qtdeAReceber.Select(c => c.QuantidadeAReceber).Sum();

            return sum.Value;
        }

        public string GetPedidosContasaPagarByNF(int pIdNotaFiscal)
        {
            string Retorno = "";
            var lista = (from i in db.RecebimentoItem
                         join p in db.PedidoCompra on i.IdPedidoCompra equals p.IdPedidoCompra
                         where i.IdNotaFiscal == pIdNotaFiscal
                         select p.PedidoNumero).ToList();

            foreach(var i in lista)
            {
                Retorno += i.ToString() + "/";
            }
            return Retorno;
        }

        public PedidoCompra GetPedidoComprasByNF(int pIdNotaFiscal)
        {
            PedidoCompra pc = (from i in db.RecebimentoItem
                              join p in db.PedidoCompra on i.IdPedidoCompra equals p.IdPedidoCompra
                              where i.IdNotaFiscal == pIdNotaFiscal
                              select p).FirstOrDefault();
            return pc;
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
