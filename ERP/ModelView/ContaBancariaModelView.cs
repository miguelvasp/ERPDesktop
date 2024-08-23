using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ContaBancariaModelView
    {
        public int IdConta { get; set; }
        public string NomeBanco { get; set; }
        public string NumeroBanco { get; set; }
        public string Agencia { get; set; }
        public string DigitoAgencia { get; set; }
        public string Conta { get; set; }
        public string DigitoConta { get; set; }
        public string NossoNumero { get; set; }
        public string Carteira { get; set; }
    }
}
