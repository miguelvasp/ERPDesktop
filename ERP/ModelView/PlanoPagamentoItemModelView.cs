using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class PlanoPagamentoItemModelView
    {
        public int IdPlanoPagamentoItem { get; set; }  
        public decimal? Quantidade { get; set; } 
        public decimal? ValorTransacao { get; set; } 
        public string PorcentagemValor { get; set; }
    }
}
