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
    [Table("FUNCIONARIO", Schema = "DBO")]
    public class Funcionario
    {
        [Key]
        [DisplayName("Id Funcionário")]
        [Column("IDFUNCIONARIO")]
        public int IdFuncionario { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Nome Fantasia")]
        [Column("NOMEFANTASIA")]
        public string NomeFantasia { get; set; }

        [DisplayName("CPF")]
        [Column("CPF")]
        public string CPF { get; set; }

        [DisplayName("RG")]
        [Column("RG")]
        public string RG { get; set; }
        
        [DisplayName("EMail")]
        [Column("EMAIL")]
        public string EMail { get; set; }

        [DisplayName("Id Vendedor")]
        [Column("IDVENDEDOR")]
        public int? IdVendedor { get; set; }

        [DisplayName("Id Fornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }

        [Column("TELEVENDAS")]
        public bool? Televendas { get; set; }
    }
}
