
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("ROTEIROOPERACAO", Schema = "DBO")]
    public class RoteiroOperacao
    {
        [Key]
        [DisplayName("IdRoteiroOperacao")]
        [Column("IDROTEIROOPERACAO")]
        public int IdRoteiroOperacao { get; set; }
 
        [DisplayName("IdRoteiro")]
        [Column("IDROTEIRO")]
        public int IdRoteiro { get; set; }
 
        [DisplayName("Atividade")]
        [Column("ATIVIDADE")]
        public string Atividade { get; set; }
 
        [DisplayName("Prioridade")]
        [Column("PRIORIDADE")]
        public int? Prioridade { get; set; }
 
        [DisplayName("Sequencia")]
        [Column("SEQUENCIA")]
        public int? Sequencia { get; set; }
 
        [DisplayName("Acumulado")]
        [Column("ACUMULADO")]
        public decimal? Acumulado { get; set; }
 
        [DisplayName("PorcentagemSucata")]
        [Column("PORCENTAGEMSUCATA")]
        public int? PorcentagemSucata { get; set; }
 
        [DisplayName("Proximo")]
        [Column("PROXIMO")]
        public int? Proximo { get; set; }
 
        [DisplayName("TaxaHoraTrabalhoTarefa")]
        [Column("TAXAHORATRABALHOTAREFA")]
        public int? TaxaHoraTrabalhoTarefa { get; set; }
 
        [DisplayName("TipoVinculo")]
        [Column("TIPOVINCULO")]
        public int? TipoVinculo { get; set; }
 
    }
}
