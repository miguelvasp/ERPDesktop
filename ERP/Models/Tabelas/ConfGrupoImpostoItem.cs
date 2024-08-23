using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("CONFGRUPOIMPOSTOITEM", Schema = "DBO")]
    public class ConfGrupoImpostoItem
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCONFGRUPOIMPOSTOITEM")]
        public int IdConfGrupoImpostoItem { get; set; }

        [DisplayName("Código")]
        [Column("IDCODIGOIMPOSTO")]
        public int? IdCodigoImposto { get; set; }

        [DisplayName("IdGrupoImpostoItem")]
        [Column("IDGRUPOIMPOSTOITEM")]
        public int IdGrupoImpostoItem { get; set; }
        public virtual GrupoImpostoItem GrupoImpostoItem { get; set; }

        [DisplayName("Isento")]
        [Column("ISENTO")]
        public bool Isento { get; set; }

        [DisplayName("Id Código Tributação")]
        [Column("IDCODIGOTRIBUTACAO")]
        public int IdCodigoTributacao { get; set; }
        public virtual CodigoTributacao CodigoTributacao { get; set; }

        [DisplayName("Sem Crédito Imposto")]
        [Column("SEMCREDITOIMPOSTO")]
        public bool SemCreditoImposto { get; set; }
        
        [DisplayName("Id Valores Imposto")]
        [Column("PERCENTUALVALOR")]
        public decimal? PercentualValor { get; set; } 
    }
}
