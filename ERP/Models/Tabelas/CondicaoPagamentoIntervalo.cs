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
    [Table("CONDICAOPAGAMENTOINTERVALO", Schema = "DBO")]
    public class CondicaoPagamentoIntervalo
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDINTERVALO")]
        public int IdIntervalo { get; set; }
 
        [DisplayName("Id Condição de Pagamento")]
        [Column("IDCONDICAOPAGAMENTO")]
        public int IdCondicaoPagamento { get; set; }
        public virtual CondicaoPagamento CondicaoPagamento { get; set; }
 
        [DisplayName("Percentual")]
        [Column("PERCENTUAL")]
        public decimal Percentual { get; set; }

        [DisplayName("Dias")]
        [Column("DIAS")]
        public int Dias { get; set; }
     }
}
