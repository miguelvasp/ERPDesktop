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
    [Table("CONTADOR", Schema = "DBO")]
    public class Contador
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCONTADOR")]
        public int IdContador { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("CPF")]
        [Column("CPF")]
        public string CPF { get; set; }

        [DisplayName("CNPJ")]
        [Column("CNPJ")]
        public string CNPJ { get; set; }

        [DisplayName("CRC")]
        [Column("CRC")]
        public string CRC { get; set; }

        [DisplayName("E-Mail")]
        [Column("EMAIL")]
        public string Email { get; set; }

        [DisplayName("Internet")]
        [Column("INTERNET")]
        public string Internet { get; set; }

        public virtual ICollection<ContadorEndereco> ContadorEndereco { get; set; }
        public virtual ICollection<ContadorTelefone> ContadorTelefone { get; set; }
    }
}
