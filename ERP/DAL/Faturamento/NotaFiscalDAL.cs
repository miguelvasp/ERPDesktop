using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using ERP.ModelView;

namespace ERP.DAL
{
    public class NotaFiscalDAL : Repository<NotaFiscal>
    {
        public List<NotaFiscalPesquisaModelView> getByParams(DateTime De, DateTime Ate, int pTipo, int Destinatário)
        {
            if(pTipo == 3)
            {
                List<NotaFiscalPesquisaModelView> lista = (from n in db.NotaFiscal
                                                           join f in db.Fornecedor on n.IdEmitente equals f.IdFornecedor
                                                           where n.DataEmissao >= De
                                                           && n.DataEmissao <= Ate
                                                           && (pTipo == 0 || n.IdDocumento == pTipo)
                                                           && (Destinatário == 0 || n.IdDestinatario == Destinatário)
                                                           select new NotaFiscalPesquisaModelView
                                                           {
                                                               Id = n.IdNotaFiscal,
                                                               Numero = n.Numero,
                                                               Emissao = n.DataEmissao,
                                                               Destinatario = f.RazaoSocial,
                                                               NomeFantasia = f.NomeFantasia,
                                                               Peso = n.PesoLiquido,
                                                               Total = n.TotalNF,
                                                               NFeResultado = n.NFeResultado,
                                                               DataEntrega = n.DataEntrega,
                                                               Situacao = n.NotaStatus == null ? "" :
                                                                          n.NotaStatus == 1 ? "A emitir" :
                                                                          n.NotaStatus == 2 ? "Emitida" :
                                                                          n.NotaStatus == 3 ? "Cancelada" : ""
                                                           }).OrderByDescending(x => x.Emissao).ThenBy(x => x.Numero).ToList();
                return lista;
            }
            else
            {
                List<NotaFiscalPesquisaModelView> lista = (from n in db.NotaFiscal
                                                           where n.DataEmissao >= De
                                                           && n.DataEmissao <= Ate
                                                           && (pTipo == 0 || n.IdDocumento == pTipo)
                                                           && (Destinatário == 0 || n.IdDestinatario == Destinatário)
                                                           select new NotaFiscalPesquisaModelView
                                                           {
                                                               Id = n.IdNotaFiscal,
                                                               Numero = n.Numero,
                                                               Emissao = n.DataEmissao,
                                                               Destinatario = n.RazaoSocial,
                                                               NomeFantasia = n.NomeFantasia,
                                                               Peso = n.PesoLiquido,
                                                               Total = n.TotalNF,
                                                               NFeResultado = n.NFeResultado,
                                                               DataEntrega = n.DataEntrega,
                                                               Situacao = n.NotaStatus == null ? "" :
                                                                          n.NotaStatus == 1 ? "A emitir" :
                                                                          n.NotaStatus == 2 ? "Emitida" :
                                                                          n.NotaStatus == 3 ? "Cancelada" : ""
                                                           }).OrderByDescending(x => x.Emissao).ThenBy(x => x.Numero).ToList();
                return lista;
            }
            
            
        }

        public bool NfeEntradaCadastrada(string numero, int IdFornecedor)
        {
            var n = (from nf in db.NotaFiscal
                     where nf.IdEmitente == IdFornecedor
                     && nf.Numero == numero
                     select nf).FirstOrDefault();
            if(n == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string getPedidosByNotaId(int IdNotaFiscal)
        {
            var lista = (from n in db.NotaFiscalItem
                         join p in db.PedidoVenda on n.IdPedidoVenda equals p.IdPedidoVenda
                         where n.IdNotaFiscal == IdNotaFiscal
                         select p.PedidoNumero).Distinct().ToList();
            string pedidos = "";
            foreach(var i in lista)
            {
                pedidos += i.ToString() + " ";
            }
            return pedidos;
        }

        public List<GeraComissaoModelView> getComissoesResumidas(int IdNotaFiscal)
        {
            return (from n in db.NotaFiscalItem
                    where n.IdNotaFiscal == IdNotaFiscal
                    group n by new { n.IdVendedor, n.IdVendedorTelevendas, n.PercentualVendedor, n.PercentualTelevendas } into g
                    select new GeraComissaoModelView
                    {
                        IdVendedor = g.Key.IdVendedor,
                        IdTelevendas = g.Key.IdVendedorTelevendas,
                        PercentualVendedor = g.Key.PercentualVendedor,
                        PercentualTelevendas = g.Key.PercentualTelevendas,
                        ComissaoTelevendas = g.Sum(x => x.ComissaoTelevendas),
                        ComissaoTelevendasExtra = g.Sum(x => x.ComissaoTelevendasExtra),
                        ComissaoVendedor = g.Sum(x => x.ComissaoVendedor),
                        ComissaoVendedorExtra = g.Sum(x => x.ComissaoVendedorExtra),
                        ComissaoNegativa = g.Sum(x => x.ComissaoNegativa),
                    }).ToList();
        } 

        public List<NotaFiscalObs> GetObsByNF(int pIdNotaFiscal)
        {
            return (from o in db.NotaFiscalObs
                    where o.IdNotaFiscal == pIdNotaFiscal
                    select o).ToList();
        }

        public string getNFNumeroByContaReceber(int idContaReceber)
        {
            return (from n in db.NotaFiscal
                    where n.IdContasReceber == idContaReceber
                    select n.Numero).FirstOrDefault();
        }

        public Operacao getNFOperacaoVenda(int IdNotaFiscal)
        {
            return (from n in db.NotaFiscalItem
                    join p in db.PedidoVenda on n.IdPedidoVenda equals p.IdPedidoVenda
                    join o in db.Operacao on p.IdOperacao equals o.IdOperacao
                    select o).FirstOrDefault();
        }

        public NotaFiscal getByNumero(string numero)
        {
            return (from n in db.NotaFiscal
                    where n.Numero == numero
                    select n).FirstOrDefault();
        }

        public NotaFiscalItem getNFItemById(int IdProduto)
        {
            return (from n in db.NotaFiscal
                    join i in db.NotaFiscalItem on n.IdNotaFiscal equals i.IdNotaFiscal
                    where n.IdDocumento == 3
                    && i.IdProduto == IdProduto
                    select i).OrderByDescending(x => x.IdNotaFiscal).FirstOrDefault();
                  
        }

         

    }
}
