using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class LancamentoModelView
    {
        public int IdLancamento { get; set; }
        public int IdTipoLancamento { get; set; }
        public string Descricao { get; set; }
        public string TipoDocumento { get; set; }
        public string TipoLancamento { get; set; }
        public string ContaContabil { get; set; }
        public int? IdContaContabil { get; set; }
        public int? IdProduto { get; set; }
        public int? IdGRupoProduto { get; set; }
        public int? IdFornecedor { get; set; }
        public int? IdGrupoFornecedor { get; set; }
        public int? IdGrupoCliente { get; set; }
        public int? RelacaoItem { get; set; }
        public int? RelacaoGrupo { get; set; }
    }
}
