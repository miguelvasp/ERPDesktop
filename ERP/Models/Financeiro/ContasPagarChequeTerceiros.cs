
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CONTASPAGARCHEQUETERCEIROS", Schema = "DBO")]
    public class ContasPagarChequeTerceiros
    {
        [Key]
        [DisplayName("IdContasPagarChequeTerceiro")]
        [Column("IDCONTASPAGARCHEQUETERCEIRO")]
        public int? IdContasPagarChequeTerceiro { get; set; }
 
        [DisplayName("IdContasPagar")]
        [Column("IDCONTASPAGAR")]
        public int? IdContasPagar { get; set; }
 
        [DisplayName("IdContasPagarBaixa")]
        [Column("IDCONTASPAGARBAIXA")]
        public int? IdContasPagarBaixa { get; set; }
 
        [DisplayName("IdChequeTerceiro")]
        [Column("IDCHEQUETERCEIRO")]
        public int? IdChequeTerceiro { get; set; }
 
    }
}
