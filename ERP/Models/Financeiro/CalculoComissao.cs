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
    [Table("CALCULOCOMISSAO", Schema = "DBO")]
    public class CalculoComissao
    {
        [Key]
        [DisplayName("Id Cálculo Comissão")]
        [Column("IDCALCULOCOMISSAO")]
        public int IdCalculoComissao { get; set; }

        [DisplayName("Id Grupo Comissão")]
        [Column("IDGRUPOCOMISSAO")]
        public int? IdGrupoComissao { get; set; }
        public virtual GrupoComissao GrupoComissao { get; set; }

        [DisplayName("Relação Item")]
        [Column("RELACAOITEM")]
        public int? RelacaoItem { get; set; }

        [DisplayName("Id Cliente")]
        [Column("IDCLIENTE")]
        public int? IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        [DisplayName("Id Fornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        [DisplayName("Id Produto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        [DisplayName("Id Grupo Produto")]
        [Column("IDGRUPOPRODUTO")]
        public int? IdGrupoProduto { get; set; }
        public virtual GrupoProduto GrupoProduto { get; set; }

        [DisplayName("Id Grupo Cliente")]
        [Column("IDGRUPOCLIENTE")]
        public int? IdGrupoCliente { get; set; }
        public virtual GrupoCliente GrupoCliente { get; set; }

        [DisplayName("Id Grupo Fornecedor")]
        [Column("IDGRUPOFORNECEDOR")]
        public int? IdGrupoFornecedor { get; set; }
        public virtual GrupoFornecedor GrupoFornecedor { get; set; }
        
        [DisplayName("Relação Grupo")]
        [Column("RELACAOGRUPO")]
        public int? RelacaoGrupo { get; set; }

        [DisplayName("Id Grupo Preço Desconto")]
        [Column("IDGRUPOPRECODESCONTO")]
        public int? IdGrupoPrecoDesconto { get; set; }
        public virtual GrupoPrecoDesconto GrupoPrecoDesconto { get; set; }

        [DisplayName("Id Funcionário")]
        [Column("IDFUNCIONARIO")]
        public int? IdFuncionario { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        [DisplayName("Desconto")]
        [Column("DESCONTO")]
        public int? Desconto { get; set; }

        [DisplayName("Aplicação")]
        [Column("APLICACAO")]
        public int? Aplicacao { get; set; }

        [DisplayName("De")]
        [Column("DE")]
        public DateTime? De { get; set; }

        [DisplayName("Até")]
        [Column("ATE")]
        public DateTime? Ate { get; set; }

        [DisplayName("Pagamento")]
        [Column("PAGAMENTO")]
        public int? Pagamento { get; set; }

    }
}
