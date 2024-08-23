using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("AUTORIDADE", Schema = "DBO")]
    public class Autoridade
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDAUTORIDADE")]
        public int IdAutoridade { get; set; }

        [DisplayName("Id Fornecedor")]
        [Column("IDFORNECEDOR")]
        public int IdFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        [DisplayName("Nome Autoridade")]
        [Column("NOMEAUTORIDADE")]
        public string NomeAutoridade { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Identificação Autoridade")]
        [Column("IDENTIFICACAOAUTORIDADE")]
        public string IdentificacaoAutoridade { get; set; }

        [DisplayName("Agência")]
        [Column("AGENCIA")]
        public int? Agencia { get; set; }

        [DisplayName("Forma Arredondamento")]
        [Column("FORMAARREDONDAMENTO")]
        public int? FormaArredondamento { get; set; }

        [DisplayName("Arredondamento")]
        [Column("ARREDONDAMENTO")]
        public decimal Arredondamento { get; set; }
    }
}
