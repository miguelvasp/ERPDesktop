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
    [Table("TIPOOPERACAOBANCARIA", Schema = "DBO")]
    public class TipoOperacaoBancaria
    {
        [Key]
        [DisplayName("Id Tipo Operação Bancária")]
        [Column("IDTIPOOPERACAOBANCARIA")]
        public int IdTipoOperacaoBancaria { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Id Conta Contábil")]
        [Column("IDCONTACONTABIL")]
        public int? IdContaContabil { get; set; }
        public virtual ContaContabil ContaContabil { get; set; }
    }
}
