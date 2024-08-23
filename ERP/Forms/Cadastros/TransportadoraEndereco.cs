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
    [Table("TRANSPORTADORAENDERECO", Schema = "DBO")]
    public class TransportadoraEndereco
    {
        [Key]
        [DisplayName("Id Transportadora Endereço")]
        [Column("IDTRANSPORTADORAENDERECO")]
        public int IdTransportadoraEndereco { get; set; }

        [DisplayName("Id Transportadora")]
        [Column("IDTRANSPORTADORA")]
        public int IdTransportadora { get; set; }
        public virtual Transportadora Transportadora { get; set; }

        [DisplayName("Id Endereço")]
        [Column("IDENDERECO")]
        public int IdEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
