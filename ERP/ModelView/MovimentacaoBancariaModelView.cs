using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class MovimentacaoBancariaModelView
    {
        public int Id { get; set; }
        public string ContaBancaria { get; set; }
        public DateTime? Data { get; set; }
        public string Tipo { get; set; }
        public string Documento { get; set; }
        public string Historico { get; set; }
        public decimal? Valor { get; set; }

    }
}
