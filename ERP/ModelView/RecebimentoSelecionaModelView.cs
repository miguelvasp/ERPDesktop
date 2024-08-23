using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class RecebimentoSelecionaModelView
    {
        public int Id { get; set; }
        public int? Pedido { get; set; }
        public string Codigo { get; set; }
        public string Produto { get; set; }
        public string Cor { get; set; }
        public string Estilo { get; set; }
        public string Tamanho { get; set; }
        public decimal Qtde { get; set; }
        public decimal Valor { get; set; }
        public string Condicao { get; set; }
        public string Unidade { get; set; }
    }
}
