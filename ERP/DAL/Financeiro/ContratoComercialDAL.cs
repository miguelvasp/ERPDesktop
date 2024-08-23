using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class ContratoComercialDAL : Repository<ContratoComercial>
    {
        public bool ExisteContratoDescontoVarejista(string IdEmpresa)
        {
            int empresa = IdEmpresa == "" ? 0 : Convert.ToInt32(IdEmpresa);

            ContratoComercial cc = (from c in db.ContratoComercial
                                    where (empresa == 0 || c.IdEmpresa == empresa)
                                        & (c.Relacao == 9)
                                        & (c.Ativo == true)
                                    select c).FirstOrDefault();
            if (cc != null)
                return true;
            else
                return false;
        }

        public bool ExisteContratoDescontoTotalVendas(string IdEmpresa)
        {
            int empresa = IdEmpresa == "" ? 0 : Convert.ToInt32(IdEmpresa);

            ContratoComercial cc = (from c in db.ContratoComercial
                                    where (empresa == 0 || c.IdEmpresa == empresa)
                                        & (c.Relacao == 8)
                                        & (c.Ativo == true)
                                    select c).FirstOrDefault();
            if (cc != null)
                return true;
            else
                return false;
        }

        public List<ComboItem> GetCombo(string RelacaoContratoComercial, string IdEmpresa)
        {
            int empresa = IdEmpresa == "" ? 0 : Convert.ToInt32(IdEmpresa);

            if (RelacaoContratoComercial.ToLower() == "compras")
            {
                List<ComboItem> lista = (from c in db.ContratoComercial
                                         join cc in db.CodigoContratoComercial on c.IdCodigoContratoComercial equals cc.IdCodigoContratoComercial
                                         where (empresa == 0 || c.IdEmpresa == empresa)
                                             & (c.RelacaoItem == 1 || c.RelacaoItem == 2 || c.RelacaoItem == 3 || c.RelacaoItem == 4)

                                         select new ComboItem
                                         {
                                             iValue = c.IdContratoComercial,
                                             Text = cc.Codigo + " - " + cc.Descricao
                                         }).OrderBy(x => x.Text).ToList();
                return lista;
            }
            else
            {
                List<ComboItem> lista = (from c in db.ContratoComercial
                                         join cc in db.CodigoContratoComercial on c.IdCodigoContratoComercial equals cc.IdCodigoContratoComercial
                                         where (empresa == 0 || c.IdEmpresa == empresa)
                                             & (c.RelacaoItem == 5 || c.RelacaoItem == 6 || c.RelacaoItem == 7 || c.RelacaoItem == 8)

                                         select new ComboItem
                                         {
                                             iValue = c.IdContratoComercial,
                                             Text = cc.Codigo + " - " + cc.Descricao
                                         }).OrderBy(x => x.Text).ToList();
                return lista;
            }
        }

        public List<ContratoComercialConfPgtoModelView> GetItens(int pIdContratoComercial)
        {
            db.Configuration.LazyLoadingEnabled = false;
            List<ContratoComercialConfPgtoModelView> lista = (from cc in db.ContratoComercialCondPgto
                                                              join cp in db.CondicaoPagamento on cc.IdCondicaoPagamento equals cp.IdCondicaoPagamento
                                                              where cc.IdContratoComercial == pIdContratoComercial
                                                              select new ContratoComercialConfPgtoModelView
                                                    {
                                                        IdContratoComercial = cc.IdContratoComercial,
                                                        IdContratoComercialCondPgto = cc.IdContratoComercialCondPgto,
                                                        CondicaoPagamento = cp.Descricao,
                                                        Juros = cc.Juros
                                                    }).ToList();
            return lista;
        }

        public List<ContratoComercialModelView> GetContratos(string DataIni, string DataFim, string prtCodigo, string prtDescricao, string IdEmpresa)
        {
            int empresa = IdEmpresa == "" ? 0 : Convert.ToInt32(IdEmpresa);

            db.Configuration.LazyLoadingEnabled = false;

            if (Util.Validacao.IsDateTime(DataIni) == null && Util.Validacao.IsDateTime(DataFim) == null)
            {
                List<ContratoComercialModelView> lista = (from c in db.ContratoComercial
                                                          join cc in db.CodigoContratoComercial on c.IdCodigoContratoComercial equals cc.IdCodigoContratoComercial
                                                          where (prtCodigo == "" || cc.Codigo.Contains(prtCodigo)) &
                                                                (prtDescricao == "" || cc.Descricao.Contains(prtDescricao)) &
                                                                (empresa == 0 || c.IdEmpresa == empresa)

                                                          from f in db.Fornecedor.Where(x => x.IdFornecedor == c.IdFornecedor).DefaultIfEmpty()

                                                          from cl in db.Cliente.Where(x => x.IdCliente == c.IdCliente).DefaultIfEmpty()

                                                          from pr in db.Produto.Where(x => x.IdProduto == c.IdProduto).DefaultIfEmpty()

                                                          select new ContratoComercialModelView
                                                          {
                                                              IdContratoComercial = c.IdContratoComercial,
                                                              ContratoNumero = c.ContratoNumero,
                                                              CodigoContrato = cc.Codigo,
                                                              Descricao = cc.Descricao,
                                                              Ativo = c.Ativo == true ? "Sim" : "Não",
                                                              Relacao = c.Relacao == 1 ? "Preço de Compra" :
                                                                        c.Relacao == 2 ? "Desconto de linha (Compras)" :
                                                                        c.Relacao == 3 ? "Desconto Combinado (Compras)" :
                                                                        c.Relacao == 4 ? "DescontoTotal (Compras)" :
                                                                        c.Relacao == 5 ? "Preço de Venda" :
                                                                        c.Relacao == 6 ? "Desconto de linha (Vendas)" :
                                                                        c.Relacao == 7 ? "Desconto Combinado (Vendas)" :
                                                                        c.Relacao == 8 ? "DescontoTotal (Vendas)" : "-",
                                                              Codigo = c.CodigoTipo == 1 ? "Tabela" :
                                                                        c.CodigoTipo == 2 ? "Grupo" :
                                                                        c.CodigoTipo == 3 ? "Todos" : "-",
                                                              RelacaoItem = c.RelacaoItem == 1 ? "Tabela" :
                                                                        c.RelacaoItem == 2 ? "Grupo" :
                                                                        c.RelacaoItem == 3 ? "Todos" : "-",
                                                              Cliente = cl.RazaoSocial,
                                                              Fornecedor = f.RazaoSocial == null ? "" : f.RazaoSocial,
                                                              Produto = pr.NomeProduto,
                                                              Valor = c.Valor.Value,
                                                              ValorPercentual = c.ValorPercentual.Value
                                                          }).Distinct().OrderByDescending(x => x.ContratoNumero).ToList();

                return lista;
            }
            else if (Util.Validacao.IsDateTime(DataIni) != null && Util.Validacao.IsDateTime(DataFim) == null)
            {
                DateTime DI = Convert.ToDateTime(DataIni + " 00:00:00");

                List<ContratoComercialModelView> lista = (from c in db.ContratoComercial
                                                          join cc in db.CodigoContratoComercial on c.IdCodigoContratoComercial equals cc.IdCodigoContratoComercial
                                                          where (c.DeData >= DI || c.AteData.Value == null) &
                                                                (prtCodigo == "" || cc.Codigo.Contains(prtCodigo)) &
                                                                (prtDescricao == "" || cc.Descricao.Contains(prtDescricao)) &
                                                                (empresa == 0 || c.IdEmpresa == empresa)

                                                          from f in db.Fornecedor.Where(x => x.IdFornecedor == c.IdFornecedor).DefaultIfEmpty()

                                                          from cl in db.Cliente.Where(x => x.IdCliente == c.IdCliente).DefaultIfEmpty()

                                                          from pr in db.Produto.Where(x => x.IdProduto == c.IdProduto).DefaultIfEmpty()

                                                          select new ContratoComercialModelView
                                                          {
                                                              IdContratoComercial = c.IdContratoComercial,
                                                              ContratoNumero = c.ContratoNumero,
                                                              CodigoContrato = cc.Codigo,
                                                              Descricao = cc.Descricao,
                                                              Ativo = c.Ativo == true ? "Sim" : "Não",
                                                              Relacao = c.Relacao == 1 ? "Preço de Compra" :
                                                                        c.Relacao == 2 ? "Desconto de linha (Compras)" :
                                                                        c.Relacao == 3 ? "Desconto Combinado (Compras)" :
                                                                        c.Relacao == 4 ? "DescontoTotal (Compras)" :
                                                                        c.Relacao == 5 ? "Preço de Venda" :
                                                                        c.Relacao == 6 ? "Desconto de linha (Vendas)" :
                                                                        c.Relacao == 7 ? "Desconto Combinado (Vendas)" :
                                                                        c.Relacao == 8 ? "DescontoTotal (Vendas)" : "-",
                                                              Codigo = c.CodigoTipo == 1 ? "Tabela" :
                                                                        c.CodigoTipo == 2 ? "Grupo" :
                                                                        c.CodigoTipo == 3 ? "Todos" : "-",
                                                              RelacaoItem = c.RelacaoItem == 1 ? "Tabela" :
                                                                        c.RelacaoItem == 2 ? "Grupo" :
                                                                        c.RelacaoItem == 3 ? "Todos" : "-",
                                                              Cliente = cl.RazaoSocial,
                                                              Fornecedor = f.RazaoSocial,
                                                              Produto = pr.NomeProduto,
                                                              Valor = c.Valor.Value,
                                                              ValorPercentual = c.ValorPercentual.Value
                                                          }).Distinct().OrderByDescending(x => x.ContratoNumero).ToList();

                return lista;
            }
            else if (Util.Validacao.IsDateTime(DataIni) == null && Util.Validacao.IsDateTime(DataFim) != null)
            {
                DateTime DF = Convert.ToDateTime(DataFim + " 23:59:00");

                List<ContratoComercialModelView> lista = (from c in db.ContratoComercial
                                                          join cc in db.CodigoContratoComercial on c.IdCodigoContratoComercial equals cc.IdCodigoContratoComercial
                                                          where (c.DeData.Value == null || c.AteData <= DF) &
                                                                (prtCodigo == "" || cc.Codigo.Contains(prtCodigo)) &
                                                                (prtDescricao == "" || cc.Descricao.Contains(prtDescricao)) &
                                                                (empresa == 0 || c.IdEmpresa == empresa)

                                                          from f in db.Fornecedor.Where(x => x.IdFornecedor == c.IdFornecedor).DefaultIfEmpty()

                                                          from cl in db.Cliente.Where(x => x.IdCliente == c.IdCliente).DefaultIfEmpty()

                                                          from pr in db.Produto.Where(x => x.IdProduto == c.IdProduto).DefaultIfEmpty()

                                                          select new ContratoComercialModelView
                                                          {
                                                              IdContratoComercial = c.IdContratoComercial,
                                                              ContratoNumero = c.ContratoNumero,
                                                              CodigoContrato = cc.Codigo,
                                                              Descricao = cc.Descricao,
                                                              Ativo = c.Ativo == true ? "Sim" : "Não",
                                                              Relacao = c.Relacao == 1 ? "Preço de Compra" :
                                                                        c.Relacao == 2 ? "Desconto de linha (Compras)" :
                                                                        c.Relacao == 3 ? "Desconto Combinado (Compras)" :
                                                                        c.Relacao == 4 ? "DescontoTotal (Compras)" :
                                                                        c.Relacao == 5 ? "Preço de Venda" :
                                                                        c.Relacao == 6 ? "Desconto de linha (Vendas)" :
                                                                        c.Relacao == 7 ? "Desconto Combinado (Vendas)" :
                                                                        c.Relacao == 8 ? "DescontoTotal (Vendas)" : "-",
                                                              Codigo = c.CodigoTipo == 1 ? "Tabela" :
                                                                        c.CodigoTipo == 2 ? "Grupo" :
                                                                        c.CodigoTipo == 3 ? "Todos" : "-",
                                                              RelacaoItem = c.RelacaoItem == 1 ? "Tabela" :
                                                                        c.RelacaoItem == 2 ? "Grupo" :
                                                                        c.RelacaoItem == 3 ? "Todos" : "-",
                                                              Cliente = cl.RazaoSocial,
                                                              Fornecedor = f.RazaoSocial,
                                                              Produto = pr.NomeProduto,
                                                              Valor = c.Valor.Value,
                                                              ValorPercentual = c.ValorPercentual.Value
                                                          }).Distinct().OrderByDescending(x => x.ContratoNumero).ToList();

                return lista;
            }
            else
            {
                DateTime DI = Convert.ToDateTime(DataIni + " 00:00:00");
                DateTime DF = Convert.ToDateTime(DataFim + " 23:59:00");

                List<ContratoComercialModelView> lista = (from c in db.ContratoComercial
                                                          join cc in db.CodigoContratoComercial on c.IdCodigoContratoComercial equals cc.IdCodigoContratoComercial
                                                          where (c.DeData >= DI & c.AteData <= DF) &
                                                                (prtCodigo == "" || cc.Codigo.Contains(prtCodigo)) &
                                                                (prtDescricao == "" || cc.Descricao.Contains(prtDescricao)) &
                                                                (empresa == 0 || c.IdEmpresa == empresa)
                                                          from f in db.Fornecedor.Where(x => x.IdFornecedor == c.IdFornecedor).DefaultIfEmpty()

                                                          from cl in db.Cliente.Where(x => x.IdCliente == c.IdCliente).DefaultIfEmpty()

                                                          from pr in db.Produto.Where(x => x.IdProduto == c.IdProduto).DefaultIfEmpty()
                                                          select new ContratoComercialModelView
                                                          {
                                                              IdContratoComercial = c.IdContratoComercial,
                                                              ContratoNumero = c.ContratoNumero,
                                                              CodigoContrato = cc.Codigo,
                                                              Descricao = cc.Descricao,
                                                              Ativo = c.Ativo == true ? "Sim" : "Não",
                                                              Relacao = c.Relacao == 1 ? "Preço de Compra" :
                                                                        c.Relacao == 2 ? "Desconto de linha (Compras)" :
                                                                        c.Relacao == 3 ? "Desconto Combinado (Compras)" :
                                                                        c.Relacao == 4 ? "DescontoTotal (Compras)" :
                                                                        c.Relacao == 5 ? "Preço de Venda" :
                                                                        c.Relacao == 6 ? "Desconto de linha (Vendas)" :
                                                                        c.Relacao == 7 ? "Desconto Combinado (Vendas)" :
                                                                        c.Relacao == 8 ? "DescontoTotal (Vendas)" : "-",
                                                              Codigo = c.CodigoTipo == 1 ? "Tabela" :
                                                                        c.CodigoTipo == 2 ? "Grupo" :
                                                                        c.CodigoTipo == 3 ? "Todos" : "-",
                                                              RelacaoItem = c.RelacaoItem == 1 ? "Tabela" :
                                                                        c.RelacaoItem == 2 ? "Grupo" :
                                                                        c.RelacaoItem == 3 ? "Todos" : "-",
                                                              Cliente = cl.RazaoSocial,
                                                              Fornecedor = f.RazaoSocial,
                                                              Produto = pr.NomeProduto,
                                                              Valor = c.Valor.Value,
                                                              ValorPercentual = c.ValorPercentual.Value
                                                          }).Distinct().OrderByDescending(x => x.ContratoNumero).ToList();

                return lista;
            }
        }

        public string CalcularAjustePreco(string pIdEmpresa, int pCodigoContrato = 0,
                                                           string pAtivo = "", int pIdCliente = 0, int pRelacao = 0, int pIdFornecedor = 0,
                                                           int pIdProduto = 0, int pAjuste = 0, decimal pValor = 0)
        {
            string retorno = "";

            int empresa = pIdEmpresa == "" ? 0 : Convert.ToInt32(pIdEmpresa);

            db.Configuration.LazyLoadingEnabled = false;

            List<ContratoComercial> cc = new List<ContratoComercial>();
            if (pAtivo == "Sim")
            {
                cc = (from c in db.ContratoComercial
                      //join ccc in db.CodigoContratoComercial on c.IdCodigoContratoComercial equals ccc.IdCodigoContratoComercial
                      where (empresa == 0 || c.IdEmpresa == empresa)
                          & (pCodigoContrato == 0 || c.IdCodigoContratoComercial == pCodigoContrato)
                          & (c.Ativo == true)
                          & (pIdCliente == 0 || c.IdCliente == pIdCliente)
                          & (pIdFornecedor == 0 || c.IdFornecedor == pIdFornecedor)
                          & (pRelacao == 0 || c.Relacao == pRelacao)
                          & (pIdProduto == 0 || c.IdProduto == pIdProduto)
                      select c).ToList();
            }
            else if (pAtivo == "Não")
            {
                cc = (from c in db.ContratoComercial
                      join ccc in db.CodigoContratoComercial on c.IdCodigoContratoComercial equals ccc.IdCodigoContratoComercial
                      where (empresa == 0 || c.IdEmpresa == empresa)
                          & (pCodigoContrato == 0 || c.IdCodigoContratoComercial == pCodigoContrato)
                          & (c.Ativo == false)
                          & (pIdCliente == 0 || c.IdCliente == pIdCliente)
                          & (pIdFornecedor == 0 || c.IdFornecedor == pIdFornecedor)
                          & (pRelacao == 0 || c.Relacao == pRelacao)
                          & (pIdProduto == 0 || c.IdProduto == pIdProduto)
                      select c).ToList();
            }
            else
            {
                cc = (from c in db.ContratoComercial
                      join ccc in db.CodigoContratoComercial on c.IdCodigoContratoComercial equals ccc.IdCodigoContratoComercial
                      where (empresa == 0 || c.IdEmpresa == empresa)
                          & (pCodigoContrato == 0 || c.IdCodigoContratoComercial == pCodigoContrato)
                          & (pIdCliente == 0 || c.IdCliente == pIdCliente)
                          & (pIdFornecedor == 0 || c.IdFornecedor == pIdFornecedor)
                          & (pRelacao == 0 || c.Relacao == pRelacao)
                          & (pIdProduto == 0 || c.IdProduto == pIdProduto)
                      select c).ToList();
            }
            if (cc != null && cc.Count > 0)
            {
                foreach (ContratoComercial item in cc)
                {
                    decimal porc = 1 + ((pValor) / 100);

                    switch (pAjuste)
                    {
                        case 1:
                            if (item.IdEstilo.Value != 0 || item.IdCor.Value != 0 || item.IdTamanho.Value != 0)
                            {
                                retorno = "Existe regras de configurações de produtos, só podem ser alteradas por percentual!";
                            }
                            else
                            {
                                if (item.De.Value != 0 && item.Ate.Value != 0)
                                {
                                    retorno = "Existe regras de configurações De e Até, só podem ser alteradas por percentual!";
                                }
                                else
                                {
                                    item.Valor = pValor;
                                    this.Update(item);
                                }
                            }
                            break;

                        case 2:
                            item.Valor = Math.Round(item.Valor.Value * porc, 2);
                            break;

                        case 3:
                            item.ValorPercentual = pValor;
                            this.Update(item);
                            break;

                        case 4:
                            item.ValorPercentual = Math.Round(item.ValorPercentual.Value * porc, 2);
                            break;
                    }
                }

                this.Save();
            }

            return retorno;
        }

        public ContratoComercialFluxoPrecoModelView ContratoComercialFluxoPrecoCompras(string IdEmpresa, string IdProduto, string IdFornecedor)
        {
            int empresa = IdEmpresa == "" ? 0 : Convert.ToInt32(IdEmpresa);
            int fornecedor = IdFornecedor == "" ? 0 : Convert.ToInt32(IdFornecedor);
            int produto = IdProduto == "" ? 0 : Convert.ToInt32(IdProduto);

            ContratoComercialFluxoPrecoModelView retorno = new ContratoComercialFluxoPrecoModelView();
            retorno.ExisteContrato = false;
            retorno.Valor = 0;
            retorno.ValorTabela = 0;
            retorno.PercentualDesconto = 0;
            retorno.ValorDesconto = 0;

            List<ContratoComercial> lcc = (from c in db.ContratoComercial
                                           where (empresa == 0 || c.IdEmpresa == empresa)
                                               & (produto == 0 || c.IdProduto == produto)
                                               & (c.Ativo == true)
                                           select c).ToList();

            // Verifica se existe um fornecedor para o Contrato//
            ContratoComercial cc = lcc.Find(f => f.IdFornecedor.Equals(fornecedor));

            if (cc != null)
            {
                if (cc.IdFornecedor == fornecedor)
                {
                    if (cc.Relacao.Value == (int)Util.EnumERP.RelacaoContratoComercial.PrecoDeCompra)
                    {
                        retorno.TipoRelacao = "P";
                        retorno.ExisteContrato = true;
                        retorno.Valor = cc.Valor.Value;
                        retorno.ValorTabela = cc.Valor.Value;
                    }
                    else if (cc.Relacao.Value == (int)Util.EnumERP.RelacaoContratoComercial.DescontoDeLinhaCompras)
                    {
                        retorno.TipoRelacao = "D";
                        retorno.ExisteContrato = true;
                        retorno.PercentualDesconto = cc.ValorPercentual.Value;
                    }
                    else if (cc.Relacao.Value == (int)Util.EnumERP.RelacaoContratoComercial.DescontoTotalCompras)
                    {
                        retorno.TipoRelacao = "DT";
                        retorno.ExisteContrato = true;
                        if (cc.Valor.Value != 0)
                        {
                            retorno.ValorDesconto = cc.Valor.Value;
                        }
                        else
                        {
                            retorno.PercentualDesconto = cc.ValorPercentual.Value;
                        }
                    }
                }
                else
                {
                    Fornecedor frn = (from f in db.Fornecedor
                                      where (fornecedor == 0 || f.IdFornecedor == fornecedor)
                                          & (empresa == 0 || f.IdEmpresa == empresa)
                                      select f).FirstOrDefault();

                    //Verifica se existe Grupo Preço Fornecedor //
                    ContratoComercial ccGrupo = lcc.Find(f => f.IdGrupoPrecoDesconto.Equals(frn.IdGrupoCompras));
                    if (ccGrupo != null)
                    {
                        retorno.TipoRelacao = "P";
                        retorno.ExisteContrato = true;
                        retorno.Valor = ccGrupo.Valor.Value;
                        retorno.ValorTabela = ccGrupo.Valor.Value;
                    }
                    else
                    {
                        //Verifica se existe Grupo Desconto Fornecedor //
                        ContratoComercial ccDescontoLinha = lcc.Find(f => f.IdGrupoPrecoDesconto.Equals(frn.IdDescontoTotal));
                        if (ccGrupo != null)
                        {
                            retorno.TipoRelacao = "DT";
                            retorno.ExisteContrato = true;
                            if (ccDescontoLinha.Valor.Value != 0)
                            {
                                retorno.ValorDesconto = ccDescontoLinha.Valor.Value;
                            }
                            else
                            {
                                retorno.PercentualDesconto = ccDescontoLinha.ValorPercentual.Value;
                            }
                        }
                        else
                        {
                            //Verifica se existe Contrato com o Código = Todos //
                            ContratoComercial ccCodigoTodos = lcc.Find(f => f.CodigoTipo.Equals((int)Util.EnumERP.CalculoDeComissaoRelacaoDeItem.Todos));
                            retorno.TipoRelacao = "P";
                            retorno.ExisteContrato = true;
                            retorno.Valor = ccCodigoTodos.Valor.Value;
                        }
                    }
                }
            }

            return retorno;
        }


         



        public ContratoComercialFluxoPrecoModelView ContratoComercialFluxoPrecoVendas(string IdEmpresa, string IdProduto, string IdCliente, int IdPedidoVenda, int? IdCor, int? IdEstilo, int? IdTamanho, int? IdConfig, decimal? ValorInformado=null, bool AlterouPreco = false, decimal? DescontoVarejista = 0)
        {
            try
            {
                int empresa = IdEmpresa == "" ? 0 : Convert.ToInt32(IdEmpresa);
                int cliente = IdCliente == "" ? 0 : Convert.ToInt32(IdCliente);
                int produto = IdProduto == "" ? 0 : Convert.ToInt32(IdProduto);
                int IdContratoSelecionado = 0;

                ContratoComercialFluxoPrecoModelView retorno = new ContratoComercialFluxoPrecoModelView();
                retorno.ExisteContrato = false;
                retorno.Valor = 0;
                retorno.PercentualDesconto = 0;
                retorno.ValorDesconto = 0;

                List<ContratoComercial> lcc = new List<ContratoComercial>();
                //Procura por produto e configurações especificas  
                lcc = (from c in db.ContratoComercial
                       where (empresa == 0 || c.IdEmpresa == empresa)
                           & (produto == 0 || c.IdProduto == produto)
                           & (c.Ativo == true)
                           & (c.IdConfig == IdConfig
                           || c.IdCor == IdCor
                           || c.IdEstilo == IdEstilo
                           || c.IdTamanho == IdTamanho)

                       select c).ToList();


                //Caso nao ache o produto especifico ele traz pelo produto.
                if (lcc.Count == 0)
                {
                    lcc = (from c in db.ContratoComercial
                           where (empresa == 0 || c.IdEmpresa == empresa)
                               & (produto == 0 || c.IdProduto == produto)
                               & (c.Ativo == true)
                           select c).ToList();
                }


                // Verifica se existe um cliente para o Contrato//
                ContratoComercial cc = lcc.Find(f => f.IdCliente.Equals(cliente));
                if (cc != null)
                {
                    IdContratoSelecionado = cc.IdContratoComercial;
                    if (cc.IdCliente == cliente)
                    {
                        if (cc.Relacao.Value == (int)Util.EnumERP.RelacaoContratoComercial.PrecoDeVenda)
                        {
                            retorno.TipoRelacao = "P";
                            retorno.ExisteContrato = true;
                            retorno.Valor = cc.Valor.Value;
                        }
                        else if (cc.Relacao.Value == (int)Util.EnumERP.RelacaoContratoComercial.DescontoDeLinhaVendas)
                        {
                            retorno.TipoRelacao = "D";
                            retorno.ExisteContrato = true;
                            retorno.PercentualDesconto = cc.ValorPercentual.Value;
                        }
                        else if (cc.Relacao.Value == (int)Util.EnumERP.RelacaoContratoComercial.DescontoTotalVendas)
                        {
                            retorno.TipoRelacao = "DT";
                            retorno.ExisteContrato = true;
                            if (cc.Valor.Value != 0)
                            {
                                retorno.ValorDesconto = cc.Valor.Value;
                            }
                            else
                            {
                                retorno.PercentualDesconto = cc.ValorPercentual.Value;
                            }
                        }
                        else if (cc.Relacao.Value == (int)Util.EnumERP.RelacaoContratoComercial.DescontoVarejista)
                        {
                            retorno.TipoRelacao = "V";
                            retorno.ExisteContrato = true;
                            retorno.ValorDesconto = cc.Valor.Value;
                            retorno.PercentualDesconto = cc.ValorPercentual.Value;
                        }
                    }
                    else
                    {
                        Cliente cl = (from c in db.Cliente
                                      where (cliente == 0 || c.IdCliente == cliente)
                                              & (empresa == 0 || c.IdEmpresa == empresa)
                                      select c).FirstOrDefault();

                        if (cc.Relacao.Value == (int)Util.EnumERP.RelacaoContratoComercial.DescontoVarejista)
                        {
                            //Verifica se existe Grupo Varejista //
                            ContratoComercial ccGrupoVarejista = lcc.Find(f => f.IdGrupoPrecoDesconto.Equals(cl.IdDescontoVarejista == null ? 0 : cl.IdDescontoVarejista));
                            if (ccGrupoVarejista != null)
                            {
                                IdContratoSelecionado = ccGrupoVarejista.IdContratoComercial;
                                retorno.TipoRelacao = "V";
                                retorno.ExisteContrato = true;
                                retorno.ValorDescontoVarejista = ccGrupoVarejista.Valor.Value;
                                retorno.PercentualDescontoVarejista = cc.ValorPercentual.Value;
                            }
                        }
                        else
                        {
                            //Verifica se existe Grupo Preço Cliente //
                            ContratoComercial ccGrupo = lcc.Find(f => f.IdGrupoPrecoDesconto.Equals(cl.IdGrupoVendas == null ? 0 : cl.IdGrupoVendas));
                            if (ccGrupo != null)
                            {
                                IdContratoSelecionado = ccGrupo.IdContratoComercial;
                                retorno.TipoRelacao = "P";
                                retorno.ExisteContrato = true;
                                retorno.Valor = ccGrupo.Valor.Value;
                            }
                            else
                            {
                                //Verifica se existe Grupo Desconto Cliente //
                                ContratoComercial ccDescontoLinha = lcc.Find(f => f.IdGrupoPrecoDesconto.Equals(cl.IdDescontoTotal == null ? 0 : cl.IdDescontoTotal));
                                //if (ccGrupo != null)
                                if (ccDescontoLinha != null)
                                {
                                    IdContratoSelecionado = ccDescontoLinha.IdContratoComercial;
                                    retorno.TipoRelacao = "DT";
                                    retorno.ExisteContrato = true;
                                    if (ccDescontoLinha.Valor.Value != 0)
                                    {
                                        retorno.ValorDesconto = ccDescontoLinha.Valor.Value;
                                    }
                                    else
                                    {
                                        retorno.PercentualDesconto = ccDescontoLinha.ValorPercentual.Value;
                                    }
                                }
                                else
                                {
                                    //Verifica se existe Contrato com o Código = Todos //
                                    ContratoComercial ccCodigoTodos = lcc.Find(f => f.CodigoTipo.Equals((int)Util.EnumERP.CalculoDeComissaoRelacaoDeItem.Todos));
                                    IdContratoSelecionado = ccCodigoTodos.IdContratoComercial;
                                    retorno.TipoRelacao = "P";
                                    retorno.ExisteContrato = true;
                                    retorno.Valor = ccCodigoTodos.Valor.Value;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Cliente cl = (from c in db.Cliente
                                  where (cliente == 0 || c.IdCliente == cliente)
                                          & (empresa == 0 || c.IdEmpresa == empresa)
                                  select c).FirstOrDefault();

                    //Verifica se existe Grupo Preço Cliente //
                    ContratoComercial ccGrupo = lcc.Find(f => f.IdGrupoPrecoDesconto.Equals(cl.IdGrupoVendas == null ? 0 : cl.IdGrupoVendas));
                    if (ccGrupo != null)
                    {
                        IdContratoSelecionado = ccGrupo.IdContratoComercial;
                        retorno.TipoRelacao = "P";
                        retorno.ExisteContrato = true;
                        retorno.Valor = ccGrupo.Valor.Value;
                    }
                    else
                    {
                        //Verifica se existe Grupo Desconto Cliente //
                        ContratoComercial ccDescontoLinha = lcc.Find(f => f.IdGrupoPrecoDesconto.Equals(cl.IdDescontoTotal == null ? 0 : cl.IdDescontoTotal));
                        if (ccDescontoLinha != null)
                        {
                            IdContratoSelecionado = ccDescontoLinha.IdContratoComercial;
                            retorno.TipoRelacao = "DT";
                            retorno.ExisteContrato = true;
                            if (ccDescontoLinha.Valor.Value != 0)
                            {
                                retorno.ValorDesconto = ccDescontoLinha.Valor.Value;
                            }
                            else
                            {
                                retorno.PercentualDesconto = ccDescontoLinha.ValorPercentual.Value;
                            }
                        }
                        else
                        {
                            //Verifica se existe Contrato com o Código = Todos //
                            ContratoComercial ccCodigoTodos = lcc.Find(f => f.CodigoTipo.Equals((int)Util.EnumERP.CalculoDeComissaoRelacaoDeItem.Todos));
                            IdContratoSelecionado = ccCodigoTodos.IdContratoComercial;
                            retorno.TipoRelacao = "P";
                            retorno.ExisteContrato = true;
                            retorno.Valor = ccCodigoTodos.Valor.Value;
                        }
                    }
                }




                //Verifica se a condição de pagamento do pedido tem algum indice de acrescimo no contrato
                int? IdCondicaoPagamento = new PedidoVendaDAL().PVRepository.GetByID(IdPedidoVenda).IdCondicaoPagamento;
                if (IdCondicaoPagamento != null)
                {
                    ContratoComercialCondPgto cp = (from c in db.ContratoComercialCondPgto
                                                    where c.IdContratoComercial == IdContratoSelecionado
                                                    && c.IdCondicaoPagamento == IdCondicaoPagamento
                                                    select c).FirstOrDefault();

                    if (cp != null)
                    {
                        decimal? juros = (retorno.Valor * cp.Juros) / 100M;
                        if (juros != null)
                        {
                            retorno.Valor = retorno.Valor + (decimal)juros;
                            retorno.Juros = (decimal)juros;
                        }
                    }
                }

                if (retorno.ValorTabela == 0)
                {
                    retorno.ValorTabela = retorno.Valor + retorno.ValorDesconto;
                }

                //Pesquisar desconto Varejista
                retorno.ValorOriginal = retorno.Valor;

                if (ValorInformado != null)
                {
                    retorno.Valor = Convert.ToDecimal(ValorInformado);
                    retorno.ValorOriginal = Convert.ToDecimal(ValorInformado);
                }


                var ContratoVarejista = (from c in db.ContratoComercial
                                         where (c.IdEmpresa == empresa)
                                             & c.IdGrupoDescontoVarejista != null
                                             & c.IdCliente == cliente
                                             & (c.Ativo == true)
                                         select c).FirstOrDefault();

                if (ContratoVarejista != null)
                {
                    retorno.PercentualDescontoVarejista = ContratoVarejista.ValorPercentual.Value;
                    if (retorno.PercentualDescontoVarejista != null)
                    {
                        if(AlterouPreco)
                        {
                            retorno.Valor = (Convert.ToDecimal(retorno.Valor) * Convert.ToDecimal(retorno.PercentualDescontoVarejista)) / 100M;
                            retorno.ValorDescontoVarejista = Convert.ToDecimal(retorno.ValorOriginal) - retorno.Valor;
                        } 
                        else
                        {
                            retorno.ValorDescontoVarejista = Convert.ToDecimal(DescontoVarejista);
                        }
                    }
                }



                return retorno;
            }
            catch 
            {
                return new ContratoComercialFluxoPrecoModelView();
            }



            
        }
    }
}
