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
    [Table("UNIDADEFEDERACAO", Schema = "DBO")]
    public class UnidadeFederacao
    {
        [Key]
        [DisplayName("IdUF")]
        [Column("IDUF")]
        public int IdUF { get; set; }

        [DisplayName("UF")]
        [Column("UF")]
        public string UF { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("AliquotaICMS")]
        [Column("ALIQUOTAICMS")]
        public decimal? AliquotaICMS { get; set; }

        [DisplayName("IVA")]
        [Column("IVA")]
        public decimal? IVA { get; set; }

        [DisplayName("AliquotaICMSSubs")]
        [Column("ALIQUOTAICMSSUBS")]
        public decimal? AliquotaICMSSubs { get; set; }

        [DisplayName("IBGE")]
        [Column("IBGE")]
        public int IBGE { get; set; }

        public virtual ICollection<Cidade> Cidade { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
        public virtual ICollection<UnidadeFederacaoNCM> UnidadeFederacaoNCM { get; set; }
    }
}
