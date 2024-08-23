using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class NotaFiscalItemModelView
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string NCM { get; set; }
        public decimal? Qtde { get; set; }
        public string Unidade { get; set; }
        public decimal? ValorUnit { get; set; }
        public decimal? ValorDesc { get; set; }
        public decimal? Total { get; set; }
        public decimal? BaseIcms { get; set; }
        public decimal? ValorICMS { get; set; }
        public decimal? ValorIPI { get; set; }
        public decimal? AliquotaICMS { get; set; }
        public decimal? AliquotaIPI { get; set; }
        public int? Pedido { get; set; }
    }
}
