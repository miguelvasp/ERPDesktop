using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("CONDICAOFRETE", Schema = "DBO")]
    public class CondicaoFrete
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCONDICAOFRETE")]
        public int IdCondicaoFrete { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Código Intrastat")]
        [Column("CODIGOINTRASTAT")]
        public string CodigoIntrastat { get; set; }

        [DisplayName("Condição Encargo Frete")]
        [Column("CONDICAOENCARGOFRETE")]
        public int? CondicaoEncargoFrete { get; set; }

        [DisplayName("Aplicar Mínimo Grátis")]
        [Column("APLICARMINIMOGRATIS")]
        public bool AplicarMinimoGratis { get; set; }

        [DisplayName("Mínimo Grátis")]
        [Column("MINIMOGRATIS")]
        public decimal? MinimoGratis { get; set; }

        [DisplayName("Id Tipo Endereco")]
        [Column("IDTIPOENDERECO")]
        public int? IdTipoEndereco { get; set; }
        public virtual TipoEndereco TipoEndereco { get; set; }
    }
}
