using ERP.Util;
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
    [Table("TOTALDIMENSOES", Schema = "DBO")]
    public class TotalDimensoes
    {
        [Key]
        [DisplayName("Id Total Dimensões")]
        [Column("IDTOTALDIMENSOES")]
        public int IdTotalDimensoes { get; set; }

        [DisplayName("Id Valores Centro de Custo")]
        [Column("IDVALORESCENTROCUSTO")]
        public int IdValoresCentroCusto { get; set; }
        public virtual ValoresCentroCusto ValoresCentroCusto { get; set; }

        [DisplayName("Id Centro Custo (De)")]
        [Column("IDCENTROCUSTODE")]
        public int IdCentroCustoDe { get; set; }

        [DisplayName("Id Centro Custo (Até)")]
        [Column("IDCENTROCUSTOATE")]
        public int IdCentroCustoAte { get; set; }
    }
}
