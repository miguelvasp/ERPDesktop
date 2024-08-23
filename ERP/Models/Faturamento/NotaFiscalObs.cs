using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("NOTAFISCALOBS", Schema = "DBO")]
    public class NotaFiscalObs
    {
        [Key]
        [DisplayName("IdNFOBS")]
        [Column("IDNFOBS")]
        public int IdNFOBS { get; set; }
 
        [DisplayName("IdNotaFiscal")]
        [Column("IDNOTAFISCAL")]
        public int? IdNotaFiscal { get; set; }

        [DisplayName("Observação")]
        [Column("OBSERVACAO")]
        public string Observacao { get; set; } 
    }
}
