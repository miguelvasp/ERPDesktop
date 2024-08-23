
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("PERFILPRODUCAO", Schema = "DBO")]
    public class PerfilProducao
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDPERFILPRODUCAO")]
        public int IdPerfilProducao { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
        [DisplayName("Lista Separação")]
        [Column("IDCONTABIL_LISTASEPARACAO")]
        public int? IdContabil_ListaSeparacao { get; set; }
 
        [DisplayName("Conta Partida Lista Separação")]
        [Column("IDCONTABIL_CONTAPARTIDALISTASEPARACAO")]
        public int? IdContabil_ContapartidaListaSeparacao { get; set; }
 
        [DisplayName("Relatório Conclusão")]
        [Column("IDCONTABIL_RELATORIOCONCLUSAO")]
        public int? IdContabil_RelatorioConclusao { get; set; }
 
        [DisplayName("Contra Partida Relatório Conclusão")]
        [Column("IDCONTABIL_CONTRAPARTIDARELATORIOCONCLUSAO")]
        public int? IdContabil_ContraPartidaRelatorioConclusao { get; set; }
 
        [DisplayName("Saída")]
        [Column("IDCONTABIL_SAIDA")]
        public int? IdContabil_Saida { get; set; }
 
        [DisplayName("Contra Partida Saída")]
        [Column("IDCONTABIL_CONTRAPARTIDASAIDA")]
        public int? IdContabil_ContrapartidaSaida { get; set; }
 
        [DisplayName("Recebimento")]
        [Column("IDCONTABIL_RECEBIMENTO")]
        public int? IdContabil_Recebimento { get; set; }
 
        [DisplayName("Contra Partida Recebimento")]
        [Column("IDCONTABIL_CONTRAPARTIDARECEBIMENTO")]
        public int? IdContabil_ContrapartidaRecebimento { get; set; }
 
        [DisplayName("Saída WIP")]
        [Column("IDCONTABIL_SAIDAWIP")]
        public int? IdContabil_SaidaWIP { get; set; }
 
        [DisplayName("Conta WIP")]
        [Column("IDCONTABIL_CONTAWIP")]
        public int? IdContabil_ContaWIP { get; set; }
 
    }
}
