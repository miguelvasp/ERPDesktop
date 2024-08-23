using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("CALENDARIODATALINHAS", Schema = "DBO")]
    public class CalendarioDataLinhas
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCALENDARIODATALINHAS")]
        public int IdCalendarioDataLinhas { get; set; }

        [DisplayName("Id Calendário")]
        [Column("IDCALENDARIODATA")]
        public int? IdCalendarioData { get; set; }

        [DisplayName("IdTempoTrabalho")]
        [Column("IDTEMPOTRABALHO")]
        public int? IdTempoTrabalho { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

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
