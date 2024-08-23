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
    [Table("CLIENTEENDERECO", Schema = "DBO")]
    public class ClienteEndereco
    {
        [Key]
        [DisplayName("Id Cliente Endereço")]
        [Column("IDCLIENTEENDERECO")]
        public int IdClienteEndereco { get; set; }

        [DisplayName("Id Cliente")]
        [Column("IDCLIENTE")]
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        [DisplayName("Id Endereço")]
        [Column("IDENDERECO")]
        public int IdEndereco { get; set; }
        public virtual Endereco Endereco { get; set; } 
    }
}
