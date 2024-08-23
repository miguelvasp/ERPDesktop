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
    [Table("METODOPAGAMENTO", Schema = "DBO")]
    public class MetodoPagamento
    {
        [Key]
        [DisplayName("Id Método Pagamento")]
        [Column("IDMETODOPAGAMENTO")]
        public int IdMetodoPagamento { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Período")]
        [Column("Periodo")]
        public int Periodo { get; set; }

        [DisplayName("Carência")]
        [Column("CARENCIA")]
        public int Carencia { get; set; }

        [DisplayName("Status de Pagamento")]
        [Column("STATUSPAGAMENTO")]
        public int StatusPagamento { get; set; }

        [DisplayName("Tipo de Pagamento")]
        [Column("TIPOPAGAMENTO")]
        public int TipoPagamento { get; set; }

        [DisplayName("Tipo de Conta")]
        [Column("TIPOCONTA")]
        public int TipoConta { get; set; }

        [DisplayName("Id Banco")]
        [Column("IDBANCO")]
        public int? IdBanco { get; set; }
        public virtual Banco Banco { get; set; }

        [DisplayName("Id Conta Contábil")]
        [Column("IDCONTACONTABIL")]
        public int? IdContaContabil { get; set; }
        public virtual ContaContabil ContaContabil { get; set; }

        [DisplayName("Id Cliente")]
        [Column("IDCLIENTE")]
        public int? IdCliente { get; set; }

        [DisplayName("Id Fornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }

        [DisplayName("Id Tipo Transação Bancária")]
        [Column("IDTIPOTRANSACAOBANCARIA")]
        public int? IdTipoTransacaoBancaria { get; set; }
        public virtual TipoTransacaoBancaria TipoTransacaoBancaria { get; set; }
        
        [DisplayName("Lançamento de Transição")]
        [Column("LANCAMENTOTRANSICAO")]
        public bool? LancamentoTransicao { get; set; }

        [DisplayName("Lançamento Compesação de Cheque")]
        [Column("LANCAMENTOCOMPESACAOCHEQUE")]
        public bool? LancamentoCompesacaoCheque { get; set; }

        [DisplayName("Id Conta Transição")]
        [Column("IDCONTATRANSICAO")]
        public int? IdContaTransicao { get; set; }
//        public virtual ContaContabil ContaTransicao { get; set; }

        [DisplayName("Id Grupo Layout Exportação")]
        [Column("IDGRUPOLAYOUTEXPORTACAO")]
        public int? IdGrupoLayoutExportacao { get; set; }
//        public virtual ContaContabil GrupoLayoutExportacao { get; set; }

        [DisplayName("Id Grupo Layout Retorno")]
        [Column("IDGRUPOLAYOUTRETORNO")]
        public int? IdGrupoLayoutRetorno { get; set; }
//        public virtual ContaContabil GrupoLayoutRetorno { get; set; }
    }
}
