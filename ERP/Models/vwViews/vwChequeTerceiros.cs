
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("VWCHEQUETERCEIROS", Schema = "DBO")]
    public class vwChequeTerceiros
    {
        [Key]
        [DisplayName("IdChequeTerceiro")]
        [Column("IDCHEQUETERCEIRO")]
        public int? IdChequeTerceiro { get; set; }
 
        [DisplayName("Origem")]
        [Column("ORIGEM")]
        public string Origem { get; set; }
 
        [DisplayName("RazaoSocial")]
        [Column("RAZAOSOCIAL")]
        public string RazaoSocial { get; set; }
 
        [DisplayName("DataPagamento")]
        [Column("DATAPAGAMENTO")]
        public DateTime? DataPagamento { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
        [DisplayName("NomeBanco")]
        [Column("NOMEBANCO")]
        public string NomeBanco { get; set; }
 
        [DisplayName("Agencia")]
        [Column("AGENCIA")]
        public string Agencia { get; set; }
 
        [DisplayName("Conta")]
        [Column("CONTA")]
        public string Conta { get; set; }
 
        [DisplayName("NumeroCheque")]
        [Column("NUMEROCHEQUE")]
        public string NumeroCheque { get; set; }
 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }
 
        [DisplayName("Status")]
        [Column("STATUS")]
        public string Status { get; set; }

        [Column("DATACOMPENSACAO")]
        public DateTime? DataCompensacao { get; set; }
 
    }
}
