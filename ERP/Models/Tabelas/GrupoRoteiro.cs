using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("GRUPOROTEIRO", Schema = "DBO")]
    public class GrupoRoteiro
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDGRUPOROTEIRO")]
        public int IdGrupoRoteiro { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("CalcularTempoPreparacao")]
        [Column("CALCULARTEMPOPREPARACAO")]
        public bool CalcularTempoPreparacao { get; set; }
 
        [DisplayName("CalcularTempoExecusao")]
        [Column("CALCULARTEMPOEXECUSAO")]
        public bool CalcularTempoExecusao { get; set; }
 
        [DisplayName("CalcularQuantidade")]
        [Column("CALCULARQUANTIDADE")]
        public bool CalcularQuantidade { get; set; }
 
        [DisplayName("ConsumoAutomaticoTempoExecusao")]
        [Column("CONSUMOAUTOMATICOTEMPOEXECUSAO")]
        public bool ConsumoAutomaticoTempoExecusao { get; set; }
 
        [DisplayName("ConsumoAutomaticoTempoPreparacao")]
        [Column("CONSUMOAUTOMATICOTEMPOPREPARACAO")]
        public bool ConsumoAutomaticoTempoPreparacao { get; set; }
 
        [DisplayName("RelatarQuantidadeComoConcluida")]
        [Column("RELATARQUANTIDADECOMOCONCLUIDA")]
        public bool RelatarQuantidadeComoConcluida { get; set; }
 
        [DisplayName("RelatarOperacaoComoConcluida")]
        [Column("RELATAROPERACAOCOMOCONCLUIDA")]
        public bool RelatarOperacaoComoConcluida { get; set; }
     }
}
