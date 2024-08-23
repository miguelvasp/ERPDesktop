using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("CEST",Schema ="DBO")]
    public class CEST
    {
        [Key]
        [DisplayName("IdCest")]
        [Column("IDCEST")]
        public int IdCest { get; set; }

        [DisplayName("Cest")]
        [Column("CEST")]
        public string Cest { get; set; }
        
        [DisplayName("Descricao")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("NCM")]
        [Column("NCM")]
        public string NCM { get; set; }
    }
    
}
