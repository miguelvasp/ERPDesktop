using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("CODIGOISENCAO", Schema = "DBO")]
    public class CodigoIsencao
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCODIGOISENCAO")]
        public int IdCodigoIsencao { get; set; }  

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
