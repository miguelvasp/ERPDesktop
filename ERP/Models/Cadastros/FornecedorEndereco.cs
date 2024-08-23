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
    [Table("FORNECEDORENDERECO", Schema = "DBO")]
    public class FornecedorEndereco
    {
        [Key]
        [DisplayName("Id Fornecedor Endereço")]
        [Column("IDFORNECEDORENDERECO")]
        public int IdFornecedorEndereco { get; set; }

        [DisplayName("Id Fornecedor")]
        [Column("IDFORNECEDOR")]
        public int IdFornecedor { get; set; }

        [DisplayName("Id Endereco")]
        [Column("IDENDERECO")]
        public int IdEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
