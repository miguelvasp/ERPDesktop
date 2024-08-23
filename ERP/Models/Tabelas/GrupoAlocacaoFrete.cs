using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("GRUPOALOCACAOFRETE", Schema = "DBO")]
    public class GrupoAlocacaoFrete
    {
        [Key]
        [DisplayName("IdGrupoAlocacaoFrete")]
        [Column("IDGRUPOALOCACAOFRETE")]
        public int IdGrupoAlocacaoFrete { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
    }
}
