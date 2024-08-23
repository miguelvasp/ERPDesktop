using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("TEMPOTRABALHOLINHAS", Schema = "DBO")]
    public class TempoTrabalhoLinhas
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDTEMPOTRABALHOLINHA")]
        public int IdTempoTrabalhoLinha { get; set; }
 
        [DisplayName("IdTempoTrabalho")]
        [Column("IDTEMPOTRABALHO")]
        public int? IdTempoTrabalho { get; set; }
 
        [DisplayName("DiaSemana")]
        [Column("DIASEMANA")]
        public int? DiaSemana { get; set; }
 
        [DisplayName("De")]
        [Column("DE")]
        public TimeSpan? De { get; set; }

        [DisplayName("Até")]
        [Column("ATE")]
        public TimeSpan? Ate { get; set; }
 
        [DisplayName("Porcentagem Eficiencia")]
        [Column("PORCENTAGEMEFICIENCIA")]
        public decimal? PorcentagemEficiencia { get; set; }
     }
}
