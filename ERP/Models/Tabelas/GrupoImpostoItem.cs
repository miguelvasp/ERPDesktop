using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("GRUPOIMPOSTOITEM", Schema = "DBO")]
    public class GrupoImpostoItem
    {
        [Key]
        [DisplayName("Id Grupo Imposto Item")]
        [Column("IDGRUPOIMPOSTOITEM")]
        public int IdGrupoImpostoItem { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
