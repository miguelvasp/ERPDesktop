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
    [Table("CLIENTECONTABANCARIA", Schema = "DBO")]
    public class ClienteContaBancaria
    {
        [Key]
        [DisplayName("Id Cliente Conta Bancária")]
        [Column("IDCLIENTECONTABANCARIA")]
        public int IdClienteContaBancaria { get; set; }

        [DisplayName("Id Cliente")]
        [Column("IDCLIENTE")]
        public int IdCliente { get; set; }

        [DisplayName("Id Conta Bancária")]
        [Column("IDCONTABANCARIA")]
        public int IdContaBancaria { get; set; }
        public virtual ContaBancaria ContaBancaria { get; set; } 
    }
}
