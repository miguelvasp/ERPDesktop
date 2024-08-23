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
    [Table("TIPOENDERECO", Schema = "DBO")]
    public class TipoEndereco
    {
        [Key]
        [DisplayName("Id Tipo Endereco")]
        [Column("IDTIPOENDERECO")]
        public int IdTipoEndereco { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        public virtual ICollection<Endereco> Endereco { get; set; }
    }
}
