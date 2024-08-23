
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("ORDEMPRODUCAOCONTROLEQUALIDADE", Schema = "DBO")]
    public class OrdemProducaoControleQualidade
    {
        [Key]
        [DisplayName("IdOrdemProducaoControleQualidade")]
        [Column("IDORDEMPRODUCAOCONTROLEQUALIDADE")]
        public int? IdOrdemProducaoControleQualidade { get; set; }
 
        [DisplayName("IdOrdemProducao")]
        [Column("IDORDEMPRODUCAO")]
        public int? IdOrdemProducao { get; set; }
 
        [DisplayName("IdOrdemProducaoEtapa")]
        [Column("IDORDEMPRODUCAOETAPA")]
        public int? IdOrdemProducaoEtapa { get; set; }
 
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
