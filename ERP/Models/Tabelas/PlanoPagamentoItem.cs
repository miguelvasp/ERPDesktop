
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PLANOPAGAMENTOITEM", Schema = "DBO")]
    public class PlanoPagamentoItem
    {
        [Key]
        [DisplayName("IdPlanoPagamentoItem")]
        [Column("IDPLANOPAGAMENTOITEM")]
        public int IdPlanoPagamentoItem { get; set; }
 
        [DisplayName("IdPlanoPagamento")]
        [Column("IDPLANOPAGAMENTO")]
        public int IdPlanoPagamento { get; set; }
 
        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal? Quantidade { get; set; }
 
        [DisplayName("ValorTransacao")]
        [Column("VALORTRANSACAO")]
        public decimal? ValorTransacao { get; set; }
 
        [DisplayName("PorcentagemValor")]
        [Column("PORCENTAGEMVALOR")]
        public int? PorcentagemValor { get; set; }
 
    }
}
