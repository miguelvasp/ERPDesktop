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
    [Table("MOEDA", Schema = "DBO")]
    public class Moeda
    {
        [Key]
        [DisplayName("Id Moeda")]
        [Column("IDMOEDA")]
        public int IdMoeda { get; set; }

        [DisplayName("Descri��o")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("C�digo")]
        [Column("codigo")]
        public string Codigo { get; set; }

        public virtual ICollection<MoedaCotacao> MoedaCotacao { get; set; }
        public virtual ICollection<PedidoCompra> PedidoCompra { get; set; }
    }
}
