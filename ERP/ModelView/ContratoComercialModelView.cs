using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ContratoComercialModelView
    {
        public int IdContratoComercial { get; set; }
        public int? ContratoNumero { get; set; }
        public string CodigoContrato { get; set; }
        public string Descricao { get; set; }
        public string Ativo { get; set; }
        public string Relacao { get; set; }
        public string Codigo { get; set; }
        public string Cliente { get; set; }
        public string Fornecedor { get; set; }
        public string RelacaoItem { get; set; }
        public string Produto { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorPercentual { get; set; }
    }
}
