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
    [Table("GRUPOCOMISSAO", Schema = "DBO")]
    public class GrupoComissao
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDGRUPOCOMISSAO")]
        public int IdGrupoComissao { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
