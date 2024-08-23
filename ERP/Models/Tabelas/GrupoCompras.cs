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
    [Table("GRUPOCOMPRAS", Schema = "DBO")]
    public class GrupoCompras
    {
        [Key]
        [DisplayName("Id Grupo de Compras")]
        [Column("IDGRUPOCOMPRAS")]
        public int IdGrupoCompras { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
