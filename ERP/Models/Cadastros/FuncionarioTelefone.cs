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
    [Table("FUNCIONARIOTELEFONE", Schema = "DBO")]
    public class FuncionarioTelefone
    {
        [Key]
        [DisplayName("Id Funcionário Telefone")]
        [Column("IDFUNCIONARIOTELEFONE")]
        public int IdFuncionarioTelefone { get; set; }

        [DisplayName("Id Funcionário")]
        [Column("IDFUNCIONARIO")]
        public int IdFuncionario { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        [DisplayName("Id Telefone")]
        [Column("IDTELEFONE")]
        public int IdTelefone { get; set; }
        public virtual Telefone Telefone { get; set; }
    }
}
