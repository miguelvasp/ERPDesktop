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
    [Table("FORNECEDORCONTABANCARIA", Schema = "DBO")]
    public class FornecedorContaBancaria
    {
        [Key]
        [DisplayName("Id Fornecedor Conta Bancária")]
        [Column("IDFORNECEDORCONTABANCARIA")]
        public int IdFornecedorContaBancaria { get; set; }
        
        [DisplayName("Id Fornecedor")]
        [Column("IDFORNECEDOR")]
        public int IdFornecedor { get; set; }

        [DisplayName("Id Conta Bancária")]
        [Column("IDCONTABANCARIA")]
        public int IdContaBancaria { get; set; }
        public virtual ContaBancaria ContaBancaria { get; set; } 
    }
}
