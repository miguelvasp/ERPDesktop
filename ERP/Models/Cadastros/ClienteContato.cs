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
    [Table("CLIENTECONTATO", Schema = "DBO")]
    public class ClienteContato
    {
        [Key]
        [DisplayName("Id ClienteContato")]
        [Column("IDCLIENTECONTATO")]
        public int IdClienteContato { get; set; }

        [DisplayName("Id Cliente")]
        [Column("IDCLIENTE")]
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; } 
        
        [DisplayName("Id Contato")]
        [Column("IDCONTATO")]
        public int IdContato { get; set; }
        public virtual Contato Contato { get; set; } 
    }
}
