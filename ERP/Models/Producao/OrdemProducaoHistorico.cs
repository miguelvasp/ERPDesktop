
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("ORDEMPRODUCAOHISTORICO", Schema = "DBO")]
    public class OrdemProducaoHistorico
    {
        [Key]
        [DisplayName("IdOrdemProducaoHistorico")]
        [Column("IDORDEMPRODUCAOHISTORICO")]
        public int? IdOrdemProducaoHistorico { get; set; }
 
        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime? Data { get; set; }
 
        [DisplayName("Descricao")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Usuario")]
        [Column("USUARIO")]
        public string Usuario { get; set; }
 
        [DisplayName("IdOrdemProducao")]
        [Column("IDORDEMPRODUCAO")]
        public int? IdOrdemProducao { get; set; }
 
    }
}
