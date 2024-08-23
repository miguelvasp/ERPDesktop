
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PLANOPRODUCAOPRODUTO", Schema = "DBO")]
    public class PlanoProducaoProduto
    {
        [Key]
        [DisplayName("IdPlanoProducaoProduto")]
        [Column("IDPLANOPRODUCAOPRODUTO")]
        public int IdPlanoProducaoProduto { get; set; }
 
        [DisplayName("IdPlanoProducao")]
        [Column("IDPLANOPRODUCAO")]
        public int? IdPlanoProducao { get; set; }
 
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

        public decimal? QdeProducao { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual VariantesCor Cor { get; set; }
        public virtual VariantesEstilo Estilo { get; set; }
        public virtual VariantesTamanho Tamanho { get; set; }
        public virtual VariantesConfig Config { get; set; }

    }
}
