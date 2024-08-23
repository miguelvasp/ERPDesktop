using ERP.Util;
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
    [Table("CONVERSAOUNIDADE", Schema = "DBO")]
    public class ConversaoUnidade
    {
        [Key]
        [DisplayName("Id Conversão Unidade")]
        [Column("IDCONVERSAOUNIDADE")]
        public int IdConversaoUnidade { get; set; }

        [DisplayName("Id Produto")]
        [Column("IDPRODUTO")]
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        [DisplayName("Fator")]
        [Column("FATOR")]
        public decimal Fator { get; set; }

        [DisplayName("Numerador")]
        [Column("NUMERADOR")]
        public int Numerador { get; set; }

        [DisplayName("Denominador")]
        [Column("DENOMINADOR")]
        public int Denominador { get; set; }

        [DisplayName("Id Unidade (De)")]
        [Column("IDUNIDADEDE")]
        public int IdUnidadeDe { get; set; }

        [DisplayName("Id Unidade (Para)")]
        [Column("IDUNIDADEPARA")]
        public int IdUnidadePara { get; set; }
    }
}
