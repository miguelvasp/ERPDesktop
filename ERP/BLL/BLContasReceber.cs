using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Models;
using ERP.DAL;

namespace ERP.BLL
{
    public class BLContasReceber
    {
        ContasReceberDAL dal = new ContasReceberDAL();
        ContasReceberAbertoDAL aDal = new ContasReceberAbertoDAL();
        ContasReceberBaixaDAL bDal = new ContasReceberBaixaDAL();
        public BLContasReceber() { }

        public ContasReceber GeraAPartirDaNotaVenda(NotaFiscal n, out string Message)
        {
            try
            {
                ContasReceber c = new ContasReceber();
                c.IdNotaFiscal = n.IdNotaFiscal; 
                c.Documento = n.Numero;
                c.ValorTitulo = n.TotalNF;
                c.Desconto = 0;
                c.ValorLiquido = n.TotalNF;
                //c.Vencimento 
                c.Emissao = n.DataEmissao;
                c.Saldo = n.TotalNF;
                //c.Correcao
                c.DataDocumento = n.DataEmissao;
                c.IdCliente = n.IdDestinatario;
                c.Observacao = "Nota Fiscal de Vendas: " + n.Numero;
                //c.Acrecimo
                c.ValorPago = 0;
                c.Status = 1;
                //c.Cancelamento
                //c.Cancelado
                //c.UltimoPagamento
                //c.CalculaRetencao
                PedidoVenda p = new PedidoVendaDAL().GetPedidoByNF(n.IdNotaFiscal);
                if (p != null)
                {
                    c.IdMoeda = p.IdMoeda;
                    c.IdMetodoPagamento = p.IdMetodoPagamento;
                    c.IdPerfilCliente = p.IdPerfilCliente;
                    c.TipoTransacao = 1;//pedido de vendas
                    if (p.IdOperacao != null)
                    {
                        Operacao o = new OperacaoDAL().GetByID(Convert.ToInt32(p.IdOperacao));
                        if (o != null)
                        {
                            c.IdContaContabil = o.IdContaContabil;
                        }
                    }
                }
                else
                {
                    Message = "Não foi localizado pedido de compras vinculado a nota fiscal.";
                    return null;
                }

                //Consulta os vencimentos da nota fiscal
                var Vencimentos = new NotaFiscalVencimentosDAL().GetByNF(n.IdNotaFiscal);
                if (Vencimentos.Count > 0)
                {
                    //se possui os vencimentos, salvamos os dados do pagamento e geramos as baixas em aberto;
                    c.Vencimento = Vencimentos[0].Data;
                    c.VencimentoOriginal = Vencimentos[0].Data;
                    dal.Insert(c);
                    dal.Save();
                    int Contador = 0;
                    foreach (NotaFiscalVencimentos v in Vencimentos)
                    {
                        Contador++;
                        ContasReceberAberto pa = new ContasReceberAberto();
                        pa.IdContasReceber = c.IdContasReceber;
                        //pa.IdCodigoMulta
                        //pa.IdCodigoJuros
                        //pa.IdFornecedorContaBancaria 
                        pa.Vencimento = v.Data;
                        pa.VencimentoOriginal = c.VencimentoOriginal;
                        pa.NumeroParcela = Contador;
                        pa.NumeroParcelaOriginal = Contador;
                        pa.ValorTitulo = v.Valor;
                        pa.Desconto = 0;
                        pa.ValorJuros = 0;
                        pa.ValorMulta = 0;
                        pa.ValorDescontoVista = 0;
                        pa.ValorLiquido = v.Valor;
                        aDal.Insert(pa);
                        aDal.Save();
                    }
                }
                else
                {
                    Message = "Nota Fiscal sem vencimentos.";
                    return null;
                }

                Message = "Contas a receber criado com sucesso.";
                return c;
            }
            catch (Exception ex)
            {
                Message = "Erro: " + ex.Message;
                return null;
            }
        }


        public void GerarRecebimentoDoPedidoBalcao(int IdPedidoVendaBalcao)
        {
            PedidoBalcaoDAL pdal = new PedidoBalcaoDAL();
            PedidoBalcao p = pdal.GetByID(IdPedidoVendaBalcao);
            List<PedidoBalcaoPagamento> fpg = new PedidoBalcaoPagamentoDAL().getByPedidoId(IdPedidoVendaBalcao);
            
            foreach(var f in fpg)
            {
                bool Credito = false;
                ContasReceber c = new ContasReceber();
                c.Documento = "pb" + p.IdPedidoBalcao.ToString();
                c.ValorTitulo = f.Valor;
                c.Desconto = 0;
                c.ValorLiquido = f.Valor;
                c.IdCondicaoPagamento = p.IdCondicaoPagamento;
                c.Emissao = p.Data;
                if(f.FormaPagamento == "DINHEIRO")
                {
                    c.IdMetodoPagamento = 4; //dinheiro
                    c.IdContaContabil = 6;
                    c.IdCondicaoPagamento = 1;
                    c.ValorTitulo = f.Valor - p.Troco; 
                    c.ValorLiquido = f.Valor - p.Troco;
                }
                else if(f.FormaPagamento.Contains("CARTÃO CRÉDITO"))
                {
                    c.IdMetodoPagamento = 6;
                    c.IdContaContabil = 7;
                    Credito = true;
                    if (f.FormaPagamento == "CARTÃO CRÉDITO")
                    {
                        c.IdCondicaoPagamento = 3;
                    }

                    if (f.FormaPagamento == "CARTÃO CRÉDITO 2x")
                    {
                        c.IdCondicaoPagamento = 4;
                    }

                    if (f.FormaPagamento == "CARTÃO CRÉDITO 3x")
                    {
                        c.IdCondicaoPagamento = 2;
                    }

                    if (f.FormaPagamento == "CARTÃO CRÉDITO 4x")
                    {
                        c.IdCondicaoPagamento = 5;
                    }

                    
                }
                else if(f.FormaPagamento == "CARTÃO DÉBITO")
                {
                    c.IdMetodoPagamento = 5;
                    c.IdContaContabil = 8;
                    c.IdCondicaoPagamento = 1;
                }
                else if (f.FormaPagamento == "CHEQUE")
                {
                    c.IdMetodoPagamento = 2;
                    c.IdContaContabil = 10;
                    Credito = true;
                }
                else if(f.FormaPagamento.Contains("CREDIARIO LOJA"))
                {
                    c.IdMetodoPagamento = 7;
                    c.IdContaContabil = 9;
                    Credito = true;
                    if (f.FormaPagamento == "CREDIARIO LOJA 30 DIAS")
                    {
                        c.IdCondicaoPagamento = 3;
                    }

                    if (f.FormaPagamento == "CREDIARIO LOJA 30/60 DIAS")
                    {
                        c.IdCondicaoPagamento = 4;
                    }

                    if (f.FormaPagamento == "CREDIARIO LOJA 30/60/90 DIAS")
                    {
                        c.IdCondicaoPagamento = 2;
                    } 
                }


                c.Saldo = Credito ? f.Valor : 0;
                c.DataDocumento = p.Data;
                c.IdCliente = p.IdCliente;
                c.Observacao = "Pedido balcao: " + p.IdPedidoBalcao.ToString();
                c.ValorPago = Credito ? 0 : f.Valor;
                c.Status = 1;
                c.IdMoeda = 12;
                c.IdPerfilCliente = 1;
                c.TipoTransacao = 1;//pedido de vendas


                //Consulta os vencimentos da nota fiscal
                var Vencimentos = new CondicaoPagamentoDAL().CalculaVencimentos(Convert.ToInt32(c.IdCondicaoPagamento), Convert.ToDecimal(c.ValorLiquido), Convert.ToDateTime(p.Data));
                if (Vencimentos.Count > 0)
                {
                    //se possui os vencimentos, salvamos os dados do pagamento e geramos as baixas 
                    c.Vencimento = Vencimentos[0].Data;
                    c.VencimentoOriginal = Vencimentos[0].Data;
                    dal.Insert(c);
                    dal.Save();
                    int Contador = 0;
                    foreach (var v in Vencimentos)
                    {
                        Contador++;
                        ContasReceberAberto pa = new ContasReceberAberto();
                        pa.IdContasReceber = c.IdContasReceber;
                        pa.Vencimento = v.Data;
                        pa.VencimentoOriginal = c.VencimentoOriginal;
                        pa.NumeroParcela = Contador;
                        pa.NumeroParcelaOriginal = Contador;
                        pa.ValorTitulo = v.Valor;
                        pa.Desconto = 0;
                        pa.ValorJuros = 0;
                        pa.ValorMulta = 0;
                        pa.ValorDescontoVista = 0;
                        pa.ValorLiquido = v.Valor;
                        aDal.Insert(pa);
                        aDal.Save();

                        if (!Credito)
                        {
                            ContasReceberBaixa cb = new ContasReceberBaixa();
                            cb.IdContasReceberAberto = pa.IdContasReceberAberto;
                            cb.DataPagamento = p.Data;
                            cb.Documento = "pb" + p.IdPedidoBalcao.ToString();
                            cb.IdContaBancaria = 1;
                            cb.Valor = v.Valor;
                            cb.IdContaBancaria = 1;
                            cb.IdMetodoPagamento = c.IdMetodoPagamento;
                            cb.IdCliente = p.IdCliente;
                            cb.IdContaContabil = c.IdContaContabil;
                            bDal.Insert(cb);
                            bDal.Save();
                        }
                    }
                }
                else
                {
                    c.Vencimento = DateTime.Now;
                    c.VencimentoOriginal = DateTime.Now;
                    dal.Insert(c);
                    dal.Save();
                }


            } 
        }



        public void GeraAPartirDoPedidoBalcao(int IdPedidoVendaBalcao, bool Credito = false)
        {
            try
            {
                PedidoBalcaoDAL pdal = new PedidoBalcaoDAL();
                PedidoBalcao p = pdal.GetByID(IdPedidoVendaBalcao);
                ContasReceber c = new ContasReceber(); 
                c.Documento = "pb" + p.IdPedidoBalcao.ToString();
                c.ValorTitulo = p.Total;
                c.Desconto = 0;
                c.ValorLiquido = p.Total; 
                c.Emissao = p.Data;
                c.Saldo = Credito ? p.Total : 0; 
                c.DataDocumento = p.Data;
                c.IdCliente = p.IdCliente;
                c.Observacao = "Pedido balcao: " + p.IdPedidoBalcao.ToString(); 
                c.ValorPago = Credito ? 0 : p.Total;
                c.Status = 1;  
                c.IdMoeda = 12;

                if(p.Dinheiro >= p.Total)
                {
                    c.IdMetodoPagamento = 4; //dinheiro
                    c.IdContaContabil = 6;
                }
                else if(p.Credito > 0)
                {
                    c.IdMetodoPagamento = 6;
                    c.IdContaContabil = 7;
                }
                else if (p.Debito > 0)
                {
                    c.IdMetodoPagamento = 6;
                    c.IdContaContabil = 8;
                }
                else if(p.Crediario > 0)
                {
                    c.IdMetodoPagamento = 7;
                    c.IdContaContabil = 9;
                }
                else if (p.Crediario > 0)
                {
                    c.IdMetodoPagamento = 7;
                    c.IdContaContabil = 9;
                }
                else
                {
                    c.IdMetodoPagamento = 7;
                    c.IdContaContabil = 9;
                }

                c.IdPerfilCliente = 1;
                c.TipoTransacao = 1;//pedido de vendas
                


                //Consulta os vencimentos da nota fiscal
                var Vencimentos = new CondicaoPagamentoDAL().CalculaVencimentos(Convert.ToInt32(p.IdCondicaoPagamento), Convert.ToDecimal(p.Total), Convert.ToDateTime(p.Data));
                if (Vencimentos.Count > 0)
                {
                    //se possui os vencimentos, salvamos os dados do pagamento e geramos as baixas 
                    c.Vencimento = Vencimentos[0].Data;
                    c.VencimentoOriginal = Vencimentos[0].Data;
                    dal.Insert(c);
                    dal.Save();
                    int Contador = 0;
                    foreach (var v in Vencimentos)
                    {
                        Contador++;
                        ContasReceberAberto pa = new ContasReceberAberto();
                        pa.IdContasReceber = c.IdContasReceber; 
                        pa.Vencimento = v.Data;
                        pa.VencimentoOriginal = c.VencimentoOriginal;
                        pa.NumeroParcela = Contador;
                        pa.NumeroParcelaOriginal = Contador; 
                        pa.ValorTitulo = v.Valor;
                        pa.Desconto = 0;
                        pa.ValorJuros = 0;
                        pa.ValorMulta = 0;
                        pa.ValorDescontoVista = 0;
                        pa.ValorLiquido = v.Valor;
                        aDal.Insert(pa);
                        aDal.Save();

                        if(!Credito)
                        {
                            ContasReceberBaixa cb = new ContasReceberBaixa();
                            cb.IdContasReceberAberto = pa.IdContasReceberAberto;
                            cb.DataPagamento = p.Data;
                            cb.Documento = "pb" + p.IdPedidoBalcao.ToString();
                            cb.IdContaBancaria = 1;
                            cb.Valor = p.Total;
                            cb.IdContaBancaria = 1;
                            cb.IdMetodoPagamento = c.IdMetodoPagamento;
                            cb.IdCliente = p.IdCliente;
                            cb.IdContaContabil = 4;
                            bDal.Insert(cb);
                            bDal.Save();
                        } 
                    }
                }  
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }
    }
}
