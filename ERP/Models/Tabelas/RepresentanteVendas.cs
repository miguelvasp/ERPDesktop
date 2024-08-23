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
    [Table("REPRESENTANTEVENDAS", Schema = "DBO")]
    public class RepresentanteVendas
    {
        [Key]
        [DisplayName("Id Representante de Vendas")]
        [Column("IDREPRESENTANTEVENDAS")]
        public int IdRepresentanteVendas { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Id Funcionário")]
        [Column("IDFUNCIONARIO")]
        public int? IdFuncionario { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        [DisplayName("Cota de Comissão")]
        [Column("COTACOMISSAO")]
        public int? CotaComissao { get; set; }
    }
}
