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
    [Table("CLASSIFICACAOFISCAL", Schema = "DBO")]
    public class ClassificacaoFiscal
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDNCM")]
        public int IdNCM { get; set; }

        [DisplayName("NCM")]
        [Column("NCM")]
        public string NCM { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("IPI")]
        [Column("IPI")]
        public decimal IPI { get; set; }

        [DisplayName("Id CEST")]
        [Column("IdCest")]
        public int? IdCest { get; set; }
                       
    }
}
