
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("APROVACAODOCUMENTO", Schema = "DBO")]
    public class AprovacaoDocumento
    {
        [Key]
        [DisplayName("IdAprovacaoDocumento")]
        [Column("IDAPROVACAODOCUMENTO")]
        public int IdAprovacaoDocumento { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
        [DisplayName("Sigla")]
        [Column("SIGLA")]
        public string Sigla { get; set; }
 
    }
}
