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
    public class CodigoMultas
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCODIGOMULTAS")]
        public int IdCodigoMultas { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
        
        [DisplayName("Dias")]
        [Column("DIAS")]
        public int Dias { get; set; }

        [DisplayName("Percentual")]
        [Column("PERCENTUAL")]
        public decimal Percentual { get; set; }
    }
}
