
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PLANOPRODUCAOETAPA", Schema = "DBO")]
    public class PlanoProducaoEtapa
    {
        [Key]
        [DisplayName("IdPlanoProducaoEtapa")]
        [Column("IDPLANOPRODUCAOETAPA")]
        public int IdPlanoProducaoEtapa { get; set; }

        [DisplayName("IdPlanoProducao")]
        [Column("IDPLANOPRODUCAO")]
        public int? IdPlanoProducao { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Tempo")]
        [Column("TEMPO")]
        public string Tempo { get; set; }
        public int? Ordem { get; set; }

        public virtual ICollection<PlanoProducaoMateriaPrima> MateriaPrima { get; set; }
        public virtual ICollection<PlanoProducaoRecurso> Recursos { get; set; }
        
 
    }
}
