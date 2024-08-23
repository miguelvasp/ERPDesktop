using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("CODIGOCONTRATOCOMERCIAL", Schema = "DBO")]
    public class CodigoContratoComercial
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCODIGOCONTRATOCOMERCIAL")]
        public int IdCodigoContratoComercial { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
