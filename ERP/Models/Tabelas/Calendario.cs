using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("CALENDARIO", Schema = "DBO")]
    public class Calendario
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCALENDARIO")]
        public int IdCalendario { get; set; }
 
        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("PadraoHoraDiaTrabalho")]
        [Column("PADRAOHORADIATRABALHO")]
        public int? PadraoHoraDiaTrabalho { get; set; }
    }
}
