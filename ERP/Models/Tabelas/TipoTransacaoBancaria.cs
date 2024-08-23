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
    [Table("TIPOTRANSACAOBANCARIA", Schema = "DBO")]
    public class TipoTransacaoBancaria
    {
        [Key]
        [DisplayName("Id Tipo Transação Bancária")]
        [Column("IDTIPOTRANSACAOBANCARIA")]
        public int IdTipoTransacaoBancaria { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
