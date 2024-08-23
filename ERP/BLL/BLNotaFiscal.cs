using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Models;
using ERP.DAL;
using ERP.ModelView;
using ERP.DAL.Fiscal;
using ERP.Forms.Faturamento;

namespace ERP.BLL
{
    public class BLNotaFiscal
    {
        DB_ERPContext db = new DB_ERPContext();
        public NotaFiscalDAL dal = null;
        public NotaFiscalItemDAL iDal = null;
        public NotaFiscalVencimentosDAL vDal = null;
        public RecebimentoDAL rDal = null;
        PedidoVendaDAL pvDal = new PedidoVendaDAL();
        ComissaoContaCorrenteDAL comissaoDal = new ComissaoContaCorrenteDAL();

        public bool VerificaGeracaoContasPagarCompras(int pIdNota)
        {
            //verifica se o pedido de compras e a operação informam a geração de financeiro
            bool? r = (from i in db.RecebimentoItem
                       join p in db.PedidoCompra on i.IdPedidoCompra equals p.IdPedidoCompra
                       join o in db.Operacao on p.IdOperacao equals o.IdOperacao
                       where i.IdNotaFiscal == pIdNota
                       select o.TransacoesFinanceiras).FirstOrDefault();
            if (r == null)
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(r);
            }
        }


        public NotaFiscal GeraNotaFiscalEntrada(List<int> ItensRecebimento, int Fornecedor, int NumeroNF, string pSerie, DateTime DataEmissao)
        {

            NotaFiscal n = null;
            PedidoCompra ped = null;
            Fornecedor fornecedor = new FornecedorDAL().FRepository.GetByID(Fornecedor);
            List<RecebimentoItem> Itens = rDal.GetListaItensRecebidos(ItensRecebimento);
            Empresa emp = new EmpresaDAL().ERepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
            if (Itens.Count > 0)
            {
                n = new NotaFiscal();
                ped = new PedidoCompraDAL().PCRepository.GetByID(Itens[0].IdPedidoCompra);
                n.Numero = NumeroNF.ToString();
                n.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                n.IdDocumento = 3;
                n.IdEmitente = Fornecedor;
                n.ClienteFornecedor = "F"; //indica o idEmitente se pertence a um fornecedor ou a empresa
                n.IdDestinatario = emp.IdEmpresa;
                n.RazaoSocial = emp.RazaoSocial;
                n.NomeFantasia = emp.Fantasia;
                n.Endereco = emp.Endereco;
                n.EnderecoNumero = emp.Numero;
                n.Complemento = emp.Complemento;
                n.Bairro = emp.Bairro;
                UnidadeFederacaoDAL ufDal = new UnidadeFederacaoDAL(new DB_ERPContext());
                n.UF = ufDal.GetByID(Convert.ToInt32(emp.IdUF)).UF;
                n.CEP = emp.CEP;
                n.CNPJ = emp.CNPJ;
                n.IE = emp.IE;
                n.DataEntrada = DateTime.Now;
                n.DirecaoCFOP = 1;
                //n.FormaEmissao
                //n.TipoAtendimento
                //n.FinalidadeEmissao
                //n.NomeOperacao := ''

                //Procura os dados do frete
                n.ValorFrete = 0;
                var encargos = new PedidoCompraEncargosDAL().GetPedidoCompraEncargos(ped.IdPedidoCompra);
                var frete = encargos.Where(x => x.TipoEncargo == 1).FirstOrDefault();

                if(frete != null)
                {
                    n.ValorFrete = frete.Valor == null ? 0 : frete.Valor;
                }


                n.ValorDesconto = 0;
                
                n.ValorSeguro = 0;
                var seguro = encargos.Where(x => x.TipoEncargo == 2).FirstOrDefault();
                if(seguro != null)
                {
                    n.ValorSeguro = seguro.Valor == null ? 0 : seguro.Valor;
                }
                n.BaseIPI = 0;
                n.ValorIPI = 0;
                n.BaseICMS = 0;
                n.ValorICMS = 0;
                n.BaseICMSSubs = 0;
                n.ValorICMSSubs = 0;
                n.ValorMercadoria = 0;
                n.TotalNF = 0;
                n.IdTransportadora = ped.IdTransportadora;
                n.TipoFrete = ped.TipoFrete;
                //n.Quantidade
                //n.Especie
                n.PesoLiquido = 0;
                n.PesoBruto = 0;
                //n.Volumes

                n.DataEmissao = DataEmissao;
                //n.IdCFOP
                n.IdCidade = emp.IdCidade;
                //n.DataEntrega
                n.NotaStatus = 2;
                n.Serie = pSerie;
                //n.ChaveNFe
                n.IdPais = n.IdPais;
                dal.Insert(n);
                dal.Save();
                if(ped.IdTransportadora != null)
                {
                    n.IdTransportadora = ped.IdTransportadora;
                }


                int contador = 0;
                //Lemos os itens
                foreach (RecebimentoItem r in Itens)
                {
                    NotaFiscalItem ni = new NotaFiscalItem();
                    contador++;
                    ni.IdNotaFiscal = n.IdNotaFiscal;
                    ni.Item = contador;
                    Produto prod = new ProdutoDAL().ProdutoRepository.GetByID(r.IdProduto);
                    PedidoCompraItem pci = new PedidoCompraItemDAL().GetItem(r.IdPedidoCompra, r.IdProduto);
                    ni.IdProduto = r.IdProduto;
                    ni.Codigo = prod.Codigo;
                    ni.Descricao = prod.Descricao;
                    ni.Quantidade = r.QuantidadeRecebida;
                    ni.ValorUnitario = r.ValorUnitario;
                    ni.Desconto = pci.DescontoValor;
                    ni.AliquotaIPI = pci.Ipi;
                    ni.ValorIPI = pci.Ipi * (ni.Quantidade * ni.ValorUnitario);
                    ni.ValorTotal = pci.ValorLiquido;
                    ni.PesoLiquido = prod.EstoquePeso * ni.Quantidade;
                    ni.PesoBruto = prod.EstqouePesoBruto * ni.Quantidade;
                    ni.IdUnidade = r.IdUnidade;
                    ni.IdNCM = pci.IdNCM;
                    ni.IdPedidoVendaItem = r.IdPedidoCompraItem;
                    ni.IdPedidoVenda = r.IdPedidoCompra;
                    ni.Desconto = pci.DescontoValor;
                    iDal.Insert(ni);
                    iDal.Save();

                    NotaFiscalItemApuracaoImpostoDAL itemImpostosDAL = new NotaFiscalItemApuracaoImpostoDAL();
                    itemImpostosDAL.AdicionaImpostosCompras((int)ni.IdPedidoVendaItem, ni.IdNotaFiscalItem);
                    var impostos = itemImpostosDAL.GetImpostosByNFItem(Convert.ToInt32(ni.IdNotaFiscalItem));
                    if (impostos != null)
                    {
                        foreach (var imp in impostos)
                        {

                            //IPI
                            if (imp.TipoImposto == 1)
                            {

                                ni.SituacaoTribIPI = new GrupoImpostoDAL().GetCodigoSituacaoTributaria((int)imp.IdGrupoImposto, 1);
                                ni.AliquotaIPI = imp.Aliquota;
                                if (imp.ValorAjustado != null && imp.ValorAjustado > 0)
                                {
                                    ni.ValorIPI = imp.ValorAjustado;
                                }
                                else
                                {
                                    ni.ValorIPI = imp.ValorImposto;
                                }
                                ni.EnquadramentoIPI = 999;
                            }

                            if (imp.TipoImposto == 2)//PIS
                            {
                                ni.SituacaoTribPIS = new GrupoImpostoDAL().GetCodigoSituacaoTributaria((int)imp.IdGrupoImposto, 2);
                                if (imp.BaseValorAjustado != null && imp.BaseValorAjustado > 0)
                                {
                                    ni.BasePIS = imp.BaseValorAjustado;
                                }
                                else
                                {
                                    ni.BasePIS = imp.BaseValor;
                                }

                                ni.AliquotaPIS = imp.Aliquota;
                                if (imp.ValorAjustado != null && imp.ValorAjustado > 0)
                                {
                                    ni.ValorPIS = imp.ValorAjustado;
                                }
                                else
                                {
                                    ni.ValorPIS = imp.ValorImposto;
                                }
                            }

                            if (imp.TipoImposto == 3)//ICMS
                            {
                                ni.SituacaoTribICMS = new GrupoImpostoDAL().GetCodigoSituacaoTributaria((int)imp.IdGrupoImposto, 3);
                                if (imp.BaseValorAjustado != null && imp.BaseValorAjustado > 0)
                                {
                                    ni.BaseICMS = imp.BaseValorAjustado;
                                }
                                else
                                {
                                    ni.BaseICMS = imp.BaseValor;
                                }

                                ni.AliquotaICMS = imp.Aliquota;
                                if (imp.ValorAjustado != null && imp.ValorAjustado > 0)
                                {
                                    ni.ValorICMS = imp.ValorAjustado;
                                }
                                else
                                {
                                    ni.ValorICMS = imp.ValorImposto;
                                }
                            }

                            if (imp.TipoImposto == 4)//COFINS
                            {

                                ni.SituacaoTribCOFINS = new GrupoImpostoDAL().GetCodigoSituacaoTributaria((int)imp.IdGrupoImposto, 4);
                                if (imp.BaseValorAjustado != null && imp.BaseValorAjustado > 0)
                                {
                                    ni.BaseCOFINS = imp.BaseValorAjustado;
                                }
                                else
                                {
                                    ni.BaseCOFINS = imp.BaseValor;
                                }

                                ni.AliquotaCOFINS = imp.Aliquota;
                                if (imp.ValorAjustado != null && imp.ValorAjustado > 0)
                                {
                                    ni.ValorCOFINS = imp.ValorAjustado;
                                }
                                else
                                {
                                    ni.ValorCOFINS = imp.ValorImposto;
                                }
                            }

                            if (imp.TipoImposto == 11)//ICMSST
                            {
                                ni.SituacaoTriICMSST = new GrupoImpostoDAL().GetCodigoSituacaoTributaria((int)imp.IdGrupoImposto, 11);
                                if (imp.BaseValorAjustado != null && imp.BaseValorAjustado > 0)
                                {
                                    ni.BaseICMSST = imp.BaseValorAjustado;
                                }
                                else
                                {
                                    ni.BaseICMSST = imp.BaseValor;
                                }

                                ni.AliquotaCOFINS = imp.Aliquota;
                                if (imp.ValorAjustado != null && imp.ValorAjustado > 0)
                                {
                                    ni.ValorICMSST = imp.ValorAjustado;
                                }
                                else
                                {
                                    ni.ValorICMSST = imp.ValorImposto;
                                }
                            }
                        }
                    }


                    iDal.Update(ni);
                    iDal.Save();

                    r.IdNotaFiscal = n.IdNotaFiscal;
                    rDal.RIRepository.Update(r);
                    rDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                }
            }
            //Efetua o calculo da nota fiscal
            n = CalculaNota(n.IdNotaFiscal);
            dal.Update(n);
            dal.Save();


            //Apos calculo dos valores efetuamos a geração dos vencimentos
            var vencimentos = new CondicaoPagamentoDAL().CalculaVencimentos(Convert.ToInt32(ped.IdCondicaoPagamento), Convert.ToDecimal(n.TotalNF), Convert.ToDateTime(n.DataEmissao));
            foreach (VencimentosModelView v in vencimentos)
            {
                NotaFiscalVencimentos nv = new NotaFiscalVencimentos();
                nv.IdNotaFiscal = n.IdNotaFiscal;
                nv.Data = v.Data;
                nv.Valor = v.Valor;
                vDal.Insert(nv);
                vDal.Save();
            }

            return n;
        }

        public void RecalculaVencimentos(int IdNotaFiscal, NotaFiscalVencimentosDAL vDal)
        {
            
            var n = new NotaFiscalDAL().GetByID(IdNotaFiscal);
            var it = new NotaFiscalItemDAL().GetByNF(IdNotaFiscal).FirstOrDefault();
            int IdCondicao = 0;
            if(n.IdDocumento == 3)//nota de entrada
            {
                if(it != null)
                {
                    IdCondicao = (int)new PedidoCompraDAL().PCRepository.GetByID(it.IdPedidoVenda).IdCondicaoPagamento;
                }  
            }

            if (n.IdDocumento == 6)//Nota de Saida
            {
                if (it != null)
                {
                    IdCondicao = (int)new PedidoVendaDAL().PVRepository.GetByID(it.IdPedidoVenda).IdCondicaoPagamento;
                }
            }

            vDal.ApagaVencimentos(IdNotaFiscal);
            var vencimentos = new CondicaoPagamentoDAL().CalculaVencimentos(IdCondicao, Convert.ToDecimal(n.TotalNF), Convert.ToDateTime(n.DataEmissao));
            foreach (VencimentosModelView v in vencimentos)
            {
                NotaFiscalVencimentos nv = new NotaFiscalVencimentos();
                nv.IdNotaFiscal = n.IdNotaFiscal;
                nv.Data = v.Data;
                nv.Valor = v.Valor;
                vDal.Insert(nv);
                vDal.Save();
            }
        }

        public NotaFiscal GeraNotaFiscalVendas(List<int> ItensPedido, int pIdCliente)
        {
            ClienteDAL clDal = new ClienteDAL();
            NotaFiscal n = null;
            PedidoVenda ped = null;
            Cliente cliente = clDal.CRepository.GetByID(pIdCliente);
            Endereco EFiscal = clDal.GetEnderecoFiscal(pIdCliente);
            Endereco EEntrega = clDal.GetEnderecoEntrega(pIdCliente);
            
            if (cliente == null)
            {
                Util.Aplicacao.ShowMessage("Cliente não localizado!");
                return null;
            }

            if (EFiscal == null)
            {
                if (EEntrega == null)
                {
                    Util.Aplicacao.ShowMessage("Cliente não possui endereço fiscal ou endereço de entrega.");
                    return null;
                }
            }



            List<PedidoVendaItem> Itens = pvDal.GetListaItensPedidoVendas(ItensPedido);
            Empresa emp = new EmpresaDAL().ERepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
            if (Itens.Count > 0)
            {
                n = new NotaFiscal();
                ped = new PedidoVendaDAL().PVRepository.GetByID(Itens[0].IdPedidoVenda);
                
                //n.Numero =
                n.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                n.IdDocumento = 6; //nota fiscal de vendas
                n.IdEmitente = emp.IdEmpresa;
                n.ClienteFornecedor = "C";//indica o idEmitente se pertence a um fornecedor ou a empresa
                n.IdDestinatario = cliente.IdCliente;
                n.RazaoSocial = cliente.RazaoSocial;
                n.NomeFantasia = cliente.NomeFantasia;
                n.Endereco = EFiscal.Logradouro;
                n.EnderecoNumero = EFiscal.Numero;
                n.Complemento = EFiscal.Complemento;
                n.FormaEmissao = 1;
                n.TipoAtendimento = ped.TipoAtendimento;
                n.TipoFrete = cliente.IdCondicaoFrete;
                if (ped.IdOperacao != null)
                {
                    Operacao op = new OperacaoDAL().GetByID((int)ped.IdOperacao);
                    n.NomeOperacao = op.Descricao;
                }
                n.Bairro = EFiscal.Bairro;
                UnidadeFederacaoDAL ufDal = new UnidadeFederacaoDAL(new DB_ERPContext());
                n.UF = ufDal.GetByID(Convert.ToInt32(EFiscal.IdUF)).UF;
                n.CEP = EFiscal.CodigoPostal;
                n.CNPJ = cliente.CNPJ;
                n.IE = cliente.InscricaoEstadual;
                //n.DataEntrada = DateTime.Now;
                n.DirecaoCFOP = 2; //saida 
                n.ValorDesconto = 0;
                n.ValorFrete = 0;
                n.ValorSeguro = 0;
                n.BaseIPI = 0;
                n.ValorIPI = 0;
                n.BaseICMS = 0;
                n.ValorICMS = 0;
                n.BaseICMSSubs = 0;
                n.ValorICMSSubs = 0;
                n.ValorMercadoria = 0;
                n.TotalNF = 0;
                n.IdTransportadora = ped.IdTransportadora;
                if(ped.TipoFrete > 0)
                {
                    n.TipoFrete = ped.TipoFrete;
                }
                
                //n.Quantidade
                //n.Especie
                n.PesoLiquido = 0;
                n.PesoBruto = 0;
                //n.Volumes

                n.DataEmissao = DateTime.Now;
                n.IdCidade = emp.IdCidade;
                n.DataEntrega = ped.DataEntrega;
                n.NotaStatus = 1;
                n.IdPais = EFiscal.IdPais;
                n.IdCidade = EFiscal.IdCidade;

                //Campos NFe
                n.NFeModelo = 55;
                n.Serie = "1";
                n.NFetpEmiss = 1;
                n.NFefinNFe = 1;
                n.NFeIndFinal = 1;
                n.NFeIndPag = 2;
                n.NFeIndPres = 9;
                n.NFetpNF = 1;
                n.FinalidadeEmissao = 1;

                dal.Insert(n);
                dal.Save();


                int contador = 0;
                //Lemos os itens
                foreach (PedidoVendaItem i in Itens)
                {
                    NotaFiscalItem ni = new NotaFiscalItem();
                    contador++;
                    ni.IdNotaFiscal = n.IdNotaFiscal;
                    ni.Item = contador;
                    Produto prod = new ProdutoDAL().ProdutoRepository.GetByID(i.IdProduto);
                    ni.IdProduto = i.IdProduto;
                    ni.IdConfiguracao = i.IdVariantesConfig;
                    ni.IdCor = i.IdVariantesCor;
                    ni.IdEstilo = i.IdVariantesEstilo;
                    ni.IdTamanho = i.IdVariantesTamanho;
                    ni.Codigo = prod.Codigo;
                    ni.Descricao = prod.Descricao;
                    ni.Quantidade = i.QuantidadePorFaturar;
                    ni.ValorUnitario = i.PrecoUnitario;
                    ni.IdCest = i.IdCest;
                    ni.Desconto = i.DescontoValor == null ? 0 : i.DescontoValor;
                    ni.ValorTotal = i.ValorLiquido;
                    ni.PesoLiquido = prod.EstoquePeso * ni.Quantidade;
                    ni.PesoBruto = prod.EstqouePesoBruto * ni.Quantidade;
                    ni.IdUnidade = i.IdUnidade;
                    ni.IdNCM = i.IdNCM;
                    ni.IdPedidoVenda = i.IdPedidoVenda;
                    ni.IdPedidoVendaItem = i.IdPedidoVendaItem;
                    if(i.IdCFOP != null && i.IdCFOP > 0)
                    {
                        ni.IdCFOP = i.IdCFOP;
                    }
                    
                    ni.Seguro = 0;
                    ni.Frete = 0;
                    ni.DespesasAcessorias = 0;
                    ni.AliquotaIPI = 0;
                    ni.ValorIPI = 0;
                    ni.BaseICMS = 0;
                    ni.AliquotaICMS = 0;
                    ni.ValorICMS = 0;
                    ni.ValorTotal = 0;
                    ni.Volumes = 0;
                    ni.ValorICMSST = 0;
                    ni.Origem = prod.FiscalOrigem; 
                    ni.ValorTotal = (ni.Quantidade * ni.ValorUnitario); 
                    ni.IdCFOP = i.IdCFOP;

                    //Calcula a comissao por item
                    var pedido = new PedidoVendaDAL().PVRepository.GetByID(i.IdPedidoVenda);
                    var operacao = new OperacaoDAL().GetByID(Convert.ToInt32(pedido.IdOperacao));
                    if(Convert.ToBoolean(operacao.TransacoesFinanceiras) && !Convert.ToBoolean(operacao.Bonificacao))
                    {
                        ni.IdVendedor = pedido.IdVendedor;
                        ni.PercentualTelevendas = 0;
                        Funcionario f = new FuncionarioDAL().FRepository.GetByID(pedido.IdTeleVendas);
                        if (f != null)
                        {
                            if (f.IdVendedor != null)
                            {
                                var tv = new VendedorDAL().VendedorRepository.GetByID(f.IdVendedor);
                                ni.IdVendedorTelevendas = tv.IdVendedor;
                                ni.PercentualTelevendas = tv.ComissaoAdicional == null ? 0 : tv.ComissaoAdicional;
                            }
                        }
                        var vend = new VendedorDAL().VendedorRepository.GetByID(ni.IdVendedor);

                        var percentual = vend.ComissaoPrincipal + ni.PercentualTelevendas > 6 ? (6 - ni.PercentualTelevendas) : vend.ComissaoPrincipal;
                        ni.PercentualVendedor = percentual;
                        ni.ComissaoVendedor = 0;
                        ni.ComissaoTelevendas = 0;
                        ni.ComissaoNegativa = 0;
                        //Gera a comissão normal
                        ni.ComissaoVendedor = ((i.PrecoTabela * ni.Quantidade) * ni.PercentualVendedor) / 100M;
                        if(ni.IdVendedorTelevendas != null)
                        {
                            ni.ComissaoTelevendas = ((i.PrecoTabela * ni.Quantidade) * ni.PercentualTelevendas) / 100M;
                        }

                        

                        //Gera a comissão exta
                        ni.ComissaoTelevendasExtra = 0;
                        ni.ComissaoVendedorExtra = 0;
                        if(i.PrecoTabela < (i.PrecoUnitario + i.DescontoVarejista))
                        {
                            //lança o valor da diferença entre o valor unitário e o valor de tabela
                            ni.ComissaoVendedorExtra = ((i.PrecoUnitario + i.DescontoVarejista) * ni.Quantidade) - (i.PrecoTabela * ni.Quantidade);

                            //Lança o percentual sobre o valor a mais
                            if(ni.IdVendedorTelevendas != null)
                            {
                                ni.ComissaoTelevendasExtra = (((i.PrecoUnitario + i.DescontoVarejista) * ni.Quantidade) - (i.PrecoTabela * ni.Quantidade) * ni.PercentualTelevendas) / 100M;
                            }
                            
                        }

                        if (i.PrecoTabela > (i.PrecoUnitario + i.DescontoVarejista))
                        {
                            //lança o valor da diferença entre o faltante para chegar na tabela
                            ni.ComissaoNegativa = (i.PrecoTabela * ni.Quantidade) - ((i.PrecoUnitario + i.DescontoVarejista) * ni.Quantidade);
                        }

                    }

                    if(Convert.ToBoolean(operacao.Bonificacao)) //quando o pedido não efetua transações financeiras
                    {
                        ni.ComissaoNegativa = (i.PrecoTabela * ni.Quantidade) - ((i.PrecoUnitario + i.DescontoVarejista) * ni.Quantidade);
                    }
                    



                    iDal.Insert(ni);
                    iDal.Save();

                    NotaFiscalItemApuracaoImpostoDAL itemImpostosDAL = new NotaFiscalItemApuracaoImpostoDAL(); 
                    itemImpostosDAL.AdicionaImpostos((int)ni.IdPedidoVendaItem, ni.IdNotaFiscalItem);
                    var impostos = itemImpostosDAL.GetImpostosByNFItem(Convert.ToInt32(ni.IdNotaFiscalItem));
                    if (impostos != null)
                    {
                        foreach (var imp in impostos)
                        {

                            //IPI
                            if (imp.TipoImposto == 1)
                            {

                                ni.SituacaoTribIPI = new GrupoImpostoDAL().GetCodigoSituacaoTributaria((int)imp.IdGrupoImposto, 1);
                                ni.AliquotaIPI = imp.Aliquota;
                                if (imp.ValorAjustado != null && imp.ValorAjustado > 0)
                                {
                                    ni.ValorIPI = imp.ValorAjustado;
                                }
                                else
                                {
                                    ni.ValorIPI = imp.ValorImposto;
                                }
                                ni.EnquadramentoIPI = 999;
                            }

                            if (imp.TipoImposto == 2)//PIS
                            {
                                ni.SituacaoTribPIS = new GrupoImpostoDAL().GetCodigoSituacaoTributaria((int)imp.IdGrupoImposto, 2);
                                if (imp.BaseValorAjustado != null && imp.BaseValorAjustado > 0)
                                {
                                    ni.BasePIS = imp.BaseValorAjustado;
                                }
                                else
                                {
                                    ni.BasePIS = imp.BaseValor;
                                }

                                ni.AliquotaPIS = imp.Aliquota;
                                if (imp.ValorAjustado != null && imp.ValorAjustado > 0)
                                {
                                    ni.ValorPIS = imp.ValorAjustado;
                                }
                                else
                                {
                                    ni.ValorPIS = imp.ValorImposto;
                                }
                            }

                            if (imp.TipoImposto == 3)//ICMS
                            {
                                ni.SituacaoTribICMS = new GrupoImpostoDAL().GetCodigoSituacaoTributaria((int)imp.IdGrupoImposto, 3);
                                if (imp.BaseValorAjustado != null && imp.BaseValorAjustado > 0)
                                {
                                    ni.BaseICMS = imp.BaseValorAjustado;
                                }
                                else
                                {
                                    ni.BaseICMS = imp.BaseValor;
                                }

                                ni.AliquotaICMS = imp.Aliquota;
                                if (imp.ValorAjustado != null && imp.ValorAjustado > 0)
                                {
                                    ni.ValorICMS = imp.ValorAjustado;
                                }
                                else
                                {
                                    ni.ValorICMS = imp.ValorImposto;
                                }
                            }

                            if (imp.TipoImposto == 4)//COFINS
                            {

                                ni.SituacaoTribCOFINS = new GrupoImpostoDAL().GetCodigoSituacaoTributaria((int)imp.IdGrupoImposto, 4);
                                if (imp.BaseValorAjustado != null && imp.BaseValorAjustado > 0)
                                {
                                    ni.BaseCOFINS = imp.BaseValorAjustado;
                                }
                                else
                                {
                                    ni.BaseCOFINS = imp.BaseValor;
                                }

                                ni.AliquotaCOFINS = imp.Aliquota;
                                if (imp.ValorAjustado != null && imp.ValorAjustado > 0)
                                {
                                    ni.ValorCOFINS = imp.ValorAjustado;
                                }
                                else
                                {
                                    ni.ValorCOFINS = imp.ValorImposto;
                                }
                            }

                            if (imp.TipoImposto == 11)//ICMSST
                            {
                                ni.SituacaoTriICMSST = new GrupoImpostoDAL().GetCodigoSituacaoTributaria((int)imp.IdGrupoImposto, 11);
                                if (imp.BaseValorAjustado != null && imp.BaseValorAjustado > 0)
                                {
                                    ni.BaseICMSST = imp.BaseValorAjustado;
                                }
                                else
                                {
                                    ni.BaseICMSST = imp.BaseValor;
                                }

                                ni.AliquotaCOFINS = imp.Aliquota;
                                if (imp.ValorAjustado != null && imp.ValorAjustado > 0)
                                {
                                    ni.ValorICMSST = imp.ValorAjustado;
                                }
                                else
                                {
                                    ni.ValorICMSST = imp.ValorImposto;
                                }
                            }
                        }
                    }


                    iDal.Update(ni);
                    iDal.Save();


                    //Atualiza as quantidades do pedido
                    i.QuantidadeFaturada = Convert.ToDecimal(i.QuantidadeFaturada) + Convert.ToInt32(i.QuantidadePorFaturar);
                    i.QuantidadeSeparacao = Convert.ToDecimal(i.QuantidadeSeparacao) - Convert.ToInt32(i.QuantidadePorFaturar);
                    i.QuantidadePorFaturar = 0;
                    pvDal.PVIRepository.Update(i);
                    pvDal.Save();

                    //Atualizamos o status da nota.
                    pvDal.AtualizaStatusPedidoAposFaturamento(i.IdPedidoVenda);
                }
            }


            //Efetua o calculo da nota fiscal
            n = CalculaNota(n.IdNotaFiscal);
            //trazemos os vencimentos
            Operacao operacaoNF = dal.getNFOperacaoVenda(n.IdNotaFiscal);
            if(Convert.ToBoolean(operacaoNF.TransacoesFinanceiras))
            {
                var vencimentos = new CondicaoPagamentoDAL().CalculaVencimentos(Convert.ToInt32(ped.IdCondicaoPagamento), Convert.ToDecimal(n.TotalNF), Convert.ToDateTime(n.DataEmissao));
                if (vencimentos != null)
                {
                    if (vencimentos.Count == 1)
                    {
                        n.NFeIndPag = 0;
                    }
                    else
                    {
                        n.NFeIndPag = 1;
                    }

                }
                //Apos calculo dos valores efetuamos a geração dos vencimentos

                foreach (VencimentosModelView v in vencimentos)
                {
                    NotaFiscalVencimentos nv = new NotaFiscalVencimentos();
                    nv.IdNotaFiscal = n.IdNotaFiscal;
                    nv.Data = v.Data;
                    nv.Valor = v.Valor;
                    vDal.Insert(nv);
                    vDal.Save();
                }

                dal.Update(n);
                dal.Save();
            } 

            return n;
        }

        public NotaFiscal GeraNotaFiscalVendasBalcao(int IdPedidoBalcao, PedidoBalcaoDAL pbdal)
        {
            PedidoBalcao p = pbdal.GetByID(IdPedidoBalcao);
            ClienteDAL clDal = new ClienteDAL();
            NotaFiscal n = null; 
            Cliente cliente = clDal.CRepository.GetByID(p.IdCliente); 

            if (cliente == null)
            {
                Util.Aplicacao.ShowMessage("Cliente não localizado!");
                return null;
            }

             



            var Itens = pbdal.getItensById(p.IdPedidoBalcao);
            Empresa emp = new EmpresaDAL().ERepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
            if (Itens.Count > 0)
            {
                n = new NotaFiscal(); 

                //n.Numero =
                n.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                n.IdDocumento = 6; //nota fiscal de vendas
                n.IdEmitente = emp.IdEmpresa;
                n.ClienteFornecedor = "C";//indica o idEmitente se pertence a um fornecedor ou a empresa
                n.IdDestinatario = cliente.IdCliente;
                n.RazaoSocial = cliente.RazaoSocial;
                n.NomeFantasia = cliente.NomeFantasia;
                n.Endereco = cliente.Logradouro;
                n.EnderecoNumero = cliente.Nro;
                n.Complemento = cliente.Compl;
                n.FormaEmissao = 1;
                n.TipoAtendimento = 1;
                n.TipoFrete = cliente.IdCondicaoFrete;
                n.IdCondicaoPagamento = p.IdCondicaoPagamento;
                 
                Operacao op = new OperacaoDAL().GetByID(1);
                n.NomeOperacao = op.Descricao;
                 
                n.Bairro = cliente.Bairro;
                UnidadeFederacaoDAL ufDal = new UnidadeFederacaoDAL(new DB_ERPContext());
                n.UF = ufDal.GetByID(Convert.ToInt32((int)cliente.IdUf)).UF;
                n.CEP = cliente.CEP;
                n.CNPJ = cliente.CNPJ;
                if(cliente.CNPJ.Length == 14)
                {
                    n.IE = cliente.InscricaoEstadual;
                }
                
                //n.DataEntrada = DateTime.Now;
                n.DirecaoCFOP = 2; //saida 
                n.ValorDesconto = 0;
                n.ValorFrete = 0;
                n.ValorSeguro = 0;
                n.BaseIPI = 0;
                n.ValorIPI = 0;
                n.BaseICMS = 0;
                n.ValorICMS = 0;
                n.BaseICMSSubs = 0;
                n.ValorICMSSubs = 0;
                n.ValorMercadoria = 0;
                n.TotalNF = 0;  
                n.TipoFrete = 2;
                 

                //n.Quantidade
                //n.Especie
                n.PesoLiquido = 0;
                n.PesoBruto = 0;
                //n.Volumes

                n.DataEmissao = DateTime.Now;
                n.IdCidade = emp.IdCidade;
                n.DataEntrega = DateTime.Now;
                n.NotaStatus = 1;
                n.IdPais = cliente.IdPais;
                n.IdCidade = cliente.IdCidade;

                //Campos NFe
                n.NFeModelo = 55;
                n.Serie = "1";
                n.NFetpEmiss = 1;
                n.NFefinNFe = 1;
                n.NFeIndFinal = 0;
                n.NFeIndPag = 2;
                n.NFeIndPres = 9;
                n.NFetpNF = 1;
                n.FinalidadeEmissao = 1;

                dal.Insert(n);
                dal.Save();


                int contador = 0;
                //Lemos os itens
                foreach (var i in Itens)
                {
                    var nfi = dal.getNFItemById((int)i.IdProduto);
                    NotaFiscalItem ni = new NotaFiscalItem();
                    contador++;
                    ni.IdNotaFiscal = n.IdNotaFiscal;
                    ni.Item = contador;
                    Produto prod = new ProdutoDAL().ProdutoRepository.GetByID(i.IdProduto);
                    ni.IdProduto = i.IdProduto; 
                    ni.Codigo = prod.Codigo;
                    ni.Descricao = prod.NomeProduto;
                    ni.Quantidade = i.Qtde;
                    ni.ValorUnitario = i.ValorUnitario; 
                    ni.Desconto = i.Desconto;
                    ni.ValorTotal = i.ValorTotal;
                    ni.PesoLiquido = prod.EstoquePeso * ni.Quantidade;
                    ni.PesoBruto = prod.EstqouePesoBruto * ni.Quantidade;
                    ni.IdUnidade = i.Produto.VendaIdUnidade;
                    ni.IdNCM = i.Produto.FiscalIdNCM == null ? 4575 : i.Produto.FiscalIdNCM;
                    ni.IdCest = i.Produto.IdCest;
                    ni.IdPedidoVenda = i.IdPedidoBalcao;
                    ni.IdPedidoVendaItem = i.IdPedidoBalcaoProduto; 
                    ni.Seguro = 0;
                    ni.Frete = 0;
                    ni.DespesasAcessorias = 0;
                    ni.AliquotaIPI = 0;
                    ni.ValorIPI = 0;
                    ni.BaseICMS = 0;
                    ni.AliquotaICMS = 0;
                    ni.ValorICMS = 0;
                    ni.ValorTotal = 0;
                    ni.Volumes = 0;
                    ni.ValorICMSST = 0;
                    ni.Origem = prod.FiscalOrigem;
                    ni.ValorTotal = (ni.Quantidade * ni.ValorUnitario);
                    ni.SituacaoTribCOFINS = "07";
                    ni.BaseCOFINS = 0;
                    ni.AliquotaCOFINS = 0;
                    ni.ValorCOFINS = 0;
                    ni.SituacaoTribPIS = "07";
                    ni.BasePIS = 0;
                    ni.AliquotaPIS = 0;
                    ni.ValorPIS = 0;

                    if(nfi != null)
                    { 
                        switch(nfi.SituacaoTribICMS)
                        {
                            case "00":
                                {
                                    ni.SituacaoTribICMS = "102";
                                    ni.IdCFOP = 221; 
                                }
                                break;
                            case "10":
                                {
                                    ni.SituacaoTribICMS = "500";
                                    ni.IdCFOP = 281;
                                }
                                break;
                            case "20":
                                {
                                    ni.SituacaoTribICMS = "102";
                                    ni.IdCFOP = 221;
                                }
                                break;
                            case "30":
                                {
                                    ni.SituacaoTribICMS = "500";
                                    ni.IdCFOP = 281;
                                }
                                break;
                            case "40":
                                {
                                    ni.SituacaoTribICMS = "102";
                                    ni.IdCFOP = 221;
                                }
                                break;
                            case "41":
                                {
                                    ni.SituacaoTribICMS = "102";
                                    ni.IdCFOP = 221;
                                }
                                break;
                            case "51":
                                {
                                    ni.SituacaoTribICMS = "102";
                                    ni.IdCFOP = 221;
                                }
                                break;
                            case "60":
                                {
                                    ni.SituacaoTribICMS = "500";
                                    ni.IdCFOP = 281;
                                }
                                break;
                            case "90":
                                {
                                    ni.SituacaoTribICMS = "500";
                                    ni.IdCFOP = 281;
                                }
                                break;
                            case "101":
                                {
                                    ni.SituacaoTribICMS = "102";
                                    ni.IdCFOP = 221;
                                }
                                break;
                            case "500":
                                {
                                    ni.SituacaoTribICMS = "500";
                                    ni.IdCFOP = 281;
                                }
                                break;
                            case "102":
                                {
                                    ni.SituacaoTribICMS = "102";
                                    ni.IdCFOP = 221;
                                }
                                break;
                            default:
                                {
                                    ni.SituacaoTribICMS = "102";
                                    ni.IdCFOP = 221;
                                }
                                break;
                        } 
                        ni.BaseICMS = 0;
                        ni.ValorICMS = 0;
                        ni.AliquotaICMS = 0;
                        ni.SituacaoTribIPI = "53";
                        ni.EnquadramentoIPI = 999;
                        ni.AliquotaIPI = 0;
                        ni.ValorIPI = 0;
                    }
                    else
                    {
                        ni.IdCFOP = 221; 
                        ni.SituacaoTribICMS = "102";
                        ni.BaseICMS = 0;
                        ni.ValorICMS = 0;
                        ni.AliquotaICMS = 0;
                        ni.SituacaoTribIPI = "53";
                        ni.EnquadramentoIPI = 999;
                        ni.AliquotaIPI = 0;
                        ni.ValorIPI = 0;
                    }

                    //lanca os impostos




                    iDal.Insert(ni);
                    iDal.Save(); 
                     
                }

                List<NotaFiscalItem> itens = new NotaFiscalItemDAL().GetByNF(n.IdNotaFiscal);
                n.PesoBruto = itens.Sum(x => x.PesoBruto);
                n.PesoLiquido = itens.Sum(x => x.PesoLiquido);
                n.ValorMercadoria = Convert.ToDecimal(itens.Sum(x => x.Quantidade * x.ValorUnitario));
                n.ValorDesconto = itens.Sum(x => x.Desconto);
                n.BaseIPI = n.ValorMercadoria;
                n.ValorIPI = itens.Sum(x => x.ValorIPI);
                n.BaseICMS = itens.Sum(x => x.BaseICMS);
                n.ValorICMS = itens.Sum(x => x.ValorICMS);
                n.BaseICMSSubs = itens.Sum(x => x.BaseICMSST);
                n.ValorICMSSubs = itens.Sum(x => x.ValorICMSST);
                n.TotalNF = n.ValorMercadoria - n.ValorDesconto + n.ValorFrete + n.ValorSeguro + n.ValorIPI + n.ValorICMS;
                dal.Update(n);
                dal.Save();

                //Adiciona as Informações
                NotaFiscalObsDAL odal = new NotaFiscalObsDAL();
                NotaFiscalObs obs1 = new NotaFiscalObs();
                obs1.IdNotaFiscal = n.IdNotaFiscal;
                obs1.Observacao = "DOCUMENTO EMITIDO POR ME OPTANTE PELO SIMPLES NACIONAL, NAO GERA DIREITO A CRÉDITO FISCAL DE ISS E IPI";

                var vencimentos = new CondicaoPagamentoDAL().CalculaVencimentos(Convert.ToInt32(n.IdCondicaoPagamento), Convert.ToDecimal(n.TotalNF), Convert.ToDateTime(n.DataEmissao));
                if (vencimentos != null)
                {
                    if (vencimentos.Count == 1)
                    {
                        n.NFeIndPag = 0;
                    }
                    else
                    {
                        n.NFeIndPag = 1;
                    }

                }
                //Apos calculo dos valores efetuamos a geração dos vencimentos

                foreach (VencimentosModelView v in vencimentos)
                {
                    NotaFiscalVencimentos nv = new NotaFiscalVencimentos();
                    nv.IdNotaFiscal = n.IdNotaFiscal;
                    nv.Data = v.Data;
                    nv.Valor = v.Valor;
                    vDal.Insert(nv);
                    vDal.Save();
                }

                dal.Update(n);
                dal.Save();

                //Atualiza o numero da nf no pedido
                PedidoBalcao pb = pbdal.GetByID(IdPedidoBalcao);
                pb.IdNotaFiscal = n.IdNotaFiscal;
                pbdal.Update(pb);
                pbdal.Save(); 
            } 

            return n;
        }

        public void GeraComissao(int pIdNotaFiscal)
        {
            NotaFiscal n = dal.GetByID(pIdNotaFiscal);
            string pedidos = "Ped " + dal.getPedidosByNotaId(pIdNotaFiscal);
            var lista = dal.getComissoesResumidas(pIdNotaFiscal);

            foreach(var i in lista)
            {
                //Comissão normal
                if(i.ComissaoVendedor > 0)
                {
                    AddComissao(Convert.ToInt32(i.IdVendedor), n.IdNotaFiscal, n.DataEmissao, Convert.ToDecimal(i.ComissaoVendedor), Convert.ToDecimal(i.PercentualVendedor), Convert.ToDecimal(i.ComissaoVendedor), 0, pedidos + " NF " + n.Numero.ToString(), 1, 1);
                }

                if(i.ComissaoTelevendas > 0)
                {
                    AddComissao(Convert.ToInt32(i.IdTelevendas), n.IdNotaFiscal, n.DataEmissao, Convert.ToDecimal(i.ComissaoTelevendas), Convert.ToDecimal(i.PercentualTelevendas), Convert.ToDecimal(i.ComissaoTelevendas), 0, pedidos + " NF " + n.Numero.ToString(), 1, 2);
                }

                //Gera comissão extra
                if (i.ComissaoVendedorExtra > 0)
                {
                    AddComissao(Convert.ToInt32(i.IdVendedor), n.IdNotaFiscal, n.DataEmissao, Convert.ToDecimal(i.ComissaoVendedorExtra), Convert.ToDecimal(i.PercentualVendedor), Convert.ToDecimal(i.ComissaoVendedorExtra), 0, pedidos + " NF " + n.Numero.ToString() + " choque", 2, 3);
                }

                if (i.ComissaoTelevendasExtra > 0)
                {
                    AddComissao(Convert.ToInt32(i.IdTelevendas), n.IdNotaFiscal, n.DataEmissao, Convert.ToDecimal(i.ComissaoTelevendasExtra), Convert.ToDecimal(i.PercentualTelevendas), Convert.ToDecimal(i.ComissaoTelevendasExtra), 0, pedidos + " NF " + n.Numero.ToString() + " choque", 2, 3);
                }

                //Gera comissão negativa
                if (i.ComissaoNegativa > 0)
                {
                    AddComissao(Convert.ToInt32(i.IdVendedor), n.IdNotaFiscal, n.DataEmissao, Convert.ToDecimal(i.ComissaoNegativa * -1), Convert.ToDecimal(i.PercentualVendedor), Convert.ToDecimal(i.ComissaoNegativa * -1), 0, pedidos + " NF " + n.Numero.ToString() + "Bonificação/Abaixo Tabela", 2, 3);
                }
            }

            //verifica se a nota nao tem comissao gerada
            //var lista = comissaoDal.GetByNotaFiscal(pIdNotaFiscal);

            //if (lista == null || lista.Count == 0)
            //{
            //    var Comissao = comissaoDal.ComissaoPorNotaFiscal(pIdNotaFiscal);
                
            //    //Calcula a comissao do vendedor

            //    foreach (ComissaoVendedorModelView i in Comissao)
            //    {
                    
            //        decimal Percentual = new VendedorDAL().ComissaoPrincipal(Convert.ToInt32(i.IdVendedor), i.IdTeleVendas);

            //        //Calcula o valor do pedido 
            //        var ComissaoVencimentos = new CondicaoPagamentoDAL().CalculaVencimentos(Convert.ToInt32(i.IdCondicaoPagamento), Convert.ToDecimal(i.ValorDeTabela), Convert.ToDateTime(n.DataEmissao));
            //        foreach (VencimentosModelView vi in ComissaoVencimentos)
            //        {
            //            //Gera a Comiss
            //            if (i.IdVendedor != null && i.IdVendedor > 0)
            //            {
            //                if (vi.Valor > 0)
            //                {
            //                    ComissaoContaCorrente cc = new ComissaoContaCorrente();
            //                    cc.IdVendedor = (int)i.IdVendedor;
            //                    cc.IdNotaFiscal = pIdNotaFiscal;
            //                    cc.DataNotaFiscal = n.DataEmissao;
            //                    cc.Comissao = (vi.Valor * Percentual) / 100M;
            //                    cc.ComissaoPercentual = Percentual;
            //                    cc.ValorAPagar = cc.Comissao;
            //                    cc.Acrescimo = 0;
            //                    cc.ValorPago = 0;
            //                    cc.Observacao = pedidos + " NF " + n.Numero.ToString();
            //                    cc.TipoLancamento = 1; //Lançamento pelo sistema
            //                    cc.TipoComissao = 1;
            //                    comissaoDal.Insert(cc);
            //                    comissaoDal.Save();
            //                } 
            //            }
            //        }

            //        //Gera a comissao normal do televendas
            //        decimal? BaseTelemarketing = 0;
            //        if (i.ValorUnitarioDeVenda - i.ValorDeContratoComJuros > 0) //Se existe valor acima da tabela
            //        {
            //            BaseTelemarketing = i.ValorLiquido;
            //        }
            //        else
            //        {
            //            BaseTelemarketing = i.ValorUnitarioDeVenda;
            //        }


            //        var ComissaoVencimentosTelevendas = new CondicaoPagamentoDAL().CalculaVencimentos(Convert.ToInt32(i.IdCondicaoPagamento), Convert.ToDecimal(BaseTelemarketing), Convert.ToDateTime(n.DataEmissao));

            //        foreach (VencimentosModelView vi in ComissaoVencimentosTelevendas)
            //        {
            //            //Gera a Comissa do televendas
            //            if (i.IdTeleVendas != null && i.IdTeleVendas > 0)
            //            {
            //                Funcionario f = new FuncionarioDAL().FRepository.GetByID(i.IdTeleVendas);
            //                if (f != null)
            //                {
            //                    if (f.IdVendedor != null)
            //                    {
            //                        if (vi.Valor > 0)
            //                        {
            //                            Vendedor vend = new VendedorDAL().VendedorRepository.GetByID(f.IdVendedor);
            //                            ComissaoContaCorrente ct = new ComissaoContaCorrente();
            //                            ct.IdVendedor = (int)f.IdVendedor;
            //                            ct.IdTeleVendas = i.IdTeleVendas;
            //                            ct.IdNotaFiscal = pIdNotaFiscal;
            //                            ct.DataNotaFiscal = n.DataEmissao;
            //                            ct.Comissao = (vi.Valor * Convert.ToDecimal(vend.ComissaoAdicional)) / 100M;
            //                            ct.ComissaoPercentual = Convert.ToDecimal(vend.ComissaoAdicional);
            //                            ct.ValorAPagar = ct.Comissao;
            //                            ct.Acrescimo = 0;
            //                            ct.ValorPago = 0;
            //                            ct.Observacao = pedidos + " NF " + n.Numero.ToString();
            //                            ct.TipoLancamento = 1; //Lançamento pelo sistema
            //                            ct.TipoComissao = 2;
            //                            comissaoDal.Insert(ct);
            //                            comissaoDal.Save();
            //                        }
            //                    }
            //                }
            //            }
            //        }


            //        if (i.ValorTotalPedido - i.ValorLiquido > 0)
            //        {
            //            //Calcula o valor da venda com valor acima da tabela
            //            if (i.ValorUnitarioDeVenda - i.ValorDeContratoComJuros > 0)
            //            {
            //                var ComissaoVencimentosExtra = new CondicaoPagamentoDAL().CalculaVencimentos(Convert.ToInt32(i.IdCondicaoPagamento), Convert.ToDecimal(i.ValorUnitarioDeVenda - i.ValorDeContratoComJuros), Convert.ToDateTime(n.DataEmissao));
            //                foreach (VencimentosModelView vi in ComissaoVencimentosExtra)
            //                {
            //                    if (vi.Valor > 0)
            //                    {
            //                        ComissaoContaCorrente cc = new ComissaoContaCorrente();
            //                        cc.IdVendedor = (int)i.IdVendedor;
            //                        cc.IdNotaFiscal = pIdNotaFiscal;
            //                        cc.DataNotaFiscal = n.DataEmissao;
            //                        cc.Comissao = vi.Valor;
            //                        cc.ComissaoPercentual = Percentual;
            //                        cc.ValorAPagar = cc.Comissao;
            //                        cc.Acrescimo = 0;
            //                        cc.ValorPago = 0;
            //                        cc.Observacao = pedidos + " NF " + n.Numero.ToString() + " choque";
            //                        cc.TipoLancamento = 2; //Lançamento manual
            //                        cc.TipoComissao = 3;
            //                        comissaoDal.Insert(cc);
            //                        comissaoDal.Save();
            //                    }
            //                }
            //            }



            //            //gera a comissao a mais do televendas
            //            if (BaseTelemarketing == i.ValorLiquido)//Compara para ver se é necesssario gerar a comissao extra do televendas
            //            {
            //                var ComissaoVencimentosTelevendasAMais = new CondicaoPagamentoDAL().CalculaVencimentos(Convert.ToInt32(i.IdCondicaoPagamento), Convert.ToDecimal(i.ValorTotalPedido - i.ValorLiquido), Convert.ToDateTime(n.DataEmissao));
            //                foreach (VencimentosModelView vi in ComissaoVencimentosTelevendasAMais)
            //                {
            //                    //Gera a Comissa do televendas
            //                    if (i.IdTeleVendas != null && i.IdTeleVendas > 0)
            //                    {
            //                        Funcionario f = new FuncionarioDAL().FRepository.GetByID(i.IdTeleVendas);
            //                        if (f != null)
            //                        {
            //                            if (f.IdVendedor != null)
            //                            {
            //                                if (vi.Valor > 0)
            //                                {
            //                                    Vendedor vend = new VendedorDAL().VendedorRepository.GetByID(f.IdVendedor);
            //                                    ComissaoContaCorrente ct = new ComissaoContaCorrente();
            //                                    ct.IdVendedor = (int)f.IdVendedor;
            //                                    ct.IdTeleVendas = i.IdTeleVendas;
            //                                    ct.IdNotaFiscal = pIdNotaFiscal;
            //                                    ct.DataNotaFiscal = n.DataEmissao;
            //                                    ct.Comissao = (vi.Valor * Convert.ToDecimal(vend.ComissaoAdicional)) / 100M;
            //                                    ct.ComissaoPercentual = Convert.ToDecimal(vend.ComissaoAdicional);
            //                                    ct.ValorAPagar = ct.Comissao;
            //                                    ct.Acrescimo = 0;
            //                                    ct.ValorPago = 0;
            //                                    ct.Observacao = pedidos + " NF " + n.Numero.ToString() + " choque";
            //                                    ct.TipoLancamento = 2; //Lançamento pelo sistema
            //                                    ct.TipoComissao = 3;
            //                                    comissaoDal.Insert(ct);
            //                                    comissaoDal.Save();
            //                                }
            //                            }
            //                        }
            //                    }
            //                } 
            //            } 
            //        }






            //        //Calcula o valor da venda com valor abaixo da tabela
            //        if (i.ValorDeContratoComJuros - i.ValorUnitarioDeVenda > 0)
            //        {
            //            var ComissaoVencimentosExtra = new CondicaoPagamentoDAL().CalculaVencimentos(Convert.ToInt32(i.IdCondicaoPagamento), Convert.ToDecimal(i.ValorDeContratoComJuros - i.ValorUnitarioDeVenda), Convert.ToDateTime(n.DataEmissao));
            //            foreach (VencimentosModelView vi in ComissaoVencimentosExtra)
            //            {
            //                if (vi.Valor > 0)
            //                {
            //                    ComissaoContaCorrente cc = new ComissaoContaCorrente();
            //                    cc.IdVendedor = (int)i.IdVendedor;
            //                    cc.IdNotaFiscal = pIdNotaFiscal;
            //                    cc.DataNotaFiscal = n.DataEmissao;
            //                    cc.Comissao = vi.Valor * -1;
            //                    cc.ComissaoPercentual = Percentual;
            //                    cc.ValorAPagar = cc.Comissao * -1;
            //                    cc.Acrescimo = 0;
            //                    cc.ValorPago = 0;
            //                    cc.Observacao = pedidos + " NF " + n.Numero.ToString();
            //                    cc.TipoLancamento = 2; //Lançamento manual
            //                    cc.TipoComissao = 3;
            //                    comissaoDal.Insert(cc);
            //                    comissaoDal.Save();
            //                }
            //            }
            //        }


            //    }
            //}
        }

        private void AddComissao(int IdVendedor, 
                                 int IdNotaFiscal, 
                                 DateTime DataNotaFiscal, 
                                 decimal Comissao,
                                 decimal ComissaoPercentual,
                                 decimal ValorAPagar,
                                 decimal Acrescimo,
                                 string Observacao,
                                 int TipoLancamento,
                                 int TipoComissao)
        {
            ComissaoContaCorrente cc = new ComissaoContaCorrente();
            cc.IdVendedor = IdVendedor;
            cc.IdNotaFiscal = IdNotaFiscal;
            cc.DataNotaFiscal = DataNotaFiscal;
            cc.Comissao = Comissao;
            cc.ComissaoPercentual = ComissaoPercentual;
            cc.ValorAPagar = ValorAPagar;
            cc.Acrescimo = Acrescimo;
            cc.ValorPago = 0;
            cc.Observacao = Observacao;
            cc.TipoLancamento = TipoLancamento; //Lançamento pelo sistema
            cc.TipoComissao = TipoComissao;
            comissaoDal.Insert(cc);
            comissaoDal.Save();
        }

        public NotaFiscal CalculaNota(int pIdNotaFiscal)
        {
            //Recalcula


            NotaFiscal n = dal.GetByID(pIdNotaFiscal);
             
            n.BaseIPI = 0;
            n.ValorIPI = 0;
            n.BaseICMS = 0;
            n.ValorICMS = 0;
            n.BaseICMSSubs = 0;
            n.ValorICMSSubs = 0;
            n.ValorMercadoria = 0;
            n.TotalNF = 0;
            n.Quantidade = 0; 
            n.PesoLiquido = 0;
            n.PesoBruto = 0;

            var lista = iDal.GetByNF(pIdNotaFiscal);
 


            //Recalcula os impostos
            foreach(var i in lista)
            {
                try
                {
                    BLImpostoEncargosVendas blImpostos = new BLImpostoEncargosVendas();
                    blImpostos.dal = new PedidoVendaItemApuracaoImpostoDAL();
                    blImpostos.pedidoDal = new PedidoVendaDAL();
                    blImpostos.GeraImpostos(Convert.ToInt32(i.IdPedidoVendaItem));
                }
                catch  
                { 
                }
                
            }


            foreach(var ni in lista)
            {
                NotaFiscalItemApuracaoImpostoDAL itemImpostosDAL = new NotaFiscalItemApuracaoImpostoDAL();
                
                var impostos = itemImpostosDAL.GetImpostosByNFItem(Convert.ToInt32(ni.IdNotaFiscalItem));
                if (impostos != null)
                {
                    foreach (var imp in impostos)
                    {

                        //IPI
                        if (imp.TipoImposto == 1)
                        {

                            ni.SituacaoTribIPI = new GrupoImpostoDAL().GetCodigoSituacaoTributaria((int)imp.IdGrupoImposto, 1);
                            ni.AliquotaIPI = imp.Aliquota;
                            if (imp.ValorAjustado != null && imp.ValorAjustado > 0)
                            {
                                ni.ValorIPI = imp.ValorAjustado;
                            }
                            else
                            {
                                ni.ValorIPI = imp.ValorImposto;
                            }
                            ni.EnquadramentoIPI = 999;
                        }

                        if (imp.TipoImposto == 2)//PIS
                        {
                            ni.SituacaoTribPIS = new GrupoImpostoDAL().GetCodigoSituacaoTributaria((int)imp.IdGrupoImposto, 2);
                            if (imp.BaseValorAjustado != null && imp.BaseValorAjustado > 0)
                            {
                                ni.BasePIS = imp.BaseValorAjustado;
                            }
                            else
                            {
                                ni.BasePIS = imp.BaseValor;
                            }

                            ni.AliquotaPIS = imp.Aliquota;
                            if (imp.ValorAjustado != null && imp.ValorAjustado > 0)
                            {
                                ni.ValorPIS = imp.ValorAjustado;
                            }
                            else
                            {
                                ni.ValorPIS = imp.ValorImposto;
                            }
                        }

                        if (imp.TipoImposto == 3)//ICMS
                        {
                            ni.SituacaoTribICMS = new GrupoImpostoDAL().GetCodigoSituacaoTributaria((int)imp.IdGrupoImposto, 3);
                            if (imp.BaseValorAjustado != null && imp.BaseValorAjustado > 0)
                            {
                                ni.BaseICMS = imp.BaseValorAjustado;
                            }
                            else
                            {
                                ni.BaseICMS = imp.BaseValor;
                            }

                            ni.AliquotaICMS = imp.Aliquota;
                            if (imp.ValorAjustado != null && imp.ValorAjustado > 0)
                            {
                                ni.ValorICMS = imp.ValorAjustado;
                            }
                            else
                            {
                                ni.ValorICMS = imp.ValorImposto;
                            }
                        }

                        if (imp.TipoImposto == 4)//COFINS
                        {

                            ni.SituacaoTribCOFINS = new GrupoImpostoDAL().GetCodigoSituacaoTributaria((int)imp.IdGrupoImposto, 4);
                            if (imp.BaseValorAjustado != null && imp.BaseValorAjustado > 0)
                            {
                                ni.BaseCOFINS = imp.BaseValorAjustado;
                            }
                            else
                            {
                                ni.BaseCOFINS = imp.BaseValor;
                            }

                            ni.AliquotaCOFINS = imp.Aliquota;
                            if (imp.ValorAjustado != null && imp.ValorAjustado > 0)
                            {
                                ni.ValorCOFINS = imp.ValorAjustado;
                            }
                            else
                            {
                                ni.ValorCOFINS = imp.ValorImposto;
                            }
                        }

                        if (imp.TipoImposto == 11)//ICMSST
                        {
                            ni.SituacaoTriICMSST = new GrupoImpostoDAL().GetCodigoSituacaoTributaria((int)imp.IdGrupoImposto, 11);
                            if (imp.BaseValorAjustado != null && imp.BaseValorAjustado > 0)
                            {
                                ni.BaseICMSST = imp.BaseValorAjustado;
                            }
                            else
                            {
                                ni.BaseICMSST = imp.BaseValor;
                            }

                            ni.AliquotaCOFINS = imp.Aliquota;
                            if (imp.ValorAjustado != null && imp.ValorAjustado > 0)
                            {
                                ni.ValorICMSST = imp.ValorAjustado;
                            }
                            else
                            {
                                ni.ValorICMSST = imp.ValorImposto;
                            }
                        }
                    }
                }


                iDal.Update(ni);
                iDal.Save();
            }
             
            List<NotaFiscalItem> itens = new NotaFiscalItemDAL().GetByNF(pIdNotaFiscal);
            n.PesoBruto = itens.Sum(x => x.PesoBruto);
            n.PesoLiquido = itens.Sum(x => x.PesoLiquido);
            n.ValorMercadoria = Convert.ToDecimal(itens.Sum(x => x.Quantidade * x.ValorUnitario));
            n.ValorDesconto = itens.Sum(x => x.Desconto);
            n.BaseIPI = n.ValorMercadoria;
            n.ValorIPI = itens.Sum(x => x.ValorIPI);
            n.BaseICMS = itens.Sum(x => x.BaseICMS);
            n.ValorICMS = itens.Sum(x => x.ValorICMS);
            n.BaseICMSSubs = itens.Sum(x => x.BaseICMSST);
            n.ValorICMSSubs = itens.Sum(x => x.ValorICMSST);

            //Pega os impostos que nao estao inclusos e soma no total.
            if(n.IdDocumento == 6)
            {
                decimal impostosNaoInclusos = new PedidoVendaItemApuracaoImpostoDAL().GetImpostosNaoInclusosByNotaFiscal(n.IdNotaFiscal);
                n.TotalNF = n.ValorMercadoria - n.ValorDesconto + n.ValorFrete + n.ValorSeguro + impostosNaoInclusos;
            }
            else
            {
                n.TotalNF = n.ValorMercadoria - n.ValorDesconto + n.ValorFrete + n.ValorSeguro + n.ValorIPI + n.ValorICMS;
            }
            
            return n;
        }

        public NotaFiscal GeraNotaFiscalDevolucao(int IdCFOP, string NumNF, string pSerie, DateTime Emissao, NotaFiscal nota, List<NotaFiscalItemModelView> Itens)
        {
            Fornecedor c = new FornecedorDAL().FRepository.GetByID(nota.IdEmitente);
            NotaFiscal n = new NotaFiscal();
            Empresa empx = new EmpresaDAL().ERepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
            if (Itens.Count > 0)
            {
                n = new NotaFiscal(); 
                //n.Numero = NumNF.ToString();
                n.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                n.IdDocumento = 8;
                n.IdEmitente = 1;
                n.ClienteFornecedor = "C"; //indica o idEmitente se pertence a um fornecedor ou a empresa
                n.IdDestinatario = c.IdFornecedor;
                n.RazaoSocial = c.RazaoSocial;
                n.NomeFantasia = c.NomeFantasia;
                n.Endereco = c.Endereco;
                n.EnderecoNumero = c.Numero;
                n.Complemento = c.Complemento;
                n.Bairro = c.Bairro;
                UnidadeFederacaoDAL ufDal = new UnidadeFederacaoDAL(new DB_ERPContext());
                n.UF = nota.UF;
                n.CEP = nota.CEP;
                n.CNPJ = nota.CNPJ;
                n.IE = nota.IE;
                n.DataEntrada = DateTime.Now;
                n.DirecaoCFOP = 2; 
                n.ValorDesconto = 0;
                n.ValorFrete = 0;
                n.ValorSeguro = 0;
                n.BaseIPI = 0;
                n.ValorIPI = 0;
                n.BaseICMS = 0;
                n.ValorICMS = 0;
                n.BaseICMSSubs = 0;
                n.ValorICMSSubs = 0;
                n.ValorMercadoria = 0;
                n.TotalNF = 0;  
                n.PesoLiquido = 0;
                n.PesoBruto = 0; 
                n.NFConfirmada = true;
                n.DataEmissao = Emissao; 
                n.IdCidade = nota.IdCidade; 
                n.NotaStatus = 1;
                //n.Serie = pSerie; 
                n.IdPais = n.IdPais;
                n.FinalidadeEmissao = 4;
                dal.Insert(n);
                dal.Save();

                NotaFiscalObsDAL odal = new NotaFiscalObsDAL();
                NotaFiscalObs o = new NotaFiscalObs();
                o.IdNotaFiscal = n.IdNotaFiscal;
                o.Observacao = "Nota Fiscal de devolução referente a nota fiscal " + nota.Numero + " emitida em " + nota.DataEmissao.ToShortDateString();
                odal.Insert(o);
                odal.Save();

                int contador = 0;
                //Lemos os itens
                foreach (NotaFiscalItemModelView item in Itens)
                {
                    if(item.Qtde > 0)
                    {
                        NotaFiscalItem r = new NotaFiscalItemDAL().GetByID(item.Id);
                        NotaFiscalItem ni = new NotaFiscalItem();
                        contador++;
                        ni.IdNotaFiscal = n.IdNotaFiscal;
                        ni.Item = contador; 
                        ni.IdProduto = r.IdProduto;
                        ni.Codigo = r.Codigo;
                        ni.Descricao = r.Descricao;
                        ni.Quantidade = r.Quantidade;
                        ni.ValorUnitario = r.ValorUnitario;
                        ni.Desconto = r.Desconto;
                        ni.AliquotaIPI = r.AliquotaIPI;
                        ni.ValorIPI = r.ValorIPI;
                        ni.ValorTotal = r.ValorTotal;
                        ni.PesoLiquido = r.PesoLiquido;
                        ni.PesoBruto = r.PesoBruto;
                        ni.IdUnidade = r.IdUnidade;
                        ni.IdNCM = r.IdNCM; 
                        iDal.Insert(ni);
                        iDal.Save();  
                    }  
                }
            }
            //Efetua o calculo da nota fiscal
            n = CalculaNota(n.IdNotaFiscal);
            dal.Update(n);
            dal.Save(); 

            return n;
        }

        public string LerXMLEntrada(string path, int IdCondicaoPagamento, out int IdNotaFiscal)
        {
            IdNotaFiscal = 0;
            int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            Empresa emp = new EmpresaDAL().getByIdEmpresa(idEmpresa);
            BLNFe bl = new BLNFe();
            List<vwDanfe> dados = bl.MontaCamposDanfe(path);

            if(dados.Count == 0)
            {
                return "Não foi possível efetuar a leitura do XML, verifique se o XML é válido!";
            }


            //Abre o form para correção da conversao
            frmCorrigeConversao frmcv = new frmCorrigeConversao(dados);
            frmcv.ShowDialog();
            dados = frmcv.dados;

            if (dados == null)
            {
                return "Leitura cancelada pelo usuário!";
            }

            var d = dados[0];

            NotaFiscal n = new NotaFiscal();
            List<NotaFiscalItem> Itens = new List<NotaFiscalItem>();
             
            #region verificação os cadastros

            //Cadastro de fornecedor
            FornecedorDAL fdal = new FornecedorDAL();
            var fornecedor = fdal.getByParams("", d.emi_CNPJ);
            Fornecedor f = new Fornecedor();
            if (fornecedor.Count == 0)
            {
                f = new Fornecedor();
                f.RazaoSocial = d.emi_xNome;
                f.NomeFantasia = d.emi_xFant;
                f.CNPJ = d.emi_CNPJ.Replace(".", "").Replace("-", "").Replace("/", "");
                f.InscricaoEstadual = d.emi_IE;
                f.Endereco = d.emi_xLgr;
                f.Numero = d.emi_nro;
                f.Bairro = d.emi_xBairro;
                f.Complemento = d.emi_xCpl;
                f.Cidade = d.emi_xMun;
                f.Pais = d.emi_xPais;
                f.Fone = d.emi_Fone;
                f.CEP = d.emi_CEP;
                f.IdEmpresa = idEmpresa;
                fdal.FRepository.Insert(f);
                fdal.Save();
            }
            else
            {
                f = fornecedor[0]; 
            }


            //Produtos
            ProdutoDAL pdal = new ProdutoDAL();
            UnidadeDAL udal = new UnidadeDAL();
            ClassificacaoFiscalDAL cfdal = new ClassificacaoFiscalDAL();
            CESTDAL CESTDAL = new CESTDAL();
            bool CadastrouProduto = false;
            foreach (var i in dados)
            {
                var pr = pdal.GetByCodigoIdFornecedor(i.Prod_cProd, f.IdFornecedor);
                if(pr == null)
                {
                    Produto p = new Produto();
                    p.Codigo = i.Prod_cProd;
                    p.Descricao = i.Prod_xProd;
                    p.NomeProduto = i.Prod_xProd;

                    //verifica a unidade 
                    Unidade un = udal.GetByUnidade(i.Prod_uCOM.ToUpper());
                    if(un == null)
                    {
                        un = new Unidade();
                        un.UnidadeMedida = i.Prod_uCOM.ToUpper();
                        un.Descricao = i.Prod_uCOM.ToUpper();
                        udal.Insert(un);
                        udal.Save();
                    }
                    p.ComprasIdUnidade = un.IdUnidade;
                    p.VendaIdUnidade = un.IdUnidade;
                    p.EstoqueIdUnidade = un.IdUnidade;
                    p.ComprasIdFornecedor = f.IdFornecedor;
                     
                    p.VendaPrecoUnit = Convert.ToDecimal(i.Prod_vUnCom / i.Conversao);
                    p.VendaPreco = Convert.ToDecimal(i.Prod_vUnCom / i.Conversao);
                    
                    p.VendaMagemLucro = 80;
                    p.EAN = i.Prod_cEAN == null ? "" : i.Prod_cEAN;
                    //verifica NCM
                    ClassificacaoFiscal cf = cfdal.getByNCM(i.Prod_NCM);
                    if(cf == null)
                    {
                        cf = new ClassificacaoFiscal();
                        cf.NCM = i.Prod_NCM;
                        cfdal.Insert(cf);
                        cfdal.Save();
                    } 
                    p.FiscalIdNCM = cf.IdNCM;

                    //procura o cest
                    if(!String.IsNullOrEmpty(i.Prod_CEST))
                    {
                        var cest = CESTDAL.getByCod(i.Prod_CEST);
                        if (cest == null)
                        {
                            CEST cts = new CEST();
                            cts.Cest = i.Prod_CEST;
                            cts.NCM = i.Prod_NCM;
                            CESTDAL.Insert(cts);
                            CESTDAL.Save();
                            p.IdCest = cts.IdCest;
                        }
                        else
                        {
                            p.IdCest = cest.IdCest;
                        }
                    } 
                    p.FiscalOrigem = Convert.ToInt32(i.icms_orig);
                    p.IdEmpresa = idEmpresa;
                    p.EstoquePeso = 0.200M;
                    p.EstqouePesoBruto = 0.220M;
                    pdal.ProdutoRepository.Insert(p);
                    pdal.Save();
                    CadastrouProduto = true;

                    i.IdProduto = p.IdProduto;
                    i.IdNCM = p.FiscalIdNCM;
                    i.IdUnidade = p.ComprasIdUnidade;
                }
                else
                {
                    if(pr.DescricaoCorrigida != "S")
                    {
                        var t = new vwTabelaOrcamentoDAL().getByCodigo(i.Prod_cProd);
                        if(t != null)
                        {
                            pr.NomeProduto = t.Nome;
                            pr.Descricao = t.Descricao;
                            pr.DescricaoCorrigida = "S";
                        } 
                    }
                    if(pr.ComprasIdFornecedor == null)
                    pr.ComprasIdFornecedor = f.IdFornecedor;
                    if(Convert.ToDecimal(i.Prod_vUnCom)  > (pr.VendaPrecoUnit / i.Conversao) )
                    {
                        pr.VendaPrecoUnit = Convert.ToDecimal(i.Prod_vUnCom / i.Conversao);
                        pr.VendaPreco = Convert.ToDecimal(i.Prod_vUnCom / i.Conversao);
                    }
                    
                    pr.EAN = i.Prod_cEAN == null ? "" : i.Prod_cEAN;

                    if (pr.FiscalOrigem == null)
                    {
                        pr.FiscalOrigem = Convert.ToInt32(i.icms_orig);
                    }

                    //verifica NCM
                    ClassificacaoFiscal cf = cfdal.getByNCM(i.Prod_NCM);
                    if (cf == null)
                    {
                        cf = new ClassificacaoFiscal();
                        cf.NCM = i.Prod_NCM;
                        cfdal.Insert(cf);
                        cfdal.Save();
                    }
                    if(pr.FiscalIdNCM == null)
                    {
                        pr.FiscalIdNCM = cf.IdNCM;
                    }
                    

                    //procura o cest
                    if(pr.IdCest == null)
                    {
                        if (!String.IsNullOrEmpty(i.Prod_CEST))
                        {
                            var cest = CESTDAL.getByCod(i.Prod_CEST);
                            if (cest == null)
                            {
                                CEST cts = new CEST();
                                cts.Cest = i.Prod_CEST;
                                cts.NCM = i.Prod_NCM;
                                CESTDAL.Insert(cts);
                                CESTDAL.Save();
                                pr.IdCest = cts.IdCest;
                            }
                            else
                            {
                                pr.IdCest = cest.IdCest;
                            }
                        }
                    }
                    
                    pdal.ProdutoRepository.Update(pr);
                    pdal.Save();
                    
                }
            }


            #endregion

            //Verifica se a nota não existe
            if(dal.NfeEntradaCadastrada(d.ide_nNF.ToString(), f.IdFornecedor))
            {
                return "Nota Fiscal cadastrada";
            }


            n.Numero = d.ide_nNF.ToString();
            n.IdDocumento = 3;
            n.IdEmitente = f.IdFornecedor;
            n.ClienteFornecedor = "F";
            n.IdDestinatario = emp.IdEmpresa;
            n.RazaoSocial = emp.RazaoSocial;
            n.NomeFantasia = emp.Fantasia;
            n.Endereco = emp.Endereco;
            n.Complemento = emp.Complemento;
            n.Bairro = emp.Bairro;
            n.CEP = emp.CEP;
            n.CNPJ = emp.CNPJ;
            n.IE = emp.IE;
            n.DirecaoCFOP = 1;
            n.ValorDesconto = d.tot_vDesc;
            n.ValorFrete = d.tot_vFrete;
            n.ValorSeguro = d.tot_vSeg;
            n.ValorIPI = d.tot_vIPI;
            n.ValorICMS = d.tot_vICMS;
            n.ValorICMSSubs = d.tot_vST;
            n.ValorMercadoria = d.tot_vProd;
            n.TotalNF = d.tot_vNF;
            n.DataSaida = DateTime.Now;
            n.DataEntrega = DateTime.Now;
            n.DataEmissao = d.ide_dEmi == null? DateTime.Now : Convert.ToDateTime(d.ide_dEmi);
            n.Serie = d.ide_serie.ToString();
            n.ChaveNFe = d.ChaveAut;
            n.IdEmpresa = idEmpresa;
            n.NotaStatus = 2;
            dal.Insert(n);
            dal.Save();

            CFOPDAL cfopdal = new CFOPDAL();
            //Cadastra os produtos
            int Contador = 0;
            foreach(var i in dados)
            {
                var pr = pdal.GetByCodigoIdFornecedor(i.Prod_cProd, f.IdFornecedor);
                NotaFiscalItem ni = new NotaFiscalItem();
                ni.IdNotaFiscal = n.IdNotaFiscal;
                Contador++;
                ni.Item = Contador;
                ni.IdProduto = pr.IdProduto;
                ni.Codigo = i.Prod_cProd;
                ni.Descricao = pr.NomeProduto;
                ni.Quantidade = i.Prod_qCom;
                ni.ValorUnitario = i.Prod_vUnCom;
                ni.AliquotaIPI = i.ipi_pIPI;
                ni.ValorIPI = i.ipi_vIPI == null ? Convert.ToDecimal(0.00) : i.ipi_vIPI;
                ni.BaseICMS = i.icms_vBC;
                ni.Desconto = i.prod_Vdesc == null ? Convert.ToDecimal(0) : i.prod_Vdesc;
                ni.AliquotaICMS = i.icms_pICMS;
                ni.ValorICMS = i.icms_vICMS == null ? Convert.ToDecimal(0.00) : i.icms_vICMS;
                ni.ValorTotal = (ni.Quantidade * ni.ValorUnitario) + ni.ValorIPI + ni.ValorICMS - ni.Desconto;
                ni.IdUnidade = i.IdUnidade;
                ni.IdNCM = i.IdNCM;
                ni.SituacaoTribICMS = i.icms_CST;
                ni.Conversao = i.Conversao;

                //Localiza o CFOP
                var cfop = cfopdal.getByCFOPCodigo(i.Prod_CFOP);
                ni.IdCFOP = cfop.IdCFOP;
                iDal.Insert(ni);
                iDal.Save();
            }
            IdNotaFiscal = n.IdNotaFiscal;

            //Gera os vencimentos
            var vencimentos = new CondicaoPagamentoDAL().CalculaVencimentos(IdCondicaoPagamento, Convert.ToDecimal(n.TotalNF), Convert.ToDateTime(n.DataEmissao));
            foreach (VencimentosModelView v in vencimentos)
            {
                NotaFiscalVencimentos nv = new NotaFiscalVencimentos();
                nv.IdNotaFiscal = n.IdNotaFiscal;
                nv.Data = v.Data;
                nv.Valor = v.Valor;
                vDal.Insert(nv);
                vDal.Save();
            }

            if(CadastrouProduto)
            {

            }



            return "ok";
        }

    }
}
