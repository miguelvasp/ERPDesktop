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
    public class TempoTrabalhoLinhasDAL : Repository<TempoTrabalhoLinhas>
    {
        public List<TempoTrabalhoItemModelView> GetByTempoId(int Id)
        {
            List<TempoTrabalhoItemModelView> lista = (from i in db.TempoTrabalhoLinhas
                                                      where i.IdTempoTrabalho == Id
                                                      select new TempoTrabalhoItemModelView
                                                      {
                                                          Id = i.IdTempoTrabalhoLinha,
                                                          Dia = i.DiaSemana == null ? "" :
                                                                i.DiaSemana == 1 ? "Segunda-feira" :
                                                                i.DiaSemana == 2 ? "Terça-feira" :
                                                                i.DiaSemana == 3 ? "Quarta-feira" :
                                                                i.DiaSemana == 4 ? "Quinta-feira" :
                                                                i.DiaSemana == 5 ? "Sexta-feira" :
                                                                i.DiaSemana == 6 ? "Sábado" :
                                                                i.DiaSemana == 7 ? "Domingo" : "",
                                                          De = i.De,
                                                          Ate = i.Ate
                                                      }).ToList();
            return lista;
        }


        public List<ComboItem> GetDiasSemana()
        {
            List<ComboItem> itens = new List<ComboItem>();
            var lista = (from i in db.TempoTrabalhoLinhas
                                     select new 
                        {
                            iValue = i.DiaSemana,
                            Text = i.DiaSemana == null ? "" :
                                i.DiaSemana == 1 ? "Segunda-feira" :
                                i.DiaSemana == 2 ? "Terça-feira" :
                                i.DiaSemana == 3 ? "Quarta-feira" :
                                i.DiaSemana == 4 ? "Quinta-feira" :
                                i.DiaSemana == 5 ? "Sexta-feira" :
                                i.DiaSemana == 6 ? "Sábado" :
                                i.DiaSemana == 7 ? "Domingo" : ""
                        }).Distinct().ToList();

            foreach(var i in lista)
            {
                itens.Add(new ComboItem() { iValue = Convert.ToInt32(i.iValue), Text = i.Text });
            }

            return itens;
        }
    }
}
