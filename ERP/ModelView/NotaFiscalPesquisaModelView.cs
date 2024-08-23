using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class NotaFiscalPesquisaModelView
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime? Emissao { get; set; }
        public string Destinatario { get; set; }
        public string NomeFantasia { get; set; }
        public decimal? Peso { get; set; }
        public decimal? Total { get; set; }
        public DateTime? DataEntrega { get; set; }
        public string Situacao { get; set; }
        public string NFeResultado { get; set; }
    }
}
