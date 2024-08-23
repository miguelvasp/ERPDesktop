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
    [Table("AVALIACAOCREDITO", Schema = "DBO")]
    public class AvaliacaoCredito
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDAVALIACAOCREDITO")]
        public int IdAvaliacaoCredito { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [Column("valor")]
        public decimal? Valor { get; set; }
    }
}
