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
    [Table("VENDEDORMETAS", Schema = "DBO")]
    public class VendedorMetas
    {
        [Key]
        [DisplayName("IdMetaVendedor")]
        [Column("IDMETAVENDEDOR")]
        public int IdMetaVendedor { get; set; }

        [DisplayName("IdVendedor")]
        [Column("IDVENDEDOR")]
        public int IdVendedor { get; set; }

        [DisplayName("Sequencia")]
        [Column("SEQUENCIA")]
        public string Sequencia { get; set; }

        [DisplayName("ValorInicial")]
        [Column("VALORINICIAL")]
        public decimal ValorInicial { get; set; }

        [DisplayName("ValorFinal")]
        [Column("VALORFINAL")]
        public decimal ValorFinal { get; set; }

        [DisplayName("TipoMeta")]
        [Column("TIPOMETA")]
        public string TipoMeta { get; set; }

        [DisplayName("ValorPremio")]
        [Column("VALORPREMIO")]
        public decimal ValorPremio { get; set; }
    }
}
