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
    [Table("LINHANEGOCIO", Schema = "DBO")]
    public class LinhaNegocio
    {
        [Key]
        [DisplayName("Id Linha de Negócio")]
        [Column("IDLINHANEGOCIO")]
        public int IdLinhaNegocio { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
