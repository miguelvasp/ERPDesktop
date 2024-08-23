
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("ORDEMPRODUCAOMATERIAPRIMA", Schema = "DBO")]
    public class OrdemProducaoMateriaPrima
    {
        [Key]
        [DisplayName("IdOrdemProducaoMateriaPrima")]
        [Column("IDORDEMPRODUCAOMATERIAPRIMA")]
        public int? IdOrdemProducaoMateriaPrima { get; set; }
 
        [DisplayName("IdOrdemProducao")]
        [Column("IDORDEMPRODUCAO")]
        public int? IdOrdemProducao { get; set; }
 
        [DisplayName("IdOrdemProducaoEtapa")]
        [Column("IDORDEMPRODUCAOETAPA")]
        public int? IdOrdemProducaoEtapa { get; set; }
 
        [DisplayName("IdProduto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }
 
        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal? Quantidade { get; set; }
 
        [DisplayName("Densidade")]
        [Column("DENSIDADE")]
        public decimal? Densidade { get; set; }
 
        [DisplayName("Volume")]
        [Column("VOLUME")]
        public decimal? Volume { get; set; }
 
        [DisplayName("Peso")]
        [Column("PESO")]
        public decimal? Peso { get; set; }
 
        [DisplayName("VolumeTotal")]
        [Column("VOLUMETOTAL")]
        public decimal? VolumeTotal { get; set; }
 
        [DisplayName("PesoTotal")]
        [Column("PESOTOTAL")]
        public decimal? PesoTotal { get; set; }
 
        [DisplayName("ValorExtra")]
        [Column("VALOREXTRA")]
        public decimal? ValorExtra { get; set; }
 
        [DisplayName("LitrosTotal")]
        [Column("LITROSTOTAL")]
        public decimal? LitrosTotal { get; set; }
 
        [DisplayName("KilosTotal")]
        [Column("KILOSTOTAL")]
        public decimal? KilosTotal { get; set; }

        public virtual Produto Produto { get; set; }
 
    }
}
