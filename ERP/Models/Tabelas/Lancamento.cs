using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("LANCAMENTO", Schema = "DBO")]
    public class Lancamento
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDLANCAMENTO")]
        public int IdLancamento { get; set; }

        [DisplayName("Id Tipo Lancamento")]
        [Column("IDTIPOLANCAMENTO")]
        public int IdTipoLancamento { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Tipo de Conta")]
        [Column("TIPOCONTA")]
        public int? TipoConta { get; set; }

        [DisplayName("Relação de Item")]
        [Column("RELACAOITEM")]
        public int? RelacaoItem { get; set; }

        [DisplayName("Relação de Grupo")]
        [Column("RELACAOGRUPO")]
        public int? RelacaoGrupo { get; set; }

        [DisplayName("Id Produto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        [DisplayName("Id Grupo Produto")]
        [Column("IDGRUPOPRODUTO")]
        public int? IdGrupoProduto { get; set; }
        public virtual GrupoProduto GrupoProduto { get; set; }

        [DisplayName("Id Cliente")]
        [Column("IDCLIENTE")]
        public int? IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        [DisplayName("Id Fornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        [DisplayName("Id Grupo Cliente")]
        [Column("IDGRUPOCLIENTE")]
        public int? IdGrupoCliente { get; set; }
        public virtual GrupoCliente GrupoCliente { get; set; }

        [DisplayName("Id Grupo Fornecedor")]
        [Column("IDGRUPOFORNECEDOR")]
        public int? IdGrupoFornecedor { get; set; }
        public virtual GrupoFornecedor GrupoFornecedor { get; set; }

        [DisplayName("Id Grupo Imposto")]
        [Column("IDGRUPOIMPOSTO")]
        public int? IdGrupoImposto { get; set; }
        public virtual GrupoImposto GrupoImposto { get; set; }

        [DisplayName("Id Conta Contábil")]
        [Column("IDCONTACONTABIL")]
        public int? IdContaContabil { get; set; }
        public virtual ContaContabil ContaContabil { get; set; }
   }
}
