using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("DESCONTOAVISTA", Schema = "DBO")]
    public class DescontoaVista
    {
        [Key]
        [DisplayName("Id Desconto a Vista")]
        [Column("IDDESCONTOAVISTA")]
        public int IdDescontoaVista { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Cálculo")]
        [Column("CALCULO")]
        public int? Calculo { get; set; }

        [DisplayName("Meses")]
        [Column("MESES")]
        public int Meses { get; set; }

        [DisplayName("Dias")]
        [Column("DIAS")]
        public int Dias { get; set; }

        [DisplayName("Id Conta Contábil Cliente")]
        [Column("IDCONTACONTABILCLIENTE")]
        public int? IdContaContabilCliente { get; set; }

        [DisplayName("Id Conta Contábil Fornecedor")]
        [Column("IDCONTACONTABILFORNECEDOR")]
        public int? IdContaContabilFornecedor { get; set; }
    }
}
