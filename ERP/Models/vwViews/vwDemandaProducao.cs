
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("vwDemandaProducao", Schema = "DBO")]
    public class vwDemandaProducao
    {
        [Key]
        [DisplayName("IdDemandaProducao")]
        [Column("IDDEMANDAPRODUCAO")]
        public long? IdDemandaProducao { get; set; }
 
        [DisplayName("IdEmpresa")]
        [Column("IDEMPRESA")]
        public int? IdEmpresa { get; set; }
 
        [DisplayName("IdProduto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }
 
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
 
        [DisplayName("Descricao")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
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
 
        [DisplayName("Estoque")]
        [Column("ESTOQUE")]
        public decimal? Estoque { get; set; }
 
        [DisplayName("OrdemProducao")]
        [Column("ORDEMPRODUCAO")]
        public decimal? OrdemProducao { get; set; }
 
        [DisplayName("DemandaProducao")]
        [Column("DEMANDAPRODUCAO")]
        public decimal? DemandaProducao { get; set; }

        public int? ProducaoIdUnidade { get; set; }

        public decimal? QtdeProducao { get; set; }

        public string NomeProduto { get; set; }


    }
}
