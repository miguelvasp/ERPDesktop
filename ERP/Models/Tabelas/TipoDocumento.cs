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
    [Table("TIPODOCUMENTO", Schema = "DBO")]
    public class TipoDocumento
    {
        [Key]
        [DisplayName("IdDocumento")]
        [Column("IDDOCUMENTO")]
        public int IdDocumento { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        public virtual ICollection<NotaFiscal> NotaFiscal { get; set; }
    }
}
