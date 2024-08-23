using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("SEGMENTOBANCARIO", Schema = "DBO")]
    public class SegmentoBancario
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDSEGMENTOBANCARIO")]
        public int IdSegmentoBancario { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descri��o")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("IdProximoSegmento")]
        [Column("IDPROXIMOSEGMENTO")]
        public int? IdProximoSegmento { get; set; }

        [DisplayName("Obrigat�rio")]
        [Column("OBRIGATORIO")]
        public bool Obrigatorio { get; set; }
    }
}
