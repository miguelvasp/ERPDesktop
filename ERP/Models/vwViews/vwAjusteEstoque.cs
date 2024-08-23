
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("VWAJUSTEESTOQUE", Schema = "DBO")]
    public class vwAjusteEstoque
    {
        [Key]
        [DisplayName("IdAjusteEstoque")]
        [Column("IDAJUSTEESTOQUE")]
        public int? IdAjusteEstoque { get; set; }
 
        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime? Data { get; set; }
 
        [DisplayName("IdInventario")]
        [Column("IDINVENTARIO")]
        public int? IdInventario { get; set; }
 
        [DisplayName("IdEmpresa")]
        [Column("IDEMPRESA")]
        public int? IdEmpresa { get; set; }
 
        [DisplayName("IdProduto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }
 
        [DisplayName("IdDeposito")]
        [Column("IDDEPOSITO")]
        public int? IdDeposito { get; set; }
 
        [DisplayName("IdArmazem")]
        [Column("IDARMAZEM")]
        public int? IdArmazem { get; set; }
 
        [DisplayName("IdLocalizacao")]
        [Column("IDLOCALIZACAO")]
        public int? IdLocalizacao { get; set; }
 
        [DisplayName("IdVariantesCor")]
        [Column("IDVARIANTESCOR")]
        public int? IdVariantesCor { get; set; }
 
        [DisplayName("IdVariantesTamanho")]
        [Column("IDVARIANTESTAMANHO")]
        public int? IdVariantesTamanho { get; set; }
 
        [DisplayName("IdVariantesEstilo")]
        [Column("IDVARIANTESESTILO")]
        public int? IdVariantesEstilo { get; set; }
 
        [DisplayName("IdVariantesConfig")]
        [Column("IDVARIANTESCONFIG")]
        public int? IdVariantesConfig { get; set; }
 
        [DisplayName("IdUnidade")]
        [Column("IDUNIDADE")]
        public int? IdUnidade { get; set; }
 
        [DisplayName("Codigo")]
        [Column("CODIGO")]
        public string Codigo { get; set; }
 
        [DisplayName("NomeProduto")]
        [Column("NOMEPRODUTO")]
        public string NomeProduto { get; set; }
 
        [DisplayName("Descricao")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Deposito")]
        [Column("DEPOSITO")]
        public string Deposito { get; set; }
 
        [DisplayName("Armazem")]
        [Column("ARMAZEM")]
        public string Armazem { get; set; }
 
        [DisplayName("Localizacao")]
        [Column("LOCALIZACAO")]
        public string Localizacao { get; set; }
 
        [DisplayName("Cor")]
        [Column("COR")]
        public string Cor { get; set; }
 
        [DisplayName("Tamanho")]
        [Column("TAMANHO")]
        public string Tamanho { get; set; }
 
        [DisplayName("Estilo")]
        [Column("ESTILO")]
        public string Estilo { get; set; }
 
        [DisplayName("Configuracao")]
        [Column("CONFIGURACAO")]
        public string Configuracao { get; set; }
 
        [DisplayName("Unidade")]
        [Column("UNIDADE")]
        public string Unidade { get; set; }
 
        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal? Quantidade { get; set; }
 
        [DisplayName("DataAvisoPrateleira")]
        [Column("DATAAVISOPRATELEIRA")]
        public DateTime? DataAvisoPrateleira { get; set; }
 
        [DisplayName("DataFabricacao")]
        [Column("DATAFABRICACAO")]
        public DateTime? DataFabricacao { get; set; }
 
        [DisplayName("DataValidade")]
        [Column("DATAVALIDADE")]
        public DateTime? DataValidade { get; set; }
 
        [DisplayName("DataVencimento")]
        [Column("DATAVENCIMENTO")]
        public DateTime? DataVencimento { get; set; }
 
        [DisplayName("LoteFornecedor")]
        [Column("LOTEFORNECEDOR")]
        public string LoteFornecedor { get; set; }
 
        [DisplayName("LoteInterno")]
        [Column("LOTEINTERNO")]
        public string LoteInterno { get; set; }
 
    }
}
