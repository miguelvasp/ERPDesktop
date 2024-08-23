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
    [Table("GRUPOVENDAS", Schema = "DBO")]
    public class GrupoVendas
    {
        [Key]
        [DisplayName("Id Grupo de Vendas")]
        [Column("IDGRUPOVENDAS")]
        public int IdGrupoVendas { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
