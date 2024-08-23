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
    [Table("FORNECEDORCONTATO", Schema = "DBO")]
    public class FornecedorContato
    {
        [Key]
        [DisplayName("Id FornecedorContato")]
        [Column("IDFORNECEDORCONTATO")]
        public int IdFornecedorContato { get; set; }

        [DisplayName("Id Fornecedor")]
        [Column("IDFORNECEDOR")]
        public int IdFornecedor { get; set; }

        [DisplayName("Id Contato")]
        [Column("IDCONTATO")]
        public int IdContato { get; set; }
        public virtual Contato Contato { get; set; }
    }
}
