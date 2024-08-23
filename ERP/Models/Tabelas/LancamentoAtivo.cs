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
    [Table("LANCAMENTOATIVO", Schema = "DBO")]
    public class LancamentoAtivo
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDLANCAMENTOATIVO")]
        public int IdLancamentoAtivo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Tipo de Conta Ativo")]
        [Column("TIPOCONTAATIVO")]
        public int? TipoContaAtivo { get; set; }

        [DisplayName("Relação Ativo")]
        [Column("RELACAOATIVO")]
        public int? RelacaoAtivo { get; set; }

        [DisplayName("Id Ativo")]
        [Column("IDATIVO")]
        public int? IdAtivo { get; set; }

        [DisplayName("Id Grupo Ativo")]
        [Column("IDGRUPOATIVO")]
        public int? IdGrupoAtivo { get; set; }
        public virtual GrupoAtivo GrupoAtivo { get; set; }

        [DisplayName("Relação Operação")]
        [Column("RELACAOOPERACAO")]
        public int? RelacaoOperacao { get; set; }

        [DisplayName("Id Operação")]
        [Column("IDOPERACAO")]
        public int? IdOperacao { get; set; }
        public virtual Operacao Operacao { get; set; }

        [DisplayName("Relação Valores")]
        [Column("RELACAOVALORES")]
        public int? RelacaoValores { get; set; }

        [DisplayName("Id Conta Contábil Partida")]
        [Column("IDCONTACONTABILPARTIDA")]
        public int? IdContaContabilPartida { get; set; }

        [DisplayName("Id Conta Contábil Contra Partida")]
        [Column("IDCONTACONTABILCONTRAPARTIDA")]
        public int? IdContaContabilContraPartida { get; set; }
    }
}
