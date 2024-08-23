
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("VWTABELAORCAMENTO", Schema = "DBO")]
    public class vwTabelaOrcamento
    {
        [Key]
        [DisplayName("CODIGO1")]
        [Column("CODIGO1")]
        public string CODIGO1 { get; set; }
 
        [DisplayName("CODIGO1semZero")]
        [Column("CODIGO1SEMZERO")]
        public string CODIGO1semZero { get; set; }
 
        [DisplayName("CODIGO1semSimbolos")]
        [Column("CODIGO1SEMSIMBOLOS")]
        public string CODIGO1semSimbolos { get; set; }
 
        [DisplayName("CODIGO2")]
        [Column("CODIGO2")]
        public string CODIGO2 { get; set; }
 
        [DisplayName("CODIGO2semZero")]
        [Column("CODIGO2SEMZERO")]
        public string CODIGO2semZero { get; set; }
 
        [DisplayName("CODIGO2semSimbolos")]
        [Column("CODIGO2SEMSIMBOLOS")]
        public string CODIGO2semSimbolos { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
        [DisplayName("Descricao")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
    }
}
