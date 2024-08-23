using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("CLIENTECENTROCUSTO", Schema = "DBO")]
    public class ClienteCentroCusto
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCLIENTECENTROCUSTO")]
        public int IdClienteCentroCusto { get; set; }
 
        [DisplayName("IdCliente")]
        [Column("IDCLIENTE")]
        public int? IdCliente { get; set; }
 
        [DisplayName("IdValoresCentroCusto")]
        [Column("IDVALORESCENTROCUSTO")]
        public int? IdValoresCentroCusto { get; set; }
    }
}
