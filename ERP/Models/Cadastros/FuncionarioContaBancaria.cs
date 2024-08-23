using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("FUNCIONARIOCONTABANCARIA", Schema = "DBO")]
    public class FuncionarioContaBancaria
    {
        [Key]
        [DisplayName("Id Funcionario Conta Bancária")]
        [Column("IDFUNCIONARIOCONTABANCARIA")]
        public int IdFuncionarioContaBancaria { get; set; }

        [DisplayName("Id Funcionario")]
        [Column("IDFUNCIONARIO")]
        public int IdFuncionario { get; set; }

        [DisplayName("Id Conta Bancária")]
        [Column("IDCONTABANCARIA")]
        public int IdContaBancaria { get; set; }
        public virtual ContaBancaria ContaBancaria { get; set; }
    }
}
