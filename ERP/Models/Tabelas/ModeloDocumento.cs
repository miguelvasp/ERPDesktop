using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("MODELODOCUMENTO", Schema = "DBO")]
    public class ModeloDocumento
    {
        [Key]
        [DisplayName("Id Modelo Documento")]
        [Column("IDMODELODOCUMENTO")]
        public int IdModeloDocumento { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("NFE")]
        [Column("NFE")]
        public bool NFE { get; set; }

        [DisplayName("Pode Ser Ajustado")]
        [Column("PODESERAJUSTADO")]
        public bool PodeSerAjustado { get; set; }
    }
}
