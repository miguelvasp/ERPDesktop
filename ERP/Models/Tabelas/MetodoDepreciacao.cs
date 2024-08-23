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
    [Table("METODODEPRECIACAO", Schema = "DBO")]
    public class MetodoDepreciacao
    {
        [Key]
        [DisplayName("Id Método Depreciação")]
        [Column("IDMETODODEPRECIACAO")]
        public int IdMetodoDepreciacao { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Depreciação")]
        [Column("DEPRECIACAO")]
        public bool Depreciacao { get; set; }

        [DisplayName("Id Perfil Depreciação Comum")]
        [Column("IDPERFILDEPRECIACAOCOMUM")]
        public int? IdPerfilDepreciacaoComum { get; set; }

        [DisplayName("Id Perfil Depreciação Alternativa")]
        [Column("IDPERFILDEPRECIACAOALTERNATIVA")]
        public int? IdPerfilDepreciacaoAlternativa { get; set; }

        [DisplayName("Id Perfil Depreciação Extraordinaria")]
        [Column("IDPERFILDEPRECIACAOEXTRAORDINARIA")]
        public int? IdPerfilDepreciacaoExtraordinaria { get; set; }

        [DisplayName("Arredondamento")]
        [Column("ARREDONDAMENTO")]
        public decimal? Arredondamento { get; set; }

        [DisplayName("Manter Valor Líquido Em")]
        [Column("MANTERVALORLIQUIDOEM")]
        public decimal? ManterValorLiquidoEm { get; set; }

        [DisplayName("Nível Lançamento")]
        [Column("NIVELLANCAMENTO")]
        public int? NivelLancamento { get; set; }
        
        [DisplayName("Permitir Custo Superior Aquisição")]
        [Column("PERMITIRCUSTOSUPERIORAQUISICAO")]
        public bool PermitirCustoSuperiorAquisicao { get; set; }

        [DisplayName("Permitir Valor Negativo")]
        [Column("PERMITIRVALORNEGATIVO")]
        public bool PermitirValorNegativo { get; set; }

        [DisplayName("Convenção")]
        [Column("CONVENCAO")]
        public int? Convencao { get; set; }
    }
}
