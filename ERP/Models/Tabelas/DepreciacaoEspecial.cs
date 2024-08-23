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
    [Table("DEPRECIACAOESPECIAL", Schema = "DBO")]
    public class DepreciacaoEspecial
    {
        [Key]
        [DisplayName("Id Depreciação Especial")]
        [Column("IDDEPRECIACAOESPECIAL")]
        public int IdDepreciacaoEspecial { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Percentual de Exclusão")]
        [Column("PERCENTUALEXCLUSAO")]
        public decimal? PercentualExclusao { get; set; }
    }
}
