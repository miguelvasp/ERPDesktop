using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("GRUPORECURSOLINHA", Schema = "DBO")]
    public class GrupoRecursoLinha
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDGRUPORECURSOLINHA")]
        public int IdGrupoRecursoLinha { get; set; }

        [DisplayName("Id Grupo Recurso")]
        [Column("IDGRUPORECURSO")]
        public int? IdGrupoRecurso { get; set; }

        [DisplayName("Id Recurso")]
        [Column("IDRECURSO")]
        public int? IdRecurso { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Até")]
        [Column("ATE")]
        public DateTime? Ate { get; set; }

        [DisplayName("Id Calendário")]
        [Column("IDCALENDARIO")]
        public int? IdCalendario { get; set; }

        [DisplayName("Id Depósito")]
        [Column("IDDEPOSITO")]
        public int? IdDeposito { get; set; }
    }
}
