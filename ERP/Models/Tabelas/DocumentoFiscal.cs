using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("DOCUMENTOFISCAL", Schema = "DBO")]
    public class DocumentoFiscal
    {
        [Key]
        [DisplayName("Id Documento Fiscal")]
        [Column("IDDOCUMENTOFISCAL")]
        public int IdDocumentoFiscal { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Id Modelo Documento")]
        [Column("IDMODELODOCUMENTO")]
        public int? IdModeloDocumento { get; set; }

        [DisplayName("Id Espécie")]
        [Column("IDESPECIE")]
        public int? IdEspecie { get; set; }
        public virtual Especie Especie { get; set; }
    }
}
