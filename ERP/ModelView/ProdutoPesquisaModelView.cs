using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class ProdutoPesquisaModelView
    {
        public int IdProduto { get; set; }
        public int? IdVarianteCor { get; set; }
        public int? IdVarianteEstilo { get; set; }
        public int? idVarianteTamanho { get; set; }
    }
}
