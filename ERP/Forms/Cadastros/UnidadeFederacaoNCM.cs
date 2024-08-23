using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("UNIDADEFEDERACAONCM", Schema = "DBO")]
    public class UnidadeFederacaoNCM
    {
        [Key]
        [DisplayName("IdUFNCM")]
        [Column("IDUFNCM")]
        public int IdUFNCM { get; set; }

        [DisplayName("IdUF")]
        [Column("IDUF")]
        public int IdUF { get; set; }
        public virtual UnidadeFederacao UnidadeFederacao { get; set; }

        [DisplayName("IdNCM")]
        [Column("IDNCM")]
        public int IdNCM { get; set; }
        public virtual ClassificacaoFiscal ClassificacaoFiscal { get; set; }
    }
}
