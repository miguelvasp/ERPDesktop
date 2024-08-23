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
    [Table("MOEDACOTACAO", Schema = "DBO")]
    public class MoedaCotacao
    {
        [Key]
        [DisplayName("Id Moeda Cotação")]
        [Column("IDMOEDACOTACAO")]
        public int IdMoedaCotacao { get; set; }

        [DisplayName("Id Moeda")]
        [Column("IDMOEDA")]
        public int IdMoeda { get; set; }
        public virtual Moeda Moeda { get; set; }

        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime Data { get; set; }

        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal Valor { get; set; }
    }
}
