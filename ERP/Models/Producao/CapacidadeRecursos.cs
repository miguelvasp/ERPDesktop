using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("CAPACIDADERECURSOS", Schema = "DBO")]
    public class CapacidadeRecursos
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCAPACIDADERECURSOS")]
        public int IdCapacidadeRecursos { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
