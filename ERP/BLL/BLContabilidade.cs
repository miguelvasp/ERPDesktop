using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Models;
using ERP.ModelView;
using ERP.DAL;

namespace ERP.BLL
{
    public class BLContabilidade
    {
        #region DAL

        public PedidoCompraDAL pcDal = new PedidoCompraDAL();
        public PedidoVendaDAL pvDal = new PedidoVendaDAL();
        public PedidoCompraContabilidadeDAL pcContabilidadeDal = new PedidoCompraContabilidadeDAL();
        public PedidoVendaContabilidadeDAL pvContabilidadeDal = new PedidoVendaContabilidadeDAL();
        TextoTransacaoDAL textoTransacaoDal = new TextoTransacaoDAL();

        #endregion

        #region Compras
        public void GeraContabilidadeCompras(int IdPedidoCompras)
        {
            PedidoCompra pc = new PedidoCompraDAL().PCRepository.GetByID(IdPedidoCompras);
            foreach (PedidoCompraItem Item in pc.PedidoCompraItem)
            {
                //1 - Case:Exemplo de uma compra sem impostos, sem desconto, sem frete e sem royalty, sem movimentação de estoque criando títulos no contas a pagar. 

                if (pc.IdOperacao != null)
                {
                    //Conta de Debito
                    if (!Convert.ToBoolean(pc.Operacao.MovimentaEstoque)) //Nao Movimenta Estoque
                    {
                        if (Convert.ToBoolean(pc.Operacao.TransacoesFinanceiras)) //Gera Financeiro
                        {
                            PedidoCompraContabilidade PCContabilidadeDebito = pcContabilidadeDal.GetByPedidoItem(Item.IdPedidoCompraItem, "D");
                            if (PCContabilidadeDebito == null) PCContabilidadeDebito = new PedidoCompraContabilidade();
                            PCContabilidadeDebito.IdContaContabil = GetContaContabilCompras(pc, Item, 15);
                            PCContabilidadeDebito.ValorDebito = Item.ValorLiquido;
                            PCContabilidadeDebito.IdOrigemLancamento = 36;
                            PCContabilidadeDebito.DataHora = DateTime.Now;
                            PCContabilidadeDebito.IdMoeda = pc.IdMoeda;
                            PCContabilidadeDebito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                            PCContabilidadeDebito.Preco = 0;
                            PCContabilidadeDebito.IdFornecedor = pc.IdFornecedor;
                            PCContabilidadeDebito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                            PCContabilidadeDebito.Origem = "Ordem de compra";
                            PCContabilidadeDebito.IdLote = "PC" + pc.IdPedidoCompra.ToString().PadLeft(10, '0');
                            PCContabilidadeDebito.TextoTransacao = GetTextoTransacao(36, null, pc.IdFornecedor, pc.IdOperacao, pc.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                            PCContabilidadeDebito.IdTipoLancamento = 15;
                            PCContabilidadeDebito.IdPedidoCompra = pc.IdPedidoCompra;
                            PCContabilidadeDebito.IdPedidoCompraItem = Item.IdPedidoCompraItem;
                            PCContabilidadeDebito.TipoMovimento = "D";
                            if (PCContabilidadeDebito.IdPedidoCompraContabilidade == 0)
                            {
                                pcContabilidadeDal.Insert(PCContabilidadeDebito);
                            }
                            else
                            {
                                pcContabilidadeDal.Update(PCContabilidadeDebito);
                            }

                            pcContabilidadeDal.Save();


                            //Conta de Credito
                            if (pc.Operacao.IdPerfilFornecedor != null)
                            {
                                if (pc.Operacao.PerfilFornecedor.IdContaContabil != null)
                                {
                                    PedidoCompraContabilidade PCContabilidadeCredito = pcContabilidadeDal.GetByPedidoItem(Item.IdPedidoCompraItem, "C");
                                    if (PCContabilidadeCredito == null) PCContabilidadeCredito = new PedidoCompraContabilidade();
                                    PCContabilidadeCredito.IdContaContabil = pc.Operacao.PerfilFornecedor.IdContaContabil;
                                    PCContabilidadeCredito.ValorCredito = Item.ValorLiquido;
                                    PCContabilidadeCredito.IdOrigemLancamento = 36;
                                    PCContabilidadeCredito.DataHora = DateTime.Now;
                                    PCContabilidadeCredito.IdMoeda = pc.IdMoeda;
                                    PCContabilidadeCredito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                    PCContabilidadeCredito.Preco = 0;
                                    PCContabilidadeCredito.IdFornecedor = pc.IdFornecedor;
                                    PCContabilidadeCredito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                    PCContabilidadeCredito.Origem = "Ordem de compra";
                                    PCContabilidadeCredito.IdLote = "PC" + pc.IdPedidoCompra.ToString().PadLeft(10, '0');
                                    PCContabilidadeCredito.TextoTransacao = GetTextoTransacao(36, null, pc.IdFornecedor, pc.IdOperacao, pc.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                    PCContabilidadeCredito.IdPedidoCompra = pc.IdPedidoCompra;
                                    PCContabilidadeCredito.IdTipoLancamento = 36;//Saldo de Forecedor
                                    PCContabilidadeCredito.IdPedidoCompraItem = Item.IdPedidoCompraItem;
                                    PCContabilidadeCredito.TipoMovimento = "C";
                                    if (PCContabilidadeCredito.IdPedidoCompraContabilidade == 0)
                                    {
                                        pcContabilidadeDal.Insert(PCContabilidadeCredito);
                                    }
                                    else
                                    {
                                        pcContabilidadeDal.Update(PCContabilidadeCredito);
                                    }
                                    pcContabilidadeDal.Save();
                                }
                            }
                        }
                    }


                }

                //2 - Case: Exemplo de uma compra sem impostos, sem desconto, sem frete e sem royalty. Compra com Operação 
                if (pc.IdOperacao != null)
                {
                    //Conta de Debito
                    if (Convert.ToBoolean(pc.Operacao.MovimentaEstoque)) //Nao Movimenta Estoque
                    {
                        if (Convert.ToBoolean(pc.Operacao.TransacoesFinanceiras)) //Gera Financeiro
                        {
                            PedidoCompraContabilidade PCContabilidadeDebito = pcContabilidadeDal.GetByPedidoItem(Item.IdPedidoCompraItem, "D");
                            if (PCContabilidadeDebito == null) PCContabilidadeDebito = new PedidoCompraContabilidade();
                            PCContabilidadeDebito.IdContaContabil = GetContaContabilCompras(pc, Item, 9);//Tipo lançamento Recebimento estoque / Pedido de compras
                            PCContabilidadeDebito.ValorDebito = Item.ValorLiquido;
                            PCContabilidadeDebito.IdOrigemLancamento = 36;
                            PCContabilidadeDebito.DataHora = DateTime.Now;
                            PCContabilidadeDebito.IdMoeda = pc.IdMoeda;
                            PCContabilidadeDebito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                            PCContabilidadeDebito.Preco = 0;
                            PCContabilidadeDebito.IdFornecedor = pc.IdFornecedor;
                            PCContabilidadeDebito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                            PCContabilidadeDebito.Origem = "Ordem de compra";
                            PCContabilidadeDebito.IdLote = "PC" + pc.IdPedidoCompra.ToString().PadLeft(10, '0');
                            PCContabilidadeDebito.TextoTransacao = GetTextoTransacao(36, null, pc.IdFornecedor, pc.IdOperacao, pc.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                            PCContabilidadeDebito.IdTipoLancamento = 9;
                            PCContabilidadeDebito.IdPedidoCompra = pc.IdPedidoCompra;
                            PCContabilidadeDebito.IdPedidoCompraItem = Item.IdPedidoCompraItem;
                            PCContabilidadeDebito.TipoMovimento = "D";
                            if (PCContabilidadeDebito.IdPedidoCompraContabilidade == 0)
                            {
                                pcContabilidadeDal.Insert(PCContabilidadeDebito);
                            }
                            else
                            {
                                pcContabilidadeDal.Update(PCContabilidadeDebito);
                            }
                            pcContabilidadeDal.Save();

                            //Conta de Credito
                            if (pc.Operacao.IdPerfilFornecedor != null)
                            {
                                if (pc.Operacao.PerfilFornecedor.IdContaContabil != null)
                                {
                                    PedidoCompraContabilidade PCContabilidadeCredito = pcContabilidadeDal.GetByPedidoItem(Item.IdPedidoCompraItem, "C");
                                    if (PCContabilidadeCredito == null) PCContabilidadeCredito = new PedidoCompraContabilidade();
                                    PCContabilidadeCredito.IdContaContabil = pc.Operacao.PerfilFornecedor.IdContaContabil;
                                    PCContabilidadeCredito.ValorCredito = Item.ValorLiquido;
                                    PCContabilidadeCredito.IdOrigemLancamento = 36;
                                    PCContabilidadeCredito.DataHora = DateTime.Now;
                                    PCContabilidadeCredito.IdMoeda = pc.IdMoeda;
                                    PCContabilidadeCredito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                    PCContabilidadeCredito.Preco = 0;
                                    PCContabilidadeCredito.IdFornecedor = pc.IdFornecedor;
                                    PCContabilidadeCredito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                    PCContabilidadeCredito.Origem = "Ordem de compra";
                                    PCContabilidadeCredito.IdLote = "PC" + pc.IdPedidoCompra.ToString().PadLeft(10, '0');
                                    PCContabilidadeCredito.TextoTransacao = GetTextoTransacao(36, null, pc.IdFornecedor, pc.IdOperacao, pc.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                    PCContabilidadeCredito.IdPedidoCompra = pc.IdPedidoCompra;
                                    PCContabilidadeCredito.IdTipoLancamento = 36;//Saldo de Fornecedor
                                    PCContabilidadeCredito.IdPedidoCompraItem = Item.IdPedidoCompraItem;
                                    PCContabilidadeCredito.TipoMovimento = "C";
                                    if (PCContabilidadeCredito.IdPedidoCompraContabilidade == 0)
                                    {
                                        pcContabilidadeDal.Insert(PCContabilidadeCredito);
                                    }
                                    else
                                    {
                                        pcContabilidadeDal.Update(PCContabilidadeCredito);
                                    }
                                    pcContabilidadeDal.Save();
                                }
                            }


                        }
                    }



                }
            }
        }

        public int? GetContaContabilCompras(PedidoCompra pc, PedidoCompraItem Item, int IdTipoLancamento)
        {
            if (pc.Operacao.IdContaContabil != null) //Procura a conta na operação da compra
            {
                return pc.Operacao.IdContaContabil;
            }
            else //senao ve a conta nos lançamentos pelo tipo de lançamento Despesa de compra para despesa
            {
                List<LancamentoModelView> Lancamentos = new LancamentoDAL().getByTipoLancamento(IdTipoLancamento);

                //Pesquisa se existe uma condição para o produto
                var lancProduto = Lancamentos.Where(x => x.IdProduto == Item.IdProduto).FirstOrDefault();
                if (lancProduto != null && lancProduto.IdContaContabil != null)
                {
                    return lancProduto.IdContaContabil;
                }
                else
                {
                    //Se nao encontra para o produto pesquisa pelo grupo
                    var LancGrupo = Lancamentos.Where(x => x.IdGRupoProduto == Item.Produto.IdGrupoProduto).FirstOrDefault();
                    if (LancGrupo != null && lancProduto.IdContaContabil != null)
                    {
                        return LancGrupo.IdContaContabil;
                    }
                    else
                    {
                        //Se nao encontra o grupo pesquisa pelo fornecedor
                        var LancForn = Lancamentos.Where(x => x.IdFornecedor == pc.IdFornecedor).FirstOrDefault();
                        if (LancForn != null && LancForn.IdContaContabil != null)
                        {
                            return LancForn.IdContaContabil;
                        }
                        else
                        {
                            //Se nao acha o fornecedor pesquisa pelo grupo de fornecedor
                            var LancGrupoForn = Lancamentos.Where(x => x.IdGrupoFornecedor == pc.Fornecedor.IdGrupoFornecedor).FirstOrDefault();
                            if (LancGrupoForn != null && LancGrupoForn.IdContaContabil != null)
                            {
                                return LancGrupoForn.IdContaContabil;
                            }
                            else
                            {
                                //Pesquisa conta para o item relação a todos os produtos
                                var LancTodosProdutos = Lancamentos.Where(x => x.RelacaoItem == 3).FirstOrDefault();
                                if (LancTodosProdutos != null && LancTodosProdutos.IdContaContabil != null)
                                {
                                    return LancTodosProdutos.IdContaContabil;
                                }
                                else
                                {
                                    //finalmente tenta achar para todos os produtos do grupo
                                    var LancTodosGrupos = Lancamentos.Where(x => x.RelacaoGrupo == 3).FirstOrDefault();
                                    if (LancTodosGrupos != null && LancTodosGrupos.IdContaContabil != null)
                                    {
                                        return LancTodosGrupos.IdContaContabil;
                                    }
                                    else
                                    {
                                        return null;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion


        #region Vendas
        public void GeraContabilidadeVenda(int IdPedidoVenda)
        {
            PedidoVenda pv = new PedidoVendaDAL().PVRepository.GetByID(IdPedidoVenda);
            foreach (PedidoVendaItem Item in pv.PedidoVendaItem)
            {
                //1 - Case:Exemplo de uma venda sem impostos, sem desconto, sem frete e sem comissão..  
                if (pv.IdOperacao != null)
                {
                    //Conta de Credito
                    if (Convert.ToBoolean(pv.Operacao.MovimentaEstoque)) //Nao Movimenta Estoque
                    {
                        if (Convert.ToBoolean(pv.Operacao.TransacoesFinanceiras)) //Gera Financeiro
                        {
                            PedidoVendaContabilidade PCContabilidadeCredito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "C");
                            if (PCContabilidadeCredito == null) PCContabilidadeCredito = new PedidoVendaContabilidade();
                            PCContabilidadeCredito.IdContaContabil = GetContaContabilVendas(pv, Item, 34); //Tipo lançamento > receita
                            PCContabilidadeCredito.ValorDebito = Item.ValorLiquido;
                            PCContabilidadeCredito.IdOrigemLancamento = 33;
                            PCContabilidadeCredito.DataHora = DateTime.Now;
                            PCContabilidadeCredito.IdMoeda = pv.IdMoeda;
                            PCContabilidadeCredito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                            PCContabilidadeCredito.Preco = 0;
                            PCContabilidadeCredito.IdCliente = pv.IdCliente;
                            PCContabilidadeCredito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                            PCContabilidadeCredito.Origem = "Ordem de Venda";
                            PCContabilidadeCredito.IdLote = "PV" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                            PCContabilidadeCredito.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                            PCContabilidadeCredito.IdTipoLancamento = 34;
                            PCContabilidadeCredito.IdPedidoVenda = pv.IdPedidoVenda;
                            PCContabilidadeCredito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                            PCContabilidadeCredito.TipoMovimento = "C";
                            if (PCContabilidadeCredito.IdPedidoVendaContabilidade == 0)
                            {
                                pvContabilidadeDal.Insert(PCContabilidadeCredito);
                            }
                            else
                            {
                                pvContabilidadeDal.Update(PCContabilidadeCredito);
                            }

                            pvContabilidadeDal.Save();


                            //Conta de Debito
                            if (pv.Operacao.IdPerfilCliente != null)
                            {
                                if (pv.Operacao.PerfilCliente.IdContaContabil != null)
                                {
                                    PedidoVendaContabilidade PVContabilidadeDebito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "D");
                                    if (PVContabilidadeDebito == null) PVContabilidadeDebito = new PedidoVendaContabilidade();
                                    PVContabilidadeDebito.IdContaContabil = pv.Operacao.PerfilCliente.IdContaContabil;
                                    PVContabilidadeDebito.ValorCredito = Item.ValorLiquido;
                                    PVContabilidadeDebito.IdOrigemLancamento = 33;
                                    PVContabilidadeDebito.DataHora = DateTime.Now;
                                    PVContabilidadeDebito.IdMoeda = pv.IdMoeda;
                                    PVContabilidadeDebito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                    PVContabilidadeDebito.Preco = 0;
                                    PVContabilidadeDebito.IdCliente = pv.IdCliente;
                                    PVContabilidadeDebito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                    PVContabilidadeDebito.Origem = "Ordem de Venda";
                                    PVContabilidadeDebito.IdLote = "PV" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                    PVContabilidadeDebito.IdTipoLancamento = 38;//saldo de cliente
                                    PVContabilidadeDebito.IdPedidoVenda = pv.IdPedidoVenda;
                                    PVContabilidadeDebito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                    PVContabilidadeDebito.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                    PVContabilidadeDebito.TipoMovimento = "D";
                                    if (PVContabilidadeDebito.IdPedidoVendaContabilidade == 0)
                                    {
                                        pvContabilidadeDal.Insert(PVContabilidadeDebito);
                                    }
                                    else
                                    {
                                        pvContabilidadeDal.Update(PVContabilidadeDebito);
                                    }
                                    pvContabilidadeDal.Save();
                                }
                            }
                        }
                    }


                }

                //2 - Case: Exemplo de uma Venda sem impostos, sem desconto, sem frete e sem royalty. Venda com Operação 
                if (pv.IdOperacao != null)
                {
                    //Conta de Credito
                    if (!Convert.ToBoolean(pv.Operacao.MovimentaEstoque)) //Nao Movimenta Estoque
                    {
                        if (!Convert.ToBoolean(pv.Operacao.TransacoesFinanceiras)) //nao Gera Financeiro
                        {
                            PedidoVendaContabilidade PVContabilidadeCredito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "D");
                            if (PVContabilidadeCredito == null) PVContabilidadeCredito = new PedidoVendaContabilidade();
                            PVContabilidadeCredito.IdContaContabil = GetContaContabilVendas(pv, Item, 3);//Tipo lançamento Saida / Pedido de Venda
                            PVContabilidadeCredito.ValorDebito = Item.ValorLiquido;
                            PVContabilidadeCredito.IdOrigemLancamento = 33;
                            PVContabilidadeCredito.DataHora = DateTime.Now;
                            PVContabilidadeCredito.IdMoeda = pv.IdMoeda;
                            PVContabilidadeCredito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                            PVContabilidadeCredito.Preco = 0;
                            PVContabilidadeCredito.IdCliente = pv.IdCliente;
                            PVContabilidadeCredito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                            PVContabilidadeCredito.Origem = "Ordem de Venda";
                            PVContabilidadeCredito.IdLote = "PV" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                            PVContabilidadeCredito.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                            PVContabilidadeCredito.IdTipoLancamento = 3;
                            PVContabilidadeCredito.IdPedidoVenda = pv.IdPedidoVenda;
                            PVContabilidadeCredito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                            PVContabilidadeCredito.TipoMovimento = "C";
                            if (PVContabilidadeCredito.IdPedidoVendaContabilidade == 0)
                            {
                                pvContabilidadeDal.Insert(PVContabilidadeCredito);
                            }
                            else
                            {
                                pvContabilidadeDal.Update(PVContabilidadeCredito);
                            }
                            pvContabilidadeDal.Save();

                            //Conta de Debito
                            if (pv.Operacao.IdPerfilCliente != null)
                            {
                                if (pv.Operacao.PerfilCliente.IdContaContabil != null)
                                {
                                    PedidoVendaContabilidade PVContabilidadeDebito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "D");
                                    if (PVContabilidadeDebito == null) PVContabilidadeDebito = new PedidoVendaContabilidade();
                                    PVContabilidadeDebito.IdContaContabil = GetContaContabilVendas(pv, Item, 4);//Tipo lançamento Consumo / Pedido de Venda
                                    PVContabilidadeDebito.ValorCredito = Item.ValorLiquido;
                                    PVContabilidadeDebito.IdOrigemLancamento = 33;
                                    PVContabilidadeDebito.DataHora = DateTime.Now;
                                    PVContabilidadeDebito.IdMoeda = pv.IdMoeda;
                                    PVContabilidadeDebito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                    PVContabilidadeDebito.Preco = 0;
                                    PVContabilidadeDebito.IdCliente = pv.IdCliente;
                                    PVContabilidadeDebito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                    PVContabilidadeDebito.Origem = "Ordem de Venda";
                                    PVContabilidadeDebito.IdLote = "PC" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                    PVContabilidadeDebito.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                    PVContabilidadeDebito.IdPedidoVenda = pv.IdPedidoVenda;
                                    PVContabilidadeDebito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                    PVContabilidadeDebito.IdTipoLancamento = 4;
                                    PVContabilidadeDebito.TipoMovimento = "D";
                                    if (PVContabilidadeDebito.IdPedidoVendaContabilidade == 0)
                                    {
                                        pvContabilidadeDal.Insert(PVContabilidadeDebito);
                                    }
                                    else
                                    {
                                        pvContabilidadeDal.Update(PVContabilidadeDebito);
                                    }
                                    pvContabilidadeDal.Save();
                                }
                            }


                        }
                    }



                }


                //Cases com impostos 
                //3 - Mesmo case 1 só que verifica se tem imposto ICMS
                if (pv.IdOperacao != null)
                {
                    //Conta de Credito
                    if (Convert.ToBoolean(pv.Operacao.MovimentaEstoque)) //Movimenta Estoque
                    {
                        if (Convert.ToBoolean(pv.Operacao.TransacoesFinanceiras)) //Gera Financeiro
                        {
                            PedidoVendaItemApuracaoImpostoDAL apuracaoImpostoDal = new PedidoVendaItemApuracaoImpostoDAL();
                            if (apuracaoImpostoDal.ContemTipoImposto(Item.IdPedidoVendaItem, 3)) //verifica se o item tem ICMS
                            {
                                CodigoImposto codigoImposto = apuracaoImpostoDal.GetCodigoImpostoItemPedidoVenda(Item.IdPedidoVendaItem, 3);
                                if (codigoImposto != null)
                                {
                                    if (codigoImposto.ImpostoIncluso)//imposto incluso == true
                                    {
                                        if (codigoImposto.CodigoTributacao.ValorFiscal == 1)//Com Crédito/Débito
                                        {
                                            PedidoVendaContabilidade PCContabilidadeCredito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "C");
                                            if (PCContabilidadeCredito == null) PCContabilidadeCredito = new PedidoVendaContabilidade();
                                            PCContabilidadeCredito.IdContaContabil = GetContaContabilVendas(pv, Item, 34); //Tipo lançamento > receita
                                            PCContabilidadeCredito.ValorDebito = Item.ValorLiquido;
                                            PCContabilidadeCredito.IdOrigemLancamento = 33;
                                            PCContabilidadeCredito.DataHora = DateTime.Now;
                                            PCContabilidadeCredito.IdMoeda = pv.IdMoeda;
                                            PCContabilidadeCredito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                            PCContabilidadeCredito.Preco = 0;
                                            PCContabilidadeCredito.IdCliente = pv.IdCliente;
                                            PCContabilidadeCredito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                            PCContabilidadeCredito.Origem = "Ordem de Venda";
                                            PCContabilidadeCredito.IdLote = "PV" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                            PCContabilidadeCredito.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                            PCContabilidadeCredito.IdTipoLancamento = 34;
                                            PCContabilidadeCredito.IdPedidoVenda = pv.IdPedidoVenda;
                                            PCContabilidadeCredito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                            PCContabilidadeCredito.TipoMovimento = "C";
                                            PCContabilidadeCredito.Impostos = false;
                                            if (PCContabilidadeCredito.IdPedidoVendaContabilidade == 0)
                                            {
                                                pvContabilidadeDal.Insert(PCContabilidadeCredito);
                                            }
                                            else
                                            {
                                                pvContabilidadeDal.Update(PCContabilidadeCredito);
                                            }
                                            pvContabilidadeDal.Save();

                                            //Conta de Debito
                                            if (pv.Operacao.IdPerfilCliente != null)
                                            {
                                                if (pv.Operacao.PerfilCliente.IdContaContabil != null)
                                                {
                                                    PedidoVendaContabilidade PVContabilidadeDebito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "D");
                                                    if (PVContabilidadeDebito == null) PVContabilidadeDebito = new PedidoVendaContabilidade();
                                                    PVContabilidadeDebito.IdContaContabil = pv.Operacao.PerfilCliente.IdContaContabil;
                                                    PVContabilidadeDebito.ValorCredito = Item.ValorLiquido;
                                                    PVContabilidadeDebito.IdOrigemLancamento = 33;
                                                    PVContabilidadeDebito.DataHora = DateTime.Now;
                                                    PVContabilidadeDebito.IdMoeda = pv.IdMoeda;
                                                    PVContabilidadeDebito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                                    PVContabilidadeDebito.Preco = 0;
                                                    PVContabilidadeDebito.IdCliente = pv.IdCliente;
                                                    PVContabilidadeDebito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                                    PVContabilidadeDebito.Origem = "Ordem de Venda";
                                                    PVContabilidadeDebito.IdLote = "PV" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                                    PVContabilidadeDebito.IdTipoLancamento = 38;//saldo de cliente
                                                    PVContabilidadeDebito.IdPedidoVenda = pv.IdPedidoVenda;
                                                    PVContabilidadeDebito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                                    PVContabilidadeDebito.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                                    PVContabilidadeDebito.TipoMovimento = "D";
                                                    PVContabilidadeDebito.Impostos = false;
                                                    if (PVContabilidadeDebito.IdPedidoVendaContabilidade == 0)
                                                    {
                                                        pvContabilidadeDal.Insert(PVContabilidadeDebito);
                                                    }
                                                    else
                                                    {
                                                        pvContabilidadeDal.Update(PVContabilidadeDebito);
                                                    }
                                                    pvContabilidadeDal.Save();
                                                }
                                            }


                                            //Efetua o lançamento dos impostos
                                            PedidoVendaItemApuracaoImposto apuracaoImposto = apuracaoImpostoDal.GetApuracaoImpostoItem(Item.IdPedidoVendaItem, 3);
                                            if (apuracaoImposto != null)
                                            {
                                                GrupoLancamentoContabil grupoLancamentoContabil = new GrupoLancamentoContabilDAL().GetByID(codigoImposto.IdGrupoLancamentoContabil);
                                                if (grupoLancamentoContabil != null)
                                                {
                                                    if (grupoLancamentoContabil.IdImpostoAPagar != null)
                                                    {
                                                        //lança o credito
                                                        PedidoVendaContabilidade pcvCredito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "C");
                                                        if (pcvCredito == null) pcvCredito = new PedidoVendaContabilidade();
                                                        pcvCredito.IdContaContabil = grupoLancamentoContabil.IdImpostoAPagar;
                                                        if (apuracaoImposto.ValorAjustado != null && apuracaoImposto.ValorAjustado > 0)
                                                        {
                                                            pcvCredito.ValorCredito = apuracaoImposto.ValorAjustado;
                                                        }
                                                        else
                                                        {
                                                            pcvCredito.ValorCredito = apuracaoImposto.ValorImposto;
                                                        }

                                                        pcvCredito.IdOrigemLancamento = 33;
                                                        pcvCredito.DataHora = DateTime.Now;
                                                        pcvCredito.IdMoeda = pv.IdMoeda;
                                                        pcvCredito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                                        pcvCredito.Preco = 0;
                                                        pcvCredito.IdCliente = pv.IdCliente;
                                                        pcvCredito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                                        pcvCredito.Origem = "Ordem de Venda";
                                                        pcvCredito.IdLote = "PV" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                                        pcvCredito.IdTipoLancamento = 82; //Imposto
                                                        pcvCredito.IdPedidoVenda = pv.IdPedidoVenda;
                                                        pcvCredito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                                        pcvCredito.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                                        pcvCredito.TipoMovimento = "C";
                                                        pcvCredito.Impostos = true;
                                                        if (pcvCredito.IdPedidoVendaContabilidade == 0)
                                                        {
                                                            pvContabilidadeDal.Insert(pcvCredito);
                                                        }
                                                        else
                                                        {
                                                            pvContabilidadeDal.Update(pcvCredito);
                                                        }
                                                        pvContabilidadeDal.Save();

                                                        //lança o debito
                                                        PedidoVendaContabilidade pcvDebito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "D");
                                                        if (pcvDebito == null) pcvDebito = new PedidoVendaContabilidade();
                                                        pcvDebito.IdContaContabil = grupoLancamentoContabil.IdDespesaComImposto;
                                                        if (apuracaoImposto.ValorAjustado != null && apuracaoImposto.ValorAjustado > 0)
                                                        {
                                                            pcvDebito.ValorCredito = apuracaoImposto.ValorAjustado;
                                                        }
                                                        else
                                                        {
                                                            pcvDebito.ValorCredito = apuracaoImposto.ValorImposto;
                                                        }

                                                        pcvDebito.IdOrigemLancamento = 33;
                                                        pcvDebito.DataHora = DateTime.Now;
                                                        pcvDebito.IdMoeda = pv.IdMoeda;
                                                        pcvDebito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                                        pcvDebito.Preco = 0;
                                                        pcvDebito.IdCliente = pv.IdCliente;
                                                        pcvDebito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                                        pcvDebito.Origem = "Ordem de Venda";
                                                        pcvDebito.IdLote = "PV" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                                        pcvDebito.IdTipoLancamento = 82; //Imposto
                                                        pcvDebito.IdPedidoVenda = pv.IdPedidoVenda;
                                                        pcvDebito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                                        pcvDebito.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                                        pcvDebito.TipoMovimento = "D";
                                                        pcvDebito.Impostos = true;
                                                        if (pcvDebito.IdPedidoVendaContabilidade == 0)
                                                        {
                                                            pvContabilidadeDal.Insert(pcvDebito);
                                                        }
                                                        else
                                                        {
                                                            pvContabilidadeDal.Update(pcvDebito);
                                                        }
                                                        pvContabilidadeDal.Save();
                                                    }

                                                }
                                            }



                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //4 - Mesmo case que o 2 só que verifica impostos
                if (pv.IdOperacao != null)
                {
                    //Conta de Credito
                    if (!Convert.ToBoolean(pv.Operacao.MovimentaEstoque)) //Nao Movimenta Estoque
                    {
                        if (!Convert.ToBoolean(pv.Operacao.TransacoesFinanceiras)) //nao Gera Financeiro
                        {
                            PedidoVendaItemApuracaoImpostoDAL apuracaoImpostoDal = new PedidoVendaItemApuracaoImpostoDAL();
                            if (apuracaoImpostoDal.ContemTipoImposto(Item.IdPedidoVendaItem, 3)) //verifica se o item tem ICMS
                            {
                                CodigoImposto codigoImposto = apuracaoImpostoDal.GetCodigoImpostoItemPedidoVenda(Item.IdPedidoVendaItem, 3);
                                if (codigoImposto != null)
                                {
                                    if (codigoImposto.ImpostoIncluso)//imposto incluso == true
                                    {
                                        if (codigoImposto.CodigoTributacao.ValorFiscal == 1)//Com Crédito/Débito
                                        {
                                            PedidoVendaContabilidade PVContabilidadeCredito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "D");
                                            if (PVContabilidadeCredito == null) PVContabilidadeCredito = new PedidoVendaContabilidade();
                                            PVContabilidadeCredito.IdContaContabil = pv.Operacao.IdContaContabil;//Somente a conta da operação.
                                            PVContabilidadeCredito.ValorDebito = Item.ValorLiquido;
                                            PVContabilidadeCredito.IdOrigemLancamento = 37;
                                            PVContabilidadeCredito.DataHora = DateTime.Now;
                                            PVContabilidadeCredito.IdMoeda = pv.IdMoeda;
                                            PVContabilidadeCredito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                            PVContabilidadeCredito.Preco = 0;
                                            PVContabilidadeCredito.IdCliente = pv.IdCliente;
                                            PVContabilidadeCredito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                            PVContabilidadeCredito.Origem = "Ordem de Venda";
                                            PVContabilidadeCredito.IdLote = "PV" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                            PVContabilidadeCredito.TextoTransacao = GetTextoTransacao(37, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                            PVContabilidadeCredito.IdTipoLancamento = 105;
                                            PVContabilidadeCredito.IdPedidoVenda = pv.IdPedidoVenda;
                                            PVContabilidadeCredito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                            PVContabilidadeCredito.TipoMovimento = "C";
                                            PVContabilidadeCredito.Impostos = false;
                                            if (PVContabilidadeCredito.IdPedidoVendaContabilidade == 0)
                                            {
                                                pvContabilidadeDal.Insert(PVContabilidadeCredito);
                                            }
                                            else
                                            {
                                                pvContabilidadeDal.Update(PVContabilidadeCredito);
                                            }
                                            pvContabilidadeDal.Save();

                                            //Conta de Debito
                                            if (pv.Operacao.IdPerfilCliente != null)
                                            {
                                                if (pv.Operacao.PerfilCliente.IdContaContabil != null)
                                                {
                                                    PedidoVendaContabilidade PVContabilidadeDebito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "D");
                                                    if (PVContabilidadeDebito == null) PVContabilidadeDebito = new PedidoVendaContabilidade();
                                                    PVContabilidadeDebito.IdContaContabil = pv.Operacao.PerfilCliente.IdContaContabil;
                                                    PVContabilidadeDebito.ValorCredito = Item.ValorLiquido;
                                                    PVContabilidadeDebito.IdOrigemLancamento = 37;
                                                    PVContabilidadeDebito.DataHora = DateTime.Now;
                                                    PVContabilidadeDebito.IdMoeda = pv.IdMoeda;
                                                    PVContabilidadeDebito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                                    PVContabilidadeDebito.Preco = 0;
                                                    PVContabilidadeDebito.IdCliente = pv.IdCliente;
                                                    PVContabilidadeDebito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                                    PVContabilidadeDebito.Origem = "Ordem de Venda";
                                                    PVContabilidadeDebito.IdLote = "PC" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                                    PVContabilidadeDebito.TextoTransacao = GetTextoTransacao(37, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                                    PVContabilidadeDebito.IdPedidoVenda = pv.IdPedidoVenda;
                                                    PVContabilidadeDebito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                                    PVContabilidadeDebito.IdTipoLancamento = 105;
                                                    PVContabilidadeDebito.TipoMovimento = "D";
                                                    PVContabilidadeDebito.Impostos = false;
                                                    if (PVContabilidadeDebito.IdPedidoVendaContabilidade == 0)
                                                    {
                                                        pvContabilidadeDal.Insert(PVContabilidadeDebito);
                                                    }
                                                    else
                                                    {
                                                        pvContabilidadeDal.Update(PVContabilidadeDebito);
                                                    }
                                                    pvContabilidadeDal.Save();
                                                }
                                            }



                                            //Efetua o lançamento dos impostos
                                            PedidoVendaItemApuracaoImposto apuracaoImposto = apuracaoImpostoDal.GetApuracaoImpostoItem(Item.IdPedidoVendaItem, 3);
                                            if (apuracaoImposto != null)
                                            {
                                                GrupoLancamentoContabil grupoLancamentoContabil = new GrupoLancamentoContabilDAL().GetByID(codigoImposto.IdGrupoLancamentoContabil);
                                                if (grupoLancamentoContabil != null)
                                                {
                                                    if (grupoLancamentoContabil.IdImpostoAPagar != null)
                                                    {
                                                        //lança o credito
                                                        PedidoVendaContabilidade pcvCredito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "C");
                                                        if (pcvCredito == null) pcvCredito = new PedidoVendaContabilidade();
                                                        pcvCredito.IdContaContabil = grupoLancamentoContabil.IdImpostoAPagar;
                                                        if (apuracaoImposto.ValorAjustado != null && apuracaoImposto.ValorAjustado > 0)
                                                        {
                                                            pcvCredito.ValorCredito = apuracaoImposto.ValorAjustado;
                                                        }
                                                        else
                                                        {
                                                            pcvCredito.ValorCredito = apuracaoImposto.ValorImposto;
                                                        }

                                                        pcvCredito.IdOrigemLancamento = 33;
                                                        pcvCredito.DataHora = DateTime.Now;
                                                        pcvCredito.IdMoeda = pv.IdMoeda;
                                                        pcvCredito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                                        pcvCredito.Preco = 0;
                                                        pcvCredito.IdCliente = pv.IdCliente;
                                                        pcvCredito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                                        pcvCredito.Origem = "Ordem de Venda";
                                                        pcvCredito.IdLote = "PV" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                                        pcvCredito.IdTipoLancamento = 82; //Imposto
                                                        pcvCredito.IdPedidoVenda = pv.IdPedidoVenda;
                                                        pcvCredito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                                        pcvCredito.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                                        pcvCredito.TipoMovimento = "C";
                                                        pcvCredito.Impostos = true;
                                                        if (pcvCredito.IdPedidoVendaContabilidade == 0)
                                                        {
                                                            pvContabilidadeDal.Insert(pcvCredito);
                                                        }
                                                        else
                                                        {
                                                            pvContabilidadeDal.Update(pcvCredito);
                                                        }
                                                        pvContabilidadeDal.Save();

                                                        //lança o debito
                                                        PedidoVendaContabilidade pcvDebito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "D");
                                                        if (pcvDebito == null) pcvDebito = new PedidoVendaContabilidade();
                                                        pcvDebito.IdContaContabil = grupoLancamentoContabil.IdDespesaComImposto;
                                                        if (apuracaoImposto.ValorAjustado != null && apuracaoImposto.ValorAjustado > 0)
                                                        {
                                                            pcvDebito.ValorCredito = apuracaoImposto.ValorAjustado;
                                                        }
                                                        else
                                                        {
                                                            pcvDebito.ValorCredito = apuracaoImposto.ValorImposto;
                                                        }

                                                        pcvDebito.IdOrigemLancamento = 33;
                                                        pcvDebito.DataHora = DateTime.Now;
                                                        pcvDebito.IdMoeda = pv.IdMoeda;
                                                        pcvDebito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                                        pcvDebito.Preco = 0;
                                                        pcvDebito.IdCliente = pv.IdCliente;
                                                        pcvDebito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                                        pcvDebito.Origem = "Ordem de Venda";
                                                        pcvDebito.IdLote = "PV" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                                        pcvDebito.IdTipoLancamento = 82; //Imposto
                                                        pcvDebito.IdPedidoVenda = pv.IdPedidoVenda;
                                                        pcvDebito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                                        pcvDebito.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                                        pcvDebito.TipoMovimento = "D";
                                                        pcvDebito.Impostos = true;
                                                        if (pcvDebito.IdPedidoVendaContabilidade == 0)
                                                        {
                                                            pvContabilidadeDal.Insert(pcvDebito);
                                                        }
                                                        else
                                                        {
                                                            pvContabilidadeDal.Update(pcvDebito);
                                                        }
                                                        pvContabilidadeDal.Save();
                                                    }

                                                }
                                            }





                                        }
                                    }
                                }
                            }






                        }
                    }



                }



                //5 - Mesmo case que o 2 Exemplo de uma venda com imposto incluso do Tipo ICMS no valor de 18%, sem desconto, sem frete e sem comissão, com movimentação de estoque sem títulos no contas a receber
                if (pv.IdOperacao != null)
                {
                    //Conta de Credito
                    if (Convert.ToBoolean(pv.Operacao.MovimentaEstoque)) //Movimenta Estoque
                    {
                        if (!Convert.ToBoolean(pv.Operacao.TransacoesFinanceiras)) //nao Gera Financeiro
                        {
                            PedidoVendaItemApuracaoImpostoDAL apuracaoImpostoDal = new PedidoVendaItemApuracaoImpostoDAL();
                            if (apuracaoImpostoDal.ContemTipoImposto(Item.IdPedidoVendaItem, 3)) //verifica se o item tem ICMS
                            {
                                CodigoImposto codigoImposto = apuracaoImpostoDal.GetCodigoImpostoItemPedidoVenda(Item.IdPedidoVendaItem, 3);
                                if (codigoImposto != null)
                                {
                                    if (codigoImposto.ImpostoIncluso)//imposto incluso == true
                                    {
                                        if (codigoImposto.CodigoTributacao.ValorFiscal == 1)//Com Crédito/Débito
                                        {
                                            PedidoVendaContabilidade PVContabilidadeCredito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "D");
                                            if (PVContabilidadeCredito == null) PVContabilidadeCredito = new PedidoVendaContabilidade();
                                            PVContabilidadeCredito.IdContaContabil = GetContaContabilVendas(pv, Item, 3);
                                            PVContabilidadeCredito.ValorDebito = Item.ValorLiquido;
                                            PVContabilidadeCredito.IdOrigemLancamento = 33;
                                            PVContabilidadeCredito.DataHora = DateTime.Now;
                                            PVContabilidadeCredito.IdMoeda = pv.IdMoeda;
                                            PVContabilidadeCredito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                            PVContabilidadeCredito.Preco = 0;
                                            PVContabilidadeCredito.IdCliente = pv.IdCliente;
                                            PVContabilidadeCredito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                            PVContabilidadeCredito.Origem = "Ordem de Venda";
                                            PVContabilidadeCredito.IdLote = "PV" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                            PVContabilidadeCredito.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                            PVContabilidadeCredito.IdTipoLancamento = 85;
                                            PVContabilidadeCredito.IdPedidoVenda = pv.IdPedidoVenda;
                                            PVContabilidadeCredito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                            PVContabilidadeCredito.TipoMovimento = "C";
                                            PVContabilidadeCredito.Impostos = false;
                                            if (PVContabilidadeCredito.IdPedidoVendaContabilidade == 0)
                                            {
                                                pvContabilidadeDal.Insert(PVContabilidadeCredito);
                                            }
                                            else
                                            {
                                                pvContabilidadeDal.Update(PVContabilidadeCredito);
                                            }
                                            pvContabilidadeDal.Save();

                                            //Conta de Debito
                                            if (pv.Operacao.IdPerfilCliente != null)
                                            {
                                                if (pv.Operacao.PerfilCliente.IdContaContabil != null)
                                                {
                                                    PedidoVendaContabilidade PVContabilidadeDebito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "D");
                                                    if (PVContabilidadeDebito == null) PVContabilidadeDebito = new PedidoVendaContabilidade();
                                                    PVContabilidadeDebito.IdContaContabil = GetContaContabilVendas(pv, Item, 20);//perda
                                                    PVContabilidadeDebito.ValorCredito = Item.ValorLiquido;
                                                    PVContabilidadeDebito.IdOrigemLancamento = 33;
                                                    PVContabilidadeDebito.DataHora = DateTime.Now;
                                                    PVContabilidadeDebito.IdMoeda = pv.IdMoeda;
                                                    PVContabilidadeDebito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                                    PVContabilidadeDebito.Preco = 0;
                                                    PVContabilidadeDebito.IdCliente = pv.IdCliente;
                                                    PVContabilidadeDebito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                                    PVContabilidadeDebito.Origem = "Ordem de Venda";
                                                    PVContabilidadeDebito.IdLote = "PC" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                                    PVContabilidadeDebito.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                                    PVContabilidadeDebito.IdPedidoVenda = pv.IdPedidoVenda;
                                                    PVContabilidadeDebito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                                    PVContabilidadeDebito.IdTipoLancamento = 20;//perda
                                                    PVContabilidadeDebito.TipoMovimento = "D";
                                                    PVContabilidadeDebito.Impostos = false;
                                                    if (PVContabilidadeDebito.IdPedidoVendaContabilidade == 0)
                                                    {
                                                        pvContabilidadeDal.Insert(PVContabilidadeDebito);
                                                    }
                                                    else
                                                    {
                                                        pvContabilidadeDal.Update(PVContabilidadeDebito);
                                                    }
                                                    pvContabilidadeDal.Save();
                                                }
                                            }



                                            //Efetua o lançamento dos impostos
                                            PedidoVendaItemApuracaoImposto apuracaoImposto = apuracaoImpostoDal.GetApuracaoImpostoItem(Item.IdPedidoVendaItem, 3);
                                            if (apuracaoImposto != null)
                                            {
                                                GrupoLancamentoContabil grupoLancamentoContabil = new GrupoLancamentoContabilDAL().GetByID(codigoImposto.IdGrupoLancamentoContabil);
                                                if (grupoLancamentoContabil != null)
                                                {
                                                    if (grupoLancamentoContabil.IdDespesasImpostoUso != null)
                                                    {
                                                        //lança o credito
                                                        PedidoVendaContabilidade pcvCredito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "C");
                                                        if (pcvCredito == null) pcvCredito = new PedidoVendaContabilidade();
                                                        pcvCredito.IdContaContabil = grupoLancamentoContabil.IdDespesasImpostoUso;
                                                        if (apuracaoImposto.ValorAjustado != null && apuracaoImposto.ValorAjustado > 0)
                                                        {
                                                            pcvCredito.ValorCredito = apuracaoImposto.ValorAjustado;
                                                        }
                                                        else
                                                        {
                                                            pcvCredito.ValorCredito = apuracaoImposto.ValorImposto;
                                                        }

                                                        pcvCredito.IdOrigemLancamento = 33;
                                                        pcvCredito.DataHora = DateTime.Now;
                                                        pcvCredito.IdMoeda = pv.IdMoeda;
                                                        pcvCredito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                                        pcvCredito.Preco = 0;
                                                        pcvCredito.IdCliente = pv.IdCliente;
                                                        pcvCredito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                                        pcvCredito.Origem = "Ordem de Venda";
                                                        pcvCredito.IdLote = "PV" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                                        pcvCredito.IdTipoLancamento = 82; //Imposto
                                                        pcvCredito.IdPedidoVenda = pv.IdPedidoVenda;
                                                        pcvCredito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                                        pcvCredito.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                                        pcvCredito.TipoMovimento = "C";
                                                        pcvCredito.Impostos = true;
                                                        if (pcvCredito.IdPedidoVendaContabilidade == 0)
                                                        {
                                                            pvContabilidadeDal.Insert(pcvCredito);
                                                        }
                                                        else
                                                        {
                                                            pvContabilidadeDal.Update(pcvCredito);
                                                        }
                                                        pvContabilidadeDal.Save();

                                                        //lança o debito
                                                        PedidoVendaContabilidade pcvDebito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "D");
                                                        if (pcvDebito == null) pcvDebito = new PedidoVendaContabilidade();
                                                        pcvDebito.IdContaContabil = grupoLancamentoContabil.IdImpostoAReceber;
                                                        if (apuracaoImposto.ValorAjustado != null && apuracaoImposto.ValorAjustado > 0)
                                                        {
                                                            pcvDebito.ValorCredito = apuracaoImposto.ValorAjustado;
                                                        }
                                                        else
                                                        {
                                                            pcvDebito.ValorCredito = apuracaoImposto.ValorImposto;
                                                        }

                                                        pcvDebito.IdOrigemLancamento = 33;
                                                        pcvDebito.DataHora = DateTime.Now;
                                                        pcvDebito.IdMoeda = pv.IdMoeda;
                                                        pcvDebito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                                        pcvDebito.Preco = 0;
                                                        pcvDebito.IdCliente = pv.IdCliente;
                                                        pcvDebito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                                        pcvDebito.Origem = "Ordem de Venda";
                                                        pcvDebito.IdLote = "PV" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                                        pcvDebito.IdTipoLancamento = 82; //Imposto
                                                        pcvDebito.IdPedidoVenda = pv.IdPedidoVenda;
                                                        pcvDebito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                                        pcvDebito.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                                        pcvDebito.TipoMovimento = "D";
                                                        pcvDebito.Impostos = true;
                                                        if (pcvDebito.IdPedidoVendaContabilidade == 0)
                                                        {
                                                            pvContabilidadeDal.Insert(pcvDebito);
                                                        }
                                                        else
                                                        {
                                                            pvContabilidadeDal.Update(pcvDebito);
                                                        }
                                                        pvContabilidadeDal.Save();
                                                    }

                                                }
                                            }





                                        }
                                    }
                                }
                            }






                        }
                    }



                }


                //6 - O mesmo Processo que o case 1 com a diferença do calculo de imposto.
                //Exemplo de uma venda com imposto incluso do Tipo ICMS no valor de 18 %, PIS 0,65 e Cofins 3,00, sem desconto, sem frete e sem comissão

                if (pv.IdOperacao != null)
                {
                    if (Convert.ToBoolean(pv.Operacao.MovimentaEstoque)) //Movimenta Estoque
                    {
                        if (Convert.ToBoolean(pv.Operacao.TransacoesFinanceiras)) //Gera Financeiro
                        {
                            PedidoVendaItemApuracaoImpostoDAL apuracaoImpostoDal = new PedidoVendaItemApuracaoImpostoDAL();
                            if (apuracaoImpostoDal.ContemTipoImposto(Item.IdPedidoVendaItem, 3)) //verifica se o item tem ICMS
                            {
                                if (apuracaoImpostoDal.ContemTipoImposto(Item.IdPedidoVendaItem, 2)) //verifica se o item tem PIS
                                {
                                    if (apuracaoImpostoDal.ContemTipoImposto(Item.IdPedidoVendaItem, 4)) //verifica se o item tem COFINS
                                    {
                                        CodigoImposto codigoImposto = apuracaoImpostoDal.GetCodigoImpostoItemPedidoVenda(Item.IdPedidoVendaItem, 3);
                                        if (codigoImposto != null)
                                        {
                                            if (codigoImposto.ImpostoIncluso)//imposto incluso == true
                                            {
                                                if (codigoImposto.CodigoTributacao.ValorFiscal == 1)//Com Crédito/Débito
                                                {
                                                    //lANÇA O credito
                                                    PedidoVendaContabilidade PVCredito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "C");
                                                    if (PVCredito == null) PVCredito = new PedidoVendaContabilidade();
                                                    PVCredito.IdContaContabil = GetContaContabilVendas(pv, Item, 34); //Tipo lançamento > receita
                                                    PVCredito.ValorCredito = -1;
                                                    PVCredito.IdOrigemLancamento = 33;
                                                    PVCredito.DataHora = DateTime.Now;
                                                    PVCredito.IdMoeda = pv.IdMoeda;
                                                    PVCredito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                                    PVCredito.Preco = 0;
                                                    PVCredito.IdCliente = pv.IdCliente;
                                                    PVCredito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                                    PVCredito.Origem = "Ordem de Venda";
                                                    PVCredito.IdLote = "PV" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                                    PVCredito.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                                    PVCredito.IdTipoLancamento = 34;//Receita
                                                    PVCredito.IdPedidoVenda = pv.IdPedidoVenda;
                                                    PVCredito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                                    PVCredito.TipoMovimento = "C";
                                                    PVCredito.Impostos = false;
                                                    if (PVCredito.IdPedidoVendaContabilidade == 0)
                                                    {
                                                        pvContabilidadeDal.Insert(PVCredito);
                                                    }
                                                    else
                                                    {
                                                        pvContabilidadeDal.Update(PVCredito);
                                                    }
                                                    pvContabilidadeDal.Save();

                                                    //lança o Debito
                                                    if (pv.Operacao.IdPerfilCliente != null)
                                                    {
                                                        if (pv.Operacao.PerfilCliente.IdContaContabil != null)
                                                        {
                                                            PedidoVendaContabilidade PVDebito = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "D");
                                                            if (PVDebito == null) PVDebito = new PedidoVendaContabilidade();
                                                            PVDebito.IdContaContabil = pv.Operacao.PerfilCliente.IdContaContabil;
                                                            PVDebito.ValorDebito = Item.ValorLiquido;
                                                            PVDebito.IdOrigemLancamento = 33;
                                                            PVDebito.DataHora = DateTime.Now;
                                                            PVDebito.IdMoeda = pv.IdMoeda;
                                                            PVDebito.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                                            PVDebito.Preco = 0;
                                                            PVDebito.IdCliente = pv.IdCliente;
                                                            PVDebito.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                                            PVDebito.Origem = "Ordem de Venda";
                                                            PVDebito.IdLote = "PV" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                                            PVDebito.IdTipoLancamento = 38;//saldo de cliente
                                                            PVDebito.IdPedidoVenda = pv.IdPedidoVenda;
                                                            PVDebito.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                                            PVDebito.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                                            PVDebito.TipoMovimento = "D";
                                                            PVDebito.Impostos = false;
                                                            if (PVDebito.IdPedidoVendaContabilidade == 0)
                                                            {
                                                                pvContabilidadeDal.Insert(PVDebito);
                                                            }
                                                            else
                                                            {
                                                                pvContabilidadeDal.Update(PVDebito);
                                                            }
                                                            pvContabilidadeDal.Save();
                                                        }
                                                    }

                                                    //lANÇA O credito 2° lançamento
                                                    PedidoVendaContabilidade PVCreditoSegundo = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "C");
                                                    if (PVCreditoSegundo == null) PVCreditoSegundo = new PedidoVendaContabilidade();
                                                    PVCreditoSegundo.IdContaContabil = GetContaContabilVendas(pv, Item, 85); //Tipo lançamento > Ordem de venda, saída da
                                                    PVCreditoSegundo.ValorCredito = -1;
                                                    PVCreditoSegundo.IdOrigemLancamento = 33;
                                                    PVCreditoSegundo.DataHora = DateTime.Now;
                                                    PVCreditoSegundo.IdMoeda = pv.IdMoeda;
                                                    PVCreditoSegundo.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                                    PVCreditoSegundo.Preco = 0;
                                                    PVCreditoSegundo.IdCliente = pv.IdCliente;
                                                    PVCreditoSegundo.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                                    PVCreditoSegundo.Origem = "Ordem de Venda";
                                                    PVCreditoSegundo.IdLote = "PV" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                                    PVCreditoSegundo.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                                    PVCreditoSegundo.IdTipoLancamento = 85;//Ordem de venda, saída da
                                                    PVCreditoSegundo.IdPedidoVenda = pv.IdPedidoVenda;
                                                    PVCreditoSegundo.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                                    PVCreditoSegundo.TipoMovimento = "C";
                                                    PVCreditoSegundo.Impostos = false;
                                                    if (PVCreditoSegundo.IdPedidoVendaContabilidade == 0)
                                                    {
                                                        pvContabilidadeDal.Insert(PVCreditoSegundo);
                                                    }
                                                    else
                                                    {
                                                        pvContabilidadeDal.Update(PVCreditoSegundo);
                                                    }
                                                    pvContabilidadeDal.Save();


                                                    //Lança o segundo lançamento de debito
                                                    PedidoVendaContabilidade PVDebitoSegundo = pvContabilidadeDal.GetByPedidoItem(Item.IdPedidoVendaItem, "D");
                                                    if (PVDebitoSegundo == null) PVDebitoSegundo = new PedidoVendaContabilidade();
                                                    PVDebitoSegundo.IdContaContabil = GetContaContabilVendas(pv, Item, 4);
                                                    PVDebitoSegundo.ValorDebito = -1;
                                                    PVDebitoSegundo.IdOrigemLancamento = 33;
                                                    PVDebitoSegundo.DataHora = DateTime.Now;
                                                    PVDebitoSegundo.IdMoeda = pv.IdMoeda;
                                                    PVDebitoSegundo.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                                                    PVDebitoSegundo.Preco = 0;
                                                    PVDebitoSegundo.IdCliente = pv.IdCliente;
                                                    PVDebitoSegundo.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                                                    PVDebitoSegundo.Origem = "Ordem de Venda";
                                                    PVDebitoSegundo.IdLote = "PV" + pv.IdPedidoVenda.ToString().PadLeft(10, '0');
                                                    PVDebitoSegundo.IdTipoLancamento = 83;//saldo de cliente
                                                    PVDebitoSegundo.IdPedidoVenda = pv.IdPedidoVenda;
                                                    PVDebitoSegundo.IdPedidoVendaItem = Item.IdPedidoVendaItem;
                                                    PVDebitoSegundo.TextoTransacao = GetTextoTransacao(33, pv.IdCliente, null, pv.IdOperacao, pv.IdMetodoPagamento, Item.ValorLiquido, Item.ValorLiquido);
                                                    PVDebitoSegundo.TipoMovimento = "D";
                                                    PVDebitoSegundo.Impostos = false;
                                                    if (PVDebitoSegundo.IdPedidoVendaContabilidade == 0)
                                                    {
                                                        pvContabilidadeDal.Insert(PVDebitoSegundo);
                                                    }
                                                    else
                                                    {
                                                        pvContabilidadeDal.Update(PVDebitoSegundo);
                                                    }
                                                    pvContabilidadeDal.Save();


                                                }
                                            }
                                        }
                                    }
                                        
                                }

                            }
                        }
                    }
                }

            }
        }

        public int? GetContaContabilVendas(PedidoVenda pv, PedidoVendaItem Item, int IdTipoLancamento)
        {
            if (pv.Operacao.IdContaContabil != null) //Procura a conta na operação da compra
            {
                return pv.Operacao.IdContaContabil;
            }
            else //senao ve a conta nos lançamentos pelo tipo de lançamento Despesa de compra para despesa
            {
                List<LancamentoModelView> Lancamentos = new LancamentoDAL().getByTipoLancamento(IdTipoLancamento);

                //Pesquisa se existe uma condição para o produto
                var lancProduto = Lancamentos.Where(x => x.IdProduto == Item.IdProduto).FirstOrDefault();
                if (lancProduto != null && lancProduto.IdContaContabil != null)
                {
                    return lancProduto.IdContaContabil;
                }
                else
                {
                    //Se nao encontra para o produto pesquisa pelo grupo
                    var LancGrupo = Lancamentos.Where(x => x.IdGRupoProduto == Item.Produto.IdGrupoProduto).FirstOrDefault();
                    if (LancGrupo != null && lancProduto.IdContaContabil != null)
                    {
                        return LancGrupo.IdContaContabil;
                    }
                    else
                    {
                        //Se nao encontra o grupo pesquisa pelo cliente
                        var LancClie = Lancamentos.Where(x => x.IdContaContabil == pv.IdCliente).FirstOrDefault();
                        if (LancClie != null && LancClie.IdContaContabil != null)
                        {
                            return LancClie.IdContaContabil;
                        }
                        else
                        {
                            //Se nao acha o fornecedor pesquisa pelo grupo de clientes
                            var LancGrupoForn = Lancamentos.Where(x => x.IdGrupoCliente == pv.Cliente.IdGrupoCliente).FirstOrDefault();
                            if (LancGrupoForn != null && LancGrupoForn.IdContaContabil != null)
                            {
                                return LancGrupoForn.IdContaContabil;
                            }
                            else
                            {
                                //Pesquisa conta para o item relação a todos os produtos
                                var LancTodosProdutos = Lancamentos.Where(x => x.RelacaoItem == 3).FirstOrDefault();
                                if (LancTodosProdutos != null && LancTodosProdutos.IdContaContabil != null)
                                {
                                    return LancTodosProdutos.IdContaContabil;
                                }
                                else
                                {
                                    //finalmente tenta achar para todos os produtos do grupo
                                    var LancTodosGrupos = Lancamentos.Where(x => x.RelacaoGrupo == 3).FirstOrDefault();
                                    if (LancTodosGrupos != null && LancTodosGrupos.IdContaContabil != null)
                                    {
                                        return LancTodosGrupos.IdContaContabil;
                                    }
                                    else
                                    {
                                        return null;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion



        #region Acessorios
        public string GetTextoTransacao(int IdOrigemLancamento, int? IdCliente = null, int? IdFornecedor = null, int? IdOperacao = null, int? IdMetodoPagamento = null, decimal? ValorTransacao = null, decimal? ValorTransacaoTotal = null)
        {
            string Texto = textoTransacaoDal.GetTextoTransacao(IdOrigemLancamento);

            if (Texto == null) Texto = "";

            if (Texto.Contains("%1")) Texto.Replace("%1", DateTime.Now.ToShortDateString());
            if (Texto.Contains("%2")) Texto.Replace("%2", DateTime.Now.Year.ToString());
            Empresa emp = new EmpresaDAL().ERepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
            if (Texto.Contains("%3"))
            {
                Texto.Replace("%3", emp.RazaoSocial);
            }
            if (Texto.Contains("%4"))
            {
                Texto.Replace("%4", emp.Fantasia);
            }
            if (Texto.Contains("%5"))
            {
                Texto.Replace("%5", Util.Util.FormatarCpfCnpj(emp.CNPJ));
            }

            if (IdCliente != null)
            {
                Cliente cl = new ClienteDAL().CRepository.GetByID(IdCliente);
                if (Texto.Contains("%6"))
                {
                    Texto.Replace("%6", cl.RazaoSocial);
                }
                if (Texto.Contains("%7"))
                {
                    Texto.Replace("%7", cl.NomeFantasia);
                }
                if (Texto.Contains("%8"))
                {
                    Texto.Replace("%8", Util.Util.FormatarCpfCnpj(cl.CNPJ));
                }
            }


            if (IdFornecedor != null)
            {
                Fornecedor f = new FornecedorDAL().FRepository.GetByID(IdFornecedor);
                if (Texto.Contains("%9"))
                {
                    Texto.Replace("%9", f.RazaoSocial);
                }
                if (Texto.Contains("%10"))
                {
                    Texto.Replace("%10", f.NomeFantasia);
                }
                if (Texto.Contains("%11"))
                {
                    Texto.Replace("%11", Util.Util.FormatarCpfCnpj(f.CNPJ));
                }
            }


            if (IdOperacao != null)
            {
                if (Texto.Contains("%13"))
                {
                    Operacao op = new OperacaoDAL().GetByID(Convert.ToInt32(IdOperacao));
                    Texto.Replace("%13", op.Descricao);
                }
            }

            if (IdMetodoPagamento != null)
            {
                if (Texto.Contains("%15"))
                {
                    MetodoPagamento m = new MetodoPagamentoDAL().GetByID(Convert.ToInt32(IdMetodoPagamento));
                    Texto.Replace("%15", m.Nome);
                }
            }

            if (ValorTransacao != null && ValorTransacaoTotal != null)
            {
                if (Texto.Contains("%17"))
                {
                    MetodoPagamento m = new MetodoPagamentoDAL().GetByID(Convert.ToInt32(IdMetodoPagamento));
                    Texto.Replace("%17", Convert.ToDecimal(ValorTransacao).ToString("C2") + " " + Convert.ToDecimal(ValorTransacaoTotal).ToString("C2"));
                }
            }


            return Texto;
        }


        #endregion
    }
}
