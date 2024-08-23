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
    [Table("GRUPOIMPOSTORETIDO", Schema = "DBO")]
    public class GrupoImpostoRetido
    {
        [Key]
        [DisplayName("Id Grupo Imposto Retido")]
        [Column("IDGRUPOIMPOSTORETIDO")]
        public int IdGrupoImpostoRetido { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Reverter Imposto Desconto a Visa")]
        [Column("REVERTERIMPOSTODESCONTOAVISTA")]
        public bool ReverterImpostoDescontoAVista { get; set; }

        //[DisplayName("Id Código Imposto Retido")]
        //[Column("IDCODIGOIMPOSTORETIDO")]
        //public int IdCodigoImpostoRetido { get; set; }
        //public virtual CodigoImpostoRetido CodigoImpostoRetido { get; set; }

        //[DisplayName("Alíquota")]
        //[Column("ALIQUOTA")]
        //public decimal Aliquota { get; set; }

        //[DisplayName("Exclusão")]
        //[Column("EXCLUSAO")]
        //public decimal Exclusao { get; set; }
    }
}
