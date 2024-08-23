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
    [Table("GRUPOLANCAMENTOCONTABIL", Schema = "DBO")]
    public class GrupoLancamentoContabil
    {
        [Key]
        [DisplayName("Id Grupo Lançamento Contábil")]
        [Column("IDGRUPOLANCAMENTOCONTABIL")]
        public int IdGrupoLancamentoContabil { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Id Imposto a Pagar")]
        [Column("IDIMPOSTOAPAGAR")]
        public int? IdImpostoAPagar { get; set; }

        [DisplayName("Id Despesa Com Imposto")]
        [Column("IDDESPESACOMIMPOSTO")]
        public int? IdDespesaComImposto { get; set; }

        [DisplayName("Id Imposto a Receber")]
        [Column("IDIMPOSTOARECEBER")]
        public int? IdImpostoAReceber { get; set; }

        [DisplayName("Id Despesas Imposto Uso")]
        [Column("IDDESPESASIMPOSTOUSO")]
        public int? IdDespesasImpostoUso { get; set; }

        [DisplayName("Id Imposto Sobre o Uso Pagar")]
        [Column("IDIMPOSTOSOBREOUSOPAGAR")]
        public int? IdImpostoSobreOUsoPagar { get; set; }

        [DisplayName("Id Conta Liquidação")]
        [Column("IDCONTALIQUIDACAO")]
        public int? IdContaLiquidacao { get; set; }

        [DisplayName("Id Imposto Receber Longo Prazo")]
        [Column("IDIMPOSTORECEBERLONGOPRAZO")]
        public int? IdImpostoReceberLongoPrazo { get; set; }

        [DisplayName("Id Imposto Receber Curto Prazo")]
        [Column("IDIMPOSTORECEBERCURTOPRAZO")]
        public int? IdImpostoReceberCurtoPrazo { get; set; }
    }
}
