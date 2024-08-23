using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Models;
using ERP.DAL;
using ERP.ModelView;

namespace ERP.BLL
{
    public class BLContasPagar
    {
        ContasPagarDAL dal = new ContasPagarDAL();
        ContasPagarAbertoDAL aDal = new ContasPagarAbertoDAL(); 

        public BLContasPagar() { }

        public ContasPagar GeraAPartirDaNotaEntrada(NotaFiscal n, out string Message)
        {
            try
            {
                RecebimentoDAL irecDal = new RecebimentoDAL();
                ContasPagar c = new ContasPagar();
                c.IdNotaFiscal = n.IdNotaFiscal;
                c.PedidoCompras = irecDal.GetPedidosContasaPagarByNF(n.IdNotaFiscal);
                c.Documento = n.Numero;
                c.ValorTitulo = n.TotalNF;
                c.Desconto = 0;
                c.ValorLiquido = n.TotalNF;
                //c.Vencimento 
                c.Emissao = n.DataEmissao;
                c.Saldo = n.TotalNF;
                //c.Correcao
                c.DataDocumento = n.DataEmissao;
                c.IdFornecedor = n.IdEmitente;
                c.Observacao = "Nota Fiscal de Entrada: " + n.Numero;
                //c.Acrecimo
                c.ValorPago = 0;
                c.Status = 1;
                //c.Cancelamento
                //c.Cancelado
                //c.UltimoPagamento
                //c.CalculaRetencao
                PedidoCompra p = irecDal.GetPedidoComprasByNF(n.IdNotaFiscal);
                if(p != null)
                {
                    c.IdMoeda = p.IdMoeda;
                    c.IdMetodoPagamento = p.IdMetodoPagamento;
                    c.IdPerfilFornecedor = p.IdPerfilFornecedor;
                    c.TipoTransacao = 1;//pedido de compras
                    if(p.IdOperacao != null)
                    {
                        Operacao o = new OperacaoDAL().GetByID(Convert.ToInt32(p.IdOperacao));
                        if(o != null)
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
                if(Vencimentos.Count > 0)
                {
                    //se possui os vencimentos, salvamos os dados do pagamento e geramos as baixas em aberto;
                    c.Vencimento = Vencimentos[0].Data;
                    c.VencimentoOriginal = Vencimentos[0].Data;
                    dal.Insert(c);
                    dal.Save();
                    int Contador = 0;
                    foreach(NotaFiscalVencimentos v in Vencimentos)
                    {
                        Contador++;
                        ContasPagarAberto pa = new ContasPagarAberto();
                        pa.IdContasPagar = c.IdContasPagar;
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

                Message = "Contas a pagar criado com sucesso.";
                return c; 
            }
            catch(Exception ex)
            {
                Message = "Erro: " + ex.Message;
                return null;
            }
        }
         
        public ContasPagar MotaContasaPagarPelosPedidos(string pPedidos, out string Msg )
        {
            try
            {
                ContasPagar c = new ContasPagar();
                List<int> Pedidos = new List<int>();
                string[] aux = pPedidos.Split('/');
                foreach (string s in aux)
                {
                    Pedidos.Add(Convert.ToInt32(s));
                }


                Msg = "";
                return c;
            }
            catch(Exception ex)
            {
                Msg = ex.Message;
                return null;
            }
        }
         
        public bool GeraAPartirComissaoVendedor(int IdVendedor, int IdCondicaoPagamento, decimal Valor, int IdMetodoPagamento, out int IdContasPagar)
        {
            bool ok = true;
            try
            {
                EmpresaDAL edal = new EmpresaDAL();
                Empresa Emp = edal.getByIdEmpresa(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
                int NumDocumento = Emp.UltimaComissao == null ? 0 : (int)Emp.UltimaComissao;
                NumDocumento = NumDocumento + 1;
                Vendedor v = new VendedorDAL().GetVendedorById(IdVendedor);
                PerfilFornecedor pf = new PerfilFornecedorDAL().GetByID(Convert.ToInt32(v.IdPerfilFornecedor));

                if(pf == null)
                {
                    IdContasPagar = 0;
                    return false;
                }

                ContasPagar c = new ContasPagar(); 
                c.Documento = "CV " + NumDocumento.ToString().PadLeft(6, '0');
                c.ValorTitulo = Valor;
                c.Desconto = 0;
                c.ValorLiquido = Valor; 
                c.Emissao = DateTime.Now;
                c.Saldo = Valor; 
                c.DataDocumento = DateTime.Now;
                c.IdFornecedor = v.IdFornecedor;
                c.Observacao = "Pagamento de Comissao vendedor: " + v.Nome; 
                c.ValorPago = 0;
                c.Status = 1;  
                c.IdMoeda = Emp.IdMoeda;
                c.IdMetodoPagamento = IdMetodoPagamento;
                c.IdPerfilFornecedor = pf.IdPerfilFornecedor;
                c.TipoTransacao = 9;//comissao
                c.IdContaContabil = pf.IdContaContabil;
                c.IdCondicaoPagamento = IdCondicaoPagamento;

                //Apos calculo dos valores efetuamos a geração dos vencimentos
                var Vencimentos = new CondicaoPagamentoDAL().CalculaVencimentos(Convert.ToInt32(IdCondicaoPagamento), Convert.ToDecimal(Valor), DateTime.Now);
                
                if (Vencimentos.Count > 0)
                {
                    //se possui os vencimentos, salvamos os dados do pagamento e geramos as baixas em aberto;
                    c.Vencimento = Vencimentos[0].Data;
                    c.VencimentoOriginal = Vencimentos[0].Data;
                    dal.Insert(c);
                    dal.Save();
                    int Contador = 0;
                    foreach (VencimentosModelView ve in Vencimentos)
                    {
                        Contador++;
                        ContasPagarAberto pa = new ContasPagarAberto();
                        pa.IdContasPagar = c.IdContasPagar; 
                        pa.Vencimento = ve.Data;
                        pa.VencimentoOriginal = c.VencimentoOriginal;
                        pa.NumeroParcela = Contador;
                        pa.NumeroParcelaOriginal = Contador;
                        pa.ValorTitulo = ve.Valor;
                        pa.Desconto = 0;
                        pa.ValorJuros = 0;
                        pa.ValorMulta = 0;
                        pa.ValorDescontoVista = 0;
                        pa.ValorLiquido = ve.Valor;
                        aDal.Insert(pa);
                        aDal.Save();
                    }
                }

                Emp.UltimaComissao = NumDocumento;
                edal.ERepository.Update(Emp);
                edal.Save();
                IdContasPagar = c.IdContasPagar;
                return ok;
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
                IdContasPagar = 0;
                return false;
            }
        }


    }
}
