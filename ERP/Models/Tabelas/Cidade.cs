using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("CIDADE", Schema = "DBO")]
    public class Cidade
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCIDADE")]
        public int IdCidade { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("IBGE")]
        [Column("IBGE")]
        public int IBGE { get; set; }

        [DisplayName("IdUF")]
        [Column("IDUF")]
        public int IdUF { get; set; }
        public virtual UnidadeFederacao UnidadeFederacao { get; set; }

        [DisplayName("Id País")]
        [Column("IDPAIS")]
        public int IdPais { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
