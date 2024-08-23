using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class OrdemProducaoModelView
    {
        public int IdOrdemProducao { get; set; }
        public DateTime? DataProgramada { get; set; }
        public int? NumeroOP { get; set; }
        public string NomePlano { get; set; }
        public string CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
        public string TipoProducao { get; set; }
        public Decimal? Quantidade { get; set; }
        public string Status { get; set; }
        public string Cor { get; set; }
        public int Hora { get; set; }
        public string dtstr { get; set; }
        public string Local { get; set; }
    }
}
