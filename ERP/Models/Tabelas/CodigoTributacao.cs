using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("CODIGOTRIBUTACAO", Schema = "DBO")]
    public class CodigoTributacao
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCODIGOTRIBUTACAO")]
        public int IdCodigoTributacao { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("De")]
        [Column("DE")]
        public DateTime? De { get; set; }

        [DisplayName("Até")]
        [Column("ATE")]
        public DateTime? Ate { get; set; }

        [DisplayName("Tipo Imposto")]
        [Column("TIPOIMPOSTO")]
        public int? TipoImposto { get; set; }

        [DisplayName("Valor Fiscal")]
        [Column("VALORFISCAL")]
        public int? ValorFiscal { get; set; }

        [DisplayName("Código Sped")]
        [Column("CODIGOSPED")]
        public string CodigoSped { get; set; }

        [DisplayName("Código Entrada")]
        [Column("CODIGOENTRADA")]
        public string CodigoEntrada { get; set; }

        [DisplayName("Código Saída")]
        [Column("CODIGOSAIDA")]
        public string CodigoSaida { get; set; }
    }
}
