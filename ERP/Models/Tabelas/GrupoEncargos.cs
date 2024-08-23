using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("GRUPOENCARGOS", Schema = "DBO")]
    public class GrupoEncargos
    {
        [Key]
        [DisplayName("Id Grupo Encargos")]
        [Column("IDGRUPOENCARGOS")]
        public int IdGrupoEncargos { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; } 
    }
}
