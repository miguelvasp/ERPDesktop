using ERP.Util;
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
    [Table("VALORESCENTROCUSTO", Schema = "DBO")]
    public class ValoresCentroCusto
    {
        [Key]
        [DisplayName("Id Valores Centro de Custo")]
        [Column("IDVALORESCENTROCUSTO")]
        public int IdValoresCentroCusto { get; set; }

        [DisplayName("Id Centro de Custo")]
        [Column("IDCENTROCUSTO")]
        public int IdCentroCusto { get; set; }
        public virtual CentroCusto CentroCusto { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Data Início")]
        [Column("DATAINICIO")]
        public DateTime DataInicio { get; set; }

        [DisplayName("Data Final")]
        [Column("DATAFINAL")]
        public DateTime DataFinal { get; set; }

        [DisplayName("Dimensão Totalizadora")]
        [Column("DIMENSAOTOTALIZADORA")]
        public bool DimensaoTotalizadora { get; set; }
    }
}
