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
    [Table("ESTOQUE", Schema = "DBO")]
    public class Estoque
    {
        [Key]
        [DisplayName("Id Estoque")]
        [Column("IDESTOQUE")]
        public int IdEstoque { get; set; }

        [DisplayName("Id Produto")]
        [Column("IDPRODUTO")]
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal Quantidade { get; set; }

        [DisplayName("Quantidade Retirada")]
        [Column("QUANTIDADERETIRADA")]
        public decimal QuantidadeRetirada { get; set; }

        [DisplayName("Lote")]
        [Column("LOTE")]
        public string Lote { get; set; }

        [DisplayName("Validade")]
        [Column("VALIDADE")]
        public DateTime Validade { get; set; }

        [DisplayName("Id Nota")]
        [Column("IDNOTA")]
        public int IdNota { get; set; }
        public virtual NotaFiscal NotaFiscal { get; set; }

        [DisplayName("Data Entrada")]
        [Column("DATAENTRADA")]
        public DateTime DataEntrada { get; set; }

        [DisplayName("Custo Reposição")]
        [Column("CUSTOREPOSICAO")]
        public decimal CustoReposicao { get; set; }

        [DisplayName("Custo Médio")]
        [Column("CUSTOMEDIO")]
        public decimal CustoMedio { get; set; }

        [DisplayName("Documento Movimentação")]
        [Column("DOCUMENTOMOVIMENTACAO")]
        public string DocumentoMovimentacao { get; set; }

        public virtual ICollection<MovimentoEstoque> MovimentoEstoque { get; set; }
    }
}
