
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CODIGOENCARGO", Schema = "DBO")]
    public class CodigoEncargo
    {
        [Key]
        [DisplayName("IdCodigoEncargo")]
        [Column("IDCODIGOENCARGO")]
        public int IdCodigoEncargo { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descricao")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Tipo")]
        [Column("TIPO")]
        public int? Tipo { get; set; }

        [DisplayName("IdGrupoImposto")]
        [Column("IDGRUPOIMPOSTO")]
        public int? IdGrupoImposto { get; set; }

        [DisplayName("LancamentoTipo")]
        [Column("LANCAMENTOTIPO")]
        public int? LancamentoTipo { get; set; }

        [DisplayName("IdContaContabilDebito")]
        [Column("IDCONTACONTABILDEBITO")]
        public int? IdContaContabilDebito { get; set; }

        [DisplayName("CreditoTipoLancamento")]
        [Column("CREDITOTIPOLANCAMENTO")]
        public int? CreditoTipoLancamento { get; set; }

        [DisplayName("IdContaContabilCredito")]
        [Column("IDCONTACONTABILCREDITO")]
        public int? IdContaContabilCredito { get; set; }

        [DisplayName("IncluiNotaFiscal")]
        [Column("INCLUINOTAFISCAL")]
        public bool? IncluiNotaFiscal { get; set; }

        [DisplayName("IncluiImpostos")]
        [Column("INCLUIIMPOSTOS")]
        public bool? IncluiImpostos { get; set; }

    }
}
