using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    [Table("TIPOITEM", Schema = "DBO")]
    public class TipoItem
    {
        [Key]
        [DisplayName("IdTipoItem")]
        [Column("IDTIPOITEM")]
        public int IdTipoItem { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

    }
}
