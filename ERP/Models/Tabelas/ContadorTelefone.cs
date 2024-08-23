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
    [Table("CONTADORTELEFONE", Schema = "DBO")]
    public class ContadorTelefone
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCONTADORTELEFONE")]
        public int IdContadorTelefone { get; set; }

        [DisplayName("Id Contador")]
        [Column("IDCONTADOR")]
        public int IdContador { get; set; }
        public virtual Contador Contador { get; set; }

        [DisplayName("Id Telefone")]
        [Column("IDTELEFONE")]
        public int IdTelefone { get; set; }
        public virtual Telefone Telefone { get; set; }
    }
}
