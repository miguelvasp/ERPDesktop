
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PLANOPRODUCAO", Schema = "DBO")]
    public class PlanoProducao
    {
        [Key]
        [DisplayName("IdPlanoProducao")]
        [Column("IDPLANOPRODUCAO")]
        public int IdPlanoProducao { get; set; }

        [DisplayName("DataCadastro")]
        [Column("DATACADASTRO")]
        public DateTime? DataCadastro { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("IdVariantesCor")]
        [Column("IDVARIANTESCOR")]
        public int? IdVariantesCor { get; set; }

        [DisplayName("Revisao")]
        [Column("REVISAO")]
        public DateTime? Revisao { get; set; }

        [DisplayName("VolumeContainer")]
        [Column("VOLUMECONTAINER")]
        public decimal? VolumeContainer { get; set; }

        [DisplayName("Rendimento")]
        [Column("RENDIMENTO")]
        public decimal? Rendimento { get; set; }

        public virtual ICollection<PlanoProducaoEtapa> Etapas { get; set; } 
        public virtual VariantesCor Cor { get; set; } 
 
    }
}
