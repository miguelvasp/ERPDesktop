
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PLANOPRODUCAORECURSO", Schema = "DBO")]
    public class PlanoProducaoRecurso
    {
        [Key]
        [DisplayName("IdPlanoProducaoRecurso")]
        [Column("IDPLANOPRODUCAORECURSO")]
        public int? IdPlanoProducaoRecurso { get; set; }
 
        [DisplayName("IdPlanoProducao")]
        [Column("IDPLANOPRODUCAO")]
        public int? IdPlanoProducao { get; set; }
 
        [DisplayName("IdPlanoProducaoEtapa")]
        [Column("IDPLANOPRODUCAOETAPA")]
        public int? IdPlanoProducaoEtapa { get; set; }
 
        [DisplayName("IdRecurso")]
        [Column("IDRECURSO")]
        public int? IdRecurso { get; set; }

        public virtual Recursos Recurso { get; set; }
 
    }
}
