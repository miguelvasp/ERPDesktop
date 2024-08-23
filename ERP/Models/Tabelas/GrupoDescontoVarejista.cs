using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("GRUPODESCONTOVAREJISTA", Schema = "DBO")]
    public class GrupoDescontoVarejista
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDGRUPODESCONTOVAREJISTA")]
        public int IdGrupoDescontoVarejista { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
     }
}
