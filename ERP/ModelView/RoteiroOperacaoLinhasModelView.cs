using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class RoteiroOperacaoLinhasModelView
    {
        public int Id { get; set; }
        public string CodigoItem { get; set; }
        public string Produto { get; set; }
        public string GrupoLancamento { get; set; }
        public string GrupoRoteiro { get; set; }
    }
}
