using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("APROVACAONIVEL", Schema = "DBO")]
    public class AprovacaoNivel
    {
        [Key]
        [DisplayName("IdAprovacaoNivel")]
        [Column("IDAPROVACAONIVEL")]
        public int IdAprovacaoNivel { get; set; }

        [DisplayName("IdAprovacaoDocumento")]
        [Column("IDAPROVACAODOCUMENTO")]
        public int? IdAprovacaoDocumento { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Sequência")]
        [Column("SEQUENCIA")]
        public int? Sequencia { get; set; }
    }
}
