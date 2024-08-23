using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("GRUPOATIVO", Schema = "DBO")]
    public class GrupoAtivo
    {
        [Key]
        [DisplayName("Id Grupo de Ativos")]
        [Column("IDGRUPOATIVO")]
        public int IdGrupoAtivo { get; set; }
 
        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }
 
        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Tipo")]
        [Column("TIPO")]
        public int? Tipo { get; set; }
 
        [DisplayName("SequenciaAtivo")]
        [Column("SEQUENCIAATIVO")]
        public string SequenciaAtivo { get; set; }
 
        [DisplayName("Numerar Código de Barras")]
        [Column("NUMERARCODIGOBARRAS")]
        public bool NumerarCodigoBarras { get; set; }
 
        [DisplayName("Sequencia Código de Barras")]
        [Column("SEQUENCIACODIGOBARRAS")]
        public string SequenciaCodigoBarras { get; set; }
 
        [DisplayName("Tipo de Propriedade")]
        [Column("TIPOPROPRIEDADE")]
        public int? TipoPropriedade { get; set; }
 
        [DisplayName("Limite Capitalização")]
        [Column("LIMITECAPITALIZACAO")]
        public decimal? LimiteCapitalizacao { get; set; }
 
        [DisplayName("Crédito ICMS")]
        [Column("CREDITOICMS")]
        public bool CreditoICMS { get; set; }
 
        [DisplayName("CreditoPisCofins")]
        [Column("CREDITOPISCOFINS")]
        public bool CreditoPisCofins { get; set; }
 
        [DisplayName("Parcelas do Crédito")]
        [Column("PARCELASDOCREDITO")]
        public int? ParcelasDoCredito { get; set; }
 
    }
}
