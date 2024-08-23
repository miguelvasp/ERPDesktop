
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CFPS", Schema = "DBO")]
    public class CFPS
    {
        [Key]
        [DisplayName("IdCFPS")]
        [Column("IDCFPS")]
        public int IdCFPS { get; set; }
 
        [DisplayName("CFPS")]
        [Column("CFPSCOD")]
        public string CFPSCod { get; set; }
 
        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Tipo de Transação")]
        [Column("TIPOTRANSACAO")]
        public int TipoTransacao { get; set; } 
    }
}
