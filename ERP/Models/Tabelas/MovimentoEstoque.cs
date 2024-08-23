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
    [Table("MOVIMENTOESTOQUE", Schema = "DBO")]
    public class MovimentoEstoque
    {
        [Key]
        [DisplayName("Id Movimento")]
        [Column("IDMOVIMENTO")]
        public int IdMovimento { get; set; }

        [DisplayName("Id Estoque")]
        [Column("IDESTOQUE")]
        public int IdEstoque { get; set; }
        public virtual Estoque Estoque { get; set; }

        [DisplayName("Id Produto")]
        [Column("IDPRODUTO")]
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime Data { get; set; }

        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal Quantidade { get; set; }

        [DisplayName("Tipo Entrada Saída")]
        [Column("TIPOENTRSAIDA")]
        public string TipoEntrSaida { get; set; }

        [DisplayName("Histórico")]
        [Column("HISTORICO")]
        public string Historico { get; set; }

        [DisplayName("Documento")]
        [Column("DOCUMENTO")]
        public string Documento { get; set; }

        [DisplayName("Saldo")]
        [Column("SALDO")]
        public decimal Saldo { get; set; }

        [DisplayName("Qtde Estoque")]
        [Column("QUANTIDADEESTOQUE")]
        public decimal QuantidadeEstoque { get; set; }
    }
}
