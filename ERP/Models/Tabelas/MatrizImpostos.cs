using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("MATRIZIMPOSTOS", Schema = "DBO")]
    public class MatrizImpostos
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDMATRIZIMPOSTOS")]
        public int IdMatrizImpostos { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("IdEmpresa")]
        [Column("IDEMPRESA")]
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }

        [DisplayName("Id Grupo CFOP")]
        [Column("IDGRUPOCFOP")]
        public int IdGrupoCFOP { get; set; }
        public virtual GrupoCFOP GrupoCFOP { get; set; }

        [DisplayName("Relação ao Grupo")]
        [Column("RELACAOGRUPO")]
        public int RelacaoGrupo { get; set; }

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

        [DisplayName("Relação Item")]
        [Column("RELACAOITEM")]
        public int RelacaoItem { get; set; }

        [DisplayName("IdProduto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        [DisplayName("Id Grupo Produto")]
        [Column("IDGRUPOPRODUTO")]
        public int? IdGrupoProduto { get; set; }
        public virtual GrupoProduto GrupoProduto { get; set; }

        [DisplayName("Id Grupo Imposto")]
        [Column("IDGRUPOIMPOSTO")]
        public int? IdGrupoImposto { get; set; }
        public virtual GrupoImposto GrupoImposto { get; set; }

        [DisplayName("Id Grupo Imposto Item")]
        [Column("IDGRUPOIMPOSTOITEM")]
        public int? IdGrupoImpostoItem { get; set; }
        public virtual GrupoImpostoItem GrupoImpostoItem { get; set; }
    }
}
