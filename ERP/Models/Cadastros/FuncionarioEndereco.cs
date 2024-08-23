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
    [Table("FUNCIONARIOENDERECO", Schema = "DBO")]
    public class FuncionarioEndereco
    {
        [Key]
        [DisplayName("Id Funcionário Endereço")]
        [Column("IDFUNCIONARIOENDERECO")]
        public int IdFuncionarioEndereco { get; set; }

        [DisplayName("Id Funcionário")]
        [Column("IDFUNCIONARIO")]
        public int IdFuncionario { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        [DisplayName("Id Endereço")]
        [Column("IDENDERECO")]
        public int IdEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
