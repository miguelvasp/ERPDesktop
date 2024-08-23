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
    public class CondicaoPagamentoDAL : Repository<CondicaoPagamento>
    {
        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.CondicaoPagamento
                                     select new ComboItem()
                                     {
                                         Text = c.Nome,
                                         iValue = c.IdCondicaoPagamento
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<ComboItem> GetComboVendas()
        {
            List<ComboItem> lista = (from c in db.CondicaoPagamento
                                     where c.CondicaoVendas == true
                                     select new ComboItem()
                                     {
                                         Text = c.Nome,
                                         iValue = c.IdCondicaoPagamento
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<VencimentosModelView> CalculaVencimentos(int pIdCondicaoPagamento, decimal Valor, DateTime Data)
        {
            decimal Cem = 100.00M;
            List<VencimentosModelView> lista = new List<VencimentosModelView>();
            CondicaoPagamento c = new CondicaoPagamentoDAL().GetByID(pIdCondicaoPagamento);
            List<CondicaoPagamentoIntervalo> ci = new CondicaoPagamentoIntervaloDAL().GetByCondicaoPagamentoId(pIdCondicaoPagamento);

            //Metodo de pagamento
            //1- Liquido ; 
            if (c.MetodoPagamento == 1)
            {
                foreach (CondicaoPagamentoIntervalo i in ci)
                {
                    VencimentosModelView v = new VencimentosModelView();
                    v.Data = Data.AddDays(i.Dias);
                    v.Valor = (i.Percentual * Valor) / Cem;
                    lista.Add(v);
                }
            }

            //2-Mes; 
            if(c.MetodoPagamento == 2)
            {
                //Calcula a data a partir do primeiro dia do proximo mes, adicionando os meses e dias cadastrados.
                int mes = Data.Month + 1;
                int ano = Data.Year;
                DateTime NovaData = new DateTime(ano, mes, 1);
                if(c.Mes > 0)
                {
                    NovaData = NovaData.AddMonths(c.Mes);
                }
                if(c.Dias != null && c.Dias > 0)
                {
                    NovaData = NovaData.AddDays(Convert.ToInt32(c.Dias));
                }

                foreach (CondicaoPagamentoIntervalo i in ci)
                {
                    VencimentosModelView v = new VencimentosModelView();
                    v.Data = NovaData.AddDays(i.Dias);
                    v.Valor = (i.Percentual * Valor) / Cem;
                    lista.Add(v);
                }
            }

            //3- Trimestal; 
            if (c.MetodoPagamento == 3)
            {
                //Calcula a data a partir do primeiro dia do proximo mes, adicionando os meses e dias cadastrados.
                int mes = Data.Month + 3;
                int ano = Data.Year;
                DateTime NovaData = new DateTime(ano, mes, 1);
                if (c.Mes > 0)
                {
                    NovaData = NovaData.AddMonths(c.Mes);
                }
                if (c.Dias != null && c.Dias > 0)
                {
                    NovaData = NovaData.AddDays(Convert.ToInt32(c.Dias));
                }

                foreach (CondicaoPagamentoIntervalo i in ci)
                {
                    VencimentosModelView v = new VencimentosModelView();
                    v.Data = NovaData.AddDays(i.Dias);
                    v.Valor = (i.Percentual * Valor) / Cem;
                    lista.Add(v);
                }
            }
            //4- Anual; 
            if (c.MetodoPagamento == 4)
            {
                //Calcula a data a partir do primeiro dia do proximo mes, adicionando os meses e dias cadastrados.
                DateTime NovaData = Data.AddYears(1);
                if (c.Mes > 0)
                {
                    NovaData = NovaData.AddMonths(c.Mes);
                }
                if (c.Dias != null && c.Dias > 0)
                {
                    NovaData = NovaData.AddDays(Convert.ToInt32(c.Dias));
                }

                foreach (CondicaoPagamentoIntervalo i in ci)
                {
                    VencimentosModelView v = new VencimentosModelView();
                    v.Data = NovaData.AddDays(i.Dias);
                    v.Valor = (i.Percentual * Valor) / Cem;
                    lista.Add(v);
                }
            }
            //5- Semanal; 
            if(c.MetodoPagamento == 5)
            {
                //calcula a data a partir da proxima segunda feira
                int dias = ((int)DayOfWeek.Monday - (int)Data.DayOfWeek + 7) % 7;
                DateTime nextMondayy = Data.AddDays(dias);
                if (c.Mes > 0)
                {
                    Data = Data.AddMonths(c.Mes);
                }
                if (c.Dias != null && c.Dias > 0)
                {
                    Data = Data.AddDays(Convert.ToInt32(c.Dias));
                }
                foreach (CondicaoPagamentoIntervalo i in ci)
                {
                    VencimentosModelView v = new VencimentosModelView();
                    v.Data = Data.AddDays(i.Dias);
                    v.Valor = (i.Percentual * Valor) / Cem;
                    lista.Add(v);
                }
            }
            //6- C.O.D; 
            if(c.MetodoPagamento == 6)
            {
                if (c.Mes > 0)
                {
                    Data = Data.AddMonths(c.Mes);
                }
                if (c.Dias != null && c.Dias > 0)
                {
                    Data = Data.AddDays(Convert.ToInt32(c.Dias));
                }
                VencimentosModelView v = new VencimentosModelView();
                v.Data = Data;
                v.Valor = Valor;
                lista.Add(v);
            }

            //7- Dia de fechamento.
            if (c.MetodoPagamento == 6)
            {
                if (c.Mes > 0)
                {
                    Data = Data.AddMonths(c.Mes);
                }
                if (c.Dias != null && c.Dias > 0)
                {
                    Data = Data.AddDays(Convert.ToInt32(c.Dias));
                }

                //calcula o ultimo dia do mes
                int UltimoDia = DateTime.DaysInMonth(Data.Year, Data.Month);
                Data = new DateTime(Data.Year, Data.Month, UltimoDia);

                foreach (CondicaoPagamentoIntervalo i in ci)
                {
                    //calcula novamente o ultimo dia do mes
                    VencimentosModelView v = new VencimentosModelView();
                    Data = Data.AddDays(i.Dias);
                    int fimmes = DateTime.DaysInMonth(Data.Year, Data.Month);
                    Data = new DateTime(Data.Year, Data.Month, fimmes);
                    v.Data = Data;
                    v.Valor = (i.Percentual * Valor) / Cem;
                    lista.Add(v);
                } 
            } 
            return lista;
        }
    }
}
