
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("ORDEMPRODUCAO", Schema = "DBO")]
    public class OrdemProducao
    {
        [Key]
        [DisplayName("IdOrdemProducao")]
        [Column("IDORDEMPRODUCAO")]
        public int IdOrdemProducao { get; set; }

        public int? IdPlanoProducao { get; set; }

        [DisplayName("IdProduto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }
 
        [DisplayName("TipoProducao")]
        [Column("TIPOPRODUCAO")]
        public int? TipoProducao { get; set; }
 
        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal? Quantidade { get; set; }
 
        [DisplayName("StatusProducao")]
        [Column("STATUSPRODUCAO")]
        public int? StatusProducao { get; set; }
 
        [DisplayName("DataProgramada")]
        [Column("DATAPROGRAMADA")]
        public DateTime? DataProgramada { get; set; }
 
        [DisplayName("DataInicial")]
        [Column("DATAINICIAL")]
        public DateTime? DataInicial { get; set; }
 
        [DisplayName("DataFinal")]
        [Column("DATAFINAL")]
        public DateTime? DataFinal { get; set; }
 
        [DisplayName("IdPerfilProducao")]
        [Column("IDPERFILPRODUCAO")]
        public int? IdPerfilProducao { get; set; }
 
        [DisplayName("DefinicaoLucro")]
        [Column("DEFINICAOLUCRO")]
        public int? DefinicaoLucro { get; set; }
 
        [DisplayName("AlocacaoCustoTotal")]
        [Column("ALOCACAOCUSTOTOTAL")]
        public bool AlocacaoCustoTotal { get; set; }
 
        [DisplayName("IdVariantesConfiguracao")]
        [Column("IDVARIANTESCONFIGURACAO")]
        public int? IdVariantesConfiguracao { get; set; }
 
        [DisplayName("IdVariantesTamanho")]
        [Column("IDVARIANTESTAMANHO")]
        public int? IdVariantesTamanho { get; set; }
 
        [DisplayName("IdVariantesCor")]
        [Column("IDVARIANTESCOR")]
        public int? IdVariantesCor { get; set; }
 
        [DisplayName("IdVariantesEstilo")]
        [Column("IDVARIANTESESTILO")]
        public int? IdVariantesEstilo { get; set; }
 
        [DisplayName("IdLote")]
        [Column("IDLOTE")]
        public int? IdLote { get; set; }
 
        [DisplayName("Serie")]
        [Column("SERIE")]
        public string Serie { get; set; }
 
        [DisplayName("IdEmpresa")]
        [Column("IDEMPRESA")]
        public int? IdEmpresa { get; set; }
 
        [DisplayName("NumeroOP")]
        [Column("NUMEROOP")]
        public int? NumeroOP { get; set; }

        public int? IdLocalProducao { get; set; }

        public virtual Lote Lote { get; set; }
        public virtual LocalProducao LocalProducao { get; set; }
        public virtual ICollection<OrdemProducaoEtapa> Etapas { get; set; }
        public virtual ICollection<OrdemProducaoControleQualidade> Qualidade { get; set; }
        public virtual ICollection<OrdemProducaoProduto> Produtos { get; set; }
        public virtual ICollection<OrdemProducaoMateriaPrima> Materiais { get; set; }
 
    }
}
