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
    public class ChequeTerceirosDAL : Repository<ChequeTerceiros>
    {
        public List<ChequeTerceiroModelView> GetListagemCheques(int IdBanco, string Cheque)
        {
            List<ChequeTerceiroModelView> lista = (from c in db.ChequeTerceiros 
                                                   join a in db.Banco on c.IdBanco equals a.IdBanco
                                                   where (IdBanco == 0 || c.IdBanco == IdBanco)
                                                   && (Cheque == "" || c.NumeroCheque.Contains(Cheque))
                                                   && c.IdContasPagarBaixa == null
                                                   select new ChequeTerceiroModelView
                                                   {
                                                       Id = c.IdChequeTerceiro,
                                                       Banco = a.NomeBanco,
                                                       Nome = c.Nome,
                                                       Cheque = c.NumeroCheque,
                                                       Data = c.Emissao,
                                                       Valor = c.Valor,
                                                       Agencia = c.Agencia,
                                                       Conta = c.Conta,
                                                       Status = c.Status == 1 ? "Em transito" :
                                                                c.Status == 2 ? "Custodia" :
                                                                c.Status == 3 ? "Depositado" :
                                                                c.Status == 4 ? "Devolvido Custodia" :
                                                                c.Status == 5 ? "Devolvido" :
                                                                c.Status == 6 ? "Reapresentado" :
                                                                c.Status == 7 ? "Protestado" :
                                                                c.Status == 8 ? "Baixado" : ""
                                                   }).ToList();
            return lista;
        }

        public List<ChequeTerceiroModelView> GetChequesContasPagar(int pIdBaixa)
        {
            List<ChequeTerceiroModelView> lista = (from b in db.ContasPagarChequeTerceiros
                                                  join c in db.ChequeTerceiros on b.IdChequeTerceiro equals c.IdChequeTerceiro
                                                  join a in db.Banco on c.IdBanco equals a.IdBanco
                                                  where b.IdContasPagarBaixa == pIdBaixa
                                                  select new ChequeTerceiroModelView
                                                  {
                                                      Id = c.IdChequeTerceiro,
                                                      Banco = a.NomeBanco,
                                                      Nome = c.Nome,
                                                      Cheque = c.NumeroCheque,
                                                      Data = c.Emissao,
                                                      Valor = c.Valor,
                                                      Status = c.Status == 1 ? "Em transito" :
                                                               c.Status == 2 ? "Custodia" :
                                                               c.Status == 3 ? "Depositado" :
                                                               c.Status == 4 ? "Devolvido Custodia" :
                                                               c.Status == 5 ? "Devolvido" :
                                                               c.Status == 6 ? "Reapresentado" :
                                                               c.Status == 7 ? "Protestado" :
                                                               c.Status == 8 ? "Baixado" : ""
                                                  }).ToList();
            return lista;
        }

        public List<ChequeTerceiroModelView> GetChequesContasReceber(int pIdBaixa)
        {
            List<ChequeTerceiroModelView> lista = (from b in db.ContasReceberChequeTerceiros
                                                   join c in db.ChequeTerceiros on b.IdChequeTerceiro equals c.IdChequeTerceiro
                                                   join a in db.Banco on c.IdBanco equals a.IdBanco
                                                   where b.IdContasReceberBaixa == pIdBaixa
                                                   select new ChequeTerceiroModelView
                                                   {
                                                       Id = c.IdChequeTerceiro,
                                                       Banco = a.NomeBanco,
                                                       Nome = c.Nome,
                                                       Cheque = c.NumeroCheque,
                                                       Data = c.Emissao,
                                                       Valor = c.Valor,
                                                       Status = c.Status == 1 ? "Em transito" :
                                                                c.Status == 2 ? "Custodia" :
                                                                c.Status == 3 ? "Depositado" :
                                                                c.Status == 4 ? "Devolvido Custodia" :
                                                                c.Status == 5 ? "Devolvido" :
                                                                c.Status == 6 ? "Reapresentado" :
                                                                c.Status == 7 ? "Protestado" :
                                                                c.Status == 8 ? "Baixado" : ""
                                                   }).ToList();
            return lista;
        }

    }

   
}
