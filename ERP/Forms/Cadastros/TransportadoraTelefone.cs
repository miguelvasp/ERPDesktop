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
    [Table("TRANSPORTADORATELEFONE", Schema = "DBO")]
    public class TransportadoraTelefone
    {
        [Key]
        [DisplayName("Id TransportadoraTelefone")]
        [Column("IDTRANSPORTADORATELEFONE")]
        public int IdTransportadoraTelefone { get; set; }

        [DisplayName("Id Transportadora")]
        [Column("IDTRANSPORTADORA")]
        public int IdTransportadora { get; set; }
        public virtual Transportadora Transportadora { get; set; }

        [DisplayName("Id Telefone")]
        [Column("IDTELEFONE")]
        public int IdTelefone { get; set; }
        public virtual Telefone Telefone { get; set; }
    }
}
