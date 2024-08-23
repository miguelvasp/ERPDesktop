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
    [Table("SEGMENTO", Schema = "DBO")]
    public class Segmento  
    {
        [Key]
        [DisplayName("Id Segmento")]
        [Column("IDSEGMENTO")]
        public int IdSegmento { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Id Próximo Segmento")]
        [Column("IDPROXIMOSEGMENTO")]
        public int? IdProximoSegmento { get; set; }

        [DisplayName("Obrigatório")]
        [Column("OBRIGATORIO")]
        public bool Obrigatorio { get; set; }

        public virtual ICollection<SubSegmento> SubSegmento { get; set; }
    }
}
