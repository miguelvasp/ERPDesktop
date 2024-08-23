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
    [Table("UNIDADE", Schema = "DBO")]
    public class Unidade
    {
        [Key]
        [DisplayName("Id Unidade")]
        [Column("IDUNIDADE")]
        public int IdUnidade { get; set; }

        [DisplayName("Unidade de Medida")]
        [Column("UNIDADEMEDIDA")]
        public string UnidadeMedida { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        public virtual ICollection<NotaFiscalItem> NotaFiscalItem { get; set; }
    }
}
