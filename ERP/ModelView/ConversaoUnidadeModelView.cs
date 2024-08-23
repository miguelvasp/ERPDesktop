using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ConversaoUnidadeModelView
    {
        public int IdConversaoUnidade { get; set; }
        public int IdProduto { get; set; }
        public decimal Fator { get; set; }
        public int Numerador { get; set; }
        public int Denominador { get; set; }
        public string UnidadeDe { get; set; }
        public string UnidadePara { get; set; }
    }
}
