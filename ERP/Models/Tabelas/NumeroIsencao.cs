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
    [Table("NUMEROISENCAO", Schema = "DBO")]
    public class NumeroIsencao
    {
        [Key]
        [DisplayName("Id Número Isenção")]
        [Column("IDNUMEROISENCAO")]
        public int IdNumeroIsencao { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Id País")]
        [Column("IDPAIS")]
        public int? IdPais { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
