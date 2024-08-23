using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("GRUPOPRECODESCONTO", Schema = "DBO")]
    public class GrupoPrecoDesconto
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDGRUPOPRECODESCONTO")]
        public int IdGrupoPrecoDesconto { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Tipo")]
        [Column("TIPO")]
        public int? Tipo { get; set; }
 
        [DisplayName("Módulo")]
        [Column("MODULO")]
        public int? Modulo { get; set; } 
    }
}
