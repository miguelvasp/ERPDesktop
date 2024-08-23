using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class LancamentoDAL : Repository<Lancamento>
    {
        public List<LancamentoModelView> getByParams(string prtDescricao)
        {
            List<LancamentoModelView> lista = (from l in db.Lancamento
                                               join tl in db.TipoLancamento on l.IdTipoLancamento equals tl.IdTipoLancamento
                                               join cc in db.ContaContabil on l.IdContaContabil equals cc.IdContaContabil into _cc
                                               from cc in _cc.DefaultIfEmpty()
                                               where (prtDescricao == "" || l.Descricao.Contains(prtDescricao))
                                               select new LancamentoModelView
                                               {
                                                   IdLancamento = l.IdLancamento,
                                                   Descricao = l.Descricao,
                                                   IdTipoLancamento = l.IdTipoLancamento,
                                                   TipoLancamento = tl.Descricao,
                                                   TipoDocumento = tl.IdTipoDocumento == 1 ? "Pedido de Venda" :
                                                                  tl.IdTipoDocumento == 2 ? "Pedido de Compra" :
                                                                  tl.IdTipoDocumento == 3 ? "Estoque" :
                                                                  tl.IdTipoDocumento == 4 ? "Produção" : "-",
                                                   ContaContabil = cc.Codigo + " - " + cc.Descricao
                                               }).OrderBy(o => o.Descricao).ToList();
            return lista;
        } 

        public List<LancamentoModelView> getByTipoLancamento(int prtIdTipoLancamento)
        {
            List<LancamentoModelView> lista = (from l in db.Lancamento
                                               join tl in db.TipoLancamento on l.IdTipoLancamento equals tl.IdTipoLancamento
                                               join cc in db.ContaContabil on l.IdContaContabil equals cc.IdContaContabil into _cc
                                               from cc in _cc.DefaultIfEmpty()
                                               where (prtIdTipoLancamento == 0 || l.IdTipoLancamento == prtIdTipoLancamento)
                                               select new LancamentoModelView
                                                {
                                                    IdLancamento = l.IdLancamento,
                                                    Descricao = l.Descricao,
                                                    IdTipoLancamento = l.IdTipoLancamento,
                                                    TipoLancamento = tl.Descricao,
                                                    TipoDocumento = tl.IdTipoDocumento == 1 ? "Pedido de Venda" :
                                                                   tl.IdTipoDocumento == 2 ? "Pedido de Compra" :
                                                                   tl.IdTipoDocumento == 3 ? "Estoque" :
                                                                   tl.IdTipoDocumento == 4 ? "Produção" : "-",
                                                    ContaContabil = cc.Codigo + " - " + cc.Descricao,
                                                    IdContaContabil = l.IdContaContabil,
                                                    IdProduto = l.IdProduto,
                                                    IdGRupoProduto = l.IdGrupoProduto,
                                                    IdFornecedor = l.IdFornecedor,
                                                    IdGrupoFornecedor = l.IdGrupoFornecedor,
                                                    IdGrupoCliente = l.IdGrupoCliente,
                                                    RelacaoItem = l.RelacaoItem,
                                                    RelacaoGrupo = l.RelacaoGrupo
                                                }).OrderBy(o => o.IdTipoLancamento).ToList();
            return lista;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from l in db.Lancamento
                                     select new ComboItem
                                     {
                                         iValue = l.IdLancamento,
                                         Text = l.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public int GetContaContabilLancamentoContabilByTipoLancamento(int IdTipoLancamento, PedidoCompra pc, PedidoCompraItem pci)
        { 

            if(pc.Operacao.IdContaContabil != null)
            {
                return Convert.ToInt32(pc.Operacao.IdContaContabil);
            }
            else
            {
                var ListaLancamentos = (from l in db.Lancamento
                                        where l.IdTipoLancamento == IdTipoLancamento
                                        select l).ToList();
                if(ListaLancamentos == null)
                {
                    return 0;
                }
                else
                {
                    //Procura pelo Produto Especifico
                    var listaProdutoEspecifico = ListaLancamentos.Where(x => x.IdProduto == pci.IdProduto).FirstOrDefault();
                    if(listaProdutoEspecifico != null)
                    {
                        return (int)listaProdutoEspecifico.IdContaContabil;
                    }
                    else
                    {   //Procura pelo Grupo de Produto
                        var listaGrupoProduto = ListaLancamentos.Where(x => x.IdGrupoProduto == pci.Produto.IdGrupoProduto).FirstOrDefault();
                        if(listaGrupoProduto != null)
                        {
                            return (int)listaProdutoEspecifico.IdContaContabil;
                        }
                        else
                        {
                            //procura pelo fornecedor
                        }
                    }
                }
            }


            return 0;
        }
    }
}