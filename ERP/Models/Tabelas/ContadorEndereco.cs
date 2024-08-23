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
    [Table("CONTADORENDERECO", Schema = "DBO")]
    public class ContadorEndereco
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCONTADORENDERECO")]
        public int IdContadorEndereco { get; set; }

        [DisplayName("Id Contador")]
        [Column("IDCONTADOR")]
        public int IdContador { get; set; }
        public virtual Contador Contador { get; set; }

        [DisplayName("Id Endereço")]
        [Column("IDENDERECO")]
        public int IdEndereco { get; set; }
        public virtual Endereco Endereco { get; set; } 
    }
}
