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
 
        [DisplayName("C�digo")]
        [Column("CODIGO")]
        public string Codigo { get; set; }
 
        [DisplayName("Descri��o")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Tipo")]
        [Column("TIPO")]
        public int? Tipo { get; set; }
 
        [DisplayName("SequenciaAtivo")]
        [Column("SEQUENCIAATIVO")]
        public string SequenciaAtivo { get; set; }
 
        [DisplayName("Numerar C�digo de Barras")]
        [Column("NUMERARCODIGOBARRAS")]
        public bool NumerarCodigoBarras { get; set; }
 
        [DisplayName("Sequencia C�digo de Barras")]
        [Column("SEQUENCIACODIGOBARRAS")]
        public string SequenciaCodigoBarras { get; set; }
 
        [DisplayName("Tipo de Propriedade")]
        [Column("TIPOPROPRIEDADE")]
        public int? TipoPropriedade { get; set; }
 
        [DisplayName("Limite Capitaliza��o")]
        [Column("LIMITECAPITALIZACAO")]
        public decimal? LimiteCapitalizacao { get; set; }
 
        [DisplayName("Cr�dito ICMS")]
        [Column("CREDITOICMS")]
        public bool CreditoICMS { get; set; }
 
        [DisplayName("CreditoPisCofins")]
        [Column("CREDITOPISCOFINS")]
        public bool CreditoPisCofins { get; set; }
 
        [DisplayName("Parcelas do Cr�dito")]
        [Column("PARCELASDOCREDITO")]
        public int? ParcelasDoCredito { get; set; }
 
    }
}
