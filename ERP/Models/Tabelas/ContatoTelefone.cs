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
    [Table("CONTATOTELEFONE", Schema = "DBO")]
    public class ContatoTelefone
    {
        [Key]
        [DisplayName("Id ContatoTelefone")]
        [Column("IDCONTATOTELEFONE")]
        public int IdContatoTelefone { get; set; }

        [DisplayName("Id Contato")]
        [Column("IDCONTATO")]
        public int IdContato { get; set; }
        public virtual Contato Contato { get; set; }

        [DisplayName("Id Telefone")]
        [Column("IDTELEFONE")]
        public int IdTelefone { get; set; }
        public virtual Telefone Telefone { get; set; }
    }
}
