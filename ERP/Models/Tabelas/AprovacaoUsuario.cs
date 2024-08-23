using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("APROVACAOUSUARIO", Schema = "DBO")]
    public class AprovacaoUsuario
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDAPROVACAOUSUARIO")]
        public int IdAprovacaoUsuario { get; set; }

        [DisplayName("IdAprovacaoNivel")]
        [Column("IDAPROVACAONIVEL")]
        public int? IdAprovacaoNivel { get; set; }

        [DisplayName("Id Usuário")]
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
