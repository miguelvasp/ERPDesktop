
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CONTASRECEBERCHEQUETERCEIROS", Schema = "DBO")]
    public class ContasReceberChequeTerceiros
    {
        [Key]
        [DisplayName("IdContasReceberChequeTerceiro")]
        [Column("IDCONTASRECEBERCHEQUETERCEIRO")]
        public int? IdContasReceberChequeTerceiro { get; set; }
 
        [DisplayName("IdContasReceber")]
        [Column("IDCONTASRECEBER")]
        public int? IdContasReceber { get; set; }
 
        [DisplayName("IdContasReceberBaixa")]
        [Column("IDCONTASRECEBERBAIXA")]
        public int? IdContasReceberBaixa { get; set; }
 
        [DisplayName("IdChequeTerceiro")]
        [Column("IDCHEQUETERCEIRO")]
        public int? IdChequeTerceiro { get; set; }
 
    }
}
