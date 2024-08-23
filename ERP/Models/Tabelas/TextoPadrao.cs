
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("TEXTOPADRAO", Schema = "DBO")]
    public class TextoPadrao
    {
        [Key]
        [DisplayName("IdTextoPadrao")]
        [Column("IDTEXTOPADRAO")]
        public int IdTextoPadrao { get; set; }
 
        [DisplayName("C�digo")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descri��o")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Restri��o")]
        [Column("RESTRICAO")]
        public int? Restricao { get; set; }
 
        [DisplayName("Informa��es Fiscais")]
        [Column("INFORMACOESFISCAIS")]
        public bool InformacoesFiscais { get; set; }
 
        [DisplayName("Ag�ncia")]
        [Column("AGENCIA")]
        public int? Agencia { get; set; }
 
        [DisplayName("N�mero Processo")]
        [Column("NUMEROPROCESSO")]
        public string NumeroProcesso { get; set; } 
    }
}
