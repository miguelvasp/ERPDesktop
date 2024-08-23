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
    [Table("CODIGOFATURAMENTO", Schema = "DBO")]
    public class CodigoFaturamento
    {
        [Key]
        [DisplayName("Id CFOP")]
        [Column("IDCFOP")]
        public int IdCFOP { get; set; }

        [DisplayName("CFOP")]
        [Column("CFOP")]
        public string CFOP { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Descrição Complementar")]
        [Column("DESCRICAOCOMPLEMENTAR")]
        public string DescricaoComplementar { get; set; }

        [DisplayName("ICMS Tributação")]
        [Column("ICMSTRIBUTACAO")]
        public string ICMSTributacao { get; set; }

        [DisplayName("ICMS Redução")]
        [Column("ICMSREDUCAO")]
        public decimal ICMSReducao { get; set; }

        [DisplayName("FormaCalculo")]
        [Column("FORMACALCULO")]
        public bool FormaCalculo { get; set; }

        [DisplayName("IPIIncide")]
        [Column("IPIINCIDE")]
        public bool IPIIncide { get; set; }

        [DisplayName("IPITributacao")]
        [Column("IPITRIBUTACAO")]
        public bool IPITributacao { get; set; }

        [DisplayName("ISSIncide")]
        [Column("ISSINCIDE")]
        public bool ISSIncide { get; set; }

        [DisplayName("ISSAliquota")]
        [Column("ISSALIQUOTA")]
        public decimal ISSAliquota { get; set; }

        [DisplayName("PISCST")]
        [Column("PISCST")]
        public string PISCST { get; set; }

        [DisplayName("PISAliquota")]
        [Column("PISALIQUOTA")]
        public decimal PISAliquota { get; set; }

        [DisplayName("CofinsCST")]
        [Column("COFINSCST")]
        public string CofinsCST { get; set; }

        [DisplayName("CofinsAliquota")]
        [Column("COFINSALIQUOTA")]
        public decimal CofinsAliquota { get; set; }

        [DisplayName("Texto1")]
        [Column("TEXTO1")]
        public string Texto1 { get; set; }

        [DisplayName("Texto2")]
        [Column("TEXTO2")]
        public string Texto2 { get; set; }

        public virtual ICollection<NotaFiscal> NotaFiscal { get; set; }
    }
}
