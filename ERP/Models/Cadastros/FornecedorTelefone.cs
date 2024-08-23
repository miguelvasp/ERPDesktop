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
    [Table("FORNECEDORTELEFONE", Schema = "DBO")]
    public class FornecedorTelefone
    {
        [Key]
        [DisplayName("Id FornecedorTelefone")]
        [Column("IDFORNECEDORTELEFONE")]
        public int IdFornecedorTelefone { get; set; }

        [DisplayName("Id Fornecedor")]
        [Column("IDFORNECEDOR")]
        public int IdFornecedor { get; set; }

        [DisplayName("Id Telefone")]
        [Column("IDTELEFONE")]
        public int IdTelefone { get; set; }
        public virtual Telefone Telefone { get; set; }
    }
}
