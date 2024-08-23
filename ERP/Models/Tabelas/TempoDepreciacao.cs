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
    [Table("TEMPODEPRECIACAO", Schema = "DBO")]
    public class TempoDepreciacao
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDTEMPODEPRECIACAO")]
        public int IdTempoDepreciacao { get; set; }

        [DisplayName("Grupo Ativo")]
        [Column("IDGRUPOATIVO")]
        public int IdGrupoAtivo { get; set; }
        public virtual GrupoAtivo GrupoAtivo { get; set; }

        [DisplayName("Nível Lançamento")]
        [Column("NIVELLANCAMENTO")]
        public int? NivelLancamento { get; set; }

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
        public decimal Arredondamento { get; set; }

        [DisplayName("Convenção")]
        [Column("CONVENCAO")]
        public int? Convencao { get; set; }

        [DisplayName("Depreciação")]
        [Column("DEPRECIACAO")]
        public bool Depreciacao { get; set; }

        [DisplayName("Período")]
        [Column("PERIODO")]
        public int Periodo { get; set; }

        [DisplayName("Vida Útil")]
        [Column("VIDAUTIL")]
        public int VidaUtil { get; set; }
    }
}
