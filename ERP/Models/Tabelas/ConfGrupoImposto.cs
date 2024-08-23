using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("CONFGRUPOIMPOSTO", Schema = "DBO")]
    public class ConfGrupoImposto
    {
        [Key]
        [DisplayName("IdConfGrupoImposto")]
        [Column("IDCONFGRUPOIMPOSTO")]
        public int IdConfGrupoImposto { get; set; }

        [DisplayName("IdGrupoImposto")]
        [Column("IDGRUPOIMPOSTO")]
        public int? IdGrupoImposto { get; set; }

        [DisplayName("Isento")]
        [Column("ISENTO")]
        public bool Isento { get; set; }

        [DisplayName("IdCodigoIsencao")]
        [Column("IDCODIGOISENCAO")]
        public int? IdCodigoIsencao { get; set; }
        public virtual CodigoIsencao CodigoIsencao { get; set; }

        [DisplayName("IdCodigoTributacao")]
        [Column("IDCODIGOTRIBUTACAO")]
        public int IdCodigoTributacao { get; set; }
        public virtual CodigoTributacao CodigoTributacao { get; set; }

        [DisplayName("ImpostoSobreUso")]
        [Column("IMPOSTOSOBREUSO")]
        public bool? ImpostoSobreUso { get; set; }

        [DisplayName("IdCodigoImposto")]
        [Column("IDCODIGOIMPOSTO")]
        public int IdCodigoImposto { get; set; }
        public virtual CodigoImposto CodigoImposto { get; set; }


        [DisplayName("Percentual")]
        [Column("PERCENTUAL")]
        public decimal? Percentual { get; set; }
    }
}
