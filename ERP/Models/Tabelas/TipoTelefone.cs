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
    [Table("TIPOTELEFONE", Schema = "DBO")]
    public class TipoTelefone
    {
        [Key]
        [DisplayName("Id Tipo Telefone")]
        [Column("IDTIPOTELEFONE")]
        public int IdTipoTelefone { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        public virtual ICollection<Telefone> Telefone { get; set; }
    }
}
