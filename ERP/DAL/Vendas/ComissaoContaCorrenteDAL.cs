using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ERP.DAL
{
    public class ComissaoContaCorrenteDAL : Repository<ComissaoContaCorrente>
    { 
        public List<ComissaoVendedorContaCorrenteModelView> getByParams(int IdVendedor, DateTime De, DateTime Ate, int NotaFiscal, int TipoComissao, int Status)
        {
            string nf = NotaFiscal.ToString();
            var lista = (from c in db.ComissaoContaCorrente
                         
                         join v in db.Vendedor on c.IdVendedor equals v.IdVendedor
                         where c.IdVendedor == IdVendedor
                         && (c.DataNotaFiscal >= De && c.DataNotaFiscal <= Ate) 
                         && (TipoComissao == 0 || c.TipoComissao == TipoComissao)
                         from n in db.NotaFiscal
                         .Where(x => x.IdNotaFiscal == c.IdNotaFiscal && (NotaFiscal == 0 || x.Numero  == nf))
                         .DefaultIfEmpty()
                         
                         select new ComissaoVendedorContaCorrenteModelView
                         {
                             Vendedor = v.Nome,
                             IdComissaoContaCorrente = c.IdComissaoContaCorrente,
                             NotaFiscal = n.Numero,
                             Data = c.DataNotaFiscal,
                             Comissao = c.Comissao,
                             ValorAPagar = c.ValorAPagar,
                             ValorPago = c.ValorPago,
                             TipoComissao = c.TipoComissao == 1 ? "Comissão" :
                                            c.TipoComissao == 2 ? "Comissão Adicional" :
                                            c.TipoComissao == 3 ? "Choque" : "",
                             TipoLancamento = c.TipoLancamento == 1 ? "Lançamento automático" :
                                              c.TipoLancamento == 2 ? "Lançamento Manual" :
                                              c.TipoLancamento == 3 ? "Pagamento efetuado" : "",
                             Observacao = c.Observacao
                         }).ToList();

            if(Status == 1) 
            {
                return lista.Where(x => x.ValorAPagar != 0).ToList();
            }
            if(Status == 2)
            {
                return lista.Where(x => x.ValorAPagar == 0).ToList();
            }

            return lista;
        }

        public List<ComissaoVendedorModelView> ComissaoPorNotaFiscal(int pIdNotaFiscal)
        {
            var Lista = (from i in db.NotaFiscalItem
                         join p in db.PedidoVenda on i.IdPedidoVenda equals p.IdPedidoVenda
                         join pi in db.PedidoVendaItem on i.IdPedidoVendaItem equals pi.IdPedidoVendaItem
                         where i.IdNotaFiscal == pIdNotaFiscal
                         group pi by new
                         {
                             i.IdNotaFiscal,
                             p.IdVendedor,
                             p.IdTeleVendas,
                             p.IdCondicaoPagamento
                         }
                         into g
                         select new ComissaoVendedorModelView
                         { 
                             IdVendedor = g.Key.IdVendedor,
                             IdTeleVendas = g.Key.IdTeleVendas,
                             IdCondicaoPagamento = g.Key.IdCondicaoPagamento,
                             ValorDeTabela = g.Sum(x => ((x.PrecoTabela - x.JurosCondicaoPagamento) * x.Quantidade)), //Menos os jutos
                             ValorDeContratoComJuros = g.Sum(x => (x.PrecoTabela * x.Quantidade)),
                             ValorUnitarioDeVenda = g.Sum(x => (x.ValorOriginal * x.Quantidade)),
                             ValorTotalPedido = g.Sum(x => (x.ValorOriginal * x.Quantidade)),
                             ValorLiquido = g.Sum(x => (x.PrecoUnitario * x.Quantidade))
                         }).ToList();

            return Lista;
        }

        public List<ComissaoContaCorrente> GetByNotaFiscal(int pIdNotaFiscal)
        {
            List<ComissaoContaCorrente> lista = new List<ComissaoContaCorrente>();
            lista = (from c in db.ComissaoContaCorrente
                     where c.IdNotaFiscal == pIdNotaFiscal
                     select c).ToList();
            return lista;
        }

    }


}
