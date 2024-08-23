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
    public class DiasPagamentoItemDAL : Repository<DiasPagamentoItem>
    {
        public List<DiasPagamentoItemModelView> GetByDiaId(int Id)
        {
            List<DiasPagamentoItemModelView> lista = (from d in db.DiasPagamentoItem
                                                      where d.IdDiasPagamento == Id
                                                      select new DiasPagamentoItemModelView
                                                      {
                                                          IdDiasPagamentoItem = d.IdDiasPagamentoItem,
                                                          SemanaMes = d.SemanaMes == null ? "" :
                                                                      d.SemanaMes == 1 ? "Dias" : "Semanas",
                                                          DiaSemana = d.DiaSemana == null ? "" :
                                                                      d.DiaSemana == 1 ? "Segunda-feira" :
                                                                      d.DiaSemana == 2 ? "Terça-Feira" :
                                                                      d.DiaSemana == 3 ? "Quarta-Feira" :
                                                                      d.DiaSemana == 4 ? "Quinta-Feira" :
                                                                      d.DiaSemana == 5 ? "Sexta-Feira" :
                                                                      d.DiaSemana == 6 ? "Sábado-Feira" :
                                                                      d.DiaSemana == 7 ? "Domingo-Feira" : "",
                                                          DiaMes = d.DiaMes
                                                      }).ToList();
            return lista;
        }
    }
}
