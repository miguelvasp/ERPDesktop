using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("CALENDARIODATA", Schema = "DBO")]
    public class CalendarioData
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCALENDARIODATA")]
        public int IdCalendarioData { get; set; }

        [DisplayName("IdCalendario")]
        [Column("IDCALENDARIO")]
        public int? IdCalendario { get; set; }

        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime? Data { get; set; }

        [DisplayName("DiaSemana")]
        [Column("DIASEMANA")]
        public int? DiaSemana { get; set; }

        [DisplayName("IdFeriado")]
        [Column("IDFERIADO")]
        public int? IdFeriado { get; set; }

        [DisplayName("Controle")]
        [Column("CONTROLE")]
        public int? Controle { get; set; }
    }
}
