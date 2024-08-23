using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("GRUPOPRODUCAO", Schema = "DBO")]
    public class GrupoProducao
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDGRUPOPRODUCAO")]
        public int IdGrupoProducao { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
