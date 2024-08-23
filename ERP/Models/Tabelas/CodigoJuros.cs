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
    [Table("CODIGOJUROS", Schema = "DBO")]
    public class CodigoJuros
    {
        [Key]
        [DisplayName("Id Código de Juros")]
        [Column("IDCODIGOJUROS")]
        public int IdCodigoJuros { get; set; }

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

        [DisplayName("Cálculo")]
        [Column("CALCULO")]
        public decimal Calculo { get; set; }

        [DisplayName("Dia/Mês")]
        [Column("DIAMES")]
        public int? DiaMes { get; set; }
    }
}
