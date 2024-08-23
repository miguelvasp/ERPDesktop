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
    [Table("BANCO", Schema = "DBO")]
    public class Banco
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDBANCO")]
        public int IdBanco { get; set; }

        [DisplayName("Número Banco")]
        [Column("NUMEROBANCO")]
        public string NumeroBanco { get; set; }

        [DisplayName("Nome Banco")]
        [Column("NOMEBANCO")]
        public string NomeBanco { get; set; }

        //public virtual ICollection<ContaBancaria> ContaBancaria { get; set; }
    }
}
