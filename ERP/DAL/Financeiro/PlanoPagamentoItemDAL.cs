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
    public class PlanoPagamentoItemDAL : Repository<PlanoPagamentoItem>
    {
        public List<PlanoPagamentoItemModelView> GetByPlanoId(int id)
        {
            List<PlanoPagamentoItemModelView> lista = (from p in db.PlanoPagamentoItem
                                                       where p.IdPlanoPagamento == id
                                                       select new PlanoPagamentoItemModelView
                                                       {
                                                           IdPlanoPagamentoItem = p.IdPlanoPagamentoItem,
                                                           Quantidade = p.Quantidade,
                                                           ValorTransacao = p.ValorTransacao,
                                                           PorcentagemValor = p.PorcentagemValor == null ? "" :
                                                                              p.PorcentagemValor == 1 ? "Porcentagem" : "Valor"
                                                       }).ToList();

            return lista;
        }
    }
}
