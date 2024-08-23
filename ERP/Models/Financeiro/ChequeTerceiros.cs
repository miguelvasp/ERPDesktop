
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CHEQUETERCEIROS", Schema = "DBO")]
    public class ChequeTerceiros
    {
        [Key]
        [DisplayName("IdChequeTerceiro")]
        [Column("IDCHEQUETERCEIRO")]
        public int IdChequeTerceiro { get; set; }
 
        [DisplayName("IdBanco")]
        [Column("IDBANCO")]
        public int? IdBanco { get; set; }
 
        [DisplayName("Agencia")]
        [Column("AGENCIA")]
        public string Agencia { get; set; }
 
        [DisplayName("Conta")]
        [Column("CONTA")]
        public string Conta { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
        [DisplayName("CPF")]
        [Column("CPF")]
        public string CPF { get; set; }
 
        [DisplayName("NumeroCheque")]
        [Column("NUMEROCHEQUE")]
        public string NumeroCheque { get; set; }
 
        [DisplayName("Emissao")]
        [Column("EMISSAO")]
        public DateTime? Emissao { get; set; }
 
        [DisplayName("DataCompensacao")]
        [Column("DATACOMPENSACAO")]
        public DateTime? DataCompensacao { get; set; }
 
        [DisplayName("Status")]
        [Column("STATUS")]
        public int? Status { get; set; }
 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }

        [Column("IDCONTASPAGARBAIXA")]
        public int? IdContasPagarBaixa { get; set; }

        [Column("IDCONTASRECEBERBAIXA")]
        public int? IdContasReceberBaixa { get; set; }
    }
}
