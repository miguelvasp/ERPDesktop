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
    [Table("LOCALIZACAOATIVO", Schema = "DBO")]
    public class LocalizacaoAtivo
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDLOCALIZACAOATIVO")]
        public int IdLocalizacaoAtivo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Departamento")]
        [Column("IDDEPARTAMENTO")]
        public int? IdDepartamento { get; set; }
        public virtual Departamento Departamento { get; set; }

        [DisplayName("Sala")]
        [Column("SALA")]
        public string Sala { get; set; }

        [DisplayName("Endereço")]
        [Column("ENDERECO")]
        public string Endereco { get; set; }

        [DisplayName("Número")]
        [Column("NUMERO")]
        public string Numero { get; set; }

        [DisplayName("Complemento")]
        [Column("COMPLEMENTO")]
        public string Complemento { get; set; }

        [DisplayName("Bairro")]
        [Column("BAIRRO")]
        public string Bairro { get; set; }

        [DisplayName("Id UF")]
        [Column("IDUF")]
        public int? IdUF { get; set; }
        public virtual UnidadeFederacao UnidadeFederacao { get; set; }

        [DisplayName("Id Cidade")]
        [Column("IDCIDADE")]
        public int? IdCidade { get; set; }
        public virtual Cidade Cidade { get; set; }

        [DisplayName("CEP")]
        [Column("CEP")]
        public string CEP { get; set; }
    }
}
