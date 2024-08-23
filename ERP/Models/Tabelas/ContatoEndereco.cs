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
    [Table("CONTATOENDERECO", Schema = "DBO")]
    public class ContatoEndereco
    {
        [Key]
        [DisplayName("Id ContatoEndereco")]
        [Column("IDCONTATOENDERECO")]
        public int IdContatoEndereco { get; set; }

        [DisplayName("Id Contato")]
        [Column("IDCONTATO")]
        public int IdContato { get; set; }
        public virtual Contato Contato { get; set; }

        [DisplayName("Id Endereco")]
        [Column("IDENDERECO")]
        public int IdEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
