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
    [Table("CLIENTETELEFONE", Schema = "DBO")]
    public class ClienteTelefone
    {
        [Key]
        [DisplayName("Id Cliente Telefone")]
        [Column("IDCLIENTETELEFONE")]
        public int IdClienteTelefone { get; set; }

        [DisplayName("Id Cliente")]
        [Column("IDCLIENTE")]
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        [DisplayName("Id Telefone")]
        [Column("IDTELEFONE")]
        public int IdTelefone { get; set; }
        public virtual Telefone Telefone { get; set; }
    }
}
