using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("CORREDOR", Schema = "DBO")]
    public class Corredor
    {
        [Key]
        [DisplayName("Id Corredor")]
        [Column("IDCORREDOR")]
        public int IdCorredor { get; set; }

        [DisplayName("Id Depósito")]
        [Column("IDDEPOSITO")]
        public int IdDeposito { get; set; }
        public virtual Deposito Deposito { get; set; }

        [DisplayName("Corredor")]
        [Column("CORREDORLOCAL")]
        public string CorredorLocal { get; set; }

        [DisplayName("Número do Corredor")]
        [Column("NUMEROCORREDOR")]
        public string NumeroCorredor { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
    }
}
