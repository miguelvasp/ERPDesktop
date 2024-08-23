
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("ORDEMPRODUCAOPRODUTO", Schema = "DBO")]
    public class OrdemProducaoProduto
    {
        [Key]
        [DisplayName("IdOrdemProducaoProduto")]
        [Column("IDORDEMPRODUCAOPRODUTO")]
        public int? IdOrdemProducaoProduto { get; set; }
 
        [DisplayName("IdOrdemProducao")]
        [Column("IDORDEMPRODUCAO")]
        public int? IdOrdemProducao { get; set; }
 
        [DisplayName("IdProduto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }

        [DisplayName("IdVariantesCor")]
        [Column("IDVARIANTESCOR")]
        public int? IdVariantesCor { get; set; }

        [DisplayName("IdVariantesTamanho")]
        [Column("IDVARIANTESTAMANHO")]
        public int? IdVariantesTamanho { get; set; }

        [DisplayName("IdVariantesEstilo")]
        [Column("IDVARIANTESESTILO")]
        public int? IdVariantesEstilo { get; set; }

        [DisplayName("IdVariantesConfig")]
        [Column("IDVARIANTESCONFIG")]
        public int? IdVariantesConfig { get; set; }

        public decimal? Qtde { get; set; }
        public decimal? QtdeProducao { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual VariantesCor Cor { get; set; }
        public virtual VariantesEstilo Estilo { get; set; }
        public virtual VariantesTamanho Tamanho { get; set; }
        public virtual VariantesConfig Config { get; set; }
 
    }
}
