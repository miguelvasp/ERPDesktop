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
    [Table("TRANSPORTADORACONTATO", Schema = "DBO")]
    public class TransportadoraContato
    {
        [Key]
        [DisplayName("Id Transportadora Contato")]
        [Column("IDTRANSPORTADORACONTATO")]
        public int IdTransportadoraContato { get; set; }

        [DisplayName("Id Transportadora")]
        [Column("IDTRANSPORTADORA")]
        public int IdTransportadora { get; set; }
        public virtual Transportadora Transportadora { get; set; }

        [DisplayName("Id Contato")]
        [Column("IDCONTATO")]
        public int IdContato { get; set; }
        public virtual Contato Contato { get; set; }
    }
}
