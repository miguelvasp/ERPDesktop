using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ModelView
{
    public class InventarioModelView
    {
        public long? ID { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdProduto { get; set; }
        public int? IdDeposito { get; set; }
        public int? IdArmazem { get; set; }
        public int? IdLocalizacao { get; set; }
        public int? IdVariantesCor { get; set; }
        public int? IdVariantesTamanho { get; set; }
        public int? IdVariantesEstilo { get; set; } 
        public int? IdVariantesConfig { get; set; } 
        public int? IdUnidade { get; set; } 
        public string Codigo { get; set; } 
        public string NomeProduto { get; set; } 
        public string Descricao { get; set; } 
        public string Deposito { get; set; } 
        public string Armazem { get; set; } 
        public string Localizacao { get; set; } 
        public string Cor { get; set; } 
        public string Tamanho { get; set; } 
        public string Estilo { get; set; } 
        public string Configuracao { get; set; } 
        public string Unidade { get; set; } 
        public decimal? Quantidade { get; set; } 
        public int? IdTipoDocumento { get; set; }
    }
}
