
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PLANOPRODUCAOMATERIAPRIMA", Schema = "DBO")]
    public class PlanoProducaoMateriaPrima
    {
        [Key]
        [DisplayName("IdPlanoProducaoMateriaPrima")]
        [Column("IDPLANOPRODUCAOMATERIAPRIMA")]
        public int IdPlanoProducaoMateriaPrima { get; set; }
 
        [DisplayName("IdPlanoProducao")]
        [Column("IDPLANOPRODUCAO")]
        public int? IdPlanoProducao { get; set; }
 
        [DisplayName("IdPlanoProducaoEtapa")]
        [Column("IDPLANOPRODUCAOETAPA")]
        public int? IdPlanoProducaoEtapa { get; set; }
 
        [DisplayName("IdProduto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }
 
        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal? Quantidade { get; set; }
        public decimal? Densidade { get; set; }
        public decimal? Volume { get; set; }
        public decimal? Peso { get; set; }
        public decimal? VolumeTotal { get; set; }
        public decimal? PesoTotal { get; set; }

        public virtual Produto Produto { get; set; }
 
    }
}
