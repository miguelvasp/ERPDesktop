using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("CENTROCUSTO", Schema = "DBO")]
    public class CentroCusto
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCENTROCUSTO")]
        public int IdCentroCusto { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
