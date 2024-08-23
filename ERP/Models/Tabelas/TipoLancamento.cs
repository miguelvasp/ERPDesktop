using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("TIPOLANCAMENTO", Schema = "DBO")]
    public class TipoLancamento
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDTIPOLANCAMENTO")]
        public int IdTipoLancamento { get; set; }

        /*
         * 1 - Pedido de Vendas
         * 2 - Pedido de Compras
         * 3 - Estoque
         * 4 - Produção
         */
        [DisplayName("Id Tipo Documento")]
        [Column("IDTIPODOCUMENTO")]
        public int IdTipoDocumento { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
