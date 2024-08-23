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
    [Table("CONTATO", Schema = "DBO")]
    public class Contato
    {
        [Key]
        [DisplayName("Id Contato")]
        [Column("IDCONTATO")]
        public int IdContato { get; set; }

        [DisplayName("Id Endereco")]
        [Column("IDENDERECO")]
        public int? IdEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }

        [DisplayName("Id Telefone")]
        [Column("IDTELEFONE")]
        public int? IdTelefone { get; set; }
        public virtual Telefone Telefone { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("CPF")]
        [Column("CPF")]
        public string CPF { get; set; }

        [DisplayName("E-Mail")]
        [Column("EMAIL")]
        public string EMail { get; set; }

        public virtual ICollection<ClienteContato> ClienteContato { get; set; }
        public virtual ICollection<FornecedorContato> FornecedorContato { get; set; }
    }
}
