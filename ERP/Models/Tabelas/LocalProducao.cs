using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("LOCALPRODUCAO", Schema = "DBO")]
    public class LocalProducao
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDLOCALPRODUCAO")]
        public int IdLocalProducao { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Id Armazém")]
        [Column("IDARMAZEM")]
        public int? IdArmazem { get; set; }
 
        [DisplayName("IdDepositoEntrada")]
        [Column("IDDEPOSITOENTRADA")]
        public int? IdDepositoEntrada { get; set; }
 
        [DisplayName("IdDepositoSaida")]
        [Column("IDDEPOSITOSAIDA")]
        public int? IdDepositoSaida { get; set; }
 
    }
}
