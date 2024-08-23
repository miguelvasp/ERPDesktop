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
    [Table("TIPOPRODUTO", Schema = "DBO")]
    public class TipoProduto
    {
        [Key]
        [DisplayName("Id Tipo Produto")]
        [Column("IDTIPOPRODUTO")]
        public int IdTipoProduto { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        public virtual ICollection<Produto> Produto { get; set; }
    }
}
