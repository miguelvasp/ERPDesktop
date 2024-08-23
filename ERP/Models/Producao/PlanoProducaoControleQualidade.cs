
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PLANOPRODUCAOCONTROLEQUALIDADE", Schema = "DBO")]
    public class PlanoProducaoControleQualidade
    {
        [Key]
        [DisplayName("IdPlanoProducaoControleQualidade")]
        [Column("IDPLANOPRODUCAOCONTROLEQUALIDADE")]
        public int IdPlanoProducaoControleQualidade { get; set; }
 
        [DisplayName("IdPlanoProducao")]
        [Column("IDPLANOPRODUCAO")]
        public int? IdPlanoProducao { get; set; }
 
        [DisplayName("IdPlanoProducaoEtapa")]
        [Column("IDPLANOPRODUCAOETAPA")]
        public int? IdPlanoProducaoEtapa { get; set; }
 
        [DisplayName("Descricao")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }
 
        [DisplayName("ToleranciaAmais")]
        [Column("TOLERANCIAAMAIS")]
        public decimal? ToleranciaAmais { get; set; }
 
        [DisplayName("ToleranciaAMenos")]
        [Column("TOLERANCIAAMENOS")]
        public decimal? ToleranciaAMenos { get; set; }
 
        [DisplayName("Aspecto")]
        [Column("ASPECTO")]
        public string Aspecto { get; set; }
 
    }
}
