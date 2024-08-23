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
    [Table("PERFILDEPRECIACAO", Schema = "DBO")]
    public class PerfilDepreciacao
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDPERFILDEPRECIACAO")]
        public int IdPerfilDepreciacao { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Método de Cálculo")]
        [Column("METODOCALCULO")]
        public int? MetodoCalculo { get; set; }

        [DisplayName("Frequência")]
        [Column("FREQUENCIA")]
        public int? Frequencia { get; set; }
    }
}
