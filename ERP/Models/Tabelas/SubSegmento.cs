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
    [Table("SUBSEGMENTO", Schema = "DBO")]
    public class SubSegmento
    {
        [Key]
        [DisplayName("Id SubSegmento")]
        [Column("IDSUBSEGMENTO")]
        public int IdSubSegmento { get; set; }

        [DisplayName("Id Segmento")]
        [Column("IDSEGMENTO")]
        public int IdSegmento { get; set; }
        public virtual Segmento Segmento { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
