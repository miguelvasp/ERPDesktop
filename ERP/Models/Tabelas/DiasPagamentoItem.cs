
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("DIASPAGAMENTOITEM", Schema = "DBO")]
    public class DiasPagamentoItem
    {
        [Key]
        [DisplayName("IdDiasPagamentoItem")]
        [Column("IDDIASPAGAMENTOITEM")]
        public int IdDiasPagamentoItem { get; set; }
 
        [DisplayName("IdDiasPagamento")]
        [Column("IDDIASPAGAMENTO")]
        public int? IdDiasPagamento { get; set; }
 
        [DisplayName("SemanaMes")]
        [Column("SEMANAMES")]
        public int? SemanaMes { get; set; }
 
        [DisplayName("DiaSemana")]
        [Column("DIASEMANA")]
        public int? DiaSemana { get; set; }
 
        [DisplayName("DiaMes")]
        [Column("DIAMES")]
        public int? DiaMes { get; set; }
 
    }
}
