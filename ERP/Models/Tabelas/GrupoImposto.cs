using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("GRUPOIMPOSTO", Schema = "DBO")]
    public class GrupoImposto
    {
        [Key]
        [DisplayName("IdGrupoImposto")]
        [Column("IDGRUPOIMPOSTO")]
        public int IdGrupoImposto { get; set; }

        [DisplayName("Código Grupo Imposto")]
        [Column("CODIGOGRUPOIMPOSTO")]
        public string CodigoGrupoImposto { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Reverter Imposto Desconto a Vista")]
        [Column("REVERTERIMPOSTODESCONTOAVISTA")]
        public bool ReverterImpostoDescontoAVista { get; set; }

        
    }
}
