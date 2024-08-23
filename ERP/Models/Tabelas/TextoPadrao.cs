
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
 
        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Restrição")]
        [Column("RESTRICAO")]
        public int? Restricao { get; set; }
 
        [DisplayName("Informações Fiscais")]
        [Column("INFORMACOESFISCAIS")]
        public bool InformacoesFiscais { get; set; }
 
        [DisplayName("Agência")]
        [Column("AGENCIA")]
        public int? Agencia { get; set; }
 
        [DisplayName("Número Processo")]
        [Column("NUMEROPROCESSO")]
        public string NumeroProcesso { get; set; } 
    }
}
