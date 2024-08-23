using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("FERIADO", Schema = "DBO")]
    public class Feriado
    {
        [Key]
        [DisplayName("Id Feriado")]
        [Column("IDFERIADO")]
        public int IdFeriado { get; set; }

        [DisplayName("Data Feriado")]
        [Column("DATAFERIADO")]
        public DateTime DataFeriado { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
