using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BLL
{
    public class BLInventario
    {
        DB_ERPContext db = new DB_ERPContext();
        DB_ERPViewContext dbv = new DB_ERPViewContext();
        public InventarioDAL dal = new InventarioDAL();
        int iEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));

        public BLInventario() { }

        /// <summary>
        /// Rotina que da entrada de Reserva na confirmação do pedido de compras.
        /// </summary>
        //public void EntradaNoEstoqueReserva(int IdProduto, int? IdDeposito, int? IdArmazem, int? IdLocalizacao, int? IdVariantesConfig, int? IdVariantesTamanho, int? IdVariantesCor, int? IdVariantesEstilo, int? IdUnidade, int? IdDocumento, int? IdNCM, decimal? Quantidade)
        //{
        //    Inventario i = new Inventario();
        //    i.IdEmpresa = iEmpresa;
        //    i.IdProduto = IdProduto;
        //    i.IdDeposito = IdDeposito;
        //    i.IdArmazem = IdArmazem;
        //    i.IdLocalizacao = IdLocalizacao;
        //    i.IdVariantesConfig = IdVariantesConfig;
        //    i.IdVariantesTamanho = IdVariantesTamanho;
        //    i.IdVariantesCor = IdVariantesCor;
        //    i.IdVariantesEstilo = IdVariantesEstilo;
        //    i.IdUnidade = IdUnidade;
        //    i.IdDocumento = IdDocumento; //IdPedidoCompraItem
        //    i.IdTipoDocumento = 1;
        //    i.TipoMovimentoFinanceiro = "E";
        //    i.IdNCM = IdNCM;
        //    i.Quantidade = Quantidade;
        //    dal.Insert(i);
        //    dal.Save();
        //}



        //public void BaixaEstoqueReserva(int pIdPedidoComprasItem, decimal Qtde)
        //{
        //    Inventario inv = dal.GetByTipoDoc(pIdPedidoComprasItem, 1);
        //    inv.QuantidadeRetirada = Qtde;
        //    dal.Update(inv);
        //    dal.Save();

        //    //se sobrar estoque lançamos o saldo
        //    if (inv.Quantidade > inv.QuantidadeRetirada)
        //    {
        //        EntradaNoEstoqueReserva(
        //                            (int)inv.IdProduto,
        //                            inv.IdDeposito,
        //                            inv.IdArmazem,
        //                            inv.IdLocalizacao,
        //                            inv.IdVariantesConfig,
        //                            inv.IdVariantesTamanho,
        //                            inv.IdVariantesCor,
        //                            inv.IdVariantesEstilo,
        //                            inv.IdUnidade,
        //                            inv.IdDocumento,
        //                            inv.IdNCM,
        //                            inv.Quantidade - inv.QuantidadeRetirada);
        //    }

        //}


        /// <summary>
        /// Rotina que da entrada no estoque fisico na confirmação do Recebimento
        /// </summary>
        public void EntradaNoEstoqueFisico(int IdProduto, int? IdDeposito, int? IdArmazem, int? IdLocalizacao, int? IdVariantesConfig, int? IdVariantesTamanho, int? IdVariantesCor, int? IdVariantesEstilo, int? IdUnidade, int? IdDocumento, int? IdNCM, decimal? Quantidade, decimal? CustoReposicao, DateTime? DataFisica, int? IdLote, string NumeroDocumento = "")
        {
            Inventario i = new Inventario();
            i.IdEmpresa = iEmpresa;
            i.IdProduto = IdProduto;
            i.IdDeposito = IdDeposito;
            i.IdArmazem = IdArmazem;
            i.IdLocalizacao = IdLocalizacao;
            i.IdVariantesConfig = IdVariantesConfig;
            i.IdVariantesTamanho = IdVariantesTamanho;
            i.IdVariantesCor = IdVariantesCor;
            i.IdVariantesEstilo = IdVariantesEstilo;
            i.IdUnidade = 4;
            i.IdDocumento = IdDocumento;//Recebimento item
            i.IdTipoDocumento = 3; //Recebimento/Nf entrada
            i.TipoMovimentoFinanceiro = "E";
            i.IdNCM = IdNCM;
            i.Quantidade = Quantidade;
            i.CustoReposicao = CustoReposicao;
            i.DataFisica = DataFisica;
            i.IdLote = IdLote;
            i.NumeroDocumentoNF = NumeroDocumento;

            if (IdLote != null)
            {
                var lote = new RecebimentoItemLoteDAL().GetByID((int)IdLote);
                i.DataVencimento = lote.DataVencimento;
                i.DataFabricacao = lote.DataFabricacao;
                i.DataAvisoPrateleira = lote.DataAvisoPrateleira;
                i.DataValidade = lote.DataValidade;
                i.LoteFornecedor = lote.LoteFornecedor;
                i.LoteInterno = lote.LoteInterno;
            }

            //Consultamos o Estoque
            vwEstoqueSintetico estoque = ConsultaEstoqueSintetico(IdProduto, IdDeposito, IdArmazem, IdLocalizacao, IdVariantesConfig, IdVariantesTamanho, IdVariantesCor, IdVariantesEstilo, 5).FirstOrDefault();
            if (estoque == null)
            {
                i.EstoqueAnterior = 0;
            }
            else
            {
                i.EstoqueAnterior = estoque.Quantidade;
            }
            i.Saldo = i.EstoqueAnterior + i.Quantidade;
            dal.Insert(i);
            dal.Save();
        }


        public List<vwEstoqueSintetico> ConsultaEstoqueSintetico(int? IdProduto, int? IdDeposito, int? IdArmazem, int? IdLocalizacao, int? IdVariantesConfig, int? IdVariantesTamanho, int? IdVariantesCor, int? IdVariantesEstilo, int? IdTipoDocumento, string TextoLivre = "", int IdGrupoProduto = 0)
        {
            var lista = (from e in dbv.vwEstoqueSintetico
                         where e.IdEmpresa == iEmpresa
                         && (IdProduto == 0 || e.IdProduto == IdProduto)
                         && (IdDeposito == 0 || e.IdDeposito == IdDeposito)
                         && (IdArmazem == 0 || e.IdArmazem == IdArmazem)
                         && (IdLocalizacao == 0 || e.IdLocalizacao == IdLocalizacao)
                         && (IdGrupoProduto == 0 || e.IdGrupoProduto == IdGrupoProduto)
                         && (string.IsNullOrEmpty(TextoLivre) || (e.Codigo.Contains(TextoLivre) || e.NomeProduto.Contains(TextoLivre) || e.EAN.Contains(TextoLivre) )) 
                         && e.VendaProdDescontinuado == false
                         select e).ToList();
            return lista;
        }

        public List<vwEstoqueAnalitico> ConsultaEstoqueAnalitico(int? IdProduto, int? IdDeposito, int? IdArmazem, int? IdLocalizacao, int? IdVariantesConfig, int? IdVariantesTamanho, int? IdVariantesCor, int? IdVariantesEstilo, int? IdTipoDocumento, string LoteFornecedor, string LoteInterno, DateTime? DataFabricacao, DateTime? DataVencimento, DateTime? DataValidade, DateTime? DataAvisoPrateleira)
        {
            var lista = (from e in dbv.vwEstoqueAnalitico
                         where e.IdEmpresa == iEmpresa
                         && (IdProduto == 0 || e.IdProduto == IdProduto)
                         && (IdDeposito == 0 || e.IdDeposito == IdDeposito)
                         && (IdArmazem == 0 || e.IdArmazem == IdArmazem)
                         && (IdLocalizacao == 0 || e.IdLocalizacao == IdLocalizacao)
                         && (IdVariantesConfig == 0 || e.IdVariantesConfig == IdVariantesConfig)
                         && (IdVariantesTamanho == 0 || e.IdVariantesTamanho == IdVariantesTamanho)
                         && (IdVariantesCor == 0 || e.IdVariantesCor == IdVariantesCor)
                         && (IdVariantesEstilo == 0 || e.IdVariantesEstilo == IdVariantesEstilo)
                         && (e.IdTipoDocumento == 5 || e.IdTipoDocumento == 3 || e.IdTipoDocumento == 7)
                         && (DataAvisoPrateleira == null || e.DataAvisoPrateleira == DataAvisoPrateleira)
                         && (DataFabricacao == null || e.DataFabricacao == DataFabricacao)
                         && (DataValidade == null || e.DataValidade == DataValidade)
                         && (DataVencimento == null || e.DataVencimento == DataVencimento)
                         && (LoteFornecedor == "" || e.LoteFornecedor == LoteFornecedor)
                         && (LoteInterno == "" || e.LoteInterno == LoteInterno)
                         select e).ToList();
            return lista;
        }

        private decimal SaldoAnterior(int pIdProduto)
        {
            var saldo = (from p in dbv.vwEstoqueSintetico
                         where p.IdProduto == pIdProduto
                         select p.Quantidade).FirstOrDefault();
            if (saldo == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(saldo);
            }
        }

        public bool VerificaEntradaNoEstoqueFisico(int pIdRecebimento)
        {
            bool? r = (from i in db.RecebimentoItem
                       join p in db.PedidoCompra on i.IdPedidoCompra equals p.IdPedidoCompra
                       join o in db.Operacao on p.IdOperacao equals o.IdOperacao
                       where i.IdRecebimento == pIdRecebimento
                       select o.MovimentaEstoque).FirstOrDefault();
            if (r == null)
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(r);
            }
        }

        public void BaixaEstoqueProduto(int pIdProduto, int? IdCor, int? IdEstilo, int? IdConfiguracao, int? IdTamanho, decimal Qtde, int? IdNotaSaida, string LoteInterno = "", string LoteFornecedor = "")
        {
            InventarioDAL eDal = new InventarioDAL();

            //Consulta se o o item ja foi baixado no estoque
            var baixados = (from i in db.Inventario
                            where i.IdProduto == pIdProduto
                            & (i.IdTipoDocumento == 3 || i.IdTipoDocumento == 5) //recebimento ou nota entrada
                            & (IdCor == null || i.IdVariantesCor == IdCor)
                            & (IdEstilo == null || i.IdVariantesEstilo == IdEstilo)
                            & (IdConfiguracao == null || i.IdVariantesConfig == IdConfiguracao)
                            & (IdTamanho == null || i.IdVariantesTamanho == IdTamanho)
                            & i.IdNotaSaida == IdNotaSaida
                            select i).ToList();

            if (baixados != null)
            {
                if (baixados.Count > 0)
                {
                    return;
                }
            }
            else
            {
                return;
            }




            List<Inventario> Estoque = (from i in db.Inventario
                                        from l in db.RecebimentoItemLote
                                        .Where(x => x.IdLote == i.IdLote)

                                        where i.IdProduto == pIdProduto
                                        & (i.IdTipoDocumento == 3 || i.IdTipoDocumento == 5) //recebimento ou nota entrada
                                        & (IdCor == null || i.IdVariantesCor == IdCor)
                                        & (IdEstilo == null || i.IdVariantesEstilo == IdEstilo)
                                        & (IdConfiguracao == null || i.IdVariantesConfig == IdConfiguracao)
                                        & (IdTamanho == null || i.IdVariantesTamanho == IdTamanho)
                                        & (LoteInterno == "" || l.LoteInterno == LoteInterno) //lote interno
                                        & (LoteFornecedor == "" || l.LoteFornecedor == LoteFornecedor) // lote fornecedor
                                        & (i.QuantidadeRetirada == null)

                                        select i).OrderBy(x => x.IdInventario).ToList();

            decimal Saldo = Qtde;
            foreach (Inventario i in Estoque)
            {
                if (Saldo > 0)
                {
                    decimal EstoqueAnterior = SaldoAnterior((int)i.IdProduto);
                    //Verifica se a quantidade atende a qtde pedida.
                    if (i.Quantidade > Saldo)
                    {

                        i.QuantidadeRetirada = Saldo;
                        i.DataSaida = DateTime.Now;
                        i.IdNotaSaida = IdNotaSaida;
                        eDal.Update(i);
                        eDal.Save();

                        //lança a saida 
                        Inventario ivs = new Inventario();
                        ivs.IdEmpresa = i.IdEmpresa;
                        ivs.IdProduto = i.IdProduto;
                        ivs.IdDeposito = i.IdDeposito;
                        ivs.IdArmazem = i.IdArmazem;
                        ivs.IdLocalizacao = i.IdLocalizacao;
                        ivs.IdVariantesCor = i.IdVariantesCor;
                        ivs.IdVariantesTamanho = i.IdVariantesTamanho;
                        ivs.IdVariantesEstilo = i.IdVariantesEstilo;
                        ivs.IdVariantesConfig = i.IdVariantesConfig;
                        ivs.IdUnidade = 4;
                        ivs.IdDocumento = i.IdDocumento;
                        ivs.IdTipoDocumento = i.IdTipoDocumento;
                        ivs.IdNCM = i.IdNCM;
                        ivs.TipoMovimentoFinanceiro = "S";
                        ivs.Quantidade = Saldo;
                        ivs.QuantidadeRetirada = Saldo;
                        ivs.DataFisica = i.DataFisica;
                        ivs.DataFinanceira = i.DataFinanceira;
                        ivs.CustoReposicao = i.CustoReposicao;
                        ivs.EstoqueAnterior = EstoqueAnterior;
                        ivs.Saldo = EstoqueAnterior - Saldo;
                        ivs.DataEmissaoNF = i.DataEmissaoNF;
                        ivs.NumeroDocumentoNF = i.NumeroDocumentoNF;
                        ivs.IdNotaSaida = IdNotaSaida;
                        ivs.Serie = i.Serie;
                        ivs.IdLote = i.IdLote;
                        eDal.Insert(ivs);
                        eDal.Save();

                        //se tiver saldo da entrada do saldo
                        if (i.Quantidade > i.QuantidadeRetirada)
                        {
                            Inventario iv = new Inventario();
                            iv.IdEmpresa = i.IdEmpresa;
                            iv.IdProduto = i.IdProduto;
                            iv.IdDeposito = i.IdDeposito;
                            iv.IdArmazem = i.IdArmazem;
                            iv.IdLocalizacao = i.IdLocalizacao;
                            iv.IdVariantesCor = i.IdVariantesCor;
                            iv.IdVariantesTamanho = i.IdVariantesTamanho;
                            iv.IdVariantesEstilo = i.IdVariantesEstilo;
                            iv.IdVariantesConfig = i.IdVariantesConfig;
                            iv.IdUnidade = 4;
                            iv.IdDocumento = i.IdDocumento;
                            iv.IdTipoDocumento = i.IdTipoDocumento;
                            iv.IdNCM = i.IdNCM;
                            iv.TipoMovimentoFinanceiro = i.TipoMovimentoFinanceiro;
                            iv.Quantidade = i.Quantidade - Saldo;
                            iv.DataFisica = i.DataFisica;
                            iv.DataFinanceira = i.DataFinanceira;
                            iv.CustoReposicao = i.CustoReposicao;
                            iv.EstoqueAnterior = EstoqueAnterior;
                            iv.Saldo = EstoqueAnterior - Saldo;
                            iv.DataEmissaoNF = i.DataEmissaoNF;
                            iv.NumeroDocumentoNF = i.NumeroDocumentoNF;
                            iv.Serie = i.Serie;
                            iv.IdLote = i.IdLote;
                            eDal.Insert(iv);
                            eDal.Save();
                        }
                        //zera o saldo.
                        Saldo = 0;

                    }
                    else
                    {
                        Saldo = Saldo - (decimal)i.Quantidade;
                        i.QuantidadeRetirada = i.Quantidade;
                        i.DataSaida = DateTime.Now;
                        i.IdNotaSaida = IdNotaSaida;
                        eDal.Update(i);
                        eDal.Save();

                        //lança a saida 
                        Inventario ivs = new Inventario();
                        ivs.IdEmpresa = i.IdEmpresa;
                        ivs.IdProduto = i.IdProduto;
                        ivs.IdDeposito = i.IdDeposito;
                        ivs.IdArmazem = i.IdArmazem;
                        ivs.IdLocalizacao = i.IdLocalizacao;
                        ivs.IdVariantesCor = i.IdVariantesCor;
                        ivs.IdVariantesTamanho = i.IdVariantesTamanho;
                        ivs.IdVariantesEstilo = i.IdVariantesEstilo;
                        ivs.IdVariantesConfig = i.IdVariantesConfig;
                        ivs.IdUnidade = 4;
                        ivs.IdDocumento = i.IdDocumento;
                        ivs.IdTipoDocumento = i.IdTipoDocumento;
                        ivs.IdNCM = i.IdNCM;
                        ivs.TipoMovimentoFinanceiro = "S";
                        ivs.Quantidade = i.Quantidade;
                        ivs.QuantidadeRetirada = i.Quantidade;
                        ivs.DataFisica = i.DataFisica;
                        ivs.DataFinanceira = i.DataFinanceira;
                        ivs.CustoReposicao = i.CustoReposicao;
                        ivs.EstoqueAnterior = EstoqueAnterior;
                        ivs.Saldo = EstoqueAnterior - Qtde;
                        ivs.DataEmissaoNF = i.DataEmissaoNF;
                        ivs.NumeroDocumentoNF = i.NumeroDocumentoNF;
                        ivs.IdNotaSaida = IdNotaSaida;
                        ivs.Serie = i.Serie;
                        ivs.IdLote = i.IdLote;
                        eDal.Insert(ivs);
                        eDal.Save();

                        //se tiver saldo da entrada do saldo
                        //if (i.Quantidade > i.QuantidadeRetirada)
                        //{
                        //    Inventario iv = new Inventario();
                        //    iv.IdEmpresa = i.IdEmpresa;
                        //    iv.IdProduto = i.IdProduto;
                        //    iv.IdDeposito = i.IdDeposito;
                        //    iv.IdArmazem = i.IdArmazem;
                        //    iv.IdLocalizacao = i.IdLocalizacao;
                        //    iv.IdVariantesCor = i.IdVariantesCor;
                        //    iv.IdVariantesTamanho = i.IdVariantesTamanho;
                        //    iv.IdVariantesEstilo = i.IdVariantesEstilo;
                        //    iv.IdVariantesConfig = i.IdVariantesConfig;
                        //    iv.IdUnidade = i.IdUnidade;
                        //    iv.IdDocumento = i.IdDocumento;
                        //    iv.IdTipoDocumento = i.IdTipoDocumento;
                        //    iv.IdNCM = i.IdNCM;
                        //    iv.TipoMovimentoFinanceiro = i.TipoMovimentoFinanceiro;
                        //    iv.Quantidade = i.Quantidade - Qtde;
                        //    iv.DataFisica = i.DataFisica;
                        //    iv.DataFinanceira = i.DataFinanceira;
                        //    iv.CustoReposicao = i.CustoReposicao;
                        //    iv.EstoqueAnterior = EstoqueAnterior;
                        //    iv.Saldo = EstoqueAnterior - Qtde;
                        //    iv.DataEmissaoNF = i.DataEmissaoNF;
                        //    iv.NumeroDocumentoNF = i.NumeroDocumentoNF;
                        //    iv.Serie = i.Serie;
                        //    iv.IdLote = i.IdLote;
                        //    eDal.Insert(iv);
                        //    eDal.Save();
                        //}
                    }
                }
            }
        }

        public bool AtualizaEstoqueFinanceiro(NotaFiscal pNota, List<NotaFiscalItem> pItens)
        {
            InventarioDAL eDal = new InventarioDAL();
            bool Atualizou = true;
            List<RecebimentoItemLote> Lotes = (from i in db.RecebimentoItem
                                               join l in db.RecebimentoItemLote on i.IdRecebimentoItem equals l.IdRecebimentoItem
                                               where i.IdNotaFiscal == pNota.IdNotaFiscal
                                               select l).ToList();

            if (Lotes == null)
            {
                Atualizou = false;
            }
            else
            {
                foreach (RecebimentoItemLote l in Lotes)
                {
                    List<Inventario> listaInv = eDal.GetByLoteId(Convert.ToInt32(l.IdLote));
                    foreach (Inventario i in listaInv)
                    {
                        i.IdDocumento = pNota.IdNotaFiscal;
                        i.IdTipoDocumento = 3;
                        i.DataFinanceira = DateTime.Now;
                        NotaFiscalItem nfi = pItens.Where(x => x.IdProduto == i.IdProduto).FirstOrDefault();
                        if (nfi != null) i.CustoReposicao = nfi.ValorUnitario;
                        i.DataEmissaoNF = pNota.DataEmissao;
                        i.NumeroDocumentoNF = pNota.Numero;
                        i.Serie = pNota.Serie;
                        eDal.Update(i);
                        eDal.Save();
                    }
                }
            }
            return Atualizou;
        }

        public void AjusteEstoqueEntrada(AjusteEstoque aj)
        {
            Inventario i = new Inventario();
            i.IdEmpresa = aj.IdEmpresa;
            i.IdProduto = aj.IdProduto;
            i.IdDeposito = aj.IdDeposito;
            i.IdArmazem = aj.IdArmazem;
            i.IdLocalizacao = aj.IdLocalizacao;
            i.IdVariantesConfig = aj.IdVariantesConfig;
            i.IdVariantesTamanho = aj.IdVariantesTamanho;
            i.IdVariantesCor = aj.IdVariantesCor;
            i.IdVariantesEstilo = aj.IdVariantesEstilo;
            i.IdUnidade = 4;
            i.IdTipoDocumento = 7; //ajuste de estoque
            i.IdDocumento = aj.IdAjusteEstoque;
            i.TipoMovimentoFinanceiro = "E";
            i.IdNCM = aj.IdNCM;
            i.Quantidade = aj.Quantidade;
            i.DataVencimento = aj.DataVencimento;
            i.DataFabricacao = aj.DataFabricacao;
            i.DataAvisoPrateleira = aj.DataAvisoPrateleira;
            i.DataValidade = aj.DataValidade;
            i.LoteFornecedor = aj.LoteFornecedor;
            i.LoteInterno = aj.LoteInterno;
            i.DataFisica = DateTime.Now;

            //Consultamos o Estoque
            vwEstoqueSintetico estoque = ConsultaEstoqueSintetico(aj.IdProduto, aj.IdDeposito, aj.IdArmazem, aj.IdLocalizacao, aj.IdVariantesConfig, aj.IdVariantesTamanho, aj.IdVariantesCor, aj.IdVariantesEstilo, 7).FirstOrDefault();
            if (estoque == null)
            {
                i.EstoqueAnterior = 0;
            }
            else
            {
                i.EstoqueAnterior = estoque.Quantidade;
            }
            i.Saldo = i.EstoqueAnterior + i.Quantidade;
            dal.Insert(i);
            dal.Save();
        }

        public void AjusteEstoqueSaida(AjusteEstoque i)
        {  
            //lança a saida
            Inventario ivs = new Inventario();
            ivs.IdEmpresa = i.IdEmpresa;
            ivs.IdProduto = i.IdProduto;
            ivs.IdDeposito = i.IdDeposito;
            ivs.IdArmazem = i.IdArmazem;
            ivs.IdLocalizacao = i.IdLocalizacao;
            ivs.IdVariantesCor = i.IdVariantesCor;
            ivs.IdVariantesTamanho = i.IdVariantesTamanho;
            ivs.IdVariantesEstilo = i.IdVariantesEstilo;
            ivs.IdVariantesConfig = i.IdVariantesConfig;
            ivs.IdDocumento = i.IdAjusteEstoque;
            ivs.IdUnidade = 4;
            ivs.IdDocumento = i.IdDocumento;
            ivs.IdTipoDocumento = 7;
            ivs.IdNCM = i.IdNCM;
            ivs.TipoMovimentoFinanceiro = "S";
            ivs.Quantidade = i.Quantidade * -1; 
            ivs.DataFisica = DateTime.Now; 
            ivs.IdLote = i.IdLote;
            dal.Insert(ivs);
            dal.Save(); 

        }


        public void BaixaNotaVendas(int IdNotaFiscal)
        {
            InventarioDAL dal = new InventarioDAL();
            var Itens = new NotaFiscalItemDAL().GetByNF(IdNotaFiscal);
            var Nota = new NotaFiscalDAL().GetByID(IdNotaFiscal);
            foreach (var ni in Itens)
            {
                var i = new PedidoVendaItemDAL().GetByID(Convert.ToInt32(ni.IdPedidoVendaItem));
                Inventario ivs = new Inventario();
                ivs.IdEmpresa = Nota.IdEmpresa;
                ivs.IdProduto = i.IdProduto;
                ivs.IdDeposito = i.IdDeposito;
                ivs.IdArmazem = i.IdArmazem;
                ivs.IdLocalizacao = i.IdLocalizacao;
                ivs.IdVariantesCor = i.IdVariantesCor;
                ivs.IdVariantesTamanho = i.IdVariantesTamanho;
                ivs.IdVariantesEstilo = i.IdVariantesEstilo;
                ivs.IdVariantesConfig = i.IdVariantesConfig;
                ivs.IdDocumento = ni.IdNotaFiscal;
                ivs.IdUnidade = 4;
                ivs.IdDocumento = ni.IdNotaFiscalItem;
                ivs.IdTipoDocumento = 6;
                ivs.IdNCM = i.IdNCM;
                ivs.TipoMovimentoFinanceiro = "S";
                ivs.Quantidade = i.Quantidade * -1;
                //ivs.QuantidadeRetirada = aj.Quantidade;
                ivs.DataFisica = DateTime.Now;
                //ivs.DataFinanceira = i.DataFinanceira;
                //ivs.CustoReposicao = i.CustoReposicao; 
                //ivs.DataEmissaoNF = i.DataEmissaoNF;
                //ivs.NumeroDocumentoNF = i.NumeroDocumentoNF; 
                //;ivs.Serie = i.Serie;
                //ivs.IdLote = i.IdLote;
                dal.Insert(ivs);
                dal.Save();
            }
        }

        public void BaixaPedidoBalcao(int IdPedidoBalcao)
        {
            InventarioDAL dal = new InventarioDAL();
            var Itens = new PedidoBalcaoProdutoDAL().getByPedidoId(IdPedidoBalcao); 
            foreach (var i in Itens)
            {
                 
                Inventario ivs = new Inventario();
                ivs.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                ivs.IdProduto = i.IdProduto; 
                ivs.IdDocumento = i.IdPedidoBalcao;
                ivs.IdUnidade = 4;
                ivs.IdDeposito = 1;
                ivs.IdTipoDocumento = 10;
                ivs.IdNCM = i.Produto.FiscalIdNCM;
                ivs.TipoMovimentoFinanceiro = "S";
                ivs.Quantidade = i.Qtde * -1; 
                ivs.DataFisica = DateTime.Now; 
                dal.Insert(ivs);
                dal.Save();
            }
        }

        public void EntraOrdemProducao(OrdemProducao o, int IdArmazem, int IdLocalizacao, int IdDeposito)
        {
            //entra com os produtos
            var pl = o.Produtos.ToList();
            var plano = new PlanoProducaoDAL().GetByID(Convert.ToInt32(o.IdPlanoProducao));
            foreach(var p in pl)
            {
                if(p.Qtde > 0)
                {
                    Inventario i = new Inventario();
                    i.IdEmpresa = o.IdEmpresa;
                    i.IdProduto = p.IdProduto;
                    i.IdVariantesConfig = p.IdVariantesConfig;
                    i.IdVariantesCor = p.IdVariantesCor;
                    i.IdVariantesEstilo = p.IdVariantesEstilo;
                    i.IdVariantesTamanho = p.IdVariantesTamanho;
                    if (IdDeposito > 0) i.IdDeposito = IdDeposito;
                    if (IdArmazem > 0) i.IdArmazem = IdArmazem;
                    if (IdLocalizacao > 0) i.IdLocalizacao = IdLocalizacao;
                    i.IdUnidade = 4;
                    i.IdTipoDocumento = 4; //Ordem de produção
                    i.IdDocumento = o.IdOrdemProducao;
                    i.TipoMovimentoFinanceiro = "E";
                    i.IdNCM = p.Produto.FiscalIdNCM;
                    i.Quantidade = p.Qtde;
                    if (p.Produto.EstoqueValidadeDias != null)
                    {
                        i.DataVencimento = DateTime.Now.AddDays(Convert.ToDouble(p.Produto.EstoqueValidadeDias));
                    }

                    i.DataFabricacao = DateTime.Now;
                    i.DataFisica = DateTime.Now;
                    i.LoteInterno = o.Lote.Ano.ToString() + o.Lote.numero.ToString(); 

                    //Consultamos o Estoque
                    vwEstoqueSintetico estoque = ConsultaEstoqueSintetico(i.IdProduto, i.IdDeposito, i.IdArmazem, i.IdLocalizacao, i.IdVariantesConfig, i.IdVariantesTamanho, i.IdVariantesCor, i.IdVariantesEstilo, 7).FirstOrDefault();
                    if (estoque == null)
                    {
                        i.EstoqueAnterior = 0;
                    }
                    else
                    {
                        i.EstoqueAnterior = estoque.Quantidade;
                    }
                    i.Saldo = i.EstoqueAnterior + i.Quantidade;
                    dal.Insert(i);
                    dal.Save();
                } 
            }


            //baixa a materia prima
            var mat = o.Materiais.ToList();
            foreach(var m in mat)
            {
                if(m.KilosTotal > 0)
                {
                    Inventario ivs = new Inventario();
                    ivs.IdEmpresa = o.IdEmpresa;
                    ivs.IdProduto = m.IdProduto;  
                    ivs.IdDocumento = o.IdOrdemProducao;
                    ivs.IdUnidade = 4; 
                    ivs.IdTipoDocumento = 4; 
                    ivs.TipoMovimentoFinanceiro = "S";
                    ivs.Quantidade = m.KilosTotal * -1; 
                    ivs.DataFisica = DateTime.Now;  
                    dal.Insert(ivs);
                    dal.Save();
                }
            }
        } 
    }
}
