
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("VWVENCIMENTOSRECEBIMENTOS", Schema = "DBO")]
    public class vwVencimentosrecebimentos
    {
        [Key]
        [DisplayName("IdContasReceberAberto")]
        [Column("IDCONTASRECEBERABERTO")]
        public int? IdContasReceberAberto { get; set; }
 
        [DisplayName("IdContasReceber")]
        [Column("IDCONTASRECEBER")]
        public int? IdContasReceber { get; set; }
 
        [DisplayName("RazaoSocial")]
        [Column("RAZAOSOCIAL")]
        public string RazaoSocial { get; set; }
 
        [DisplayName("Vencimento")]
        [Column("VENCIMENTO")]
        public DateTime? Vencimento { get; set; }
 
        [DisplayName("ValorLiquido")]
        [Column("VALORLIQUIDO")]
        public decimal? ValorLiquido { get; set; }
 
        [DisplayName("IdMetodoPagamento")]
        [Column("IDMETODOPAGAMENTO")]
        public int? IdMetodoPagamento { get; set; }
 
        [DisplayName("Documento")]
        [Column("DOCUMENTO")]
        public string Documento { get; set; }
 
        [DisplayName("IdCliente")]
        [Column("IDCLIENTE")]
        public int? IdCliente { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
        [DisplayName("Saldo")]
        [Column("SALDO")]
        public decimal? Saldo { get; set; }
 
    }
}
