
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("VWESTOQUESINTETICO", Schema = "DBO")]
    public class vwEstoqueSintetico
    {
        [Key]
        [DisplayName("ID")]
        [Column("ID")]
        public long? ID { get; set; }
 
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

        public decimal Desconto { get; set; }
 
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
 
        [DisplayName("Dep?sito")]
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
        public decimal Quantidade { get; set; }

        public decimal? VendaPrecoUnit { get; set; }

        public string DadosComplementares { get; set; }

        public string EAN { get; set; }

        public int? IdGrupoProduto { get; set; }

        public bool? VendaProdDescontinuado { get; set; }

        //[Column("IDTIPODOCUMENTO")]
        //public int? IdTipoDocumento { get; set; }

    }
}
