using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using ERP.Models;
using ERP.ModelView;
using ERP.BLL;

namespace ERP.DAL
{
    public class InventarioDAL : Repository<Inventario>
    {
        public List<Inventario> GetByLoteId(int pLote)
        {
            return (from e in db.Inventario
                    where e.IdLote == pLote
                    select e).ToList();
        }

        public Inventario GetByTipoDoc(int IdDocumento, int TipoDocumento)
        {
            Inventario inv = (from i in db.Inventario
                            where i.IdDocumento == IdDocumento
                             && i.IdTipoDocumento == TipoDocumento
                             && (i.QuantidadeRetirada == null || i.QuantidadeRetirada == 0)
                            select i).FirstOrDefault();
            return inv;
        } 

        public List<InventarioHistorico> getHistorico(int IdProduto)
        {
            BLInventario blInv = new BLInventario();
            var estoque = blInv.ConsultaEstoqueSintetico(
                    IdProduto,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    ""
                );

            var lista = (from i in db.Inventario
                         join t in db.TipoDocumento on i.IdTipoDocumento equals t.IdDocumento
                         where i.IdProduto == IdProduto
                         select new
                         {
                             i.DataFisica,
                             i.TipoMovimentoFinanceiro,
                             t.Nome,
                             i.IdTipoDocumento,
                             i.NumeroDocumentoNF,
                             i.IdDocumento,
                             i.Quantidade
                         }).OrderByDescending(x => x.DataFisica).ToList();
            List<InventarioHistorico> hl = new List<InventarioHistorico>();
            decimal saldo = 0;
            if(estoque != null && estoque.Count > 0)
            {
                saldo = estoque[0].Quantidade;
            }

            foreach (var i in lista)
            {
                InventarioHistorico h = new InventarioHistorico();
                h.Data = i.DataFisica;
                h.TipoMovimento = i.TipoMovimentoFinanceiro == "E" ? "Entrada" : "Saída";
                h.TipoDocumento = i.Nome;
                h.NumeroDocumento = i.IdTipoDocumento == 3 ? i.NumeroDocumentoNF : Convert.ToString(i.IdDocumento);
                h.Quantidade = i.Quantidade;
                h.Saldo = saldo;
                if(i.TipoMovimentoFinanceiro == "E")
                {
                    saldo = saldo - (decimal)i.Quantidade;
                }
                else
                {
                    saldo = saldo + Convert.ToDecimal(i.Quantidade * -1);
                }
                h.SaldoAnterior = saldo;
                hl.Add(h);

            }
            return hl; 
        }

    }

    public class InventarioHistorico
    {
        public DateTime? Data { get; set; }
        public string TipoMovimento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public decimal? Quantidade { get; set; }
        public decimal Saldo { get; set; }
        public decimal SaldoAnterior { get; set; }
    }
}
