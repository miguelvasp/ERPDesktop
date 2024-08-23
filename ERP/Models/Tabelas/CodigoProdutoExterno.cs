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
    [Table("CODIGOPRODUTOEXTERNO", Schema = "DBO")]
    public class CodigoProdutoExterno
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCODIGOPRODUTOEXTERNO")]
        public int IdCodigoProdutoExterno { get; set; }

        [DisplayName("Id Cliente")]
        [Column("IDCLIENTE")]
        public int? IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        [DisplayName("Id Fornecedor")]
        [Column("IDFORNECEDOR")]
        public int IdFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        [DisplayName("Id Produto")]
        [Column("IDPRODUTO")]
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        [DisplayName("Id Variantes Tamanho")]
        [Column("IDVARIANTESTAMANHO")]
        public int? IdVariantesTamanho { get; set; }
        public virtual VariantesTamanho VariantesTamanho { get; set; }

        [DisplayName("Id Variantes Cor")]
        [Column("IDVARIANTESCOR")]
        public int? IdVariantesCor { get; set; }
        public virtual VariantesCor VariantesCor { get; set; }

        [DisplayName("Número Externo")]
        [Column("NUMEROEXTERNO")]
        public string NumeroExterno { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Código Padrão")]
        [Column("CODIGOPADRAO")]
        public bool CodigoPadrao { get; set; }
    }
}
