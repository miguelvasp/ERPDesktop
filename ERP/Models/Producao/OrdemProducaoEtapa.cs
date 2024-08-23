
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("ORDEMPRODUCAOETAPA", Schema = "DBO")]
    public class OrdemProducaoEtapa
    {
        [Key]
        [DisplayName("IdOrdemProducaoEtapa")]
        [Column("IDORDEMPRODUCAOETAPA")]
        public int? IdOrdemProducaoEtapa { get; set; }
 
        [DisplayName("IdOrdemProducao")]
        [Column("IDORDEMPRODUCAO")]
        public int? IdOrdemProducao { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
        [DisplayName("Tempo")]
        [Column("TEMPO")]
        public string Tempo { get; set; }

        public int? Ordem { get; set; }

        public virtual ICollection<OrdemProducaoMateriaPrima> Materiais { get; set; }

    }
}
